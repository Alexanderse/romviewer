using System;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using RomViewer.Core.Comms;

namespace RomService.Library
{
	/// <summary>
	/// Summary description for TCPSocketListener.
	/// </summary>
	public class TCPSocketListener
	{
		/// <summary>
		/// Variables that are accessed by other classes indirectly.
		/// </summary>
		private Socket m_clientSocket = null;
		private bool m_stopClient=false;
		private Thread m_clientListenerThread=null;
		private bool m_markedForDeletion=false;

		/// <summary>
		/// Working Variables.
		/// </summary>
		private StringBuilder m_oneLineBuf=new StringBuilder();
		private DateTime m_lastReceiveDateTime;
		private DateTime m_currentReceiveDateTime;

	    private IRomMessageProcessor _processor;

		/// <summary>
		/// Client Socket Listener Constructor.
		/// </summary>
		/// <param name="clientSocket"></param>
		public TCPSocketListener(Socket clientSocket, IRomMessageProcessor processor)
		{
		    _processor = processor;

			m_clientSocket = clientSocket;
		}

		/// <summary>
		/// Client SocketListener Destructor.
		/// </summary>
		~TCPSocketListener()
		{
			StopSocketListener();
		}

		/// <summary>
		/// Method that starts SocketListener Thread.
		/// </summary>
		public void StartSocketListener()
		{
			if (m_clientSocket!= null)
			{
				m_clientListenerThread = 
					new Thread(new ThreadStart(SocketListenerThreadStart));

				m_clientListenerThread.Start();
			}
		}

		/// <summary>
		/// Thread method that does the communication to the client. This 
		/// thread tries to receive from client and if client sends any data
		/// then parses it and again wait for the client data to come in a
		/// loop. The recieve is an indefinite time receive.
		/// </summary>
		private void SocketListenerThreadStart()
		{
            EventWaitHandle waiter = new ManualResetEvent(false);
			int size=0;
			Byte [] byteBuffer = new Byte[1024];

			m_lastReceiveDateTime = DateTime.Now;
			m_currentReceiveDateTime = DateTime.Now;

            Timer t = new Timer(new TimerCallback(CheckClientCommInterval), null, 180000, 180000);

			while (!m_stopClient)
			{
				try
				{
                    //read packet size
					size = m_clientSocket.Receive(byteBuffer);
                    if (size > 0)
                    {
                        m_currentReceiveDateTime = DateTime.Now;
                        ParseReceiveBuffer(byteBuffer, size);
                    }
                    else
                    {
                        waiter.WaitOne(500);
                    }
				}
				catch (SocketException se)
				{
					m_stopClient=true;
					m_markedForDeletion=true;
				}
			}
			t.Change(Timeout.Infinite, Timeout.Infinite);
			t=null;
		}

		/// <summary>
		/// Method that stops Client SocketListening Thread.
		/// </summary>
		public void StopSocketListener()
		{
			if (m_clientSocket!= null)
			{
				m_stopClient=true;
				m_clientSocket.Close();

				// Wait for one second for the the thread to stop.
				m_clientListenerThread.Join(1000);
				
				// If still alive; Get rid of the thread.
				if (m_clientListenerThread.IsAlive)
				{
					m_clientListenerThread.Abort();
				}
				m_clientListenerThread=null;
				m_clientSocket=null;
				m_markedForDeletion=true;
			}
		}

		/// <summary>
		/// Method that returns the state of this object i.e. whether this
		/// object is marked for deletion or not.
		/// </summary>
		/// <returns></returns>
		public bool IsMarkedForDeletion()
		{
			return m_markedForDeletion;
		}

		/// <summary>
		/// This method parses data that is sent by a client using TCP/IP.
		/// As per the "Protocol" between client and this Listener, client 
		/// sends each line of information by appending "#0" (
		/// ). But since the data is transmitted from client to 
		/// here by TCP/IP protocol, it is not guarenteed that each line that
		/// arrives ends with a "CRLF". So the job of this method is to make a
		/// complete line of information that ends with "CRLF" from the data
		/// that comes from the client and get it processed.
		/// </summary>
		/// <param name="byteBuffer"></param>
		/// <param name="size"></param>
		private void ParseReceiveBuffer(Byte [] byteBuffer, int size)
		{
			string data = Encoding.ASCII.GetString(byteBuffer,0, size);
			int lineEndIndex = 0;

			// Check whether data from client has more than one line of 
			// information, where each line of information ends with "CRLF"
			// ("\r\n"). If so break data into different lines and process
			// separately.
			do
			{
				lineEndIndex =	data.IndexOf((char)0);
				if(lineEndIndex != -1)
				{
					m_oneLineBuf=m_oneLineBuf.Append(data,0,lineEndIndex);
                    if (_processor != null)
                    {
                        string response = _processor.HandleMessage(m_oneLineBuf.ToString());

                        if (response != null)
                        {
                            m_clientSocket.Send(Encoding.ASCII.GetBytes(response));
                        }
                    }
					m_oneLineBuf.Remove(0,m_oneLineBuf.Length);
					data = data.Substring(lineEndIndex+1,
						data.Length -lineEndIndex-1);
				}
				else
				{
					// Just append to the existing buffer.
					m_oneLineBuf=m_oneLineBuf.Append(data);
				}
			}while((lineEndIndex != -1) && (!string.IsNullOrEmpty(data)));
		}


	    /// <summary>
		/// Method that checks whether there are any client calls for the
		/// last 15 seconds or not. If not this client SocketListener will
		/// be closed.
		/// </summary>
		/// <param name="o"></param>
		private void CheckClientCommInterval(object o)
		{
			if (m_lastReceiveDateTime.Equals(m_currentReceiveDateTime))
			{
				this.StopSocketListener();
			}
			else
			{
				m_lastReceiveDateTime = m_currentReceiveDateTime;
			}
		}
	}
}
