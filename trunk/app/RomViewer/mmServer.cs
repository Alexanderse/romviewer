using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace RomViewer
{
    public delegate void OnDataDelegate(ReceivedChat message);
    public delegate void OnDataListDelegate(List<ReceivedChat> message);

    public class mmServer
    {
        public static mmServer ServerInstance = null;

        public const string MSG_TYPE_CHAT = "CHAT";
        public const string MSG_TYPE_COMMAND = "COMMAND";

        private OnDataDelegate _onData = null;
        private OnDataListDelegate _onDataList = null;
        public Queue MessageQueue = new Queue();
        public Queue IncomingQueue = new Queue();

        private int port;
        private int sendToPort;
        private bool _running;
        private Thread _listenThread;
        private Thread _sendThread;
        private Thread _clearQThread;
        private EventWaitHandle _qHasData = new ManualResetEvent(false);
        private object _lock = new object();

        public int SendToPort
        {
            get { return sendToPort; }
        }

        public mmServer(int port, int SendToPort, OnDataDelegate onData)
        {
            this.port = port;
            this._onData = onData;
            mmServer.ServerInstance = this;
            sendToPort = SendToPort;
        }

        public mmServer(int port, int SendToPort, OnDataListDelegate onDataList)
        {
            _onDataList = onDataList;
            this.port = port;
            mmServer.ServerInstance = this;
            sendToPort = SendToPort;
        }

        public void Start()
        {
            _listenThread = new Thread(Execute);
            _listenThread.Start();

            _sendThread = new Thread(SendMessages);
            _sendThread.Start();

            _clearQThread = new Thread(ExecuteIncomingReader);
            _clearQThread.Start();

        }

        public void Stop()
        {
            lock (_lock)
            {
                _running = false;
            }

            _listenThread.Join(5000);
            _sendThread.Join(5000);
            _clearQThread.Join(5000);
        }

        public void Execute()
        {
            lock (_lock)
            {
                _running = true;
            }

            Socket _socket;
            int recv;
            byte[] data = new byte[81920]; 
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, port);

            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            _socket.Bind(ipep);

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);
            EndPoint Remote = (EndPoint)(endPoint);

            recv = 0;
            bool running = true;

            while (running)
            {
                if (recv > 0)
                {
                    //raise event
                    string received = Encoding.UTF8.GetString(data, 0, recv);
                    string[] result = received.Split((char)1);

                    if (result[0] == MSG_TYPE_CHAT)
                    {
                        ReceivedChat msg = new ReceivedChat(result[1], result[2], result[3], result[4]);
                        DoOnData(msg);
                    } else if (result[0] == MSG_TYPE_COMMAND)
                    {
                        CommandResult msg = new CommandResult(result[1]);
                    }
                }

                recv = 0;

                lock (_lock)
                {
                    running = _running;
                }

                if (running)
                {
                    if (_socket.Available > 0) 
                        recv = _socket.ReceiveFrom(data, ref Remote);
                    else
                        Thread.Sleep(50);
                }
            }

            _socket = null;
        }

        private void DoOnData(ReceivedChat msg)
        {
            Queue q = Queue.Synchronized(IncomingQueue);
            q.Enqueue(msg);
            _qHasData.Set();
            //if (_onData != null) _onData(msg);+
        }

        private void ExecuteIncomingReader()
        {
            bool running = true;

            while (running)
            {
                if (_qHasData.WaitOne(1000))
                {
                    Queue q = Queue.Synchronized(IncomingQueue);
                    List<ReceivedChat> chats = new List<ReceivedChat>();
                    while (q.Count > 0)
                    {
                        chats.Add((ReceivedChat)q.Dequeue());
                    }
                    _qHasData.Reset();

                    if (_onDataList != null) _onDataList(chats);

                }

                lock (_lock)
                {
                    running = _running;
                }
            }
        }

        private void SendMessages()
        {
            bool running = true;
            UdpClient client = new UdpClient();

            while (running)
            {
                if (MessageQueue.Count > 0)
                {
                    Queue q = Queue.Synchronized(MessageQueue);
                    while (q.Count > 0)
                    {
                        GameMessage msg = (GameMessage)q.Dequeue();
                        byte[] data = Encoding.UTF8.GetBytes(msg.ToString());
                        client.Connect(System.Net.Dns.GetHostName(), msg.Port);
                        int sent = client.Send(data, msg.ToString().Length);
                        if (sent < 1)
                        {
                            q.Enqueue(msg);
                            break;
                        }
                    }
                }
                else
                {
                    Thread.Sleep(100);
                }

                lock (_lock)
                {
                    running = _running;
                }
            }
            client.Close();
        }

        public void QueueCommand(string command)
        {
            CommandMessage gm = new CommandMessage(command, ServerInstance.SendToPort);
            Queue.Synchronized(ServerInstance.MessageQueue).Enqueue(gm);
        }

        public void QueueChat(string channel, string text, string target)
        {
            ChatMessage gm = new ChatMessage(channel, text, target, ServerInstance.SendToPort);
            Queue.Synchronized(ServerInstance.MessageQueue).Enqueue(gm);
        }
    }

    public class CommandResult
    {
        public string Result = "";

        public CommandResult(string result)
        {
            Result = result;
        }
    }

    public class ReceivedChat
    {
        public const string MSG_INVENTORY = "INVENTORY";
        public const string MSG_EQUIPMENT = "EQUIPMENT";
        public const string MSG_GOLD = "GOLD";
        public const string MSG_PLAYERDETAILS = "PLAYERDETAILS";
        public const string MSG_PID = "PID";
        public const string MSG_EXECUTIONPATH = "EXECUTIONPATH";
        public const string MSG_STATE = "STATE";
        public const string MSG_PLAYERUPDATE = "PLAYERUPDATE";
        public const string MSG_TARGETDETAILS = "TARGETDETAILS";
        public const string MSG_NAVPOINT = "NAVPOINT";
        public const string MSG_ROMOBJECTS = "ROMOBJECTS";

        public string Channel;
        public string Player;
        public string Message;
        public string receivedTime;

        public ReceivedChat(string channel, string player, string message, string receivedTime)
        {
            Channel = channel;
            Player = player;
            Message = message;
            this.receivedTime = receivedTime;
        }

        public override string ToString()
        {
            return string.Format("[{0}] [{1}] {2} - {3}", receivedTime, Channel, Player, Message);
        }
    }


    public class GameMessage
    {
        public const string STYLE_CHAT = "CHAT";
        public const string STYLE_COMMAND = "COMMAND";

        public int Port;

        public GameMessage(int port)
        {
            Port = port;
        }
    }

    public class ChatMessage: GameMessage
    {
        public string Style;
        public string Channel;
        public string Text;
        public string Target;

        public ChatMessage(string channel, string text, string target, int port) : base(port)
        {
            Channel = channel;
            Text = text;
            Target = target;
        }

        public override string ToString()
        {
            return string.Format("{1}{0}{2}{0}{3}{0}{4}", (char)1, GameMessage.STYLE_CHAT, Channel, Text, Target);
        }
    }

    public class CommandMessage : GameMessage
    {
        public string Source;
        public string Text;
        public string Target;

        public CommandMessage(string source, int port) : base(port)
        {
            Source = source;
        }

        public override string ToString()
        {
            return string.Format("{1}{0}{2}", (char)1, GameMessage.STYLE_COMMAND, Source);
        }
    }

}