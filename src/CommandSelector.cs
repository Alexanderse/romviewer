using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RomViewer
{
    public partial class CommandSelector : Form
    {
        private CommandList _commandList = null;
        private MainForm _mainForm = null;
        private int _port;

        public CommandSelector(MainForm mainForm)
        {
            _mainForm = mainForm;
            _port = Convert.ToInt32(mainForm.tbSendTo.Text);

            InitializeComponent();

            LoadCommands();
            LoadWaypointFiles();

        }

        public CommandSelector()
        {
            InitializeComponent();

            LoadCommands();
            LoadWaypointFiles();
        }

        public static CommandSelector Selector = null;

        private void LoadCommands()
        {
            if (File.Exists("commands.xml"))
                _commandList = CommandList.LoadFromFile("commands.xml");
            else
            {
                _commandList = new CommandList();
                _commandList.Commands.Add(new GameCommand("Quest: Hand in Butterfly quest", "player:target_NPC(\"Robbie Butcher\");yrest(100);CompleteQuestByName(\"Catch Butterflies\");yrest(100);AcceptQuestByName(\"Catch Butterflies\");", true));
                _commandList.Commands.Add(new GameCommand("Quest: Hand in Dogs quest", "for i=0,9,1 do player:target_NPC(\"Robbie Butcher\"); sendMacro(\"OnClick_QuestListButton(1,1)\"); yrest(100); player:target_NPC(\"Robbie Butcher\"); sendMacro(\"OnClick_QuestListButton(3,1)\"); sendMacro(\"CompleteQuest()\"); yrest(100); end;", true));
                _commandList.Commands.Add(new GameCommand("Pet: Feed Cake Stack", "local pet = CEggPet(1); pet:update(); sendChatMessage(\"Pet\", pet.Name..\"[level-\"..pet.Level..\" xp:\"..pet.Exp..\"/\"..pet.MaxExp);  pet:feed(204791,99); sendChatMessage(\"Pet\", pet.Name..\"[level-\"..pet.Level..\" xp:\"..pet.Exp..\"/\"..pet.MaxExp); sendInventory()"));
                _commandList.Commands.Add(new GameCommand("Pet: Feed Golden Egg Stack", "local pet = CEggPet(1); pet:update(); sendChatMessage(\"Pet\", pet.Name..\"[level-\"..pet.Level..\" xp:\"..pet.Exp..\"/\"..pet.MaxExp);  pet:feed(204792,99); sendChatMessage(\"Pet\", pet.Name..\"[level-\"..pet.Level..\" xp:\"..pet.Exp..\"/\"..pet.MaxExp); sendInventory()"));
                _commandList.Commands.Add(new GameCommand("Pet: Stats", "local pet = CEggPet(1); pet:update(); sendChatMessage(\"Pet\", string.format(\"%s [level %d] Str: %.2f, Sta: %.2f, Dex: %.2f, Int: %.2f, Wis: %.2f : Nourishment: %d\", pet.Name, pet.Level, pet.Str, pet.Sta, pet.Dex, pet.Int, pet.Wis, pet.Nourishment));", true));
                _commandList.Commands.Add(new GameCommand("Pet: Summon", "local pet = CEggPet(1); pet:update(); pet:Summon();", true));
                _commandList.Commands.Add(new GameCommand("Pet: Return", "local pet = CEggPet(1); pet:update(); pet:Return();", true));
                _commandList.Commands.Add(new GameCommand("Pet: Get Enhancement Pots", "keyboardPress(key.VK_DASH);sendMacro(\"ChoiceOption(3)\");yrest(200);sendMacro(\"ChoiceOption(2)\");", true));
                _commandList.Commands.Add(new GameCommand("Player: Inquire", "sendMacro(\"AskPlayerInfo(\\\" \\\")\")"));
                _commandList.Commands.Add(new GameCommand("Player: Experience", "sendChatMessage(\"System\", \"XP: \"..tostring(player.XP)..\" / \"..tostring(memoryReadRepeat(\"intptr\", getProc(), addresses.charMaxExpTable_address, (player.Level-1) * 4) or 1)..\" TP: \"..tostring(player.TP))", true));
                _commandList.Commands.Add(new GameCommand("ACS: On", "sendMacro(\"acsSlash(\\\"on\\\")\")", true));
                _commandList.Commands.Add(new GameCommand("Housekeeper: Chat", "player:target_NPC(113798); for i=0,6,1 do sendMacro(\"SpeakFrame_ListDialogOption(1, 1)\");yrest(10); end; player:target_NPC(113775); for i=0,6,1 do sendMacro(\"SpeakFrame_ListDialogOption(1, 1)\");yrest(10); end; player:target_NPC( 113772 ); for i=0,6,1 do sendMacro(\"SpeakFrame_ListDialogOption(1, 1)\");yrest(10); end;"));
                _commandList.Commands.Add(new GameCommand("Housekeeper: Protection", "player:target_NPC(113797); yrest(100); for i=0,6,1 do sendMacro(\"SpeakFrame_ListDialogOption(1, 4)\");yrest(10); end", true));
                _commandList.Commands.Add(new GameCommand("LootFilter: Set", "sendMacro(\"LootFilterConfig(nil,\\\"pick *Meat\\\")\"); sendMacro(\"LootFilterConfig(nil, \\\"pick *rune\\\")\"); sendMacro(\"LootFilterConfig(nil, \\\"pick *Rune\\\")\"); sendMacro(\"LootFilterConfig(nil, \\\"pick *II\\\")\"); sendMacro(\"LootFilterConfig(nil, \\\"qfilter on\\\")\"); sendMacro(\"LootFilterConfig(nil, \\\"setq blue\\\")\")", true));
                _commandList.Commands.Add(new GameCommand("SW: Enter", "sendMacro(\"GuildHousesWar_EnterWar()\")", true));
                _commandList.Commands.Add(new GameCommand("Eggs: Trade", "local u=player:findNearestNameOrId(\"Remmuletwo\");player:target(u);sendMacro(\"RequestTrade(\\\"target\\\");\"); yrest(1000); u=player:findNearestNameOrId(\"Klimcola\");player:target(u);sendMacro(\"RequestTrade(\\\"target\\\");\"); yrest(1000); u=player:findNearestNameOrId(\"Remuleone\");player:target(u);sendMacro(\"RequestTrade(\\\"target\\\");\");  yrest(1000); u=player:findNearestNameOrId(\"Geecola\");player:target(u);sendMacro(\"RequestTrade(\\\"target\\\");\");", true));
                _commandList.Commands.Add(new GameCommand("Connect: Get PID", "local PID=findProcessByWindow(getWin()); local winHandle=getWin(); local mmPID=findProcessByWindow(getHwnd()); local mmHwnd=getHwnd(); local res=sprintf(\"%s\\2%s\\2%s\\2%s\",tostring(PID),tostring(winHandle),tostring(mmPID),tostring(mmHwnd)); sendChatMessage(\"PID\", res);", true));
                
                
            }

            bsCommands.DataSource = _commandList.Commands;
        }

        private void LoadWaypointFiles()
        {
            lbWaypoints.Items.Clear();
            List<string> files = ToonController.GetWaypointFileList();
            lbWaypoints.Items.AddRange(files.ToArray());
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadCommands();
            LoadWaypointFiles();
        }

        private void CommandSelector_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_commandList != null) _commandList.WriteToFile("commands.xml");
            e.Cancel = false;
            CommandSelector.Selector = null;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsCommands.Current != null)
            {
                GameCommand cmd = (GameCommand) bsCommands.Current;
                if (cmd.AutoRun)
                {
                    CommandMessage gm = new CommandMessage(cmd.CommandText, _port);
                    Queue.Synchronized(_mainForm._server.MessageQueue).Enqueue(gm);                    
                }
                else
                {
                    tbCommand.Text = cmd.CommandText;
                }
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            mmServer.ServerInstance.QueueCommand(tbCommand.Text);
        }

        private void lbWaypoints_DoubleClick(object sender, EventArgs e)
        {
            if (lbWaypoints.SelectedItem != null) tbCommand.Text = string.Format("LoadNewWaypointList(\"{0}.xml\")", lbWaypoints.SelectedItem.ToString());
        }

    }
}
