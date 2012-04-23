using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Diagnostics;
using System.IO;
using System.Threading;
using WindowsInput;
using System.Runtime.InteropServices;
using System.Xml.XPath;
using System.Xml;

namespace RomViewer.Configuration
{
    [DataContract]
    public class Party
    {
        [DataMember]
        public string Name;
        [DataMember]
        public List<PartyCharacter> Characters = new List<PartyCharacter>();

        public static Party ContructRemedeParty()
        {
            Party result = new Party();
            result.Name = "Main";

            RomClientInstall romMainInstall = new RomClientInstall("Main", @"C:\Installs\rom1\", "Client.exe", @"C:\Installs\rom1\interface\Loginxml\");
            MMConfiguration mmInstall = new MMConfiguration() { Folder = @"C:\Installs\micromacro\", Filename = "micromacro.exe", Name = "MainMM" };

            Character Remede = new Character() { Name = "RemedeScout", Account = "billdoorUS", Password = "Decad098", SecondaryPassword = "Jarusal3m", CharacterNumber = "1" };

            PartyCharacter pcRem = new PartyCharacter() { Character = Remede, Configuration = mmInstall, ROMInstall = romMainInstall, Party = result, Script = "rom/edbot.lua", LaunchViewer=false, Host="192.168.100.128", HostPort=60000, MessagePort=60999 };

            result.Characters.Add(pcRem);

            return result;
        }

        public static Party ContructEggFarmerParty()
        {
            Party result = new Party();
            result.Name = "EggFarmers";

            RomClientInstall romBotInstall = new RomClientInstall("Main", @"C:\Installs\rom3\", "Client.exe", @"C:\Installs\rom3\interface\Loginxml\");
            MMConfiguration mmInstall = new MMConfiguration() { Folder = @"C:\Installs\micromacro\", Filename = "micromacro.exe", Name = "MainMM" };

            Character RemuleOne = new Character() { Name = "RemuleOne", Account = "billdoorromus1", Password = "Decad098", SecondaryPassword = "Jarusal3m", CharacterNumber = "1" };
            Character RemmuleTwo = new Character() { Name = "RemmuleTwo", Account = "billdoorromus2", Password = "Decad098", SecondaryPassword = "Jarusal3m", CharacterNumber = "1" };
            Character Klimcola = new Character() { Name = "Klimcola", Account = "billdoorromegg1", Password = "Decad098", SecondaryPassword = "Jarusal3m", CharacterNumber = "1" };
            Character GeeCola = new Character() { Name = "GeeCola", Account = "billdoorromegg2", Password = "Decad098", SecondaryPassword = "Jarusal3m", CharacterNumber = "1" };

            PartyCharacter pc1 = new PartyCharacter() { Character = RemuleOne, Configuration = mmInstall, ROMInstall = romBotInstall, Party = result, Script = "rom/bot.lua", WaypointFile = "MRC_Optimized" };
            PartyCharacter pc2 = new PartyCharacter() { Character = RemmuleTwo, Configuration = mmInstall, ROMInstall = romBotInstall, Party = result, Script = "rom/bot.lua", WaypointFile = "MRC_Optimized" };
            PartyCharacter pc3 = new PartyCharacter() { Character = Klimcola, Configuration = mmInstall, ROMInstall = romBotInstall, Party = result, Script = "rom/bot.lua", WaypointFile = "MRC_Optimized" };
            PartyCharacter pc4 = new PartyCharacter() { Character = GeeCola, Configuration = mmInstall, ROMInstall = romBotInstall, Party = result, Script = "rom/bot.lua", WaypointFile = "MRC_Optimized" };


            result.Characters.Add(pc1);
            result.Characters.Add(pc2);
            result.Characters.Add(pc3);
            result.Characters.Add(pc4);

            return result;
        }

    }

    [DataContract]
    public class PartyCharacter
    {
        [DataMember]
        public Party Party;
        [DataMember]
        public Character Character;
        [DataMember]
        public RomClientInstall ROMInstall;
        [DataMember]
        public MMConfiguration Configuration;
        [DataMember]
        public string Script;
        [DataMember]
        public string WaypointFile;
        [DataMember]
        public bool LaunchViewer = false;
        [DataMember]
        public int HostPort;
        public string Host;
        public int MessagePort;

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        public void Launch()
        {
            //update the autologin script for this install
            string autoLogin = Path.Combine(ROMInstall.AutoLoginFileLocation, "accountlogin.lua");

            if (File.Exists(autoLogin)) File.Delete(autoLogin);
            string autoLoginContents = File.ReadAllText("Configuration\\accountlogin.txt");
            autoLoginContents = string.Format(autoLoginContents, Character.Account, Character.Password, Character.CharacterNumber);
            File.WriteAllText(autoLogin, autoLoginContents);

            autoLogin = Path.Combine(ROMInstall.AutoLoginFileLocation, "logindialog.lua");
            if (File.Exists(autoLogin)) File.Delete(autoLogin);
            autoLoginContents = File.ReadAllText("Configuration\\logindialog.txt");
            autoLoginContents = string.Format(autoLoginContents, Character.SecondaryPassword);
            File.WriteAllText(autoLogin, autoLoginContents);

            //update the profile to use a specific port for commands!!!
            _updateProfile();

            //open ROM client and click on the Play button
            ProcessStartInfo info = new ProcessStartInfo(Path.Combine(ROMInstall.Folder, ROMInstall.Filename));
            info.WorkingDirectory = ROMInstall.Folder;
            info.Verb = "runas";
            Process romProc = Process.Start(info);

            ManualResetEventSlim waiter = new ManualResetEventSlim(false);

            Process[] procs = Process.GetProcessesByName("ClientUpdate");
            while (procs.Length < 1)
            {
                waiter.Wait(1000);
                procs = Process.GetProcessesByName("ClientUpdate");
            }


            //wait for form
            Thread.Sleep(4000);

            procs = Process.GetProcessesByName("ClientUpdate");
            while (procs.Length < 1)
            {
                waiter.Wait(1000);
                procs = Process.GetProcessesByName("ClientUpdate");
            }

            Process[] procList = Process.GetProcessesByName("Client.exe");

            InputSimulator sim = new InputSimulator();
            sim.Mouse.MoveMouseTo(38000, 45000);
            sim.Mouse.LeftButtonClick();

            Process[] newProcList = Process.GetProcessesByName("Client");

            //wait for new runes of magic - need to work out when it has finished loading
            while (newProcList.Length == procList.Length)
            {
                waiter.Wait(1000);
                newProcList = Process.GetProcessesByName("Client");
            }

            //wait for game to load
            Thread.Sleep(40000);

            //start MM with the selected toon and run scrip
            info = new ProcessStartInfo(Path.Combine(Configuration.Folder, Configuration.Filename));
            info.WorkingDirectory = Configuration.Folder;
            info.UseShellExecute = false;
            info.Verb = "runas";
            Process p = Process.Start(info);
            Thread.Sleep(500);

            SetForegroundWindow(p.MainWindowHandle);

            string txt = "";
            if (!String.IsNullOrEmpty(WaypointFile))
                txt = string.Format("{0} profile:{1} path:{2}", Script, Character.Name, WaypointFile);
            else
                txt = string.Format("{0} profile:{1}", Script, Character.Name);
            sim.Keyboard.TextEntry(txt);
            sim.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);

            Thread.Sleep(8000);

            procs = Process.GetProcessesByName("Client");
            Process proc = null;
            foreach (Process item in procs)
            {
                if (item.MainWindowTitle.ToLower() == "rom - " + Character.Name.ToLower())
                {
                    proc = item;
                    break;
                }
            }

            if (LaunchViewer)
            {
                info = new ProcessStartInfo(@"E:\dev\rom\romView\RomViewer\bin\Debug\RomViewer.exe");
                info.WorkingDirectory = @"E:\dev\rom\romView\RomViewer\bin\Debug";
                info.Verb = "runas";
                Process.Start(info);
            }
        }

        private void _updateProfile()
        {
            if (String.IsNullOrEmpty(Host)) return;

            string fileName = Path.Combine(Configuration.Folder, string.Format("scripts\\rom\\profiles\\{0}.xml", Character.Name));
            if (!File.Exists(fileName)) return;

            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            XmlElement root = doc.DocumentElement;

            UpdateOption(doc, root, "UDP_ENABLED", "True");
            UpdateOption(doc, root, "UDP_HOST", Host);
            UpdateOption(doc, root, "UDP_HOSTPORT", HostPort.ToString());
            UpdateOption(doc, root, "UDP_LOCALPORT", MessagePort.ToString());

            doc.Save(fileName);
        }

        private static void UpdateOption(XmlDocument doc, XmlElement root, string optionName, string optionValue)
        {
            XmlNode optionsNode = root.SelectSingleNode("/profile/options");
            XmlNode oldNode = root.SelectSingleNode("/profile/options/option[@name='" + optionName + "']");
            XmlElement newNode = doc.CreateElement("option");
            newNode.SetAttribute("name", optionName);
            newNode.SetAttribute("value", optionValue);

            if (oldNode != null)
            {
                optionsNode.ReplaceChild(newNode, oldNode);
            }
            else
            {
                optionsNode.AppendChild(newNode);
            }
        }
    }

    [DataContract]
    public class Character
    {
        [DataMember]
        public string Name;
        [DataMember]
        public string Account;
        [DataMember]
        public string Password;
        [DataMember]
        public string SecondaryPassword;
        [DataMember]
        public string CharacterNumber;
    }

    [DataContract]
    public class RomClientInstall
    {
        [DataMember]
        public string Name;
        [DataMember]
        public string Folder;
        [DataMember]
        public string Filename;
        [DataMember]
        public string AutoLoginFileLocation;

        public RomClientInstall()
        {
        }

        public RomClientInstall(string name, string folder, string filename, string autoLoginFileLocation)
        {
            Name = name;
            Folder = folder;
            Filename = filename;
            AutoLoginFileLocation = autoLoginFileLocation;
        }
    }

    [DataContract]
    public class MMConfiguration
    {
        [DataMember]
        public string Name;
        [DataMember]
        public string Folder;
        [DataMember]
        public string Filename;
    }

}
