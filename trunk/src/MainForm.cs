using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using RomViewer.Domain;
using RomViewer.Model;
using RomViewer.Navigator;
using WindowHider;
using System.Runtime.InteropServices;
using System.Threading;

//using RomViewer.Navigator;

namespace RomViewer
{
    public partial class MainForm : Form
    {
        private const string RV_VERSION = "0.5";

        public mmServer _server;
        private OnDataDelegate _onData;
        private OnDataListDelegate _onDataList;
        private Hashtable _tabChannelMap = new Hashtable();
        private Dictionary<string, ChannelPage> _pageMap = new Dictionary<string, ChannelPage>();
        private Hashtable _toons = new Hashtable();
        private List<string> _toonInquiry = new List<string>();
        private BindingListEx<Pawn> _inquiries = new BindingListEx<Pawn>();
        private Vector3 _currentCoordinates;
        private int _tick = 0;
        private bool _dontRepaint;
        private NodeViewer _viewer;
        private MapSettings _mapSettings;
        private List<FoundObject> _objectList = new List<FoundObject>();
        private List<FoundObject> _newobjectList = new List<FoundObject>();

        public MainForm()
        {
            InitializeComponent();

            try {
                World.Initialise(Path.GetFullPath("."));
                modelLoaderThread.RunWorkerAsync();

            }catch { }

            
            zoneBindingSource.DataSource = World.Data.Zones;
            if (zoneComboBox.Items.Count > 0) zoneComboBox.SelectedIndex = 0;
            gameNodeBindingSource1.DataSource = World.Data.Nodes;
            foundObjectBindingSource.DataSource = _objectList;
        }

        private void Start()
        {
            LoadPlayers();
            _onData = OnData;
            _onDataList = OnDataList;
            _server = new mmServer(Convert.ToInt32(tbListenPort.Text), Convert.ToInt32(tbSendTo.Text), _onDataList);
            _server.Start();

            AddMessage(new ReceivedChat("Guild", "", "Starting", ""));
            AddMessage(new ReceivedChat("Whisper", "", "Starting", ""));
            AddMessage(new ReceivedChat("Say", "", "Starting", ""));
            AddMessage(new ReceivedChat("World", "", "Starting", ""));
            AddMessage(new ReceivedChat("Zone", "", "Starting", ""));

            bsInquiry.DataSource = _inquiries;

            ToonController.QueryPlayerDetails();
            ToonController.QueryInventory();
            ToonController.QueryWindows();
            ToonController.QueryExecutionPath();

            tmrKeyPress.Enabled = true;
        }

        private void ShowSelector()
        {
            if (CommandSelector.Selector == null) CommandSelector.Selector = new CommandSelector(this);
            CommandSelector.Selector.Show();
            CommandSelector.Selector.Activate();
        }

        private void OnDataList(List<ReceivedChat> message)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(_onDataList, new object[] { message });
                }
                else
                {
                    AddMessages(message);
                }
            }
            catch (Exception)
            {
            }
        }

        private void AddMessages(List<ReceivedChat> message)
        {
            foreach (ReceivedChat receivedChat in message)
            {
                AddMessage(receivedChat);
            }
        }

        private void OnData(ReceivedChat message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(_onData, new object[] {message});
            }
            else
            {
                AddMessage(message);
            }
        }

        private void AddMessage(ReceivedChat message)
        {
            if (message.Channel.ToUpper() == "INVENTORY")
            {
                //Sortable
                BindingListEx<Item> inventory = new BindingListEx<Item>();
                //clear inventory and re-pop
                string[] lines = message.Message.Split('\n');
                foreach (string line in lines)
                {
                    if (line.Length > 0) inventory.Add(new Item(line));
                }
                bsInventory.DataSource = inventory;
            }
            else if (message.Channel.ToUpper() == "EQUIPMENT")
            {
                //Sortable
                BindingListEx<Item> inventory = new BindingListEx<Item>();
                //clear inventory and re-pop
                string[] lines = message.Message.Split('\n');
                foreach (string line in lines)
                {
                    if (line.Length > 0) inventory.Add(new Item(line));
                }
                bsEquipment.DataSource = inventory;
            }
            else if (message.Channel.ToUpper() == "GOLD")
            {
                lblGold.Text = message.Message + " gold";
            }
            else if (message.Channel.ToUpper() == "PLAYERDETAILS")
            {
                Player p = new Player(message.Message);
                bsPlayer.DataSource = p;
            }
            else if (message.Channel.ToUpper() == "PID")
            {
                string[] detail = message.Message.Split((char)2);
                ToonController.PID = Convert.ToInt32(detail[0]);
                ToonController.GameWindowHandle = Convert.ToInt32(detail[1]);
                ToonController.mmPID = Convert.ToInt32(detail[2]);
                ToonController.mmHandle = Convert.ToInt32(detail[3]);

                ToonController.proccessGame = null;
                ToonController.proccessMM = null;
                ToonController.AttachProcesses();
            }
            else if (message.Channel.ToUpper() == "EXECUTIONPATH")
            {
                ToonController.MicroMacroFolder = message.Message;
            }
            else if (message.Channel.ToUpper() == "STATE")
            {
                string[] detail = message.Message.Split((char)2);
                if (detail[0].ToUpper() == "FIGHTING") xbBattling.Checked = (detail[1].ToUpper() == "TRUE");

            }
            else if (message.Channel.ToUpper() == "PLAYERUPDATE")
            {
                //	local result = sprintf("%s\2%s\2%s\2%s\2%s\2%s", player.Name, player.HP, player.MaxHP, player.X, player.Y, player.Z);
                string[] detail = message.Message.Split((char)2);
                detail[3] = (Math.Round(Convert.ToDouble(detail[3]), 0)).ToString();
                detail[4] = (Math.Round(Convert.ToDouble(detail[4]), 0)).ToString();
                detail[5] = (Math.Round(Convert.ToDouble(detail[5]), 0)).ToString();

                _currentCoordinates = new Vector3((Math.Round(Convert.ToDouble(detail[3]), 0)), (Math.Round(Convert.ToDouble(detail[4]), 0)), (Math.Round(Convert.ToDouble(detail[5]), 0)));
                World.PlayerPos = _currentCoordinates;

                this.Text = string.Format("{0} ({1}/{2}) {3},{4},{5}", detail);

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

                        if (!ZoneForm.EditZone(z)) return;

                        World.Data.Zones.Add(z);
                        World.SaveToDirectory(Path.GetFullPath("."));
                        zoneBindingSource.ResetBindings(false);
                    }

                    World.CurrentZone = z;
                    zoneComboBox.SelectedItem = z;
                    GameNode node = World.FindNearestNode(World.PlayerPos);
                    if (node != null) cbNearestNode.SelectedItem = node;
                }
                catch (Exception)
                {

                    throw;
                }

                if (NodeVisualiser.Visualiser != null) NodeVisualiser.Visualiser.UpdatePlayerPosition();
                DisplayMap();
                CenterOnPlayer();
            }
            else if (message.Channel.ToUpper() == "TARGETDETAILS")
            {
                if (message.Message.Length > 0)
                {
                    Pawn p = new Pawn(message.Message);
                    bsTarget.DataSource = p;
                }
                else
                {
                    bsTarget.DataSource = new Pawn();
                }
            }
            else if (message.Channel.ToUpper() == "NAVPOINT")
            {
                if (message.Message.Length > 0)
                {
                    if (message.Message == "start")
                    {
                        World.IsTravelling = true;
                        cbSendKeys.Checked = false;
                    }
                    else if (message.Message == "end")
                    {
                        World.IsTravelling = false;
                        cbSendKeys.Checked = true;
                    }
                    else
                    {
                        int wpNum = Convert.ToInt32(message.Message);
                    }
                }
            }
            else if (message.Channel.ToUpper() == "ROMOBJECTS")
            {
                if (message.Message == "new")
                {
                    foundObjectBindingSource.RaiseListChangedEvents = false;
                    _newobjectList.Clear();
                }
                else if (message.Message == "end")
                {
                    List<FoundObject> deleteList = new List<FoundObject>();
                    foreach (var obj in _objectList)
                    {
                        if (!_newobjectList.Contains(obj)) deleteList.Add(obj);
                    }

                    foreach (var obj in deleteList)
                    {
                        _objectList.Remove(obj);
                    }

                    foundObjectBindingSource.RaiseListChangedEvents = true;
                    foundObjectBindingSource.ResetBindings(false);
                }
                else
                {
                    string[] lines = message.Message.Split((char)3);

                    foreach (string line in lines)
                    {
                        if (string.IsNullOrEmpty(line)) continue;

                        string[] detail = line.Split((char)2);

                        if (detail.Length < 6) continue;
                        if (string.IsNullOrEmpty(detail[0])) continue;

                        detail[0] = (Math.Round(Convert.ToDouble(detail[0]), 0)).ToString();
                        detail[1] = (Math.Round(Convert.ToDouble(detail[1]), 0)).ToString();
                        detail[2] = (Math.Round(Convert.ToDouble(detail[2]), 0)).ToString();

                        if (string.IsNullOrEmpty(detail[5])) continue;
                        int id = Convert.ToInt32(detail[5].Trim());

                        FoundObject fo = (FoundObject)_objectList.Find(o => o.Id == id);

                        if (fo == null)
                        {
                            FoundObject obj = new FoundObject();
                            obj.Id = id;
                            obj.Name = detail[4].Trim();
                            obj.Coordinates = new Vector3((Math.Round(Convert.ToDouble(detail[0]), 0)),
                                                         (Math.Round(Convert.ToDouble(detail[2]), 0)),
                                                         (Math.Round(Convert.ToDouble(detail[1]), 0)));

                            obj.Attackable = (detail[6].Trim().ToUpper() == "TRUE");
                            _objectList.Add(obj);

                            _newobjectList.Add(obj);
                        }
                        else
                        {
                            fo.Coordinates = new Vector3((Math.Round(Convert.ToDouble(detail[0]), 0)),
                                                         (Math.Round(Convert.ToDouble(detail[2]), 0)),
                                                         (Math.Round(Convert.ToDouble(detail[1]), 0)));

                            fo.Attackable = (detail[6].Trim().ToUpper() == "TRUE");

                            _newobjectList.Add(fo);
                        }
                    }
                }

            }
            else
            {
                GetOrAddTabPage(message);

                string player = message.Player.Trim();
                if (!string.IsNullOrEmpty(player))
                {
                    if (!_toons.ContainsKey(player.ToLower()))
                    {
                        _toons.Add(player.ToLower(), new Pawn());
                        _toonInquiry.Add(player.ToLower());
                        ToonController.QueryPlayerInfo(player);
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
            }
        }

        private void CenterOnPlayer()
        {
            //move this off to a separate class at some point
            if (hsbMap.Maximum > 0)
            {
                double x = _viewer.OriginOffset.X + (World.PlayerPos.X / _mapSettings.Scale) - (_viewer.ViewDimensions.Width / 2);
                double y = _viewer.OriginOffset.Y + (-World.PlayerPos.Z / _mapSettings.Scale) - (_viewer.ViewDimensions.Height / 2);

                if (x > hsbMap.Maximum) x = hsbMap.Maximum; if (x < hsbMap.Minimum) x = hsbMap.Minimum;
                if (y > vsbMap.Maximum) y = vsbMap.Maximum; if (y < vsbMap.Minimum) y = vsbMap.Minimum;

                hsbMap.Value = (int)x;
                vsbMap.Value = (int)y;

                DisplayMap();
            }
        }

        private void GetOrAddTabPage(ReceivedChat message)
        {
            if (!_tabChannelMap.ContainsKey(message.Channel))
            {
                tcChats.TabPages.Add(message.Channel, message.Channel);
                TabPage page = tcChats.TabPages[message.Channel];
                RichTextBox box = new RichTextBox();
                page.Controls.Add(box);
                box.Top = 0;
                box.Left = 0;
                box.Width = page.ClientRectangle.Width;
                box.Height = page.ClientRectangle.Height - 30;
                box.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;

                ChannelPage ci;

                if (message.Channel.ToUpper() == "WHISPER")
                {
                    TextBox targetBox = new TextBox();
                    page.Controls.Add(targetBox);
                    targetBox.Top = box.Bottom + 3;
                    targetBox.Height = page.ClientRectangle.Height - targetBox.Top - 3;
                    targetBox.Width = (int)(page.ClientRectangle.Width * 0.15);
                    targetBox.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;

                    TextBox tb = new TextBox();
                    page.Controls.Add(tb);
                    tb.Top = box.Bottom + 3;
                    tb.Left = targetBox.Right + 10;
                    tb.Height = page.ClientRectangle.Height - tb.Top - 3;
                    tb.Width = (int) ((page.ClientRectangle.Width - 10)*.85);
                    tb.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                    tb.KeyDown += delegate(object sender, KeyEventArgs args)
                                      {
                                          if (args.KeyCode == Keys.Enter)
                                          {
                                              ChatMessage gm = new ChatMessage(message.Channel, tb.Text, targetBox.Text, Convert.ToInt32(tbSendTo.Text));
                                              box.AppendText(gm.ToString() + Environment.NewLine);
                                              tb.Text = "";
                                              Queue.Synchronized(_server.MessageQueue).Enqueue(gm);
                                          }
                                      };
                    ci = new TargettedPage(tcChats, page, box, message.Channel, targetBox);
                }
                else
                {
                    TextBox tb = new TextBox();
                    page.Controls.Add(tb);
                    tb.Top = box.Bottom + 3;
                    tb.Height = page.ClientRectangle.Height - tb.Top - 3;
                    tb.Width = page.ClientRectangle.Width;
                    tb.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                    tb.KeyDown += delegate(object sender, KeyEventArgs args)
                    {
                        if (args.KeyCode == Keys.Enter)
                        {
                            ChatMessage gm = new ChatMessage(message.Channel, tb.Text, "", Convert.ToInt32(tbSendTo.Text));
                            tb.Text = "";
                            Queue.Synchronized(_server.MessageQueue).Enqueue(gm);
                        }
                    };
                    ci = new ChannelPage(tcChats, page, box, message.Channel);
                    
                }
                _tabChannelMap.Add(message.Channel, ci);
                _pageMap.Add(page.Name, ci);
            }
        }


        private void tcChats_Selected(object sender, TabControlEventArgs e)
        {
            if (_pageMap.ContainsKey(e.TabPage.Name))
            {
                e.TabPage.Text = ((ChannelPage) _pageMap[e.TabPage.Name]).Channel;
            }

            if (e.TabPage == tpMap) DisplayMap();
        }

        private void tbCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CommandMessage gm = new CommandMessage(tbCommand.Text, Convert.ToInt32(tbSendTo.Text));
                Queue.Synchronized(_server.MessageQueue).Enqueue(gm);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_server != null) _server.Stop();

        }

        private void btnPlayerUpdate_Click(object sender, EventArgs e)
        {
            ToonController.QueryPlayerDetails();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ToonController.QueryTargetDetailsEx();

        }

        private void btnRefreshInventory_Click(object sender, EventArgs e)
        {
            ToonController.QueryInventory();
        }

        private void xbACSOn_CheckedChanged(object sender, EventArgs e)
        {
            string state = "on";
            if (!xbACSOn.Checked) state = "off";

            string command = "sendMacro(\"acsSlash(\\\""+state+"\\\")\")";
            SendCommand(command);
        }

        private void SendCommand(string command)
        {
            mmServer.ServerInstance.QueueCommand(command);
        }

        private void xbACSPaused_CheckedChanged(object sender, EventArgs e)
        {
            string command = "sendMacro(\"acsSlash(\\\"";
            if (xbACSPaused.Checked) command += "pause\\\")\")";
            else command += "resume\\\")\")";

            SendCommand(command);
        }

        private void xbAutoTurn_CheckedChanged(object sender, EventArgs e)
        {
            string state = "on";
            if (!xbACSAutoTurn.Checked) state = "off";

            string command = "sendMacro(\"acsSlash(\\\"autoturn " + state + "\\\")\")";
            SendCommand(command);
        }

        private void xbACSAutoTarget_CheckedChanged(object sender, EventArgs e)
        {
            string state = "on";
            if (!xbACSAutoTarget.Checked) state = "off";

            string command = "sendMacro(\"acsSlash(\\\"autotarget " + state + "\\\")\")";
            SendCommand(command);
        }

        private void tsbACSTargetAdd_Click(object sender, EventArgs e)
        {
            string target = tebTargetName.Text;

            if (!string.IsNullOrEmpty(target))
            {
                string command = "sendMacro(\"acsSlash(\\\"autotarget add " + target + "\\\")\")";
                SendCommand(command);
                lbACSTargets.Items.Add(target);
            }
        }

        private void tsACSTargetRemove_Click(object sender, EventArgs e)
        {
            if (lbACSTargets.SelectedItem != null)
            {
                string target = lbACSTargets.SelectedItem.ToString();
                string command = "sendMacro(\"acsSlash(\\\"autotarget remove " + target + "\\\")\")";
                SendCommand(command);
                lbACSTargets.Items.Remove(lbACSTargets.SelectedItem);
            }
        }

        private void rb2h_CheckedChanged(object sender, EventArgs e)
        {
            string engage = "1";
            int above = 3;
            int below = 10;

            if (sender == rb2h) engage = "2";
            else if (sender == rbPvp)
            {
                engage = "3";
                above = 100;
                below = 100;
            }

            string command = "sendMacro(\"acsSlash(\\\"engage " + engage + "\\\")\")";
            SendCommand(command);

            //set max and min levels to max as we can target any opponent
            command = string.Format("settings.profile.options.TARGET_LEVELDIF_ABOVE={0};settings.profile.options.TARGET_LEVELDIF_BELOW={1};", above, below);
            SendCommand(command);
        }

        private string _getTodaysToonFilename()
        {
            //should push all this functionality out to another class
            return "toons_" + DateTime.Now.ToString("yyyymmdd");
        }

        private void btnSavePawns_Click(object sender, EventArgs e)
        {
            lock (_inquiries)
            {
                if (File.Exists("ROM.inquiries")) File.Delete("ROM.inquiries");
                using (FileStream inquiries = new FileStream("ROM.inquiries", FileMode.Create, FileAccess.Write, FileShare.None))
                {
//                    BinaryWriter writer = new BinaryWriter(inquiries);

                    XmlSerializer ser = new XmlSerializer(typeof (BindingListEx<Pawn>));
                    ser.Serialize(inquiries, _inquiries);
                }
            }
        }

        private void LoadPlayers()
        {
            lock (_inquiries)
            {
                if (File.Exists("ROM.inquiries"))
                {
                    using (FileStream inquiries = new FileStream("ROM.inquiries", FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                        XmlSerializer ser = new XmlSerializer(typeof(BindingListEx<Pawn>));
                        _inquiries = (BindingListEx<Pawn>)ser.Deserialize(inquiries);
                        foreach (Pawn pawn in _inquiries)
                            _toons[pawn.Name.ToLower()] = pawn;
                        bsInquiry.DataSource = _inquiries;
                    }
                }
            }
        }

        private void AddNewNode()
        {
            //could push this all into the world class to centralise all updatres
            GameNode node = new GameNode();
            node.Id = World.GetNextNodeId();
            node.Coordinates = new Vector3(_currentCoordinates);
            node.Name = node.Id.ToString();
            node.Zone = (Zone) zoneComboBox.SelectedItem;


            using (EditWaypointForm f = new EditWaypointForm(node))
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    World.Data.Nodes.Add(node);
                    Zone currentZone = (Zone) zoneBindingSource.Current;

                    //currentZone.AddNode(node);
                    GameNode lastNode = null;
                    if (waypointsBindingSource.Position > -1) lastNode = (GameNode)waypointsBindingSource.Current;
                    int idx = waypointsBindingSource.Add(node);

                    if (lastNode != null) lastNode.AddNeighbour(node, true);

                    waypointsBindingSource.Position = idx;

                    gameNodeBindingSource.ResetBindings(false);
                    gameNodeBindingSource1.ResetBindings(false);
                    
                }
                else
                {
                    World.Data.Zones[0].Waypoints.Remove(node);
                }
            }


        }

        private void ShowNodeManager()
        {
            if (NodeManager.Manager == null) NodeManager.Manager = new NodeManager();
            NodeManager.Manager.Show();
            NodeManager.Manager.Activate();
        }

        private void ShowMap()
        {
            Zone zone = (Zone)zoneBindingSource.Current;
            if (NodeVisualiser.Visualiser == null) new NodeVisualiser(zone, (GameNode)cbNearestNode.SelectedItem);
            NodeVisualiser.Visualiser.Show();
            NodeVisualiser.Visualiser.Activate();
        }

        private void zoneBindingSource_PositionChanged(object sender, EventArgs e)
        {
            World.PlayerZone = (Zone) zoneBindingSource.Current;
            //need to change all this to use observers to get updates rather than pushing this update to the visualiser
            if (NodeVisualiser.Visualiser != null) NodeVisualiser.Visualiser.UpdatePlayerPosition();
        }

        private void gotoNearest(GameObjectType gameObjectType)
        {
            GameNode node = (GameNode)cbNearestNode.SelectedItem;

            if (node != null)
            {
                List<WaypointLink> path = World.FindRouteTo(gameObjectType, node);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?><waypoints>");
                for (int i = 0; i < path.Count; i++)
                {
                    string script = "";
                    //if (i < path.Count - 1) script = path[i + 1].Script;
                    sb.AppendLine(path[i].Source.ToRomBotXML(i + 1, path[i].Script));
                }
                if (path.Count > 0) sb.AppendLine(path[path.Count-1].Destination.ToRomBotXML(path.Count, ""));

                sb.AppendLine("</waypoints>");

                string filename = @"C:\Installs\micromacro\scripts\rom\waypoints\newWP.xml";

                if (File.Exists(filename)) File.Delete(filename);
                string data = sb.ToString();
                File.WriteAllLines(filename, new string[] { data });

                //send a message
                filename = filename.Replace("\"", "\\\"");
                mmServer.ServerInstance.QueueCommand("LoadNewWaypointList(\"newWP.xml\")");
            }
        }
        private void btnGotoAH_Click(object sender, EventArgs e)
        {
            gotoNearest(GameObjectType.AuctionHouse);
        }

        private void btnGotoMB_Click(object sender, EventArgs e)
        {
            gotoNearest(GameObjectType.Mailbox);
        }

        private void btnGotoPet_Click(object sender, EventArgs e)
        {
            gotoNearest(GameObjectType.VendorPet);

        }

        private void btnGotoVendor_Click(object sender, EventArgs e)
        {
            gotoNearest(GameObjectType.VendorGeneral);
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void Stop()
        {
            _server.Stop();
            _server = null;
        }

        private void manageNodesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowNodeManager();
        }

        private void mapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowMap();
        }

        private void commandSelectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSelector();
        }

        private void rebuildToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pbModelProgress.Value = 0;
            modelLoaderThread.RunWorkerAsync();
        }

        private void addNodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewNode();
        }

        private void displayObjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendCommand("sendObjects()");
        }

        private void auctionHouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gotoNearest(GameObjectType.AuctionHouse);
        }

        private void mailboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gotoNearest(GameObjectType.Mailbox);

        }

        private void petVendorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gotoNearest(GameObjectType.VendorPet);

        }

        private void vEndorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gotoNearest(GameObjectType.VendorGeneral);

        }

        private void bankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gotoNearest(GameObjectType.Bank);

        }

        private void housemaidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gotoNearest(GameObjectType.Housemaid);

        }


        private void btnHideShow_Click(object sender, EventArgs e)
        {
            ToonController.ToggleVisible();
        }



        private void tmrKeyPress_Tick(object sender, EventArgs e)
        {
            _tick++;


            if (cbSendKeys.Checked && ToonController.proccessGame!=null)
            {
                if ((_tick % ToonController.proccessGame.Interval) == 0)
                {
                    ToonController.proccessGame.Window.KeyPress((IntPtr)Keys.F11, (IntPtr) 0);
                }

                if ((_tick % 100) == 0)
                {
                    SendCommand("sendObjects()");
                }
            }
        }

        private MapSettings GetMapSettings()
        {

            Pen movementPen = new Pen(Brushes.Black);
            movementPen.DashStyle = DashStyle.Dot;
            Pen linkPen = new Pen(Brushes.CornflowerBlue);
            linkPen.DashStyle = DashStyle.Dash;
            _mapSettings = new MapSettings(100, 8, (double)tkScale.Value / 10, Color.AntiqueWhite, Color.Black, movementPen, linkPen);

            _mapSettings.OnGetNodeBrush = OnGetNodeBrush;
            _mapSettings.OnGetLinkPen = OnGetLinkPen;

            return _mapSettings;
        }

        private Pen OnGetLinkPen(GameNode source, object link)
        {
            return (link is TransportLink) ? _mapSettings.TeleportLinkPen : _mapSettings.MovementLinkPen;
        }

        private Brush OnGetNodeBrush(GameNode node)
        {
            return _mapSettings.NodeBrush;
        }

        private void DisplayMap()
        {
            _dontRepaint = true;
            try
            {
                if (World.CurrentZone == null)
                {
                    pbMap.Image = null;
                    return;
                }

                /*
                double xratio, yratio;
                xratio = 1;
                yratio = 1;
                if (_viewer != null)
                {
                    //record current center
                    if (hsbMap.Maximum > 0) xratio = (((double)hsbMap.Value) / ((double)hsbMap.Maximum));
                    if (vsbMap.Maximum > 0) yratio = (((double)vsbMap.Value) / ((double)vsbMap.Maximum));
                }
                */
                _viewer = new NodeViewer(World.CurrentZone, GetMapSettings());


                Rectangle view = new Rectangle(hsbMap.Value, vsbMap.Value, pbMap.ClientSize.Width, pbMap.ClientSize.Height);
                _viewer.SetView(view);
                _viewer.SetPlayerPos(World.PlayerPos);

                foreach (FoundObject o in _objectList)
                {
                    if ((o.Id > 0) && (o.Name != "<UNKNOWN>") && (o.Coordinates.Magnitude > 0)) _viewer.AddMapToken(o.Id, o.Name, o.Coordinates);
                }

                Bitmap img = _viewer.GetMap();
                pbMap.Image = img;
                Size size = tpMap.ClientSize;
                size.Width = size.Width - tkScale.Width - vsbMap.Width;
                size.Height -= hsbMap.Height;
                pbMap.Size = size;
                int maxX, maxY;

                maxY = _viewer.MapDimensions.Height - pbMap.Height;
                if (maxY < 1) vsbMap.Maximum = vsbMap.Minimum;
                else vsbMap.Maximum = maxY;

                maxX = _viewer.MapDimensions.Width - pbMap.Width;
                if (maxX < 1) hsbMap.Maximum = hsbMap.Minimum;
                else hsbMap.Maximum = maxX;

                //scroll to player pos


                //hsbMap.Value = (int)(hsbMap.Maximum * xratio);
                //vsbMap.Value = (int)(vsbMap.Maximum * yratio);
                hsbMap.SmallChange = (int)(hsbMap.Maximum / 50);
                hsbMap.LargeChange = (int)(hsbMap.Maximum / 10);
                vsbMap.SmallChange = (int)(vsbMap.Maximum / 50);
                vsbMap.LargeChange = (int)(vsbMap.Maximum / 10);
            }
            finally
            {
                _dontRepaint = false;
            }
            
        }

        private void pbMap_Resize(object sender, EventArgs e)
        {
            if (_dontRepaint) return;
            DisplayMap();
        }

        private void tkScale_ValueChanged(object sender, EventArgs e)
        {
            DisplayMap();
        }

        private void hsbMap_Scroll(object sender, ScrollEventArgs e)
        {
            DisplayMap();
        }

        private void foundObjectDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colAddObject.Index)
            {
                if ((foundObjectBindingSource.Current != null) && (cbNearestNode.SelectedItem != null))
                {
                    GameNode nearest = (GameNode) cbNearestNode.SelectedItem;
                    FoundObject o = (FoundObject) foundObjectBindingSource.Current;

                    GameObject go = new GameObject() {Id = o.Id, Name = o.Name};
                    if (nearest.GameObjects.Find(gameObject => gameObject.Id == o.Id) == null) nearest.GameObjects.Add(go);
                }
            }
            else if (e.ColumnIndex == colTarget.Index)
            {
                if (foundObjectBindingSource.Current != null)
                {
                    FoundObject o = (FoundObject)foundObjectBindingSource.Current;
                    ToonController.TargetNPC(o.Id.ToString());
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _objectList.Clear();
            foundObjectBindingSource.ResetBindings(false);
            DisplayMap();
        }

        private void gameObjectsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colInteract.Index)
            {
                GameObject o = (GameObject) gameObjectsBindingSource.Current;
                ToonController.TargetNPC(o.Id.ToString());
            }
        }

        private void xbFly_CheckedChanged(object sender, EventArgs e)
        {
            if (xbFly.Checked)
                SendCommand("fly()");
            else
                SendCommand("flyoff()");
        }

        private void btnTeleport_Click(object sender, EventArgs e)
        {
            string xS = xTextBox.Text;
            string yS = yTextBox.Text;
            string zS = zTextBox.Text;

            int x = (int) Convert.ToDouble(xS);
            int y = (int) Convert.ToDouble(yS);
            int z = (int) Convert.ToDouble(zS);

            SendCommand("teleport(" + x.ToString() + ", " + z.ToString() + ", " + y.ToString() + ", true);");
        }

        private void miAddZone_Click(object sender, EventArgs e)
        {
            //
            Zone z = new Zone();
            z.Id = -1;
            z.Name = "";

            if (ZoneForm.EditZone(z))
            {
                World.Data.Zones.Add(z);

                World.SaveToDirectory(Path.GetFullPath("."));

                zoneBindingSource.ResetBindings(false);
            }


        }




        private void modelLoaderThread_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            World.BuildModel(modelLoaderThread);
        }

        private void modelLoaderThread_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            pbModelProgress.Value = 100;
            lblProgress.Text = "Ready";
        }

        private void modelLoaderThread_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            pbModelProgress.Value = e.ProgressPercentage;
            if (e.UserState != null) lblProgress.Text = (string)e.UserState;
        }

        private void btnSetCommsOn_Click(object sender, EventArgs e)
        {
            mmServer.ServerInstance.QueueCommand("SetCommsState\"on\"");
        }

        private void btnMount_Click(object sender, EventArgs e)
        {
            mmServer.ServerInstance.QueueCommand("player:mount()");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = "RomViewer v" + RV_VERSION;
        }


    }

    public class ChannelPage
    {
        public string Channel;
        public TabControl TabControl;
        public TabPage Page;
        public RichTextBox MessageBox;

        public ChannelPage(TabControl tabControl, TabPage page, RichTextBox messageBox, string channel)
        {
            TabControl = tabControl;
            Page = page;
            MessageBox = messageBox;
            Channel = channel;
        }
    }

    public class TargettedPage: ChannelPage
    {
        public TextBox TargetBox;

        public TargettedPage(TabControl tabControl, TabPage page, RichTextBox messageBox, string channel, TextBox targetBox) : base(tabControl, page, messageBox, channel)
        {
            TargetBox = targetBox;
        }
    }

    public class FoundObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Vector3 Coordinates { get; set; }
        public bool Attackable { get; set; }
    }
}
