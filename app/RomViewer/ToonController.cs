using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using RomViewer.Domain;
using RomViewer.Model;
using WindowHider;
using RomViewer.Navigator;
using System.IO;
using System.Diagnostics;

namespace RomViewer
{
    public class ToonController
    {
        //public mmServer _server;
        public static string MicroMacroFolder = "";
        public static int PID = -1;
        public static int GameWindowHandle;
        public static int mmPID;
        public static int mmHandle;
        public static ManagedProc proccessGame = null;
        public static ManagedProc proccessMM = null;

        public static BindingListEx<Item> _inventory = new BindingListEx<Item>();
        public static BindingListEx<Item> _equipment = new BindingListEx<Item>();
        public static int _gold;
        public static Player _player;
        public static bool _Battling;
        public static Vector3 _currentCoordinates;
        public static GameNode _nearestNode;
        public static Pawn _target;
        public static bool _commsEnabled;
        public static List<FoundObject> _objectList = new List<FoundObject>();

        public static List<ReceivedChat> _whispers = new List<ReceivedChat>();
        public static List<ReceivedChat> _says = new List<ReceivedChat>();
        private static Zone _currentZone;

        public static List<string> GetWaypointFileList()
        {
            List<string> result = new List<string>();

            if (MicroMacroFolder.Length > 0)
            {
                if (Directory.Exists(MicroMacroFolder))
                {
                    string waypointDir = Path.Combine(MicroMacroFolder, "waypoints");

                    result.AddRange(GetWaypointFiles(waypointDir, ""));

                }
            }

            return result;
        }

        public static List<string>  GetWaypointFiles(string directory, string prefix)
        {
            List<string> result = new List<string>();

            if (directory.Length > 0)
            {
                if (Directory.Exists(directory))
                {
                    foreach (string file in Directory.EnumerateFiles(directory, "*.xml"))
                    {
                        result.Add(prefix + Path.GetFileNameWithoutExtension(file));
                    }

                    foreach (string dir in Directory.EnumerateDirectories(directory))
                    {
                        string pfx = dir.Replace(directory + "\\", "");
                        result.AddRange(GetWaypointFiles(dir, pfx +"/"));
                    }

                }
            }

            return result;            
        }


        public static void AttachProcesses()
        {
            if (proccessGame == null)
            {
                if (PID > 0)
                {
                    Process process = Process.GetProcessById(PID);
                    proccessGame = new ManagedProc(process, 3);
                    if (((int)proccessGame.Window.hWnd) < 1) proccessGame.Window.hWnd = (IntPtr)GameWindowHandle;
                }
            }

            if (proccessMM == null)
            {
                if (mmPID > 0)
                {
                    Process process = Process.GetProcessById(mmPID);
                    proccessMM = new ManagedProc(process, 10);
                    if (((int)proccessMM.Window.hWnd) < 1) proccessMM.Window.hWnd = (IntPtr)mmHandle;
                }
            }
        }

        public static void ToggleVisible()
        {
            AttachProcesses();
            if (proccessGame != null) proccessGame.Window.Visible = !proccessGame.Window.Visible;
            if (proccessMM != null) proccessMM.Window.Visible = !proccessMM.Window.Visible;

        }

        public static void QueryExecutionPath()
        {
            mmServer.ServerInstance.QueueCommand("sendChatMessage(\""+ReceivedChat.MSG_EXECUTIONPATH+"\", getExecutionPath());");
        }

        public static void QueryWindows()
        {
            mmServer.ServerInstance.QueueCommand("local PID=findProcessByWindow(getWin()); local winHandle=getWin(); local mmPID=findProcessByWindow(getHwnd()); local mmHwnd=getHwnd(); local res=sprintf(\"%s\\2%s\\2%s\\2%s\",tostring(PID),tostring(winHandle),tostring(mmPID),tostring(mmHwnd)); sendChatMessage(\"PID\", res);");
        }

        private static void OnMessages(List<ReceivedChat> message)
        {
            foreach (ReceivedChat msg in message)
            {
                ProcessMessage(msg);
            }
        }

        private static void ProcessMessage(ReceivedChat message)
        {
            if (message.Channel.ToUpper() == ReceivedChat.MSG_INVENTORY)
            {
                HandleInventoryUpdate(message);
            }
            else if (message.Channel.ToUpper() == ReceivedChat.MSG_EQUIPMENT)
            {
                HandleEquipmentUpdate(message);
            }
            else if (message.Channel.ToUpper() == ReceivedChat.MSG_GOLD)
            {
                HandleGoldUpdate(message);
            }
            else if (message.Channel.ToUpper() == ReceivedChat.MSG_PLAYERDETAILS)
            {
                HandlePlayerUpdate(message);
            }
            else if (message.Channel.ToUpper() == ReceivedChat.MSG_PID)
            {
                HandleProcessIdUpdate(message);
            }
            else if (message.Channel.ToUpper() == ReceivedChat.MSG_EXECUTIONPATH)
            {
                HandleExecutionPathUpdate(message);
            }
            else if (message.Channel.ToUpper() == "STATE")
            {
                HandleStateUpdate(message);
            }
            else if (message.Channel.ToUpper() == ReceivedChat.MSG_PLAYERUPDATE)
            {
                HandlePlayerCoordsChanged(message);

            }
            else if (message.Channel.ToUpper() == ReceivedChat.MSG_TARGETDETAILS)
            {
                HandleTargetChanged(message);
            }
            else if (message.Channel.ToUpper() == ReceivedChat.MSG_NAVPOINT)
            {
                HandleNavigationUpdate(message);
            }
            else if (message.Channel.ToUpper() == ReceivedChat.MSG_ROMOBJECTS)
            {
                HandleRomObjectUpdate(message);
            }
            else
            {
                HandleChatMessage(message);
            }
        }

        private static void HandleChatMessage(ReceivedChat message)
        {
            if (message.Channel.ToUpper() == "WHISPER") _whispers.Add(message);
            else if (message.Channel.ToUpper() == "SAY") _says.Add(message);
            else
            {
            }

            /*
             * GetOrAddTabPage(message);

            string player = message.Player.Trim();
            if (!string.IsNullOrEmpty(player))
            {
                if (!_toons.ContainsKey(player.ToLower()))
                {
                    _toons.Add(player.ToLower(), new Pawn());
                    _toonInquiry.Add(player.ToLower());
                    CommandMessage gm = new CommandMessage("sendMacro(\"AskPlayerInfo(\\\"" + player + "\\\")\")", Convert.ToInt32(tbSendTo.Text));
                    Queue.Synchronized(_server.MessageQueue).Enqueue(gm);
                }
            }

            if (message.Channel.ToUpper() == "SYSTEM")
            {
                if (!string.IsNullOrEmpty(message.Message))
                {
                    string[] tokens = message.Message.Split(' ');
                    player = tokens[0].Trim();

                    if (_toonInquiry.Contains(player.ToLower()) || (_toons.ContainsKey(player.ToLower())))
                    {

                        if (_toonInquiry.Contains(player.ToLower()))
                        {
                            _toonInquiry.Remove(player.ToLower());
                        }



                        Pawn p = new Pawn();
                        p.Name = tokens[0];
                        p.Guild = tokens[1].Trim('(', ')');
                        p.Class1 = tokens[2];
                        p.Level = Convert.ToInt32(tokens[3].Trim('(', ')'));
                        p.Class2 = tokens[4];
                        p.Level2 = Convert.ToInt32(tokens[5].Trim('(', ')'));
                        int i = 6;
                        p.Location = tokens[i];
                        i++;
                        while (i < tokens.Length - 2)
                        {
                            p.Location += " " + tokens[i];
                            i++;
                        }

                        p.Race = tokens[i];
                        i++;
                        p.Sex = tokens[i].Trim('(', ')');

                        Pawn oldPawn = (Pawn)_toons[player.ToLower()];
                        _toons[player.ToLower()] = p;
                        _inquiries.Remove(oldPawn);
                        _inquiries.Add(p);
                    }
                }
            }

            if ((!string.IsNullOrEmpty(message.Player)) && (_toons.ContainsKey(message.Player.ToLower())))
            {

            }

            ChannelPage cInt = (ChannelPage)_tabChannelMap[message.Channel];

            cInt.MessageBox.AppendText(message.ToString() + Environment.NewLine);
            if (cInt.Page != tcChats.SelectedTab) cInt.Page.Text = cInt.Channel + "*";

            cInt.MessageBox.SelectionStart = cInt.MessageBox.Text.Length;
            cInt.MessageBox.ScrollToCaret();
             * */
        }

        private static void HandleRomObjectUpdate(ReceivedChat message)
        {
            if (message.Message == "new") _objectList.Clear();
            else
            {
                string[] detail = message.Message.Split((char)2);
                detail[0] = (Math.Round(Convert.ToDouble(detail[0]), 0)).ToString();
                detail[1] = (Math.Round(Convert.ToDouble(detail[1]), 0)).ToString();
                detail[2] = (Math.Round(Convert.ToDouble(detail[2]), 0)).ToString();
                int id = Convert.ToInt32(detail[5].Trim());

                if (_objectList.Find(o => o.Id == id) == null)
                {
                    FoundObject obj = new FoundObject();
                    obj.Id = id;
                    obj.Name = detail[4].Trim();
                    obj.Coordinates = new Vector3((Math.Round(Convert.ToDouble(detail[0]), 0)),
                                                 (Math.Round(Convert.ToDouble(detail[2]), 0)),
                                                 (Math.Round(Convert.ToDouble(detail[1]), 0)));

                    obj.Attackable = (detail[6].Trim().ToUpper() == "TRUE");
                    _objectList.Add(obj);
                }
            }
            //foundObjectBindingSource.ResetBindings(false);
        }

        private static void HandleNavigationUpdate(ReceivedChat message)
        {
            if (message.Message.Length > 0)
            {
                if (message.Message == "start")
                {
                    //World.IsTravelling = true;
                    _commsEnabled = false;
                }
                else if (message.Message == "end")
                {
                    //World.IsTravelling = false;
                    _commsEnabled = true;
                }
                else
                {
                    int wpNum = Convert.ToInt32(message.Message);
                }
            }
        }

        private static void HandleTargetChanged(ReceivedChat message)
        {
            if (message.Message.Length > 0)
            {
                _target = new Pawn(message.Message);
                //bsTarget.DataSource = p;
            }
            else
            {
                //bsTarget.DataSource = new Pawn();
            }
        }

        private static void HandlePlayerCoordsChanged(ReceivedChat message)
        {
            //	local result = sprintf("%s\2%s\2%s\2%s\2%s\2%s", player.Name, player.HP, player.MaxHP, player.X, player.Y, player.Z);
            string[] detail = message.Message.Split((char)2);
            detail[3] = (Math.Round(Convert.ToDouble(detail[3]), 0)).ToString();
            detail[4] = (Math.Round(Convert.ToDouble(detail[4]), 0)).ToString();
            detail[5] = (Math.Round(Convert.ToDouble(detail[5]), 0)).ToString();

            _currentCoordinates = new Vector3((Math.Round(Convert.ToDouble(detail[3]), 0)), (Math.Round(Convert.ToDouble(detail[4]), 0)), (Math.Round(Convert.ToDouble(detail[5]), 0)));

            //this.Text = string.Format("{0} ({1}/{2}) {3},{4},{5}", detail);

            try
            {
                int zoneId = Convert.ToInt32(detail[6]);
                zoneId = zoneId % 1000;
                Zone z = (Zone)World.Data.Zones.Find(zone => zone.Id == zoneId);
                if (z == null)
                {
                    z = new Zone();
                    z.Id = zoneId;
                    z.Name = "New Zone Discovered";

                    if (ZoneForm.EditZone(z))
                    {

                        World.Data.Zones.Add(z);
                        World.SaveToDirectory(Path.GetFullPath("."));
                    }
                    //zoneBindingSource.ResetBindings(false);
                }

                _currentZone = z;
                //zoneComboBox.SelectedItem = z;
                GameNode node = World.FindNearestNode(World.PlayerPos);
                if (node != null) _nearestNode = node;
            }
            catch (Exception)
            {

                throw;
            }

            //if (NodeVisualiser.Visualiser != null) NodeVisualiser.Visualiser.UpdatePlayerPosition();
            //DisplayMap();
        }

        private static void HandleStateUpdate(ReceivedChat message)
        {
            string[] detail = message.Message.Split((char)2);
            if (detail[0].ToUpper() == "FIGHTING") _Battling = (detail[1].ToUpper() == "TRUE");
        }

        private static void HandleExecutionPathUpdate(ReceivedChat message)
        {
            MicroMacroFolder = message.Message;
        }

        private static void HandleProcessIdUpdate(ReceivedChat message)
        {
            string[] detail = message.Message.Split((char)2);
            PID = Convert.ToInt32(detail[0]);
            GameWindowHandle = Convert.ToInt32(detail[1]);
            mmPID = Convert.ToInt32(detail[2]);
            mmHandle = Convert.ToInt32(detail[3]);

            AttachProcesses();
        }

        private static void HandlePlayerUpdate(ReceivedChat message)
        {
            _player = new Player(message.Message);
            //bsPlayer.DataSource = p;
        }

        private static void HandleGoldUpdate(ReceivedChat message)
        {
            _gold = Convert.ToInt32(message.Message);
            //lblGold.Text = message.Message + " gold";
        }

        private static void HandleEquipmentUpdate(ReceivedChat message)
        {
            _equipment = new BindingListEx<Item>();
            //clear inventory and re-pop
            string[] lines = message.Message.Split('\n');
            foreach (string line in lines)
            {
                if (line.Length > 0) _equipment.Add(new Item(line));
            }
            //bsEquipment.DataSource = inventory;
        }

        private static void HandleInventoryUpdate(ReceivedChat message)
        {
            _inventory = new BindingListEx<Item>();

            string[] lines = message.Message.Split('\n');
            foreach (string line in lines)
            {
                if (line.Length > 0) _inventory.Add(new Item(line));
            }
            //                bsInventory.DataSource = inventory;
        }




        internal static void QueryInventory()
        {
            mmServer.ServerInstance.QueueCommand("sendInventory();");
        }

        internal static void QueryPlayerDetails()
        {
            mmServer.ServerInstance.QueueCommand("sendPlayerDetails();");
        }

        internal static void QueryPlayerInfo(string player)
        {
            mmServer.ServerInstance.QueueCommand("sendMacro(\"AskPlayerInfo(\\\"" + player + "\\\")\")");
        }

        internal static void QueryTargetDetailsEx()
        {
            mmServer.ServerInstance.QueueCommand("sendTargetDetailsEx()");
        }

        internal static void TargetNPC(string p)
        {
            mmServer.ServerInstance.QueueCommand(string.Format("player:target_NPC(\"{0}\");", p));
        }

        internal static void SetCommsState(bool on)
        {
            string cmd = "SetCommsState(\"{0}\")";

            cmd = string.Format(cmd, on ? "on" : "off");

            mmServer.ServerInstance.QueueCommand(cmd);
        }

        public static void ApplyLootfilterSettings(string qfilter, string picks, string excludes)
        {
            string sendMacroLine = "SlashCommand(\"{0}\")";

            //clear first
            mmServer.ServerInstance.QueueCommand(string.Format(sendMacroLine, "/lf CLEAR"));

            //send excludes
            if (excludes.Length > 0)
            {
                string[] exs = excludes.Split(new string[]{Environment.NewLine},StringSplitOptions.RemoveEmptyEntries);

                foreach (string ex in exs)
                {
                    mmServer.ServerInstance.QueueCommand(string.Format(sendMacroLine, "/lf add " + ex));
                }
                mmServer.ServerInstance.QueueCommand(string.Format(sendMacroLine, "/lf list"));

            }

            //send picks
            if (picks.Length > 0)
            {
                string[] pcks = picks.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string pick in pcks)
                {
                    mmServer.ServerInstance.QueueCommand(string.Format(sendMacroLine, "/lf pick " + pick));
                }
                mmServer.ServerInstance.QueueCommand(string.Format(sendMacroLine, "/lf show"));
            }

            if (qfilter.Length > 0)
            {
                mmServer.ServerInstance.QueueCommand(string.Format(sendMacroLine, "/lf SETQ " + qfilter));
                mmServer.ServerInstance.QueueCommand(string.Format(sendMacroLine, "/lf QFILTER ON"));
            }


        }

        internal static void SetLootfilterState(bool on)
        {
            string sendMacroLine = string.Format("SlashCommand(\"/lf {0}\")", on ? "ON" : "OFF");
            mmServer.ServerInstance.QueueCommand(sendMacroLine);
        }
    }
}
