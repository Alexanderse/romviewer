using System.Reflection;
using System.Windows.Forms;
using WindowsInput;
using log4net.Config;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using NHibernate;
using NHibernate.Criterion;
using RomViewer.Core.Mapping;
using RomViewer.Core.NPCs;
using RomViewer.Domain;
using RomViewer.Model;
using RomViewer.NHibernateProvider;
using RomViewer.Navigator;
using RomViewer.Tasks.Repositories;
using SharpLite.Domain.DataInterfaces;
using WindowHider;
using System.Runtime.InteropServices;
using System.Threading;

[assembly: XmlConfigurator(ConfigFileExtension="log4net", Watch=true)]

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
        private Dictionary<ToolStripItem, GameNode> _menuMap = new Dictionary<ToolStripItem, GameNode>();
        private RomSettings _settings;
        private ToonSettings _selectedToon;
        private dlgMultiLineMessage _dlgMultiLineChat = null;
        private Player _player;
        private RichTextBox _whisperBox;
        private Hashtable _whispers = new Hashtable();
        private bool _mmUpdateSetting = false;
        private List<string> channelsToMonitor = new List<string>();
        private Process _currentROMProcess = null;
        Process _currentMMProcess = null;
        private bool _restartingProcesses;
        private string _currentWaypointFile = "";

        public MainForm()
        {
            InitializeComponent();

            try {
                World.Initialise(Path.GetFullPath("."));

                /*
               Debugger.Break();
              NHibernate.Cfg.Configuration _configuration;
              ISessionFactory _sessionFactory;

              _configuration = NHibernateInitializer.Initialize();
              _sessionFactory = _configuration.BuildSessionFactory();

              using (ISession session = _sessionFactory.OpenSession())
              {
                  ITransaction tx = session.BeginTransaction();

                  Hashtable zMap = new Hashtable();
                  List<MapZone> zones = new List<MapZone>();
                  foreach (var zone in World.Data.Zones)
                  {
                      MapZone z = new MapZone();
                      z.RomId = zone.Id;
                      z.Name = zone.Name;
                      zones.Add(z);
                      zMap.Add(z.RomId, z);
                      session.Save(z);
                  }
                  //tx.Commit();
                  //tx = session.BeginTransaction();


                    
                  Hashtable pMap = new Hashtable();
                  List<MapPoint> points = new List<MapPoint>();
                  foreach (var node in World.Data.Nodes)
                  {
                      MapPoint pt = new MapPoint
                                        {
                                            X = node.Coordinates.X,
                                            Y = node.Coordinates.Y,
                                            Z = node.Coordinates.Z,
                                            Name = node.Name
                                        };
                      double test;
                      if (double.TryParse(pt.Name, out test) || (pt.Name.Contains(pt.X.ToString())))
                          pt.Name = null;

                      if (node.Zone != null)
                      {
                          pt.MapZone = (MapZone) zMap[node.Zone.Id];
                      }
                      points.Add(pt);
                      pMap.Add(node, pt);
                      session.Save(pt);
                  }


                  foreach (var node in World.Data.Nodes)
                  {
                      MapPoint pt = (MapPoint) pMap[node];
                      foreach (var link in node.GameNodeLinks)
                      {
                          MapLink lnk = new MapLink
                                            {
                                                Start = pt,
                                                End = (MapPoint) pMap[link.Target],
                                                Script = link.Script,
                                                LinkType = LinkType.Physical
                                            };
                          session.Save(lnk);
                      }
                  }

                  foreach (var node in World.Data.Nodes)
                  {
                      foreach (var o in node.GameObjects)
                      {

                          Vector3 goPoint = node.Coordinates;

                          NonPlayerEntity entity = null;
                          var search = session.CreateCriteria<NonPlayerEntity>()
                              .Add(Restrictions.Eq("RomId", o.Id))
                              .Add(Restrictions.Eq("ZoneId", node.Zone.Id))
                              .List<NonPlayerEntity>();

                          foreach (NonPlayerEntity npe in search)
                          {
                              Vector3 dbPoint = new Vector3(npe.X, npe.Y, npe.Z);
                              if (goPoint.Distance(dbPoint) < 200) entity=npe;
                          }

                          if (entity == null)
                          {
                              entity = new NonPlayerEntity();
                              entity.RomId = o.Id;
                              entity.Name = o.Name;
                              entity.UniqueId = o.UniqueId;
                              entity.X = goPoint.X;
                              entity.Y = goPoint.Y;
                              entity.Z = goPoint.Z;
                              entity.ZoneId = node.Zone.Id;
                          }

                          if (entity != null)
                          {
                              foreach (var ot in o.ObjectTypes)
                              {
                                  switch (ot)
                                  {
                                      case GameObjectType.VendorPet:
                                          entity.EntityTypes = entity.EntityTypes | EntityTypes.PetHunter;
                                          entity.EntityTypes = entity.EntityTypes | EntityTypes.Vendor;
                                          break;
                                      case GameObjectType.VendorGeneral:
                                          entity.EntityTypes = entity.EntityTypes | EntityTypes.Vendor;
                                          break;
                                      case GameObjectType.AuctionHouse:
                                          entity.EntityTypes = entity.EntityTypes | EntityTypes.AuctionHouse;
                                          break;
                                      case GameObjectType.Bank:
                                          entity.EntityTypes = entity.EntityTypes | EntityTypes.Bank;
                                          break;
                                      case GameObjectType.Mailbox:
                                          entity.EntityTypes = entity.EntityTypes | EntityTypes.Mailbox;
                                          break;
                                      case GameObjectType.Housemaid:
                                          entity.EntityTypes = entity.EntityTypes | EntityTypes.Bank;
                                          entity.EntityTypes = entity.EntityTypes | EntityTypes.Housemaid;
                                          break;
                                      case GameObjectType.Transporter:
                                          entity.EntityTypes = entity.EntityTypes | EntityTypes.Teleporter;
                                          break;
                                      default:
                                          throw new ArgumentOutOfRangeException();
                                  }
                              }

                              session.Save(entity);
                              foreach (var link in o.TransportLinks)
                              {
                                  TeleportLink lnk = new TeleportLink
                                                         {
                                                             Start = entity,
                                                             End = (MapPoint) pMap[link.Destination],
                                                             Script = link.Script,
                                                             LinkType = LinkType.Teleport
                                                         };
                                  session.Save(lnk);
                              }
                          }

                      }
                  }

                  tx.Commit();
              }
              */
                BuildGotoMenu();
                modelLoaderThread.RunWorkerAsync();
                MicroMacroOptions opt = new MicroMacroOptions();
                opt.OnValueChanged += _onOptionChanged; 
                settingsGrid.SelectedObject = opt;
            }catch { }

          
            zoneBindingSource.DataSource = World.Data.Zones;
            if (zoneComboBox.Items.Count > 0) zoneComboBox.SelectedIndex = 0;
            gameNodeBindingSource1.DataSource = World.Data.Nodes;
            foundObjectBindingSource.DataSource = _objectList;

            LoadToonList();

        }

        public void AddWhisperText(string from, string text)
        {
            _whisperBox.AppendText(string.Format("{0} {1}{2}",from, text,Environment.NewLine));
        }

        private void _onOptionChanged(string option, string value)
        {
            mmServer.ServerInstance.QueueCommand(string.Format("settings.profile.options.{0}={1}", option, value));

        }

        private void BuildGotoMenu()
        {
            Hashtable data = World.GetNamedNodesByZone();

            foreach (Zone zone in World.Data.Zones)
            {
                List<GameNode> list = (List<GameNode>) data[zone.Name];

                if (list.Count > 0)
                {
                    ToolStripMenuItem miZone = (ToolStripMenuItem)miGoto.DropDownItems.Add(zone.Name);

                    foreach (GameNode node in list)
                    {
                        ToolStripItem item = miZone.DropDownItems.Add(node.Name);
                        _menuMap.Add(item, node);
                        item.Click += ItemOnClick;
                    }
                }
            }
        }

        private void ItemOnClick(object sender, EventArgs eventArgs)
        {
            GameNode node = _menuMap[(ToolStripItem) sender];
            _currentWaypointFile = World.Goto(node);
        }

        private void LoadToonList()
        {
            _settings = RomSettings.ReadFromFile("RomSettings.xml");
            ToonController._settings = _settings;

            /*
            RomSettings romSettings = new RomSettings();

            //load the player loot settings too
            int count = Convert.ToInt32(ConfigurationManager.AppSettings["ToonCount"]);

            string toon = "Toon.{0}";
            for (int i = 1; i <= count; i++)
            {
                string toonRef = string.Format(toon, i);
                ToonSettings settings = new ToonSettings();
                string[] details = ConfigurationManager.AppSettings[toonRef].ToString().Split(',');

                settings.name = details[0];
                settings.msgPort = Convert.ToInt32(details[1]);
                settings.cmdPort = Convert.ToInt32(details[2]);

                settings.lootActive = bool.Parse(ConfigurationManager.AppSettings[toonRef + ".LootFilter.Active"]);
                details = ConfigurationManager.AppSettings[toonRef + ".LootFilter.Picks"].Split(',');
                foreach (string s in details)
                {
                    settings.lootIncludes.Add(s);
                }

                details = ConfigurationManager.AppSettings[toonRef + ".LootFilter.Excludes"].Split(',');
                foreach (string s in details)
                {
                    settings.lootExcludes.Add(s);
                }

                settings.quality = ConfigurationManager.AppSettings[toonRef + ".LootFilter.Quality"];
                cbToons.Items.Add(settings.name);
                _toonSettings.Add(settings.name, settings);
                romSettings.Toons.Add(settings);
            }

            RomSettings.SaveToFile("RomSettings.xml", romSettings);
             */
        }

        private void Start()
        {
            World.PlayerName = _selectedToon.name;
            this.Text = "RomViewer v" + RV_VERSION + " - " + _selectedToon.name + " (" + _selectedToon.cmdPort.ToString() + ")";

            _onData = OnData;
            _onDataList = OnDataList;
            _server = new mmServer(_selectedToon.msgPort, _selectedToon.cmdPort, _onDataList, _onNoComms);
//            _server = new mmServer(Convert.ToInt32(tbListenPort.Text), Convert.ToInt32(tbSendTo.Text), _onDataList);
            _server.Start();

            AddMessage(new ReceivedChat("Guild", "", "Starting", ""));
            AddMessage(new ReceivedChat("Whisper", "", "Starting", ""));
            AddMessage(new ReceivedChat("Say", "", "Starting", ""));
            AddMessage(new ReceivedChat("World", "", "Starting", ""));
            AddMessage(new ReceivedChat("Zone", "", "Starting", ""));
            AddMessage(new ReceivedChat("Party", "", "Starting", ""));

            ToonController.QueryPlayerDetails();
            ToonController.QueryInventory();
            ToonController.QueryWindows();
            ToonController.QueryExecutionPath();

            LoadLootFilters();

            tmrKeyPress.Enabled = true;
        }

        private void _onNoComms(int seconds)
        {
            if (_restartingProcesses) return;
            if (!xbAutoRestart.Checked) return;
            if (seconds < Convert.ToInt32(tbRestartCount.Text)) return;

            _restartingProcesses = true;
            try
            {
                string currentPlayer = _player.Name;

                miLaunch_Click(null, null);

                //force settings to be resent
                ToonController.QueryPlayerDetails();
                ToonController.QueryInventory();
                xbACSOn_CheckedChanged(null, null);
                xbACSPaused_CheckedChanged(null, null);
                xbAutoTurn_CheckedChanged(null, null);
                xbACSAutoTarget_CheckedChanged(null, null);
                btnClearTargets_Click(null, null);
                xbUseBuffs_CheckedChanged(null, null);
                xbUseLongRoot_CheckedChanged(null, null);
                xbUseHeals_CheckedChanged(null, null);
                xbUseBigSlowAttack_CheckedChanged(null, null);
                xbLoot_CheckedChanged(null, null);
                btnApplyLootfilterSettings_Click(null, null);
                string command = "setWaypointLooping(" + (xbLoop.Checked).ToString().ToLower() + ")";
                SendCommand(command);

                mmServer.ServerInstance.QueueCommand(tbRestartCommands.Text);

                if (World.IsTravelling) mmServer.ServerInstance.QueueCommand(_currentWaypointFile);
            }
            finally
            {
                mmServer.ServerInstance.updateLastCommsTime();
                _restartingProcesses = false;
            }
            //restart!!!!!
        }

        private void LoadLootFilters()
        {
            cbLFQuality.Text = _selectedToon.quality;

            tbPick.Clear();
            foreach (string s in _selectedToon.lootIncludes)
            {
                tbPick.Text += s + Environment.NewLine;
            }

            tbBlack.Clear();
            foreach (string s in _selectedToon.lootExcludes)
            {
                tbBlack.Text += s + Environment.NewLine;
            }
            xbQFilterState.Checked = _selectedToon.lootActive;

            ToonController.ApplyLootfilterSettings(cbLFQuality.Text, tbPick.Text, tbBlack.Text);
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
                string[] lines = message.Message.Split((char)3);
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
                string[] lines = message.Message.Split((char)3);
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

                if (!ObjectSaver.Started)
                {
                    ObjectSaver._filenames.Add(4, Path.Combine(Application.StartupPath, p.Name + "_npcs.xml"));
                    ObjectSaver.Start();

                }

                _onPlayerUpdate(p);
            }
            else if (message.Channel.ToUpper() == "SETTINGS")
            {
                string[] detail = message.Message.Split((char)2);
                int i = 0;

                while (i < detail.Length)
                {
                    string setting = detail[i].ToUpper();
                    i++;
                    string value = detail[i];
                    i++;

                    UpdateSetting(setting, value);

                }
            }
            else if (message.Channel.ToUpper() == "PID")
            {
                string[] detail = message.Message.Split((char)2);
                ToonController.romPID = Convert.ToInt32(detail[0]);
                ToonController.romWinHandle = Convert.ToInt32(detail[1]);
                ToonController.mmPID = Convert.ToInt32(detail[2]);
                ToonController.mmWinHandle = Convert.ToInt32(detail[3]);

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

                if (_player == null) _player = new Player();
                _player.HP = (int)Convert.ToDouble(detail[1]);
                _player.MaxHP = (int)Convert.ToDouble(detail[2]);
                _player.MP = (int)Convert.ToDouble(detail[7]);
                _player.MaxMP = (int)Convert.ToDouble(detail[8]); 
                _player.MP2 = (int)Convert.ToDouble(detail[9]);
                _player.MaxMP2 = (int)Convert.ToDouble(detail[10]);

                _currentCoordinates = new Vector3((Math.Round(Convert.ToDouble(detail[3]), 0)), (Math.Round(Convert.ToDouble(detail[4]), 0)), (Math.Round(Convert.ToDouble(detail[5]), 0)));

                _onPlayerUpdate(_player);

                bool suppressRedraw = (World.PlayerPos.Distance(_currentCoordinates) < 1);

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
                        World.Data.Zones.Add(z);

                        if (!ZoneForm.EditZone(z)) return;

                        World.SaveToDirectory(Path.GetFullPath("."));
                        zoneBindingSource.ResetBindings(false);
                        suppressRedraw = false;
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
                if (!suppressRedraw)
                {
                    DisplayMap();
                    CenterOnPlayer();
                }
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
                        //cbSendKeys.Checked = false;
                    }
                    else if (message.Message == "end")
                    {
                        World.IsTravelling = false;
                        _currentWaypointFile = "";
                        //cbSendKeys.Checked = true;
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
                    Vector3 playerPos = World.PlayerPos;

                    _objectList.Sort((o, foundObject) => o.Distance.CompareTo(foundObject.Distance));

                    foundObjectBindingSource.RaiseListChangedEvents = true;
                    foundObjectBindingSource.ResetBindings(false);

                    DisplayMap();
                }
                else
                {
                    string[] lines = message.Message.Split((char)3);

                    foreach (string line in lines)
                    {
                        if (string.IsNullOrEmpty(line)) continue;

                        string[] detail = line.Split((char) 2);

                        if (detail.Length < 6) continue;
                        if (string.IsNullOrEmpty(detail[0])) continue;

                        detail[0] = (Math.Round(Convert.ToDouble(detail[0]), 0)).ToString();
                        detail[1] = (Math.Round(Convert.ToDouble(detail[1]), 0)).ToString();
                        detail[2] = (Math.Round(Convert.ToDouble(detail[2]), 0)).ToString();

                        if (string.IsNullOrEmpty(detail[5])) continue;
                        int id = Convert.ToInt32(detail[5].Trim());

                        int guid = -1;
                        try {guid = Convert.ToInt32(detail[8].Trim());} catch{}

                        FoundObject fo;
                        fo = (FoundObject)_objectList.Find(o => ((o.Id == id) && (o.Guid == guid)));

                        if (fo == null)
                        {
                            FoundObject obj = new FoundObject();
                            obj.Id = id;
                            obj.Name = detail[4].Trim();
                            obj.Guid = guid;

                            try
                            {
                                obj.ObjectType = Convert.ToInt32(detail[3].Trim());
                            } catch
                            {
                            }

                            obj.Coordinates = new Vector3((Math.Round(Convert.ToDouble(detail[0]), 0)),
                                                         (Math.Round(Convert.ToDouble(detail[2]), 0)),
                                                         (Math.Round(Convert.ToDouble(detail[1]), 0)));
                            obj.Distance = World.PlayerPos.Distance(obj.Coordinates);
                            obj.Attackable = (detail[6].Trim().ToUpper() == "TRUE");
                            obj.ZoneId = World.CurrentZone.Id;
                            _objectList.Add(obj);

                            _newobjectList.Add(obj);
                            ObjectSaver.Add(obj);
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
                            p.Class1 = Convert.ToInt32(tokens[2]);
                            p.Level = Convert.ToInt32(tokens[3].Trim('(', ')'));
                            p.Class2 = Convert.ToInt32(tokens[4]);
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

                if (this.WindowState == FormWindowState.Minimized)
                {
                    if (channelsToMonitor.Contains(message.Channel.ToUpper()))
                    {
                        noteIcon.BalloonTipText = message.ToString();
                        noteIcon.ShowBalloonTip(1000);
                    }
                }

                ChannelPage cInt = (ChannelPage)_tabChannelMap[message.Channel];

                cInt.MessageBox.AppendText(message.ToString() + Environment.NewLine);
                if (message.Channel.ToUpper()=="WHISPER")
                {
                    if (_whispers.ContainsKey(message.Player))
                    {
                        dlgWhisper d = (dlgWhisper) _whispers[message.Player];
                        d.AddText(message.ToString() + Environment.NewLine);
                    }
                }

                if (cInt.Page != tcChats.SelectedTab)
                {
                    if (cInt.Page.Text != cInt.Channel + "*")
                        cInt.Page.Text = cInt.Channel + "*";
                }

                cInt.MessageBox.SelectionStart = cInt.MessageBox.Text.Length;
                cInt.MessageBox.ScrollToCaret();
            }
        }

        private void UpdateSetting(string setting, string value)
        {
            _mmUpdateSetting = true;
            switch (setting)
            {
                case "LOOPING":
                    try
                    {
                        bool val = bool.Parse(value);
                        xbLoop.Checked = val;
                    }
                    finally
                    {
                        _mmUpdateSetting = false;
                    }
                    break;
                default:
                    break;
            }
        }

        public void _onPlayerUpdate(Player player)
        {
            //"S55/M50 Human (Female) [guild]")
            string display = string.Format("{0}{1:00}/{2}{3:00} {4} ({5}) [{6}]", RomClassHelper.GetPrefixChar(player.Class1 + 1), player.Level, 
                                                    RomClassHelper.GetPrefixChar(player.Class2+1), player.Level2, player.Race, player.Sex,
                                                    player.Guild);
            lblPlayer1.Text = display;

            pbHP.Maximum = player.MaxHP;
            pbHP.Minimum = 0;
            pbHP.Value = player.HP;

            pbMP.Maximum = player.MaxMP;
            pbMP.Minimum = 0;
            pbMP.Value = player.MP;

            pbMP2.Maximum = player.MaxMP2;
            pbMP2.Minimum = 0;
            pbMP2.Value = player.MP2;

            _player = player;
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
                    _whisperBox = box;
                    box.ContextMenuStrip = cmWhisper;
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
                                              mmServer.ServerInstance.QueueChat(message.Channel, tb.Text, targetBox.Text);
                                              AddWhisperText("-->["+targetBox.Text+"]", tb.Text);
                                              tb.Text = "";
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
                            mmServer.ServerInstance.QueueChat(message.Channel, tb.Text, "");
                            tb.Text = "";
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
                mmServer.ServerInstance.QueueCommand(tbCommand.Text);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //modelLoaderThread.CancelAsync();
            Stop();
            //if (_server != null) _server.Stop();

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

            if (rbDIYCE.Checked) command = "sendMacro(\"DIYCE_Pause(" + xbACSPaused.Checked.ToString().ToLower() + ");";

            SendCommand(command);
        }

        private void xbAutoTurn_CheckedChanged(object sender, EventArgs e)
        {
            string state = "on";
            if (!xbACSAutoTurn.Checked) state = "off";


            string command = "sendMacro(\"acsSlash(\\\"autoturn " + state + "\\\")\")";
            if (rbDIYCE.Checked) command = "sendMacro(\"DIYCE_AutoTurn(" + xbACSAutoTurn.Checked.ToString().ToLower() + ")\");";
            
            SendCommand(command);
        }

        private void xbACSAutoTarget_CheckedChanged(object sender, EventArgs e)
        {
            string state = "on";
            if (!xbACSAutoTarget.Checked) state = "off";

            string command = "sendMacro(\"acsSlash(\\\"autotarget " + state + "\\\")\")";
            if (rbDIYCE.Checked) command = "sendMacro(\"DIYCE_AutoTarget(" + xbACSAutoTarget.Checked.ToString().ToLower() + ")\");";
            SendCommand(command);
            command = "settings.profile.options.AUTO_TARGET = " + xbACSAutoTarget.Checked.ToString().ToLower();
            SendCommand(command);
        }

        private void tsbACSTargetAdd_Click(object sender, EventArgs e)
        {
            string target = tebTargetName.Text;

            if (!string.IsNullOrEmpty(target))
            {
                string command = "sendMacro(\"acsSlash(\\\"autotarget add " + target + "\\\")\")";
                if (rbDIYCE.Checked) command = "sendMacro(\"DIYCE_AddTarget(\\\"" + target + "\\\")\");sendMacro(\"DIYCE_ListTargets()\")";
                SendCommand(command);
                //lbACSTargets.Items.Add(target);
            }
        }

        private void tsACSTargetRemove_Click(object sender, EventArgs e)
        {
            /*
            if (lbACSTargets.SelectedItem != null)
            {
                string target = lbACSTargets.SelectedItem.ToString();
                string command = "sendMacro(\"acsSlash(\\\"autotarget remove " + target + "\\\")\")";
                if (rbDIYCE.Checked) command = "sendMacro(\"DIYCE_RemoveTarget(\\\"" + target + "\\\")\");sendMacro(\"DIYCE_ListTargets()\")";
                SendCommand(command);
                lbACSTargets.Items.Remove(lbACSTargets.SelectedItem);
            }
            */
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

        private void AddNewNode(bool autoAdd)
        {
            //could push this all into the world class to centralise all updatres
            GameNode node = new GameNode();
            node.Id = World.GetNextNodeId();
            node.Coordinates = new Vector3(_currentCoordinates);
            node.Name = node.Id.ToString();
            node.Zone = (Zone) zoneComboBox.SelectedItem;

            bool canAdd = autoAdd;

            if (!canAdd)
            {
                using (EditWaypointForm f = new EditWaypointForm(node))
                {
                    canAdd = (f.ShowDialog() == DialogResult.OK);
                }
            }

            if (canAdd)
            {
                World.Data.Nodes.Add(node);
                Zone currentZone = (Zone)zoneBindingSource.Current;

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
            if (_selectedToon == null)
            {
                _selectedToon = dlgToonSelector.SelectToon(_settings.Toons);
                ToonController._selectedToon = _selectedToon;
                if (_selectedToon == null) return;
            }

            Start();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void Stop()
        {
            ObjectSaver.Stop();

            if (_server != null)
            {
                _server.Stop();
                _server = null;
            }
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
            AddNewNode(false);
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
            if (tcChats.SelectedTab != tpMap) return;

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
            SetStatus("Ready");
        }

        private void SetStatus(string status)
        {
            lblStatus.Text = status;
        }

        private void modelLoaderThread_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            try
            {
                pbModelProgress.Value = e.ProgressPercentage;
                if (e.UserState != null) SetStatus((string) e.UserState);
            } catch
            {
            }
        }

        private void btnSetCommsOn_Click(object sender, EventArgs e)
        {
            ToonController.SetCommsState(true);
        }

        private void btnMount_Click(object sender, EventArgs e)
        {
            mmServer.ServerInstance.QueueCommand("player:mount()");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = "RomViewer v" + RV_VERSION;
        }

        private void tcChats_TabIndexChanged(object sender, EventArgs e)
        {
            DisplayMap();
        }

        private void btnApplyLootfilterSettings_Click(object sender, EventArgs e)
        {
            ToonController.ApplyLootfilterSettings(cbLFQuality.Text, tbPick.Text, tbBlack.Text);
            //_selectedToon.quality = cbLFQuality.Text;
            //_selectedToon.lootActive = xbQFilterState.Checked;
            //_selectedToon.lootIncludes
        }

        private void xbQFilterState_CheckedChanged(object sender, EventArgs e)
        {
            ToonController.SetLootfilterState(xbQFilterState.Checked);
        }

        private void tmrMap_Tick(object sender, EventArgs e)
        {
            if (xbAutoMap.Checked)
            {
                GameNode lastNode = null;

                if (waypointsBindingSource.Position > -1) lastNode = (GameNode)waypointsBindingSource.Current;
                if (lastNode != null)
                {
                    if (lastNode.Coordinates.Distance(_currentCoordinates) < 3) return;
                }

                //map this waypoint!!!!
                AddNewNode(true);
            }
        }

        private void xbAutoMap_CheckedChanged(object sender, EventArgs e)
        {
            tmrMap.Enabled = xbAutoMap.Checked;
        }

        private void btnClearTargets_Click(object sender, EventArgs e)
        {
            if (rbDIYCE.Checked)
            {
                string command = "sendMacro(\"DIYCE_ClearTargets()\")";
                SendCommand(command);

                SendCommand("settings.profile.mobs = {}");

                string[] details = tbTargets.Text.Split(new string[] {Environment.NewLine},
                                                        StringSplitOptions.RemoveEmptyEntries);

                string targets = "";
                foreach (var s in details)
                {
                    command = "sendMacro(\"DIYCE_AddTarget(\\\"" + s + "\\\")\");sendMacro(\"DIYCE_ListTargets()\")";
                    SendCommand(command);
                    if (targets.Length > 0) targets += ", ";
                    targets += "\"" + s + "\"";
                }

                if (targets.Length > 0) SendCommand(string.Format("settings.profile.mobs = {{{0}}}", targets));
            }

            _selectedToon.targets.Clear();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            _selectedToon = dlgToonSelector.SelectToon(_settings.Toons);
            ToonController._selectedToon = _selectedToon;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ToonSettings setting = dlgToonSelector.SelectToon(_settings.Toons);
            if (setting != null)
            {
                _selectedToon = setting;
                miLaunch.Enabled = true;
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (_dlgMultiLineChat == null)
            {
                List<string> channels = new List<string>();
                channels.Add("guild");
                channels.Add("party");
                channels.Add("say");
                channels.Add("whisper");
                channels.Add("world");
                channels.Add("zone");

                _dlgMultiLineChat = new dlgMultiLineMessage(channels);
                _dlgMultiLineChat.Closed += new EventHandler(_dlgMultiLineChat_Closed);
            }

            _dlgMultiLineChat.Show();
        }

        private void _dlgMultiLineChat_Closed(object sender, EventArgs e)
        {
            _dlgMultiLineChat.Closed -= new EventHandler(_dlgMultiLineChat_Closed);
            _dlgMultiLineChat = null;
        }

        private void foundObjectDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == colDistance.Index)
            {
                FoundObject o = (FoundObject) _objectList[e.RowIndex];
                if (o != null)
                {
                    int distance = (int) World.PlayerPos.Distance(o.Coordinates);
                    e.Value = distance;
                }
            }
        }

        private void pathBuilderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dlgPathBuilder f = new dlgPathBuilder();
            f.Show();
        }

        private void xbUseBuffs_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDIYCE.Checked)
            {
                string command = "sendMacro(\"DIYCE_SetOption(\\\"buffs\\\", " + xbUseBuffs.Checked.ToString().ToLower() + ");\")";
                SendCommand(command);
            }
        }

        private void xbUseLongRoot_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDIYCE.Checked)
            {
                string command = "sendMacro(\"DIYCE_SetOption(\\\"longroot\\\", " + xbUseLongRoot.Checked.ToString().ToLower() + ");\")";
                SendCommand(command);
            }

        }

        private void xbUseHeals_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDIYCE.Checked)
            {
                string command = "sendMacro(\"DIYCE_SetOption(\\\"heals\\\", " + xbUseHeals.Checked.ToString().ToLower() + ");\")";
                SendCommand(command);
            }

        }

        private void xbUseBigSlowAttack_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDIYCE.Checked)
            {
                string command = "sendMacro(\"DIYCE_SetOption(\\\"bigslowattack\\\", " + xbUseBigSlowAttack.Checked.ToString().ToLower() + ");\")";
                SendCommand(command);
            }

        }

        private void xbLoop_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                noteIcon.Visible = true;
                noteIcon.BalloonTipText = (string.IsNullOrEmpty(World.PlayerName)) ? "Rom1" : World.PlayerName;
                //noteIcon.ShowBalloonTip(2);  //show balloon tip for 2 seconds
                noteIcon.Text = noteIcon.BalloonTipText;
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
                Hide();
            }

        }

        private void noteIcon_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            //noteIcon.ShowBalloonTip(1000);
            WindowState = FormWindowState.Normal;
            this.BringToFront();
            this.Activate();
        }

        private void btnUpdateWin_Click(object sender, EventArgs e)
        {
            ToonController.QueryWindows();
        }

        private void cmiOpenWhisper_Click(object sender, EventArgs e)
        {
            if (_whisperBox != null)
            {
                string target = _whisperBox.SelectedText.Trim();
                if (string.IsNullOrEmpty(target)) return;

                dlgWhisper d;
                if (!_whispers.ContainsKey(target))
                {
                    d = new dlgWhisper(target, this);
                    _whispers.Add(target, d);
                    d.FormClosed += delegate(object o, FormClosedEventArgs args) { _whispers.Remove(target); };
                }

                d = (dlgWhisper) _whispers[target];
                d.Show();
                d.WindowState = FormWindowState.Normal;
                d.BringToFront();
                d.Focus();
            }
        }

        private void btnMErchant_Click(object sender, EventArgs e)
        {
            if (gameNodeComboBox.Text != null)
            {
                    mmServer.ServerInstance.QueueCommand("player:merchant(\"" + gameNodeComboBox.Text + "\")");
            }
        }

        private void btnToggleLooping_Click(object sender, EventArgs e)
        {
            string command = "setWaypointLooping(" + (!xbLoop.Checked).ToString().ToLower() + ")";
            SendCommand(command);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            channelsToMonitor.Clear();
            channelsToMonitor.AddRange(tbChannelsToMonitor.Lines);
        }

        private void xbUseTeleporters_CheckedChanged(object sender, EventArgs e)
        {
            World.UseTransporters = xbUseTeleporters.Checked;
        }

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("User32.dll", EntryPoint = "ShowWindowAsync")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);
        private const int SW_SHOWNORMAL = 1;
        private const int SW_HIDE = 0;

        private bool killMMProcess()
        {
            if (_currentMMProcess == null) return false;

            bool result = true;
            try
            {
                _currentMMProcess.CloseMainWindow();
                _currentMMProcess.WaitForExit(5000);
                result = _currentMMProcess.HasExited;
                if (result) _currentMMProcess = null;
            }
            catch
            {
                _currentMMProcess = null;
            }
            ToonController.mmPID = -1;
            ToonController.mmWinHandle = -1;
            ToonController.proccessMM = null; 
            return result;
        }

        private bool killROMProcess()
        {
            if (_currentROMProcess == null) return false;

            bool result;
            try
            {
                if (!_currentROMProcess.HasExited)
                {
                    _currentROMProcess.Kill();
                    _currentROMProcess.WaitForExit(5000);
                }
                result = _currentROMProcess.HasExited;
                _currentROMProcess = null;
            }
            catch
            {
                _currentROMProcess = null;
                result = true;
            }
            ToonController.romPID = -1;
            ToonController.romWinHandle = -1;
            ToonController.proccessGame = null;
            return result;
        }


        private void miLaunch_Click(object sender, EventArgs e)
        {
            killROMProcess();
            killMMProcess();

            ProcessStartInfo info = new ProcessStartInfo(_selectedToon.romInstall, "NoCheckVersion");
            info.WorkingDirectory = Path.GetDirectoryName(_selectedToon.romInstall);
            info.Verb = "runas";
            
            //update the autologin first
            string autoLogin = Path.Combine(Path.GetDirectoryName(_selectedToon.romInstall), "interface\\Loginxml\\accountlogin.lua");

            if (File.Exists(autoLogin)) File.Delete(autoLogin);
            string autoLoginContents = File.ReadAllText(Path.Combine(Application.StartupPath, "Configuration\\accountlogin.txt"));
            autoLoginContents = string.Format(autoLoginContents, _selectedToon.accountUser, _selectedToon.accountPwd, _selectedToon.charIndex.ToString());
            File.WriteAllText(autoLogin, autoLoginContents);

            autoLogin = Path.Combine(Path.GetDirectoryName(_selectedToon.romInstall), "interface\\Loginxml\\logindialog.lua");
            if (File.Exists(autoLogin)) File.Delete(autoLogin);
            autoLoginContents = File.ReadAllText(Path.Combine(Application.StartupPath, "Configuration\\logindialog.txt"));
            autoLoginContents = string.Format(autoLoginContents, _selectedToon.accountSecondaryPwd);
            File.WriteAllText(autoLogin, autoLoginContents);


            _currentROMProcess = Process.Start(info);


            //wait for game to load
            Thread.Sleep(500);
            ToonController.romPID = _currentROMProcess.Id;
            ToonController.romWinHandle = (int)_currentROMProcess.MainWindowHandle;
            ToonController.proccessGame = null;
            ToonController.AttachProcesses();
            ToonController.proccessGame.Window.Visible = false;

            Thread.Sleep(40000);


            //start MM with the selected toon and run script
            string launchFile = Path.Combine(Path.GetDirectoryName(_settings.MicroMacroPath), string.Format("start_{0}.lua", _selectedToon.name));
            string txt = "";
            //txt = string.Format("rom/edbot.lua profile:{0} character:{1}", _selectedToon.profile, _selectedToon.name);
            txt = string.Format("__profile=\"{1}\";{0}__character=\"{2}\";{0}{0}include(\"scripts/rom/edbot.lua\");{0}", Environment.NewLine, _selectedToon.profile, _selectedToon.name);
            if (File.Exists(launchFile)) File.Delete(launchFile);
            File.WriteAllText(launchFile, txt);
            info = new ProcessStartInfo(_settings.MicroMacroPath);
            //info.WorkingDirectory = Path.Combine(Path.GetDirectoryName(_settings.MicroMacroPath), "scripts");
            info.UseShellExecute = false;
            info.Verb = "runas";
            info.Arguments = string.Format("start_{0}.lua", _selectedToon.name);
            _currentMMProcess = Process.Start(info);
            Thread.Sleep(5000);

            ToonController.mmPID = _currentMMProcess.Id;
            ToonController.mmWinHandle = (int) _currentMMProcess.MainWindowHandle;
            ToonController.proccessMM = null;
            ToonController.AttachProcesses();
            ToonController.proccessMM.Window.Visible = false;

            if (_server == null)
            {
                Start();
                Thread.Sleep(2000);
            }
        }

        private void cbSendKeys_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void xbLoot_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDIYCE.Checked)
            {
                string command = "sendMacro(\"DIYCE_SetOption(\\\"loot\\\", " + xbLoot.Checked.ToString().ToLower() + ");\")";
                SendCommand(command);
            }
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
        public double Distance { get; set; }
        public int Id { get; set; }
        public int Guid { get; set; }
        public string Name { get; set; }
        public Vector3 Coordinates { get; set; }
        public bool Attackable { get; set; }
        public int ObjectType { get; set;  }
        public int ZoneId { get; set; }
    }
}
