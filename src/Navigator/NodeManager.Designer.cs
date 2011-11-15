using RomViewer.Model;

namespace RomViewer.Navigator
{
    partial class NodeManager
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
            System.Windows.Forms.Label zoneLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NodeManager));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gameNodeDataGridView = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coordinatesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gameNodeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.zoneComboBox = new System.Windows.Forms.ComboBox();
            this.zoneBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gameObjectsDataGridView = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gameObjectsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem1 = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gameNodeDataGridView1 = new System.Windows.Forms.DataGridView();
            this.targetDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scriptDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gameNodeLinksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigator2 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.tbZ = new System.Windows.Forms.TextBox();
            this.tbY = new System.Windows.Forms.TextBox();
            this.tbX = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            zoneLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameNodeDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameNodeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoneBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameObjectsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameObjectsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameNodeDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameNodeLinksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator2)).BeginInit();
            this.bindingNavigator2.SuspendLayout();
            this.SuspendLayout();
            // 
            // zoneLabel
            // 
            zoneLabel.AutoSize = true;
            zoneLabel.Location = new System.Drawing.Point(18, 95);
            zoneLabel.Name = "zoneLabel";
            zoneLabel.Size = new System.Drawing.Size(35, 13);
            zoneLabel.TabIndex = 17;
            zoneLabel.Text = "Zone:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(641, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visualiseToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // visualiseToolStripMenuItem
            // 
            this.visualiseToolStripMenuItem.Name = "visualiseToolStripMenuItem";
            this.visualiseToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.visualiseToolStripMenuItem.Text = "&Visualise";
            this.visualiseToolStripMenuItem.Click += new System.EventHandler(this.visualiseToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.gameNodeDataGridView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(zoneLabel);
            this.splitContainer1.Panel2.Controls.Add(this.zoneComboBox);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.tbZ);
            this.splitContainer1.Panel2.Controls.Add(this.tbY);
            this.splitContainer1.Panel2.Controls.Add(this.tbX);
            this.splitContainer1.Panel2.Controls.Add(this.tbName);
            this.splitContainer1.Panel2.Controls.Add(this.lblId);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.labelId);
            this.splitContainer1.Size = new System.Drawing.Size(641, 614);
            this.splitContainer1.SplitterDistance = 213;
            this.splitContainer1.TabIndex = 3;
            // 
            // gameNodeDataGridView
            // 
            this.gameNodeDataGridView.AllowUserToAddRows = false;
            this.gameNodeDataGridView.AllowUserToDeleteRows = false;
            this.gameNodeDataGridView.AutoGenerateColumns = false;
            this.gameNodeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gameNodeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.zoneDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.coordinatesDataGridViewTextBoxColumn});
            this.gameNodeDataGridView.DataSource = this.gameNodeBindingSource;
            this.gameNodeDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameNodeDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gameNodeDataGridView.Location = new System.Drawing.Point(0, 0);
            this.gameNodeDataGridView.Name = "gameNodeDataGridView";
            this.gameNodeDataGridView.ReadOnly = true;
            this.gameNodeDataGridView.RowHeadersVisible = false;
            this.gameNodeDataGridView.Size = new System.Drawing.Size(213, 614);
            this.gameNodeDataGridView.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 41;
            // 
            // zoneDataGridViewTextBoxColumn
            // 
            this.zoneDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.zoneDataGridViewTextBoxColumn.DataPropertyName = "Zone";
            this.zoneDataGridViewTextBoxColumn.HeaderText = "Zone";
            this.zoneDataGridViewTextBoxColumn.Name = "zoneDataGridViewTextBoxColumn";
            this.zoneDataGridViewTextBoxColumn.ReadOnly = true;
            this.zoneDataGridViewTextBoxColumn.Width = 57;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // coordinatesDataGridViewTextBoxColumn
            // 
            this.coordinatesDataGridViewTextBoxColumn.DataPropertyName = "Coordinates";
            this.coordinatesDataGridViewTextBoxColumn.HeaderText = "Coordinates";
            this.coordinatesDataGridViewTextBoxColumn.Name = "coordinatesDataGridViewTextBoxColumn";
            this.coordinatesDataGridViewTextBoxColumn.ReadOnly = true;
            this.coordinatesDataGridViewTextBoxColumn.Visible = false;
            // 
            // gameNodeBindingSource
            // 
            this.gameNodeBindingSource.DataSource = typeof(RomViewer.Model.GameNode);
            this.gameNodeBindingSource.CurrentChanged += new System.EventHandler(this.gameNodeBindingSource_CurrentChanged);
            // 
            // zoneComboBox
            // 
            this.zoneComboBox.DataSource = this.zoneBindingSource;
            this.zoneComboBox.FormattingEnabled = true;
            this.zoneComboBox.Location = new System.Drawing.Point(114, 92);
            this.zoneComboBox.Name = "zoneComboBox";
            this.zoneComboBox.Size = new System.Drawing.Size(206, 21);
            this.zoneComboBox.TabIndex = 18;
            this.zoneComboBox.SelectionChangeCommitted += new System.EventHandler(this.zoneComboBox_SelectionChangeCommitted);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gameObjectsDataGridView);
            this.groupBox2.Controls.Add(this.bindingNavigator1);
            this.groupBox2.Location = new System.Drawing.Point(18, 344);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(396, 259);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Objects";
            // 
            // gameObjectsDataGridView
            // 
            this.gameObjectsDataGridView.AllowUserToAddRows = false;
            this.gameObjectsDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gameObjectsDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.gameObjectsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gameObjectsDataGridView.AutoGenerateColumns = false;
            this.gameObjectsDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gameObjectsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gameObjectsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn1,
            this.nameDataGridViewTextBoxColumn1});
            this.gameObjectsDataGridView.DataSource = this.gameObjectsBindingSource;
            this.gameObjectsDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gameObjectsDataGridView.Location = new System.Drawing.Point(6, 44);
            this.gameObjectsDataGridView.Name = "gameObjectsDataGridView";
            this.gameObjectsDataGridView.ReadOnly = true;
            this.gameObjectsDataGridView.RowHeadersVisible = false;
            this.gameObjectsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gameObjectsDataGridView.Size = new System.Drawing.Size(375, 209);
            this.gameObjectsDataGridView.TabIndex = 1;
            this.gameObjectsDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gameObjectsDataGridView_CellDoubleClick);
            // 
            // idDataGridViewTextBoxColumn1
            // 
            this.idDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn1.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            this.idDataGridViewTextBoxColumn1.ReadOnly = true;
            this.idDataGridViewTextBoxColumn1.Width = 41;
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            this.nameDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn1.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            this.nameDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // gameObjectsBindingSource
            // 
            this.gameObjectsBindingSource.DataMember = "GameObjects";
            this.gameObjectsBindingSource.DataSource = this.gameNodeBindingSource;
            this.gameObjectsBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.gameObjectsBindingSource_AddingNew);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = this.bindingNavigatorAddNewItem1;
            this.bindingNavigator1.BindingSource = this.gameObjectsBindingSource;
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = this.bindingNavigatorDeleteItem1;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorAddNewItem1,
            this.bindingNavigatorDeleteItem1});
            this.bindingNavigator1.Location = new System.Drawing.Point(3, 16);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.Size = new System.Drawing.Size(390, 25);
            this.bindingNavigator1.TabIndex = 1;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem1
            // 
            this.bindingNavigatorAddNewItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem1.Image")));
            this.bindingNavigatorAddNewItem1.Name = "bindingNavigatorAddNewItem1";
            this.bindingNavigatorAddNewItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem1.Text = "Add new";
            // 
            // bindingNavigatorDeleteItem1
            // 
            this.bindingNavigatorDeleteItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem1.Image")));
            this.bindingNavigatorDeleteItem1.Name = "bindingNavigatorDeleteItem1";
            this.bindingNavigatorDeleteItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem1.Text = "Delete";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gameNodeDataGridView1);
            this.groupBox1.Controls.Add(this.bindingNavigator2);
            this.groupBox1.Location = new System.Drawing.Point(18, 131);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(396, 207);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Links";
            // 
            // gameNodeDataGridView1
            // 
            this.gameNodeDataGridView1.AllowUserToAddRows = false;
            this.gameNodeDataGridView1.AllowUserToDeleteRows = false;
            this.gameNodeDataGridView1.AutoGenerateColumns = false;
            this.gameNodeDataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gameNodeDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gameNodeDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.targetDataGridViewTextBoxColumn,
            this.scriptDataGridViewTextBoxColumn});
            this.gameNodeDataGridView1.DataSource = this.gameNodeLinksBindingSource;
            this.gameNodeDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameNodeDataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gameNodeDataGridView1.Location = new System.Drawing.Point(3, 41);
            this.gameNodeDataGridView1.Name = "gameNodeDataGridView1";
            this.gameNodeDataGridView1.ReadOnly = true;
            this.gameNodeDataGridView1.RowHeadersVisible = false;
            this.gameNodeDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gameNodeDataGridView1.Size = new System.Drawing.Size(390, 163);
            this.gameNodeDataGridView1.TabIndex = 1;
            this.gameNodeDataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gameNodeDataGridView1_CellDoubleClick);
            // 
            // targetDataGridViewTextBoxColumn
            // 
            this.targetDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.targetDataGridViewTextBoxColumn.DataPropertyName = "Target";
            this.targetDataGridViewTextBoxColumn.HeaderText = "Target";
            this.targetDataGridViewTextBoxColumn.Name = "targetDataGridViewTextBoxColumn";
            this.targetDataGridViewTextBoxColumn.ReadOnly = true;
            this.targetDataGridViewTextBoxColumn.Width = 63;
            // 
            // scriptDataGridViewTextBoxColumn
            // 
            this.scriptDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.scriptDataGridViewTextBoxColumn.DataPropertyName = "Script";
            this.scriptDataGridViewTextBoxColumn.HeaderText = "Script";
            this.scriptDataGridViewTextBoxColumn.Name = "scriptDataGridViewTextBoxColumn";
            this.scriptDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // gameNodeLinksBindingSource
            // 
            this.gameNodeLinksBindingSource.AllowNew = true;
            this.gameNodeLinksBindingSource.DataMember = "GameNodeLinks";
            this.gameNodeLinksBindingSource.DataSource = this.gameNodeBindingSource;
            this.gameNodeLinksBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.gameNodeLinksBindingSource_AddingNew);
            // 
            // bindingNavigator2
            // 
            this.bindingNavigator2.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator2.BindingSource = this.gameNodeLinksBindingSource;
            this.bindingNavigator2.CountItem = null;
            this.bindingNavigator2.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigator2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bindingNavigator2.Location = new System.Drawing.Point(3, 16);
            this.bindingNavigator2.MoveFirstItem = null;
            this.bindingNavigator2.MoveLastItem = null;
            this.bindingNavigator2.MoveNextItem = null;
            this.bindingNavigator2.MovePreviousItem = null;
            this.bindingNavigator2.Name = "bindingNavigator2";
            this.bindingNavigator2.PositionItem = null;
            this.bindingNavigator2.Size = new System.Drawing.Size(390, 25);
            this.bindingNavigator2.TabIndex = 1;
            this.bindingNavigator2.Text = "bindingNavigator2";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // tbZ
            // 
            this.tbZ.Location = new System.Drawing.Point(215, 66);
            this.tbZ.Name = "tbZ";
            this.tbZ.Size = new System.Drawing.Size(46, 20);
            this.tbZ.TabIndex = 15;
            this.tbZ.TextChanged += new System.EventHandler(this.tbZ_TextChanged);
            // 
            // tbY
            // 
            this.tbY.Location = new System.Drawing.Point(165, 66);
            this.tbY.Name = "tbY";
            this.tbY.Size = new System.Drawing.Size(46, 20);
            this.tbY.TabIndex = 14;
            this.tbY.TextChanged += new System.EventHandler(this.tbY_TextChanged);
            // 
            // tbX
            // 
            this.tbX.Location = new System.Drawing.Point(113, 66);
            this.tbX.Name = "tbX";
            this.tbX.Size = new System.Drawing.Size(46, 20);
            this.tbX.TabIndex = 13;
            this.tbX.TextChanged += new System.EventHandler(this.tbX_TextChanged);
            // 
            // tbName
            // 
            this.tbName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.gameNodeBindingSource, "Name", true));
            this.tbName.Location = new System.Drawing.Point(114, 38);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(158, 20);
            this.tbName.TabIndex = 12;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.gameNodeBindingSource, "Id", true));
            this.lblId.Location = new System.Drawing.Point(111, 14);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(16, 13);
            this.lblId.TabIndex = 11;
            this.lblId.Text = "-1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Coordinates";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Name";
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(16, 12);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(16, 13);
            this.labelId.TabIndex = 8;
            this.labelId.Text = "Id";
            // 
            // NodeManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 638);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "NodeManager";
            this.Text = "WorldManager";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NodeManager_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gameNodeDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameNodeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoneBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameObjectsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameObjectsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameNodeDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameNodeLinksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator2)).EndInit();
            this.bindingNavigator2.ResumeLayout(false);
            this.bindingNavigator2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView gameNodeDataGridView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView gameObjectsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.BindingNavigator bindingNavigator2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.TextBox tbZ;
        private System.Windows.Forms.TextBox tbY;
        private System.Windows.Forms.TextBox tbX;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualiseToolStripMenuItem;
        private System.Windows.Forms.BindingSource zoneBindingSource;
        private System.Windows.Forms.ComboBox zoneComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.BindingSource gameNodeBindingSource;
        private System.Windows.Forms.DataGridView gameNodeDataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource gameObjectsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn zoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn coordinatesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn scriptDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource gameNodeLinksBindingSource;

    }
}