using RomViewer.Domain;

namespace RomViewer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label class1Label;
            System.Windows.Forms.Label class2Label;
            System.Windows.Forms.Label guildLabel;
            System.Windows.Forms.Label hPLabel;
            System.Windows.Forms.Label idLabel;
            System.Windows.Forms.Label lastExpLabel;
            System.Windows.Forms.Label levelLabel;
            System.Windows.Forms.Label level2Label;
            System.Windows.Forms.Label maxHPLabel;
            System.Windows.Forms.Label maxMPLabel;
            System.Windows.Forms.Label maxMP2Label;
            System.Windows.Forms.Label mountedLabel;
            System.Windows.Forms.Label mPLabel;
            System.Windows.Forms.Label mP2Label;
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label raceLabel;
            System.Windows.Forms.Label xLabel;
            System.Windows.Forms.Label yLabel;
            System.Windows.Forms.Label zLabel;
            System.Windows.Forms.Label class1Label1;
            System.Windows.Forms.Label class2Label1;
            System.Windows.Forms.Label hPLabel1;
            System.Windows.Forms.Label idLabel1;
            System.Windows.Forms.Label maxHPLabel1;
            System.Windows.Forms.Label nameLabel1;
            System.Windows.Forms.Label raceLabel1;
            System.Windows.Forms.Label xLabel1;
            System.Windows.Forms.Label yLabel1;
            System.Windows.Forms.Label zLabel1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tcChats = new System.Windows.Forms.TabControl();
            this.pageCharacter = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.class1TextBox1 = new System.Windows.Forms.TextBox();
            this.bsTarget = new System.Windows.Forms.BindingSource(this.components);
            this.class2TextBox1 = new System.Windows.Forms.TextBox();
            this.hPTextBox1 = new System.Windows.Forms.TextBox();
            this.idTextBox1 = new System.Windows.Forms.TextBox();
            this.maxHPTextBox1 = new System.Windows.Forms.TextBox();
            this.nameTextBox1 = new System.Windows.Forms.TextBox();
            this.raceTextBox1 = new System.Windows.Forms.TextBox();
            this.xTextBox1 = new System.Windows.Forms.TextBox();
            this.yTextBox1 = new System.Windows.Forms.TextBox();
            this.zTextBox1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblGold = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colorDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slotNoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemLinkDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.durabilityDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qualityDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingDetailsDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requiredLevelDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objectTypeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objectSubTypeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objectSubSubTypeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsEquipment = new System.Windows.Forms.BindingSource(this.components);
            this.btnRefreshInventory = new System.Windows.Forms.Button();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slotNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemLinkDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.durabilityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qualityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingDetailsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requiredLevelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objectTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objectSubTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objectSubSubTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsInventory = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMount = new System.Windows.Forms.Button();
            this.btnTeleport = new System.Windows.Forms.Button();
            this.btnPlayerUpdate = new System.Windows.Forms.Button();
            this.class1TextBox = new System.Windows.Forms.TextBox();
            this.bsPlayer = new System.Windows.Forms.BindingSource(this.components);
            this.class2TextBox = new System.Windows.Forms.TextBox();
            this.guildTextBox = new System.Windows.Forms.TextBox();
            this.hPTextBox = new System.Windows.Forms.TextBox();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.lastExpTextBox = new System.Windows.Forms.TextBox();
            this.levelTextBox = new System.Windows.Forms.TextBox();
            this.level2TextBox = new System.Windows.Forms.TextBox();
            this.maxHPTextBox = new System.Windows.Forms.TextBox();
            this.maxMPTextBox = new System.Windows.Forms.TextBox();
            this.maxMP2TextBox = new System.Windows.Forms.TextBox();
            this.mountedTextBox = new System.Windows.Forms.TextBox();
            this.mPTextBox = new System.Windows.Forms.TextBox();
            this.mP2TextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.raceTextBox = new System.Windows.Forms.TextBox();
            this.xTextBox = new System.Windows.Forms.TextBox();
            this.yTextBox = new System.Windows.Forms.TextBox();
            this.zTextBox = new System.Windows.Forms.TextBox();
            this.tpSettings = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.xbBattling = new System.Windows.Forms.CheckBox();
            this.xbFly = new System.Windows.Forms.CheckBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.gameObjectsDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInteract = new System.Windows.Forms.DataGridViewButtonColumn();
            this.gameObjectsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gameNodeBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbLFQuality = new System.Windows.Forms.ComboBox();
            this.xbLFQualityFilter = new System.Windows.Forms.CheckBox();
            this.xbACSAutoTurn = new System.Windows.Forms.CheckBox();
            this.xbACSPaused = new System.Windows.Forms.CheckBox();
            this.rbPvp = new System.Windows.Forms.RadioButton();
            this.rb2h = new System.Windows.Forms.RadioButton();
            this.rb1h = new System.Windows.Forms.RadioButton();
            this.xbACSOn = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.xbACSAutoTarget = new System.Windows.Forms.CheckBox();
            this.lbACSTargets = new System.Windows.Forms.ListBox();
            this.tsACSTargets = new System.Windows.Forms.ToolStrip();
            this.tebTargetName = new System.Windows.Forms.ToolStripTextBox();
            this.tsbACSTargetAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsACSTargetRemove = new System.Windows.Forms.ToolStripButton();
            this.tbSendTo = new System.Windows.Forms.TextBox();
            this.tbListenPort = new System.Windows.Forms.TextBox();
            this.tbCommand = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tpInquiries = new System.Windows.Forms.TabPage();
            this.btnLoadPawns = new System.Windows.Forms.Button();
            this.btnSavePawns = new System.Windows.Forms.Button();
            this.pawnDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsInquiry = new System.Windows.Forms.BindingSource(this.components);
            this.tpMap = new System.Windows.Forms.TabPage();
            this.pbMap = new System.Windows.Forms.PictureBox();
            this.tkScale = new System.Windows.Forms.TrackBar();
            this.hsbMap = new System.Windows.Forms.HScrollBar();
            this.vsbMap = new System.Windows.Forms.VScrollBar();
            this.tpFind = new System.Windows.Forms.TabPage();
            this.btnClear = new System.Windows.Forms.Button();
            this.foundObjectDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colAddObject = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colTarget = new System.Windows.Forms.DataGridViewButtonColumn();
            this.foundObjectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.zoneBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.zoneComboBox = new System.Windows.Forms.ComboBox();
            this.waypointsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.waypointsComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gameNodeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cbNearestNode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.xbComms = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.displayObjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.navigationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.auctionHouseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mailboxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.petVendorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vEndorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bankToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.housemaidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.miAddZone = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.rebuildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageNodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandSelectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrKeyPress = new System.Windows.Forms.Timer(this.components);
            this.btnHideShow = new System.Windows.Forms.Button();
            this.cbSendKeys = new System.Windows.Forms.CheckBox();
            this.modelLoaderThread = new System.ComponentModel.BackgroundWorker();
            this.pbModelProgress = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.btnSetCommsOn = new System.Windows.Forms.Button();
            class1Label = new System.Windows.Forms.Label();
            class2Label = new System.Windows.Forms.Label();
            guildLabel = new System.Windows.Forms.Label();
            hPLabel = new System.Windows.Forms.Label();
            idLabel = new System.Windows.Forms.Label();
            lastExpLabel = new System.Windows.Forms.Label();
            levelLabel = new System.Windows.Forms.Label();
            level2Label = new System.Windows.Forms.Label();
            maxHPLabel = new System.Windows.Forms.Label();
            maxMPLabel = new System.Windows.Forms.Label();
            maxMP2Label = new System.Windows.Forms.Label();
            mountedLabel = new System.Windows.Forms.Label();
            mPLabel = new System.Windows.Forms.Label();
            mP2Label = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            raceLabel = new System.Windows.Forms.Label();
            xLabel = new System.Windows.Forms.Label();
            yLabel = new System.Windows.Forms.Label();
            zLabel = new System.Windows.Forms.Label();
            class1Label1 = new System.Windows.Forms.Label();
            class2Label1 = new System.Windows.Forms.Label();
            hPLabel1 = new System.Windows.Forms.Label();
            idLabel1 = new System.Windows.Forms.Label();
            maxHPLabel1 = new System.Windows.Forms.Label();
            nameLabel1 = new System.Windows.Forms.Label();
            raceLabel1 = new System.Windows.Forms.Label();
            xLabel1 = new System.Windows.Forms.Label();
            yLabel1 = new System.Windows.Forms.Label();
            zLabel1 = new System.Windows.Forms.Label();
            this.tcChats.SuspendLayout();
            this.pageCharacter.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsTarget)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEquipment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsInventory)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsPlayer)).BeginInit();
            this.tpSettings.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameObjectsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameObjectsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameNodeBindingSource1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tsACSTargets.SuspendLayout();
            this.tpInquiries.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pawnDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsInquiry)).BeginInit();
            this.tpMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkScale)).BeginInit();
            this.tpFind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.foundObjectDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.foundObjectBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoneBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waypointsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameNodeBindingSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // class1Label
            // 
            class1Label.AutoSize = true;
            class1Label.Location = new System.Drawing.Point(5, 47);
            class1Label.Name = "class1Label";
            class1Label.Size = new System.Drawing.Size(41, 13);
            class1Label.TabIndex = 0;
            class1Label.Text = "Class1:";
            // 
            // class2Label
            // 
            class2Label.AutoSize = true;
            class2Label.Location = new System.Drawing.Point(170, 47);
            class2Label.Name = "class2Label";
            class2Label.Size = new System.Drawing.Size(41, 13);
            class2Label.TabIndex = 2;
            class2Label.Text = "Class2:";
            // 
            // guildLabel
            // 
            guildLabel.AutoSize = true;
            guildLabel.Location = new System.Drawing.Point(335, 25);
            guildLabel.Name = "guildLabel";
            guildLabel.Size = new System.Drawing.Size(34, 13);
            guildLabel.TabIndex = 4;
            guildLabel.Text = "Guild:";
            // 
            // hPLabel
            // 
            hPLabel.AutoSize = true;
            hPLabel.Location = new System.Drawing.Point(5, 92);
            hPLabel.Name = "hPLabel";
            hPLabel.Size = new System.Drawing.Size(25, 13);
            hPLabel.TabIndex = 6;
            hPLabel.Text = "HP:";
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new System.Drawing.Point(5, 25);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(19, 13);
            idLabel.TabIndex = 8;
            idLabel.Text = "Id:";
            // 
            // lastExpLabel
            // 
            lastExpLabel.AutoSize = true;
            lastExpLabel.Location = new System.Drawing.Point(335, 69);
            lastExpLabel.Name = "lastExpLabel";
            lastExpLabel.Size = new System.Drawing.Size(51, 13);
            lastExpLabel.TabIndex = 10;
            lastExpLabel.Text = "Last Exp:";
            // 
            // levelLabel
            // 
            levelLabel.AutoSize = true;
            levelLabel.Location = new System.Drawing.Point(5, 69);
            levelLabel.Name = "levelLabel";
            levelLabel.Size = new System.Drawing.Size(36, 13);
            levelLabel.TabIndex = 12;
            levelLabel.Text = "Level:";
            // 
            // level2Label
            // 
            level2Label.AutoSize = true;
            level2Label.Location = new System.Drawing.Point(170, 69);
            level2Label.Name = "level2Label";
            level2Label.Size = new System.Drawing.Size(42, 13);
            level2Label.TabIndex = 14;
            level2Label.Text = "Level2:";
            // 
            // maxHPLabel
            // 
            maxHPLabel.AutoSize = true;
            maxHPLabel.Location = new System.Drawing.Point(170, 92);
            maxHPLabel.Name = "maxHPLabel";
            maxHPLabel.Size = new System.Drawing.Size(48, 13);
            maxHPLabel.TabIndex = 16;
            maxHPLabel.Text = "Max HP:";
            // 
            // maxMPLabel
            // 
            maxMPLabel.AutoSize = true;
            maxMPLabel.Location = new System.Drawing.Point(170, 114);
            maxMPLabel.Name = "maxMPLabel";
            maxMPLabel.Size = new System.Drawing.Size(49, 13);
            maxMPLabel.TabIndex = 18;
            maxMPLabel.Text = "Max MP:";
            // 
            // maxMP2Label
            // 
            maxMP2Label.AutoSize = true;
            maxMP2Label.Location = new System.Drawing.Point(170, 136);
            maxMP2Label.Name = "maxMP2Label";
            maxMP2Label.Size = new System.Drawing.Size(55, 13);
            maxMP2Label.TabIndex = 20;
            maxMP2Label.Text = "Max MP2:";
            // 
            // mountedLabel
            // 
            mountedLabel.AutoSize = true;
            mountedLabel.Location = new System.Drawing.Point(335, 117);
            mountedLabel.Name = "mountedLabel";
            mountedLabel.Size = new System.Drawing.Size(52, 13);
            mountedLabel.TabIndex = 22;
            mountedLabel.Text = "Mounted:";
            // 
            // mPLabel
            // 
            mPLabel.AutoSize = true;
            mPLabel.Location = new System.Drawing.Point(5, 114);
            mPLabel.Name = "mPLabel";
            mPLabel.Size = new System.Drawing.Size(26, 13);
            mPLabel.TabIndex = 24;
            mPLabel.Text = "MP:";
            // 
            // mP2Label
            // 
            mP2Label.AutoSize = true;
            mP2Label.Location = new System.Drawing.Point(5, 136);
            mP2Label.Name = "mP2Label";
            mP2Label.Size = new System.Drawing.Size(32, 13);
            mP2Label.TabIndex = 26;
            mP2Label.Text = "MP2:";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(170, 25);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(38, 13);
            nameLabel.TabIndex = 28;
            nameLabel.Text = "Name:";
            // 
            // raceLabel
            // 
            raceLabel.AutoSize = true;
            raceLabel.Location = new System.Drawing.Point(335, 47);
            raceLabel.Name = "raceLabel";
            raceLabel.Size = new System.Drawing.Size(36, 13);
            raceLabel.TabIndex = 30;
            raceLabel.Text = "Race:";
            // 
            // xLabel
            // 
            xLabel.AutoSize = true;
            xLabel.Location = new System.Drawing.Point(508, 25);
            xLabel.Name = "xLabel";
            xLabel.Size = new System.Drawing.Size(17, 13);
            xLabel.TabIndex = 32;
            xLabel.Text = "X:";
            // 
            // yLabel
            // 
            yLabel.AutoSize = true;
            yLabel.Location = new System.Drawing.Point(508, 47);
            yLabel.Name = "yLabel";
            yLabel.Size = new System.Drawing.Size(17, 13);
            yLabel.TabIndex = 34;
            yLabel.Text = "Y:";
            // 
            // zLabel
            // 
            zLabel.AutoSize = true;
            zLabel.Location = new System.Drawing.Point(508, 69);
            zLabel.Name = "zLabel";
            zLabel.Size = new System.Drawing.Size(17, 13);
            zLabel.TabIndex = 36;
            zLabel.Text = "Z:";
            // 
            // class1Label1
            // 
            class1Label1.AutoSize = true;
            class1Label1.Location = new System.Drawing.Point(13, 70);
            class1Label1.Name = "class1Label1";
            class1Label1.Size = new System.Drawing.Size(41, 13);
            class1Label1.TabIndex = 0;
            class1Label1.Text = "Class1:";
            // 
            // class2Label1
            // 
            class2Label1.AutoSize = true;
            class2Label1.Location = new System.Drawing.Point(13, 92);
            class2Label1.Name = "class2Label1";
            class2Label1.Size = new System.Drawing.Size(41, 13);
            class2Label1.TabIndex = 2;
            class2Label1.Text = "Class2:";
            // 
            // hPLabel1
            // 
            hPLabel1.AutoSize = true;
            hPLabel1.Location = new System.Drawing.Point(13, 47);
            hPLabel1.Name = "hPLabel1";
            hPLabel1.Size = new System.Drawing.Size(25, 13);
            hPLabel1.TabIndex = 6;
            hPLabel1.Text = "HP:";
            // 
            // idLabel1
            // 
            idLabel1.AutoSize = true;
            idLabel1.Location = new System.Drawing.Point(13, 25);
            idLabel1.Name = "idLabel1";
            idLabel1.Size = new System.Drawing.Size(19, 13);
            idLabel1.TabIndex = 8;
            idLabel1.Text = "Id:";
            // 
            // maxHPLabel1
            // 
            maxHPLabel1.AutoSize = true;
            maxHPLabel1.Location = new System.Drawing.Point(189, 47);
            maxHPLabel1.Name = "maxHPLabel1";
            maxHPLabel1.Size = new System.Drawing.Size(48, 13);
            maxHPLabel1.TabIndex = 16;
            maxHPLabel1.Text = "Max HP:";
            // 
            // nameLabel1
            // 
            nameLabel1.AutoSize = true;
            nameLabel1.Location = new System.Drawing.Point(189, 25);
            nameLabel1.Name = "nameLabel1";
            nameLabel1.Size = new System.Drawing.Size(38, 13);
            nameLabel1.TabIndex = 28;
            nameLabel1.Text = "Name:";
            // 
            // raceLabel1
            // 
            raceLabel1.AutoSize = true;
            raceLabel1.Location = new System.Drawing.Point(189, 70);
            raceLabel1.Name = "raceLabel1";
            raceLabel1.Size = new System.Drawing.Size(36, 13);
            raceLabel1.TabIndex = 30;
            raceLabel1.Text = "Race:";
            // 
            // xLabel1
            // 
            xLabel1.AutoSize = true;
            xLabel1.Location = new System.Drawing.Point(13, 114);
            xLabel1.Name = "xLabel1";
            xLabel1.Size = new System.Drawing.Size(17, 13);
            xLabel1.TabIndex = 32;
            xLabel1.Text = "X:";
            // 
            // yLabel1
            // 
            yLabel1.AutoSize = true;
            yLabel1.Location = new System.Drawing.Point(189, 92);
            yLabel1.Name = "yLabel1";
            yLabel1.Size = new System.Drawing.Size(17, 13);
            yLabel1.TabIndex = 34;
            yLabel1.Text = "Y:";
            // 
            // zLabel1
            // 
            zLabel1.AutoSize = true;
            zLabel1.Location = new System.Drawing.Point(189, 114);
            zLabel1.Name = "zLabel1";
            zLabel1.Size = new System.Drawing.Size(17, 13);
            zLabel1.TabIndex = 36;
            zLabel1.Text = "Z:";
            // 
            // tcChats
            // 
            this.tcChats.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tcChats.Controls.Add(this.pageCharacter);
            this.tcChats.Controls.Add(this.tpSettings);
            this.tcChats.Controls.Add(this.tpInquiries);
            this.tcChats.Controls.Add(this.tpMap);
            this.tcChats.Controls.Add(this.tpFind);
            this.tcChats.Location = new System.Drawing.Point(14, 57);
            this.tcChats.Name = "tcChats";
            this.tcChats.SelectedIndex = 0;
            this.tcChats.Size = new System.Drawing.Size(1109, 687);
            this.tcChats.TabIndex = 1;
            this.tcChats.Selected += new System.Windows.Forms.TabControlEventHandler(this.tcChats_Selected);
            // 
            // pageCharacter
            // 
            this.pageCharacter.AutoScroll = true;
            this.pageCharacter.Controls.Add(this.groupBox3);
            this.pageCharacter.Controls.Add(this.groupBox2);
            this.pageCharacter.Controls.Add(this.groupBox1);
            this.pageCharacter.Location = new System.Drawing.Point(4, 22);
            this.pageCharacter.Name = "pageCharacter";
            this.pageCharacter.Padding = new System.Windows.Forms.Padding(3);
            this.pageCharacter.Size = new System.Drawing.Size(1101, 661);
            this.pageCharacter.TabIndex = 0;
            this.pageCharacter.Text = "Character";
            this.pageCharacter.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(class1Label1);
            this.groupBox3.Controls.Add(this.class1TextBox1);
            this.groupBox3.Controls.Add(class2Label1);
            this.groupBox3.Controls.Add(this.class2TextBox1);
            this.groupBox3.Controls.Add(hPLabel1);
            this.groupBox3.Controls.Add(this.hPTextBox1);
            this.groupBox3.Controls.Add(idLabel1);
            this.groupBox3.Controls.Add(this.idTextBox1);
            this.groupBox3.Controls.Add(maxHPLabel1);
            this.groupBox3.Controls.Add(this.maxHPTextBox1);
            this.groupBox3.Controls.Add(nameLabel1);
            this.groupBox3.Controls.Add(this.nameTextBox1);
            this.groupBox3.Controls.Add(raceLabel1);
            this.groupBox3.Controls.Add(this.raceTextBox1);
            this.groupBox3.Controls.Add(xLabel1);
            this.groupBox3.Controls.Add(this.xTextBox1);
            this.groupBox3.Controls.Add(yLabel1);
            this.groupBox3.Controls.Add(this.yTextBox1);
            this.groupBox3.Controls.Add(zLabel1);
            this.groupBox3.Controls.Add(this.zTextBox1);
            this.groupBox3.Location = new System.Drawing.Point(731, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(364, 166);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Target";
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(275, 134);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 38;
            this.button3.Text = "Refresh";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // class1TextBox1
            // 
            this.class1TextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTarget, "Class1", true));
            this.class1TextBox1.Location = new System.Drawing.Point(74, 67);
            this.class1TextBox1.Name = "class1TextBox1";
            this.class1TextBox1.Size = new System.Drawing.Size(100, 20);
            this.class1TextBox1.TabIndex = 1;
            // 
            // bsTarget
            // 
            this.bsTarget.DataSource = typeof(RomViewer.Domain.Pawn);
            // 
            // class2TextBox1
            // 
            this.class2TextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTarget, "Class2", true));
            this.class2TextBox1.Location = new System.Drawing.Point(74, 89);
            this.class2TextBox1.Name = "class2TextBox1";
            this.class2TextBox1.Size = new System.Drawing.Size(100, 20);
            this.class2TextBox1.TabIndex = 3;
            // 
            // hPTextBox1
            // 
            this.hPTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTarget, "HP", true));
            this.hPTextBox1.Location = new System.Drawing.Point(74, 44);
            this.hPTextBox1.Name = "hPTextBox1";
            this.hPTextBox1.Size = new System.Drawing.Size(100, 20);
            this.hPTextBox1.TabIndex = 7;
            // 
            // idTextBox1
            // 
            this.idTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTarget, "Id", true));
            this.idTextBox1.Location = new System.Drawing.Point(74, 22);
            this.idTextBox1.Name = "idTextBox1";
            this.idTextBox1.Size = new System.Drawing.Size(100, 20);
            this.idTextBox1.TabIndex = 9;
            // 
            // maxHPTextBox1
            // 
            this.maxHPTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTarget, "MaxHP", true));
            this.maxHPTextBox1.Location = new System.Drawing.Point(250, 44);
            this.maxHPTextBox1.Name = "maxHPTextBox1";
            this.maxHPTextBox1.Size = new System.Drawing.Size(100, 20);
            this.maxHPTextBox1.TabIndex = 17;
            // 
            // nameTextBox1
            // 
            this.nameTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTarget, "Name", true));
            this.nameTextBox1.Location = new System.Drawing.Point(250, 22);
            this.nameTextBox1.Name = "nameTextBox1";
            this.nameTextBox1.Size = new System.Drawing.Size(100, 20);
            this.nameTextBox1.TabIndex = 29;
            // 
            // raceTextBox1
            // 
            this.raceTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTarget, "Race", true));
            this.raceTextBox1.Location = new System.Drawing.Point(250, 67);
            this.raceTextBox1.Name = "raceTextBox1";
            this.raceTextBox1.Size = new System.Drawing.Size(100, 20);
            this.raceTextBox1.TabIndex = 31;
            // 
            // xTextBox1
            // 
            this.xTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTarget, "X", true));
            this.xTextBox1.Location = new System.Drawing.Point(74, 111);
            this.xTextBox1.Name = "xTextBox1";
            this.xTextBox1.Size = new System.Drawing.Size(100, 20);
            this.xTextBox1.TabIndex = 33;
            // 
            // yTextBox1
            // 
            this.yTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTarget, "Y", true));
            this.yTextBox1.Location = new System.Drawing.Point(250, 89);
            this.yTextBox1.Name = "yTextBox1";
            this.yTextBox1.Size = new System.Drawing.Size(100, 20);
            this.yTextBox1.TabIndex = 35;
            // 
            // zTextBox1
            // 
            this.zTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsTarget, "Z", true));
            this.zTextBox1.Location = new System.Drawing.Point(250, 111);
            this.zTextBox1.Name = "zTextBox1";
            this.zTextBox1.Size = new System.Drawing.Size(100, 20);
            this.zTextBox1.TabIndex = 37;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblGold);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.btnRefreshInventory);
            this.groupBox2.Controls.Add(this.dgvInventory);
            this.groupBox2.Location = new System.Drawing.Point(6, 178);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1089, 459);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Inventory";
            // 
            // lblGold
            // 
            this.lblGold.AutoSize = true;
            this.lblGold.Location = new System.Drawing.Point(93, 21);
            this.lblGold.Name = "lblGold";
            this.lblGold.Size = new System.Drawing.Size(36, 13);
            this.lblGold.TabIndex = 3;
            this.lblGold.Text = "0 gold";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn1,
            this.countDataGridViewTextBoxColumn1,
            this.colorDataGridViewTextBoxColumn1,
            this.slotNoDataGridViewTextBoxColumn1,
            this.itemLinkDataGridViewTextBoxColumn1,
            this.durabilityDataGridViewTextBoxColumn1,
            this.qualityDataGridViewTextBoxColumn1,
            this.bindingDetailsDataGridViewTextBoxColumn1,
            this.requiredLevelDataGridViewTextBoxColumn1,
            this.objectTypeDataGridViewTextBoxColumn1,
            this.objectSubTypeDataGridViewTextBoxColumn1,
            this.objectSubSubTypeDataGridViewTextBoxColumn1});
            this.dataGridView1.DataSource = this.bsEquipment;
            this.dataGridView1.Location = new System.Drawing.Point(-3, 44);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1083, 181);
            this.dataGridView1.TabIndex = 2;
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            this.nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn1.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            this.nameDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // countDataGridViewTextBoxColumn1
            // 
            this.countDataGridViewTextBoxColumn1.DataPropertyName = "Count";
            this.countDataGridViewTextBoxColumn1.HeaderText = "Count";
            this.countDataGridViewTextBoxColumn1.Name = "countDataGridViewTextBoxColumn1";
            this.countDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // colorDataGridViewTextBoxColumn1
            // 
            this.colorDataGridViewTextBoxColumn1.DataPropertyName = "Color";
            this.colorDataGridViewTextBoxColumn1.HeaderText = "Color";
            this.colorDataGridViewTextBoxColumn1.Name = "colorDataGridViewTextBoxColumn1";
            this.colorDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // slotNoDataGridViewTextBoxColumn1
            // 
            this.slotNoDataGridViewTextBoxColumn1.DataPropertyName = "SlotNo";
            this.slotNoDataGridViewTextBoxColumn1.HeaderText = "SlotNo";
            this.slotNoDataGridViewTextBoxColumn1.Name = "slotNoDataGridViewTextBoxColumn1";
            this.slotNoDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // itemLinkDataGridViewTextBoxColumn1
            // 
            this.itemLinkDataGridViewTextBoxColumn1.DataPropertyName = "ItemLink";
            this.itemLinkDataGridViewTextBoxColumn1.HeaderText = "ItemLink";
            this.itemLinkDataGridViewTextBoxColumn1.Name = "itemLinkDataGridViewTextBoxColumn1";
            this.itemLinkDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // durabilityDataGridViewTextBoxColumn1
            // 
            this.durabilityDataGridViewTextBoxColumn1.DataPropertyName = "Durability";
            this.durabilityDataGridViewTextBoxColumn1.HeaderText = "Durability";
            this.durabilityDataGridViewTextBoxColumn1.Name = "durabilityDataGridViewTextBoxColumn1";
            this.durabilityDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // qualityDataGridViewTextBoxColumn1
            // 
            this.qualityDataGridViewTextBoxColumn1.DataPropertyName = "Quality";
            this.qualityDataGridViewTextBoxColumn1.HeaderText = "Quality";
            this.qualityDataGridViewTextBoxColumn1.Name = "qualityDataGridViewTextBoxColumn1";
            this.qualityDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // bindingDetailsDataGridViewTextBoxColumn1
            // 
            this.bindingDetailsDataGridViewTextBoxColumn1.DataPropertyName = "BindingDetails";
            this.bindingDetailsDataGridViewTextBoxColumn1.HeaderText = "BindingDetails";
            this.bindingDetailsDataGridViewTextBoxColumn1.Name = "bindingDetailsDataGridViewTextBoxColumn1";
            this.bindingDetailsDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // requiredLevelDataGridViewTextBoxColumn1
            // 
            this.requiredLevelDataGridViewTextBoxColumn1.DataPropertyName = "RequiredLevel";
            this.requiredLevelDataGridViewTextBoxColumn1.HeaderText = "RequiredLevel";
            this.requiredLevelDataGridViewTextBoxColumn1.Name = "requiredLevelDataGridViewTextBoxColumn1";
            this.requiredLevelDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // objectTypeDataGridViewTextBoxColumn1
            // 
            this.objectTypeDataGridViewTextBoxColumn1.DataPropertyName = "ObjectType";
            this.objectTypeDataGridViewTextBoxColumn1.HeaderText = "ObjectType";
            this.objectTypeDataGridViewTextBoxColumn1.Name = "objectTypeDataGridViewTextBoxColumn1";
            this.objectTypeDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // objectSubTypeDataGridViewTextBoxColumn1
            // 
            this.objectSubTypeDataGridViewTextBoxColumn1.DataPropertyName = "ObjectSubType";
            this.objectSubTypeDataGridViewTextBoxColumn1.HeaderText = "ObjectSubType";
            this.objectSubTypeDataGridViewTextBoxColumn1.Name = "objectSubTypeDataGridViewTextBoxColumn1";
            this.objectSubTypeDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // objectSubSubTypeDataGridViewTextBoxColumn1
            // 
            this.objectSubSubTypeDataGridViewTextBoxColumn1.DataPropertyName = "ObjectSubSubType";
            this.objectSubSubTypeDataGridViewTextBoxColumn1.HeaderText = "ObjectSubSubType";
            this.objectSubSubTypeDataGridViewTextBoxColumn1.Name = "objectSubSubTypeDataGridViewTextBoxColumn1";
            this.objectSubSubTypeDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // bsEquipment
            // 
            this.bsEquipment.AllowNew = false;
            this.bsEquipment.DataSource = typeof(RomViewer.Domain.Item);
            // 
            // btnRefreshInventory
            // 
            this.btnRefreshInventory.Location = new System.Drawing.Point(6, 15);
            this.btnRefreshInventory.Name = "btnRefreshInventory";
            this.btnRefreshInventory.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshInventory.TabIndex = 1;
            this.btnRefreshInventory.Text = "Refresh";
            this.btnRefreshInventory.UseVisualStyleBackColor = true;
            this.btnRefreshInventory.Click += new System.EventHandler(this.btnRefreshInventory_Click);
            // 
            // dgvInventory
            // 
            this.dgvInventory.AllowUserToAddRows = false;
            this.dgvInventory.AllowUserToDeleteRows = false;
            this.dgvInventory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInventory.AutoGenerateColumns = false;
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.countDataGridViewTextBoxColumn,
            this.colorDataGridViewTextBoxColumn,
            this.slotNoDataGridViewTextBoxColumn,
            this.itemLinkDataGridViewTextBoxColumn,
            this.durabilityDataGridViewTextBoxColumn,
            this.qualityDataGridViewTextBoxColumn,
            this.bindingDetailsDataGridViewTextBoxColumn,
            this.requiredLevelDataGridViewTextBoxColumn,
            this.objectTypeDataGridViewTextBoxColumn,
            this.objectSubTypeDataGridViewTextBoxColumn,
            this.objectSubSubTypeDataGridViewTextBoxColumn});
            this.dgvInventory.DataSource = this.bsInventory;
            this.dgvInventory.Location = new System.Drawing.Point(0, 231);
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.ReadOnly = true;
            this.dgvInventory.RowHeadersVisible = false;
            this.dgvInventory.Size = new System.Drawing.Size(1083, 249);
            this.dgvInventory.TabIndex = 0;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // countDataGridViewTextBoxColumn
            // 
            this.countDataGridViewTextBoxColumn.DataPropertyName = "Count";
            this.countDataGridViewTextBoxColumn.HeaderText = "Count";
            this.countDataGridViewTextBoxColumn.Name = "countDataGridViewTextBoxColumn";
            this.countDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // colorDataGridViewTextBoxColumn
            // 
            this.colorDataGridViewTextBoxColumn.DataPropertyName = "Color";
            this.colorDataGridViewTextBoxColumn.HeaderText = "Color";
            this.colorDataGridViewTextBoxColumn.Name = "colorDataGridViewTextBoxColumn";
            this.colorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // slotNoDataGridViewTextBoxColumn
            // 
            this.slotNoDataGridViewTextBoxColumn.DataPropertyName = "SlotNo";
            this.slotNoDataGridViewTextBoxColumn.HeaderText = "SlotNo";
            this.slotNoDataGridViewTextBoxColumn.Name = "slotNoDataGridViewTextBoxColumn";
            this.slotNoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // itemLinkDataGridViewTextBoxColumn
            // 
            this.itemLinkDataGridViewTextBoxColumn.DataPropertyName = "ItemLink";
            this.itemLinkDataGridViewTextBoxColumn.HeaderText = "ItemLink";
            this.itemLinkDataGridViewTextBoxColumn.Name = "itemLinkDataGridViewTextBoxColumn";
            this.itemLinkDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // durabilityDataGridViewTextBoxColumn
            // 
            this.durabilityDataGridViewTextBoxColumn.DataPropertyName = "Durability";
            this.durabilityDataGridViewTextBoxColumn.HeaderText = "Durability";
            this.durabilityDataGridViewTextBoxColumn.Name = "durabilityDataGridViewTextBoxColumn";
            this.durabilityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qualityDataGridViewTextBoxColumn
            // 
            this.qualityDataGridViewTextBoxColumn.DataPropertyName = "Quality";
            this.qualityDataGridViewTextBoxColumn.HeaderText = "Quality";
            this.qualityDataGridViewTextBoxColumn.Name = "qualityDataGridViewTextBoxColumn";
            this.qualityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bindingDetailsDataGridViewTextBoxColumn
            // 
            this.bindingDetailsDataGridViewTextBoxColumn.DataPropertyName = "BindingDetails";
            this.bindingDetailsDataGridViewTextBoxColumn.HeaderText = "BindingDetails";
            this.bindingDetailsDataGridViewTextBoxColumn.Name = "bindingDetailsDataGridViewTextBoxColumn";
            this.bindingDetailsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // requiredLevelDataGridViewTextBoxColumn
            // 
            this.requiredLevelDataGridViewTextBoxColumn.DataPropertyName = "RequiredLevel";
            this.requiredLevelDataGridViewTextBoxColumn.HeaderText = "RequiredLevel";
            this.requiredLevelDataGridViewTextBoxColumn.Name = "requiredLevelDataGridViewTextBoxColumn";
            this.requiredLevelDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // objectTypeDataGridViewTextBoxColumn
            // 
            this.objectTypeDataGridViewTextBoxColumn.DataPropertyName = "ObjectType";
            this.objectTypeDataGridViewTextBoxColumn.HeaderText = "ObjectType";
            this.objectTypeDataGridViewTextBoxColumn.Name = "objectTypeDataGridViewTextBoxColumn";
            this.objectTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // objectSubTypeDataGridViewTextBoxColumn
            // 
            this.objectSubTypeDataGridViewTextBoxColumn.DataPropertyName = "ObjectSubType";
            this.objectSubTypeDataGridViewTextBoxColumn.HeaderText = "ObjectSubType";
            this.objectSubTypeDataGridViewTextBoxColumn.Name = "objectSubTypeDataGridViewTextBoxColumn";
            this.objectSubTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // objectSubSubTypeDataGridViewTextBoxColumn
            // 
            this.objectSubSubTypeDataGridViewTextBoxColumn.DataPropertyName = "ObjectSubSubType";
            this.objectSubSubTypeDataGridViewTextBoxColumn.HeaderText = "ObjectSubSubType";
            this.objectSubSubTypeDataGridViewTextBoxColumn.Name = "objectSubSubTypeDataGridViewTextBoxColumn";
            this.objectSubSubTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bsInventory
            // 
            this.bsInventory.DataSource = typeof(RomViewer.Domain.Item);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnMount);
            this.groupBox1.Controls.Add(this.btnTeleport);
            this.groupBox1.Controls.Add(this.btnPlayerUpdate);
            this.groupBox1.Controls.Add(class1Label);
            this.groupBox1.Controls.Add(this.class1TextBox);
            this.groupBox1.Controls.Add(class2Label);
            this.groupBox1.Controls.Add(this.class2TextBox);
            this.groupBox1.Controls.Add(guildLabel);
            this.groupBox1.Controls.Add(this.guildTextBox);
            this.groupBox1.Controls.Add(hPLabel);
            this.groupBox1.Controls.Add(this.hPTextBox);
            this.groupBox1.Controls.Add(idLabel);
            this.groupBox1.Controls.Add(this.idTextBox);
            this.groupBox1.Controls.Add(lastExpLabel);
            this.groupBox1.Controls.Add(this.lastExpTextBox);
            this.groupBox1.Controls.Add(levelLabel);
            this.groupBox1.Controls.Add(this.levelTextBox);
            this.groupBox1.Controls.Add(level2Label);
            this.groupBox1.Controls.Add(this.level2TextBox);
            this.groupBox1.Controls.Add(maxHPLabel);
            this.groupBox1.Controls.Add(this.maxHPTextBox);
            this.groupBox1.Controls.Add(maxMPLabel);
            this.groupBox1.Controls.Add(this.maxMPTextBox);
            this.groupBox1.Controls.Add(maxMP2Label);
            this.groupBox1.Controls.Add(this.maxMP2TextBox);
            this.groupBox1.Controls.Add(mountedLabel);
            this.groupBox1.Controls.Add(this.mountedTextBox);
            this.groupBox1.Controls.Add(mPLabel);
            this.groupBox1.Controls.Add(this.mPTextBox);
            this.groupBox1.Controls.Add(mP2Label);
            this.groupBox1.Controls.Add(this.mP2TextBox);
            this.groupBox1.Controls.Add(nameLabel);
            this.groupBox1.Controls.Add(this.nameTextBox);
            this.groupBox1.Controls.Add(raceLabel);
            this.groupBox1.Controls.Add(this.raceTextBox);
            this.groupBox1.Controls.Add(xLabel);
            this.groupBox1.Controls.Add(this.xTextBox);
            this.groupBox1.Controls.Add(yLabel);
            this.groupBox1.Controls.Add(this.yTextBox);
            this.groupBox1.Controls.Add(zLabel);
            this.groupBox1.Controls.Add(this.zTextBox);
            this.groupBox1.Location = new System.Drawing.Point(9, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(716, 166);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Player";
            // 
            // btnMount
            // 
            this.btnMount.Location = new System.Drawing.Point(502, 112);
            this.btnMount.Name = "btnMount";
            this.btnMount.Size = new System.Drawing.Size(48, 23);
            this.btnMount.TabIndex = 40;
            this.btnMount.Text = "Mount";
            this.btnMount.UseVisualStyleBackColor = true;
            this.btnMount.Click += new System.EventHandler(this.btnMount_Click);
            // 
            // btnTeleport
            // 
            this.btnTeleport.Location = new System.Drawing.Point(638, 20);
            this.btnTeleport.Name = "btnTeleport";
            this.btnTeleport.Size = new System.Drawing.Size(72, 23);
            this.btnTeleport.TabIndex = 39;
            this.btnTeleport.Text = "Teleport";
            this.btnTeleport.UseVisualStyleBackColor = true;
            this.btnTeleport.Click += new System.EventHandler(this.btnTeleport_Click);
            // 
            // btnPlayerUpdate
            // 
            this.btnPlayerUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlayerUpdate.Location = new System.Drawing.Point(635, 134);
            this.btnPlayerUpdate.Name = "btnPlayerUpdate";
            this.btnPlayerUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnPlayerUpdate.TabIndex = 38;
            this.btnPlayerUpdate.Text = "Update";
            this.btnPlayerUpdate.UseVisualStyleBackColor = true;
            this.btnPlayerUpdate.Click += new System.EventHandler(this.btnPlayerUpdate_Click);
            // 
            // class1TextBox
            // 
            this.class1TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPlayer, "Class1", true));
            this.class1TextBox.Location = new System.Drawing.Point(66, 44);
            this.class1TextBox.Name = "class1TextBox";
            this.class1TextBox.Size = new System.Drawing.Size(100, 20);
            this.class1TextBox.TabIndex = 1;
            // 
            // bsPlayer
            // 
            this.bsPlayer.DataSource = typeof(RomViewer.Domain.Player);
            // 
            // class2TextBox
            // 
            this.class2TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPlayer, "Class2", true));
            this.class2TextBox.Location = new System.Drawing.Point(231, 44);
            this.class2TextBox.Name = "class2TextBox";
            this.class2TextBox.Size = new System.Drawing.Size(100, 20);
            this.class2TextBox.TabIndex = 3;
            // 
            // guildTextBox
            // 
            this.guildTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPlayer, "Guild", true));
            this.guildTextBox.Location = new System.Drawing.Point(396, 22);
            this.guildTextBox.Name = "guildTextBox";
            this.guildTextBox.Size = new System.Drawing.Size(100, 20);
            this.guildTextBox.TabIndex = 5;
            // 
            // hPTextBox
            // 
            this.hPTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPlayer, "HP", true));
            this.hPTextBox.Location = new System.Drawing.Point(66, 89);
            this.hPTextBox.Name = "hPTextBox";
            this.hPTextBox.Size = new System.Drawing.Size(100, 20);
            this.hPTextBox.TabIndex = 7;
            // 
            // idTextBox
            // 
            this.idTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPlayer, "Id", true));
            this.idTextBox.Location = new System.Drawing.Point(66, 22);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(100, 20);
            this.idTextBox.TabIndex = 9;
            // 
            // lastExpTextBox
            // 
            this.lastExpTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPlayer, "LastExp", true));
            this.lastExpTextBox.Location = new System.Drawing.Point(396, 66);
            this.lastExpTextBox.Name = "lastExpTextBox";
            this.lastExpTextBox.Size = new System.Drawing.Size(100, 20);
            this.lastExpTextBox.TabIndex = 11;
            // 
            // levelTextBox
            // 
            this.levelTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPlayer, "Level", true));
            this.levelTextBox.Location = new System.Drawing.Point(66, 66);
            this.levelTextBox.Name = "levelTextBox";
            this.levelTextBox.Size = new System.Drawing.Size(100, 20);
            this.levelTextBox.TabIndex = 13;
            // 
            // level2TextBox
            // 
            this.level2TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPlayer, "Level2", true));
            this.level2TextBox.Location = new System.Drawing.Point(231, 66);
            this.level2TextBox.Name = "level2TextBox";
            this.level2TextBox.Size = new System.Drawing.Size(100, 20);
            this.level2TextBox.TabIndex = 15;
            // 
            // maxHPTextBox
            // 
            this.maxHPTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPlayer, "MaxHP", true));
            this.maxHPTextBox.Location = new System.Drawing.Point(231, 89);
            this.maxHPTextBox.Name = "maxHPTextBox";
            this.maxHPTextBox.Size = new System.Drawing.Size(100, 20);
            this.maxHPTextBox.TabIndex = 17;
            // 
            // maxMPTextBox
            // 
            this.maxMPTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPlayer, "MaxMP", true));
            this.maxMPTextBox.Location = new System.Drawing.Point(231, 111);
            this.maxMPTextBox.Name = "maxMPTextBox";
            this.maxMPTextBox.Size = new System.Drawing.Size(100, 20);
            this.maxMPTextBox.TabIndex = 19;
            // 
            // maxMP2TextBox
            // 
            this.maxMP2TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPlayer, "MaxMP2", true));
            this.maxMP2TextBox.Location = new System.Drawing.Point(231, 133);
            this.maxMP2TextBox.Name = "maxMP2TextBox";
            this.maxMP2TextBox.Size = new System.Drawing.Size(100, 20);
            this.maxMP2TextBox.TabIndex = 21;
            // 
            // mountedTextBox
            // 
            this.mountedTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPlayer, "Mounted", true));
            this.mountedTextBox.Location = new System.Drawing.Point(396, 114);
            this.mountedTextBox.Name = "mountedTextBox";
            this.mountedTextBox.Size = new System.Drawing.Size(100, 20);
            this.mountedTextBox.TabIndex = 23;
            // 
            // mPTextBox
            // 
            this.mPTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPlayer, "MP", true));
            this.mPTextBox.Location = new System.Drawing.Point(66, 111);
            this.mPTextBox.Name = "mPTextBox";
            this.mPTextBox.Size = new System.Drawing.Size(100, 20);
            this.mPTextBox.TabIndex = 25;
            // 
            // mP2TextBox
            // 
            this.mP2TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPlayer, "MP2", true));
            this.mP2TextBox.Location = new System.Drawing.Point(66, 133);
            this.mP2TextBox.Name = "mP2TextBox";
            this.mP2TextBox.Size = new System.Drawing.Size(100, 20);
            this.mP2TextBox.TabIndex = 27;
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPlayer, "Name", true));
            this.nameTextBox.Location = new System.Drawing.Point(231, 22);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.nameTextBox.TabIndex = 29;
            // 
            // raceTextBox
            // 
            this.raceTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPlayer, "Race", true));
            this.raceTextBox.Location = new System.Drawing.Point(396, 44);
            this.raceTextBox.Name = "raceTextBox";
            this.raceTextBox.Size = new System.Drawing.Size(100, 20);
            this.raceTextBox.TabIndex = 31;
            // 
            // xTextBox
            // 
            this.xTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPlayer, "X", true));
            this.xTextBox.Location = new System.Drawing.Point(531, 22);
            this.xTextBox.Name = "xTextBox";
            this.xTextBox.Size = new System.Drawing.Size(100, 20);
            this.xTextBox.TabIndex = 33;
            // 
            // yTextBox
            // 
            this.yTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPlayer, "Y", true));
            this.yTextBox.Location = new System.Drawing.Point(531, 44);
            this.yTextBox.Name = "yTextBox";
            this.yTextBox.Size = new System.Drawing.Size(100, 20);
            this.yTextBox.TabIndex = 35;
            // 
            // zTextBox
            // 
            this.zTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsPlayer, "Z", true));
            this.zTextBox.Location = new System.Drawing.Point(531, 66);
            this.zTextBox.Name = "zTextBox";
            this.zTextBox.Size = new System.Drawing.Size(100, 20);
            this.zTextBox.TabIndex = 37;
            // 
            // tpSettings
            // 
            this.tpSettings.Controls.Add(this.groupBox8);
            this.tpSettings.Controls.Add(this.groupBox7);
            this.tpSettings.Controls.Add(this.groupBox4);
            this.tpSettings.Controls.Add(this.tbSendTo);
            this.tpSettings.Controls.Add(this.tbListenPort);
            this.tpSettings.Controls.Add(this.tbCommand);
            this.tpSettings.Controls.Add(this.label1);
            this.tpSettings.Location = new System.Drawing.Point(4, 22);
            this.tpSettings.Name = "tpSettings";
            this.tpSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tpSettings.Size = new System.Drawing.Size(1101, 661);
            this.tpSettings.TabIndex = 1;
            this.tpSettings.Text = "Settings";
            this.tpSettings.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.xbBattling);
            this.groupBox8.Controls.Add(this.xbFly);
            this.groupBox8.Location = new System.Drawing.Point(6, 44);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(1017, 44);
            this.groupBox8.TabIndex = 8;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Hacks";
            // 
            // xbBattling
            // 
            this.xbBattling.AutoSize = true;
            this.xbBattling.Location = new System.Drawing.Point(57, 19);
            this.xbBattling.Name = "xbBattling";
            this.xbBattling.Size = new System.Drawing.Size(61, 17);
            this.xbBattling.TabIndex = 1;
            this.xbBattling.Text = "Battling";
            this.xbBattling.UseVisualStyleBackColor = true;
            // 
            // xbFly
            // 
            this.xbFly.AutoSize = true;
            this.xbFly.Location = new System.Drawing.Point(11, 20);
            this.xbFly.Name = "xbFly";
            this.xbFly.Size = new System.Drawing.Size(39, 17);
            this.xbFly.TabIndex = 0;
            this.xbFly.Text = "Fly";
            this.xbFly.UseVisualStyleBackColor = true;
            this.xbFly.CheckedChanged += new System.EventHandler(this.xbFly_CheckedChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.gameObjectsDataGridView);
            this.groupBox7.Location = new System.Drawing.Point(15, 447);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(409, 166);
            this.groupBox7.TabIndex = 7;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "groupBox7";
            // 
            // gameObjectsDataGridView
            // 
            this.gameObjectsDataGridView.AllowUserToAddRows = false;
            this.gameObjectsDataGridView.AllowUserToDeleteRows = false;
            this.gameObjectsDataGridView.AutoGenerateColumns = false;
            this.gameObjectsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gameObjectsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.colInteract});
            this.gameObjectsDataGridView.DataSource = this.gameObjectsBindingSource;
            this.gameObjectsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameObjectsDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gameObjectsDataGridView.Location = new System.Drawing.Point(3, 16);
            this.gameObjectsDataGridView.Name = "gameObjectsDataGridView";
            this.gameObjectsDataGridView.ReadOnly = true;
            this.gameObjectsDataGridView.RowHeadersVisible = false;
            this.gameObjectsDataGridView.Size = new System.Drawing.Size(403, 147);
            this.gameObjectsDataGridView.TabIndex = 0;
            this.gameObjectsDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gameObjectsDataGridView_CellClick);
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn12.HeaderText = "Id";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 41;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn13.HeaderText = "Name";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // colInteract
            // 
            this.colInteract.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colInteract.HeaderText = "Interact";
            this.colInteract.Name = "colInteract";
            this.colInteract.ReadOnly = true;
            this.colInteract.Text = "Interact";
            this.colInteract.Width = 49;
            // 
            // gameObjectsBindingSource
            // 
            this.gameObjectsBindingSource.DataMember = "GameObjects";
            this.gameObjectsBindingSource.DataSource = this.gameNodeBindingSource1;
            // 
            // gameNodeBindingSource1
            // 
            this.gameNodeBindingSource1.DataSource = typeof(RomViewer.Model.GameNode);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Controls.Add(this.xbACSAutoTurn);
            this.groupBox4.Controls.Add(this.xbACSPaused);
            this.groupBox4.Controls.Add(this.rbPvp);
            this.groupBox4.Controls.Add(this.rb2h);
            this.groupBox4.Controls.Add(this.rb1h);
            this.groupBox4.Controls.Add(this.xbACSOn);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Location = new System.Drawing.Point(3, 94);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1020, 244);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Auto Combat";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.panel2);
            this.groupBox6.Controls.Add(this.panel1);
            this.groupBox6.Controls.Add(this.cbLFQuality);
            this.groupBox6.Controls.Add(this.xbLFQualityFilter);
            this.groupBox6.Location = new System.Drawing.Point(576, 19);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(404, 219);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "LootFilter";
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(178, 57);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(163, 148);
            this.panel2.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(9, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(163, 148);
            this.panel1.TabIndex = 2;
            // 
            // cbLFQuality
            // 
            this.cbLFQuality.FormattingEnabled = true;
            this.cbLFQuality.Location = new System.Drawing.Point(108, 23);
            this.cbLFQuality.Name = "cbLFQuality";
            this.cbLFQuality.Size = new System.Drawing.Size(279, 21);
            this.cbLFQuality.TabIndex = 1;
            // 
            // xbLFQualityFilter
            // 
            this.xbLFQualityFilter.AutoSize = true;
            this.xbLFQualityFilter.Location = new System.Drawing.Point(13, 25);
            this.xbLFQualityFilter.Name = "xbLFQualityFilter";
            this.xbLFQualityFilter.Size = new System.Drawing.Size(89, 17);
            this.xbLFQualityFilter.TabIndex = 0;
            this.xbLFQualityFilter.Text = "Quality Filter?";
            this.xbLFQualityFilter.UseVisualStyleBackColor = true;
            // 
            // xbACSAutoTurn
            // 
            this.xbACSAutoTurn.AutoSize = true;
            this.xbACSAutoTurn.Location = new System.Drawing.Point(137, 23);
            this.xbACSAutoTurn.Name = "xbACSAutoTurn";
            this.xbACSAutoTurn.Size = new System.Drawing.Size(69, 17);
            this.xbACSAutoTurn.TabIndex = 5;
            this.xbACSAutoTurn.Text = "Auto turn";
            this.xbACSAutoTurn.UseVisualStyleBackColor = true;
            this.xbACSAutoTurn.CheckedChanged += new System.EventHandler(this.xbAutoTurn_CheckedChanged);
            // 
            // xbACSPaused
            // 
            this.xbACSPaused.AutoSize = true;
            this.xbACSPaused.Location = new System.Drawing.Point(69, 23);
            this.xbACSPaused.Name = "xbACSPaused";
            this.xbACSPaused.Size = new System.Drawing.Size(62, 17);
            this.xbACSPaused.TabIndex = 4;
            this.xbACSPaused.Text = "Paused";
            this.xbACSPaused.UseVisualStyleBackColor = true;
            this.xbACSPaused.CheckedChanged += new System.EventHandler(this.xbACSPaused_CheckedChanged);
            // 
            // rbPvp
            // 
            this.rbPvp.AutoSize = true;
            this.rbPvp.Location = new System.Drawing.Point(192, 57);
            this.rbPvp.Name = "rbPvp";
            this.rbPvp.Size = new System.Drawing.Size(46, 17);
            this.rbPvp.TabIndex = 3;
            this.rbPvp.TabStop = true;
            this.rbPvp.Text = "PVP";
            this.rbPvp.UseVisualStyleBackColor = true;
            this.rbPvp.CheckedChanged += new System.EventHandler(this.rb2h_CheckedChanged);
            // 
            // rb2h
            // 
            this.rb2h.AutoSize = true;
            this.rb2h.Location = new System.Drawing.Point(105, 57);
            this.rb2h.Name = "rb2h";
            this.rb2h.Size = new System.Drawing.Size(70, 17);
            this.rb2h.TabIndex = 2;
            this.rb2h.TabStop = true;
            this.rb2h.Text = "2 handed";
            this.rb2h.UseVisualStyleBackColor = true;
            this.rb2h.CheckedChanged += new System.EventHandler(this.rb2h_CheckedChanged);
            // 
            // rb1h
            // 
            this.rb1h.AutoSize = true;
            this.rb1h.Location = new System.Drawing.Point(12, 57);
            this.rb1h.Name = "rb1h";
            this.rb1h.Size = new System.Drawing.Size(70, 17);
            this.rb1h.TabIndex = 1;
            this.rb1h.TabStop = true;
            this.rb1h.Text = "1 handed";
            this.rb1h.UseVisualStyleBackColor = true;
            this.rb1h.CheckedChanged += new System.EventHandler(this.rb2h_CheckedChanged);
            // 
            // xbACSOn
            // 
            this.xbACSOn.AutoSize = true;
            this.xbACSOn.Location = new System.Drawing.Point(12, 23);
            this.xbACSOn.Name = "xbACSOn";
            this.xbACSOn.Size = new System.Drawing.Size(40, 17);
            this.xbACSOn.TabIndex = 0;
            this.xbACSOn.Text = "On";
            this.xbACSOn.UseVisualStyleBackColor = true;
            this.xbACSOn.CheckedChanged += new System.EventHandler(this.xbACSOn_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.xbACSAutoTarget);
            this.groupBox5.Controls.Add(this.lbACSTargets);
            this.groupBox5.Controls.Add(this.tsACSTargets);
            this.groupBox5.Location = new System.Drawing.Point(267, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(295, 219);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Targets";
            // 
            // xbACSAutoTarget
            // 
            this.xbACSAutoTarget.AutoSize = true;
            this.xbACSAutoTarget.Location = new System.Drawing.Point(207, 19);
            this.xbACSAutoTarget.Name = "xbACSAutoTarget";
            this.xbACSAutoTarget.Size = new System.Drawing.Size(82, 17);
            this.xbACSAutoTarget.TabIndex = 6;
            this.xbACSAutoTarget.Text = "Auto Target";
            this.xbACSAutoTarget.UseVisualStyleBackColor = true;
            this.xbACSAutoTarget.CheckedChanged += new System.EventHandler(this.xbACSAutoTarget_CheckedChanged);
            // 
            // lbACSTargets
            // 
            this.lbACSTargets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbACSTargets.FormattingEnabled = true;
            this.lbACSTargets.Location = new System.Drawing.Point(6, 45);
            this.lbACSTargets.Name = "lbACSTargets";
            this.lbACSTargets.Size = new System.Drawing.Size(283, 160);
            this.lbACSTargets.TabIndex = 0;
            // 
            // tsACSTargets
            // 
            this.tsACSTargets.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tebTargetName,
            this.tsbACSTargetAdd,
            this.toolStripSeparator1,
            this.tsACSTargetRemove});
            this.tsACSTargets.Location = new System.Drawing.Point(3, 16);
            this.tsACSTargets.Name = "tsACSTargets";
            this.tsACSTargets.Size = new System.Drawing.Size(289, 25);
            this.tsACSTargets.TabIndex = 1;
            this.tsACSTargets.Text = "toolStrip1";
            // 
            // tebTargetName
            // 
            this.tebTargetName.Name = "tebTargetName";
            this.tebTargetName.Size = new System.Drawing.Size(100, 25);
            // 
            // tsbACSTargetAdd
            // 
            this.tsbACSTargetAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbACSTargetAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbACSTargetAdd.Image")));
            this.tsbACSTargetAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbACSTargetAdd.Name = "tsbACSTargetAdd";
            this.tsbACSTargetAdd.Size = new System.Drawing.Size(23, 22);
            this.tsbACSTargetAdd.Text = "+";
            this.tsbACSTargetAdd.Click += new System.EventHandler(this.tsbACSTargetAdd_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsACSTargetRemove
            // 
            this.tsACSTargetRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsACSTargetRemove.Image = ((System.Drawing.Image)(resources.GetObject("tsACSTargetRemove.Image")));
            this.tsACSTargetRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsACSTargetRemove.Name = "tsACSTargetRemove";
            this.tsACSTargetRemove.Size = new System.Drawing.Size(23, 22);
            this.tsACSTargetRemove.Text = "-";
            this.tsACSTargetRemove.Click += new System.EventHandler(this.tsACSTargetRemove_Click);
            // 
            // tbSendTo
            // 
            this.tbSendTo.Location = new System.Drawing.Point(72, 18);
            this.tbSendTo.Name = "tbSendTo";
            this.tbSendTo.Size = new System.Drawing.Size(45, 20);
            this.tbSendTo.TabIndex = 6;
            this.tbSendTo.Text = "60999";
            // 
            // tbListenPort
            // 
            this.tbListenPort.Location = new System.Drawing.Point(20, 18);
            this.tbListenPort.Name = "tbListenPort";
            this.tbListenPort.Size = new System.Drawing.Size(46, 20);
            this.tbListenPort.TabIndex = 5;
            this.tbListenPort.Text = "60000";
            // 
            // tbCommand
            // 
            this.tbCommand.Location = new System.Drawing.Point(221, 18);
            this.tbCommand.Name = "tbCommand";
            this.tbCommand.Size = new System.Drawing.Size(854, 20);
            this.tbCommand.TabIndex = 4;
            this.tbCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCommand_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(153, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Command:";
            // 
            // tpInquiries
            // 
            this.tpInquiries.Controls.Add(this.btnLoadPawns);
            this.tpInquiries.Controls.Add(this.btnSavePawns);
            this.tpInquiries.Controls.Add(this.pawnDataGridView);
            this.tpInquiries.Location = new System.Drawing.Point(4, 22);
            this.tpInquiries.Name = "tpInquiries";
            this.tpInquiries.Padding = new System.Windows.Forms.Padding(3);
            this.tpInquiries.Size = new System.Drawing.Size(1101, 661);
            this.tpInquiries.TabIndex = 2;
            this.tpInquiries.Text = "Inquiries";
            this.tpInquiries.UseVisualStyleBackColor = true;
            // 
            // btnLoadPawns
            // 
            this.btnLoadPawns.Location = new System.Drawing.Point(87, 8);
            this.btnLoadPawns.Name = "btnLoadPawns";
            this.btnLoadPawns.Size = new System.Drawing.Size(75, 23);
            this.btnLoadPawns.TabIndex = 2;
            this.btnLoadPawns.Text = "Load";
            this.btnLoadPawns.UseVisualStyleBackColor = true;
            // 
            // btnSavePawns
            // 
            this.btnSavePawns.Location = new System.Drawing.Point(6, 8);
            this.btnSavePawns.Name = "btnSavePawns";
            this.btnSavePawns.Size = new System.Drawing.Size(75, 23);
            this.btnSavePawns.TabIndex = 1;
            this.btnSavePawns.Text = "Save";
            this.btnSavePawns.UseVisualStyleBackColor = true;
            this.btnSavePawns.Click += new System.EventHandler(this.btnSavePawns_Click);
            // 
            // pawnDataGridView
            // 
            this.pawnDataGridView.AllowUserToAddRows = false;
            this.pawnDataGridView.AllowUserToDeleteRows = false;
            this.pawnDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pawnDataGridView.AutoGenerateColumns = false;
            this.pawnDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pawnDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.pawnDataGridView.DataSource = this.bsInquiry;
            this.pawnDataGridView.Location = new System.Drawing.Point(3, 37);
            this.pawnDataGridView.Name = "pawnDataGridView";
            this.pawnDataGridView.Size = new System.Drawing.Size(1026, 570);
            this.pawnDataGridView.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn3.HeaderText = "Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Guild";
            this.dataGridViewTextBoxColumn7.HeaderText = "Guild";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Class1";
            this.dataGridViewTextBoxColumn5.HeaderText = "Class1";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Level";
            this.dataGridViewTextBoxColumn8.HeaderText = "Level";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Class2";
            this.dataGridViewTextBoxColumn6.HeaderText = "Class2";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Level2";
            this.dataGridViewTextBoxColumn9.HeaderText = "Level2";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Location";
            this.dataGridViewTextBoxColumn1.HeaderText = "Location";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Sex";
            this.dataGridViewTextBoxColumn2.HeaderText = "Sex";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // bsInquiry
            // 
            this.bsInquiry.DataSource = typeof(RomViewer.Domain.Pawn);
            // 
            // tpMap
            // 
            this.tpMap.Controls.Add(this.pbMap);
            this.tpMap.Controls.Add(this.tkScale);
            this.tpMap.Controls.Add(this.hsbMap);
            this.tpMap.Controls.Add(this.vsbMap);
            this.tpMap.Location = new System.Drawing.Point(4, 22);
            this.tpMap.Name = "tpMap";
            this.tpMap.Padding = new System.Windows.Forms.Padding(3);
            this.tpMap.Size = new System.Drawing.Size(1101, 661);
            this.tpMap.TabIndex = 3;
            this.tpMap.Text = "Map";
            this.tpMap.UseVisualStyleBackColor = true;
            // 
            // pbMap
            // 
            this.pbMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbMap.Location = new System.Drawing.Point(3, 3);
            this.pbMap.Name = "pbMap";
            this.pbMap.Size = new System.Drawing.Size(1060, 638);
            this.pbMap.TabIndex = 3;
            this.pbMap.TabStop = false;
            this.pbMap.Resize += new System.EventHandler(this.pbMap_Resize);
            // 
            // tkScale
            // 
            this.tkScale.Dock = System.Windows.Forms.DockStyle.Right;
            this.tkScale.Location = new System.Drawing.Point(1063, 3);
            this.tkScale.Margin = new System.Windows.Forms.Padding(1);
            this.tkScale.Maximum = 500;
            this.tkScale.MaximumSize = new System.Drawing.Size(18, 0);
            this.tkScale.Minimum = 1;
            this.tkScale.Name = "tkScale";
            this.tkScale.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tkScale.Size = new System.Drawing.Size(18, 0);
            this.tkScale.TabIndex = 2;
            this.tkScale.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tkScale.Value = 200;
            this.tkScale.ValueChanged += new System.EventHandler(this.tkScale_ValueChanged);
            // 
            // hsbMap
            // 
            this.hsbMap.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hsbMap.Location = new System.Drawing.Point(3, 641);
            this.hsbMap.Name = "hsbMap";
            this.hsbMap.Size = new System.Drawing.Size(1078, 17);
            this.hsbMap.TabIndex = 1;
            this.hsbMap.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbMap_Scroll);
            // 
            // vsbMap
            // 
            this.vsbMap.Dock = System.Windows.Forms.DockStyle.Right;
            this.vsbMap.Location = new System.Drawing.Point(1081, 3);
            this.vsbMap.Name = "vsbMap";
            this.vsbMap.Size = new System.Drawing.Size(17, 655);
            this.vsbMap.TabIndex = 0;
            this.vsbMap.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbMap_Scroll);
            // 
            // tpFind
            // 
            this.tpFind.Controls.Add(this.btnClear);
            this.tpFind.Controls.Add(this.foundObjectDataGridView);
            this.tpFind.Location = new System.Drawing.Point(4, 22);
            this.tpFind.Name = "tpFind";
            this.tpFind.Padding = new System.Windows.Forms.Padding(3);
            this.tpFind.Size = new System.Drawing.Size(1101, 661);
            this.tpFind.TabIndex = 4;
            this.tpFind.Text = "Objects";
            this.tpFind.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(6, 6);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // foundObjectDataGridView
            // 
            this.foundObjectDataGridView.AllowUserToAddRows = false;
            this.foundObjectDataGridView.AllowUserToDeleteRows = false;
            this.foundObjectDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.foundObjectDataGridView.AutoGenerateColumns = false;
            this.foundObjectDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.foundObjectDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewCheckBoxColumn1,
            this.colAddObject,
            this.colTarget});
            this.foundObjectDataGridView.DataSource = this.foundObjectBindingSource;
            this.foundObjectDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.foundObjectDataGridView.Location = new System.Drawing.Point(3, 35);
            this.foundObjectDataGridView.Name = "foundObjectDataGridView";
            this.foundObjectDataGridView.ReadOnly = true;
            this.foundObjectDataGridView.RowHeadersVisible = false;
            this.foundObjectDataGridView.Size = new System.Drawing.Size(1095, 623);
            this.foundObjectDataGridView.TabIndex = 0;
            this.foundObjectDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.foundObjectDataGridView_CellClick);
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn4.HeaderText = "Id";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 41;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn10.HeaderText = "Name";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Coordinates";
            this.dataGridViewTextBoxColumn11.HeaderText = "Coordinates";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 88;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "Attackable";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Attackable";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Width = 64;
            // 
            // colAddObject
            // 
            this.colAddObject.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colAddObject.HeaderText = "Add at current";
            this.colAddObject.Name = "colAddObject";
            this.colAddObject.ReadOnly = true;
            this.colAddObject.Width = 80;
            // 
            // colTarget
            // 
            this.colTarget.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTarget.HeaderText = "Target";
            this.colTarget.Name = "colTarget";
            this.colTarget.ReadOnly = true;
            this.colTarget.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colTarget.Width = 44;
            // 
            // foundObjectBindingSource
            // 
            this.foundObjectBindingSource.DataSource = typeof(RomViewer.FoundObject);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Zone";
            // 
            // zoneBindingSource
            // 
            this.zoneBindingSource.DataSource = typeof(RomViewer.Model.Zone);
            this.zoneBindingSource.PositionChanged += new System.EventHandler(this.zoneBindingSource_PositionChanged);
            // 
            // zoneComboBox
            // 
            this.zoneComboBox.DataSource = this.zoneBindingSource;
            this.zoneComboBox.DisplayMember = "Name";
            this.zoneComboBox.FormattingEnabled = true;
            this.zoneComboBox.Location = new System.Drawing.Point(46, 30);
            this.zoneComboBox.Name = "zoneComboBox";
            this.zoneComboBox.Size = new System.Drawing.Size(166, 21);
            this.zoneComboBox.TabIndex = 41;
            this.zoneComboBox.ValueMember = "Id";
            // 
            // waypointsBindingSource
            // 
            this.waypointsBindingSource.DataMember = "Waypoints";
            this.waypointsBindingSource.DataSource = this.zoneBindingSource;
            // 
            // waypointsComboBox
            // 
            this.waypointsComboBox.DataSource = this.waypointsBindingSource;
            this.waypointsComboBox.DisplayMember = "Name";
            this.waypointsComboBox.FormattingEnabled = true;
            this.waypointsComboBox.Location = new System.Drawing.Point(278, 30);
            this.waypointsComboBox.Name = "waypointsComboBox";
            this.waypointsComboBox.Size = new System.Drawing.Size(187, 21);
            this.waypointsComboBox.TabIndex = 41;
            this.waypointsComboBox.ValueMember = "Coordinates";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(218, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Last node";
            // 
            // gameNodeBindingSource
            // 
            this.gameNodeBindingSource.DataSource = typeof(RomViewer.Model.GameNode);
            // 
            // cbNearestNode
            // 
            this.cbNearestNode.DataSource = this.gameNodeBindingSource1;
            this.cbNearestNode.DisplayMember = "Name";
            this.cbNearestNode.Enabled = false;
            this.cbNearestNode.FormattingEnabled = true;
            this.cbNearestNode.Location = new System.Drawing.Point(521, 30);
            this.cbNearestNode.Name = "cbNearestNode";
            this.cbNearestNode.Size = new System.Drawing.Size(248, 21);
            this.cbNearestNode.TabIndex = 43;
            this.cbNearestNode.ValueMember = "Coordinates";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(471, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "Nearest";
            // 
            // xbComms
            // 
            this.xbComms.AutoSize = true;
            this.xbComms.Checked = true;
            this.xbComms.CheckState = System.Windows.Forms.CheckState.Checked;
            this.xbComms.Location = new System.Drawing.Point(285, 7);
            this.xbComms.Name = "xbComms";
            this.xbComms.Size = new System.Drawing.Size(60, 17);
            this.xbComms.TabIndex = 47;
            this.xbComms.Text = "Comms";
            this.xbComms.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.navigationToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1136, 24);
            this.menuStrip1.TabIndex = 51;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripSeparator3,
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.toolStripMenuItem2,
            this.displayObjectsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem3.Text = "Launch ROM Main";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(173, 22);
            this.toolStripMenuItem4.Text = "Launch ROM Bot";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(170, 6);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(170, 6);
            // 
            // displayObjectsToolStripMenuItem
            // 
            this.displayObjectsToolStripMenuItem.Name = "displayObjectsToolStripMenuItem";
            this.displayObjectsToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.displayObjectsToolStripMenuItem.Text = "Display Objects";
            this.displayObjectsToolStripMenuItem.Click += new System.EventHandler(this.displayObjectsToolStripMenuItem_Click);
            // 
            // navigationToolStripMenuItem
            // 
            this.navigationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNodeToolStripMenuItem,
            this.gotoToolStripMenuItem,
            this.toolStripMenuItem1,
            this.miAddZone,
            this.toolStripSeparator2,
            this.rebuildToolStripMenuItem});
            this.navigationToolStripMenuItem.Name = "navigationToolStripMenuItem";
            this.navigationToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.navigationToolStripMenuItem.Text = "Navigation";
            // 
            // addNodeToolStripMenuItem
            // 
            this.addNodeToolStripMenuItem.Name = "addNodeToolStripMenuItem";
            this.addNodeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Insert;
            this.addNodeToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.addNodeToolStripMenuItem.Text = "Add Node";
            this.addNodeToolStripMenuItem.Click += new System.EventHandler(this.addNodeToolStripMenuItem_Click);
            // 
            // gotoToolStripMenuItem
            // 
            this.gotoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.auctionHouseToolStripMenuItem,
            this.mailboxToolStripMenuItem,
            this.petVendorToolStripMenuItem,
            this.vEndorToolStripMenuItem,
            this.bankToolStripMenuItem,
            this.housemaidToolStripMenuItem});
            this.gotoToolStripMenuItem.Name = "gotoToolStripMenuItem";
            this.gotoToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.gotoToolStripMenuItem.Text = "Goto Nearest";
            // 
            // auctionHouseToolStripMenuItem
            // 
            this.auctionHouseToolStripMenuItem.Name = "auctionHouseToolStripMenuItem";
            this.auctionHouseToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.auctionHouseToolStripMenuItem.Text = "Auction House";
            this.auctionHouseToolStripMenuItem.Click += new System.EventHandler(this.auctionHouseToolStripMenuItem_Click);
            // 
            // mailboxToolStripMenuItem
            // 
            this.mailboxToolStripMenuItem.Name = "mailboxToolStripMenuItem";
            this.mailboxToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.mailboxToolStripMenuItem.Text = "Mailbox";
            this.mailboxToolStripMenuItem.Click += new System.EventHandler(this.mailboxToolStripMenuItem_Click);
            // 
            // petVendorToolStripMenuItem
            // 
            this.petVendorToolStripMenuItem.Name = "petVendorToolStripMenuItem";
            this.petVendorToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.petVendorToolStripMenuItem.Text = "Pet Vendor";
            this.petVendorToolStripMenuItem.Click += new System.EventHandler(this.petVendorToolStripMenuItem_Click);
            // 
            // vEndorToolStripMenuItem
            // 
            this.vEndorToolStripMenuItem.Name = "vEndorToolStripMenuItem";
            this.vEndorToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.vEndorToolStripMenuItem.Text = "Vendor";
            this.vEndorToolStripMenuItem.Click += new System.EventHandler(this.vEndorToolStripMenuItem_Click);
            // 
            // bankToolStripMenuItem
            // 
            this.bankToolStripMenuItem.Name = "bankToolStripMenuItem";
            this.bankToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.bankToolStripMenuItem.Text = "Bank";
            this.bankToolStripMenuItem.Click += new System.EventHandler(this.bankToolStripMenuItem_Click);
            // 
            // housemaidToolStripMenuItem
            // 
            this.housemaidToolStripMenuItem.Name = "housemaidToolStripMenuItem";
            this.housemaidToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.housemaidToolStripMenuItem.Text = "Housemaid";
            this.housemaidToolStripMenuItem.Click += new System.EventHandler(this.housemaidToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(147, 6);
            // 
            // miAddZone
            // 
            this.miAddZone.Name = "miAddZone";
            this.miAddZone.Size = new System.Drawing.Size(150, 22);
            this.miAddZone.Text = "Add Zone";
            this.miAddZone.Click += new System.EventHandler(this.miAddZone_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(147, 6);
            // 
            // rebuildToolStripMenuItem
            // 
            this.rebuildToolStripMenuItem.Name = "rebuildToolStripMenuItem";
            this.rebuildToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.rebuildToolStripMenuItem.Text = "Rebuild";
            this.rebuildToolStripMenuItem.Click += new System.EventHandler(this.rebuildToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageNodesToolStripMenuItem,
            this.mapToolStripMenuItem,
            this.commandSelectorToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // manageNodesToolStripMenuItem
            // 
            this.manageNodesToolStripMenuItem.Name = "manageNodesToolStripMenuItem";
            this.manageNodesToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.manageNodesToolStripMenuItem.Text = "Manage Nodes";
            this.manageNodesToolStripMenuItem.Click += new System.EventHandler(this.manageNodesToolStripMenuItem_Click);
            // 
            // mapToolStripMenuItem
            // 
            this.mapToolStripMenuItem.Name = "mapToolStripMenuItem";
            this.mapToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.mapToolStripMenuItem.Text = "Map";
            this.mapToolStripMenuItem.Click += new System.EventHandler(this.mapToolStripMenuItem_Click);
            // 
            // commandSelectorToolStripMenuItem
            // 
            this.commandSelectorToolStripMenuItem.Name = "commandSelectorToolStripMenuItem";
            this.commandSelectorToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.commandSelectorToolStripMenuItem.Text = "Command Selector";
            this.commandSelectorToolStripMenuItem.Click += new System.EventHandler(this.commandSelectorToolStripMenuItem_Click);
            // 
            // tmrKeyPress
            // 
            this.tmrKeyPress.Interval = 5;
            this.tmrKeyPress.Tick += new System.EventHandler(this.tmrKeyPress_Tick);
            // 
            // btnHideShow
            // 
            this.btnHideShow.Location = new System.Drawing.Point(791, 27);
            this.btnHideShow.Name = "btnHideShow";
            this.btnHideShow.Size = new System.Drawing.Size(96, 23);
            this.btnHideShow.TabIndex = 52;
            this.btnHideShow.Text = "Toggle Visible";
            this.btnHideShow.UseVisualStyleBackColor = true;
            this.btnHideShow.Click += new System.EventHandler(this.btnHideShow_Click);
            // 
            // cbSendKeys
            // 
            this.cbSendKeys.AutoSize = true;
            this.cbSendKeys.Location = new System.Drawing.Point(365, 7);
            this.cbSendKeys.Name = "cbSendKeys";
            this.cbSendKeys.Size = new System.Drawing.Size(77, 17);
            this.cbSendKeys.TabIndex = 53;
            this.cbSendKeys.Text = "Send Keys";
            this.cbSendKeys.UseVisualStyleBackColor = true;
            // 
            // modelLoaderThread
            // 
            this.modelLoaderThread.WorkerReportsProgress = true;
            this.modelLoaderThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.modelLoaderThread_DoWork);
            this.modelLoaderThread.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.modelLoaderThread_ProgressChanged);
            this.modelLoaderThread.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.modelLoaderThread_RunWorkerCompleted);
            // 
            // pbModelProgress
            // 
            this.pbModelProgress.Location = new System.Drawing.Point(619, 1);
            this.pbModelProgress.Name = "pbModelProgress";
            this.pbModelProgress.Size = new System.Drawing.Size(389, 23);
            this.pbModelProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbModelProgress.TabIndex = 54;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(1023, 9);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(0, 13);
            this.lblProgress.TabIndex = 55;
            // 
            // btnSetCommsOn
            // 
            this.btnSetCommsOn.Location = new System.Drawing.Point(236, 1);
            this.btnSetCommsOn.Name = "btnSetCommsOn";
            this.btnSetCommsOn.Size = new System.Drawing.Size(43, 23);
            this.btnSetCommsOn.TabIndex = 56;
            this.btnSetCommsOn.Text = "On";
            this.btnSetCommsOn.UseVisualStyleBackColor = true;
            this.btnSetCommsOn.Click += new System.EventHandler(this.btnSetCommsOn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 758);
            this.Controls.Add(this.btnSetCommsOn);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.pbModelProgress);
            this.Controls.Add(this.cbSendKeys);
            this.Controls.Add(this.btnHideShow);
            this.Controls.Add(this.xbComms);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbNearestNode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.waypointsComboBox);
            this.Controls.Add(this.zoneComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tcChats);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "RomViewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tcChats.ResumeLayout(false);
            this.pageCharacter.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsTarget)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEquipment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsInventory)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsPlayer)).EndInit();
            this.tpSettings.ResumeLayout(false);
            this.tpSettings.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gameObjectsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameObjectsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameNodeBindingSource1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tsACSTargets.ResumeLayout(false);
            this.tsACSTargets.PerformLayout();
            this.tpInquiries.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pawnDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsInquiry)).EndInit();
            this.tpMap.ResumeLayout(false);
            this.tpMap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkScale)).EndInit();
            this.tpFind.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.foundObjectDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.foundObjectBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoneBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waypointsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameNodeBindingSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tcChats;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage pageCharacter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn slotNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemLinkDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn durabilityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qualityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bindingDetailsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn requiredLevelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn objectTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn objectSubTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn objectSubSubTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsInventory;
        private System.Windows.Forms.TextBox class1TextBox;
        private System.Windows.Forms.BindingSource bsPlayer;
        private System.Windows.Forms.TextBox class2TextBox;
        private System.Windows.Forms.TextBox guildTextBox;
        private System.Windows.Forms.TextBox hPTextBox;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.TextBox lastExpTextBox;
        private System.Windows.Forms.TextBox levelTextBox;
        private System.Windows.Forms.TextBox level2TextBox;
        private System.Windows.Forms.TextBox maxHPTextBox;
        private System.Windows.Forms.TextBox maxMPTextBox;
        private System.Windows.Forms.TextBox maxMP2TextBox;
        private System.Windows.Forms.TextBox mountedTextBox;
        private System.Windows.Forms.TextBox mPTextBox;
        private System.Windows.Forms.TextBox mP2TextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox raceTextBox;
        private System.Windows.Forms.TextBox xTextBox;
        private System.Windows.Forms.TextBox yTextBox;
        private System.Windows.Forms.TextBox zTextBox;
        private System.Windows.Forms.Button btnPlayerUpdate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox class1TextBox1;
        private System.Windows.Forms.BindingSource bsTarget;
        private System.Windows.Forms.TextBox class2TextBox1;
        private System.Windows.Forms.TextBox hPTextBox1;
        private System.Windows.Forms.TextBox idTextBox1;
        private System.Windows.Forms.TextBox maxHPTextBox1;
        private System.Windows.Forms.TextBox nameTextBox1;
        private System.Windows.Forms.TextBox raceTextBox1;
        private System.Windows.Forms.TextBox xTextBox1;
        private System.Windows.Forms.TextBox yTextBox1;
        private System.Windows.Forms.TextBox zTextBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnRefreshInventory;
        public System.Windows.Forms.TextBox tbCommand;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bsEquipment;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn countDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colorDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn slotNoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemLinkDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn durabilityDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn qualityDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn bindingDetailsDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn requiredLevelDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn objectTypeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn objectSubTypeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn objectSubSubTypeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.Label lblGold;
        private System.Windows.Forms.TextBox tbListenPort;
        public System.Windows.Forms.TextBox tbSendTo;
        private System.Windows.Forms.TabPage tpSettings;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox xbACSOn;
        private System.Windows.Forms.RadioButton rbPvp;
        private System.Windows.Forms.RadioButton rb2h;
        private System.Windows.Forms.RadioButton rb1h;
        private System.Windows.Forms.CheckBox xbACSPaused;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox xbACSAutoTarget;
        private System.Windows.Forms.ListBox lbACSTargets;
        private System.Windows.Forms.ToolStrip tsACSTargets;
        private System.Windows.Forms.ToolStripButton tsbACSTargetAdd;
        private System.Windows.Forms.ToolStripButton tsACSTargetRemove;
        private System.Windows.Forms.CheckBox xbACSAutoTurn;
        private System.Windows.Forms.ToolStripTextBox tebTargetName;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbLFQuality;
        private System.Windows.Forms.CheckBox xbLFQualityFilter;
        private System.Windows.Forms.TabPage tpInquiries;
        private System.Windows.Forms.DataGridView pawnDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.BindingSource bsInquiry;
        private System.Windows.Forms.Button btnSavePawns;
        private System.Windows.Forms.Button btnLoadPawns;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource zoneBindingSource;
        private System.Windows.Forms.ComboBox zoneComboBox;
        private System.Windows.Forms.BindingSource waypointsBindingSource;
        private System.Windows.Forms.ComboBox waypointsComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource gameNodeBindingSource;
        private System.Windows.Forms.BindingSource gameNodeBindingSource1;
        private System.Windows.Forms.ComboBox cbNearestNode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox xbComms;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageNodesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commandSelectorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem navigationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gotoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem auctionHouseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mailboxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem petVendorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vEndorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bankToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem rebuildToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem displayObjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem housemaidToolStripMenuItem;
        private System.Windows.Forms.Timer tmrKeyPress;
        private System.Windows.Forms.Button btnHideShow;
        private System.Windows.Forms.CheckBox cbSendKeys;
        private System.Windows.Forms.TabPage tpMap;
        private System.Windows.Forms.HScrollBar hsbMap;
        private System.Windows.Forms.VScrollBar vsbMap;
        private System.Windows.Forms.TrackBar tkScale;
        private System.Windows.Forms.PictureBox pbMap;
        private System.Windows.Forms.TabPage tpFind;
        private System.Windows.Forms.DataGridView foundObjectDataGridView;
        private System.Windows.Forms.BindingSource foundObjectBindingSource;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.DataGridView gameObjectsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewButtonColumn colInteract;
        private System.Windows.Forms.BindingSource gameObjectsBindingSource;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.CheckBox xbBattling;
        private System.Windows.Forms.CheckBox xbFly;
        private System.Windows.Forms.Button btnTeleport;
        private System.Windows.Forms.ToolStripMenuItem miAddZone;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.ComponentModel.BackgroundWorker modelLoaderThread;
        private System.Windows.Forms.ProgressBar pbModelProgress;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Button btnSetCommsOn;
        private System.Windows.Forms.Button btnMount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn colAddObject;
        private System.Windows.Forms.DataGridViewButtonColumn colTarget;
    }
}

