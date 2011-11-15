namespace RomViewer.Navigator
{
    partial class ctrlGameObject
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlGameObject));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.xbMailBox = new System.Windows.Forms.CheckBox();
            this.xbAuctionHouse = new System.Windows.Forms.CheckBox();
            this.xbVendorGeneral = new System.Windows.Forms.CheckBox();
            this.xbVendorPet = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.transportLinksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bsObject = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.transportLinksDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gameNodeBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gameNodeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.xbHouse = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transportLinksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsObject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transportLinksDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameNodeBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameNodeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.xbHouse);
            this.groupBox1.Controls.Add(this.xbMailBox);
            this.groupBox1.Controls.Add(this.xbAuctionHouse);
            this.groupBox1.Controls.Add(this.xbVendorGeneral);
            this.groupBox1.Controls.Add(this.xbVendorPet);
            this.groupBox1.Location = new System.Drawing.Point(17, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(429, 64);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Properties";
            // 
            // xbMailBox
            // 
            this.xbMailBox.AutoSize = true;
            this.xbMailBox.Location = new System.Drawing.Point(280, 29);
            this.xbMailBox.Name = "xbMailBox";
            this.xbMailBox.Size = new System.Drawing.Size(66, 17);
            this.xbMailBox.TabIndex = 3;
            this.xbMailBox.Text = "Mail Box";
            this.xbMailBox.UseVisualStyleBackColor = true;
            this.xbMailBox.CheckedChanged += new System.EventHandler(this.xbVendorGeneral_CheckedChanged);
            // 
            // xbAuctionHouse
            // 
            this.xbAuctionHouse.AutoSize = true;
            this.xbAuctionHouse.Location = new System.Drawing.Point(188, 29);
            this.xbAuctionHouse.Name = "xbAuctionHouse";
            this.xbAuctionHouse.Size = new System.Drawing.Size(96, 17);
            this.xbAuctionHouse.TabIndex = 2;
            this.xbAuctionHouse.Text = "Auction House";
            this.xbAuctionHouse.UseVisualStyleBackColor = true;
            this.xbAuctionHouse.CheckedChanged += new System.EventHandler(this.xbVendorGeneral_CheckedChanged);
            // 
            // xbVendorGeneral
            // 
            this.xbVendorGeneral.AutoSize = true;
            this.xbVendorGeneral.Location = new System.Drawing.Point(88, 29);
            this.xbVendorGeneral.Name = "xbVendorGeneral";
            this.xbVendorGeneral.Size = new System.Drawing.Size(100, 17);
            this.xbVendorGeneral.TabIndex = 1;
            this.xbVendorGeneral.Text = "General Vendor";
            this.xbVendorGeneral.UseVisualStyleBackColor = true;
            this.xbVendorGeneral.CheckedChanged += new System.EventHandler(this.xbVendorGeneral_CheckedChanged);
            // 
            // xbVendorPet
            // 
            this.xbVendorPet.AutoSize = true;
            this.xbVendorPet.Location = new System.Drawing.Point(11, 29);
            this.xbVendorPet.Name = "xbVendorPet";
            this.xbVendorPet.Size = new System.Drawing.Size(77, 17);
            this.xbVendorPet.TabIndex = 0;
            this.xbVendorPet.Text = "Pet Hunter";
            this.xbVendorPet.UseVisualStyleBackColor = true;
            this.xbVendorPet.CheckedChanged += new System.EventHandler(this.xbVendorGeneral_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bindingNavigator1);
            this.groupBox2.Controls.Add(this.transportLinksDataGridView);
            this.groupBox2.Location = new System.Drawing.Point(19, 133);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(433, 318);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Transport Links";
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator1.BindingSource = this.transportLinksBindingSource;
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(3, 16);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.Size = new System.Drawing.Size(427, 25);
            this.bindingNavigator1.TabIndex = 1;
            this.bindingNavigator1.Text = "bindingNavigator1";
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
            // transportLinksBindingSource
            // 
            this.transportLinksBindingSource.DataMember = "TransportLinks";
            this.transportLinksBindingSource.DataSource = this.bsObject;
            this.transportLinksBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.transportLinksBindingSource_AddingNew);
            // 
            // bsObject
            // 
            this.bsObject.DataSource = typeof(RomViewer.Model.GameObject);
            this.bsObject.CurrentChanged += new System.EventHandler(this.bsObject_CurrentChanged);
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
            // transportLinksDataGridView
            // 
            this.transportLinksDataGridView.AutoGenerateColumns = false;
            this.transportLinksDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.transportLinksDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.transportLinksDataGridView.DataSource = this.transportLinksBindingSource;
            this.transportLinksDataGridView.Location = new System.Drawing.Point(5, 41);
            this.transportLinksDataGridView.Name = "transportLinksDataGridView";
            this.transportLinksDataGridView.RowHeadersVisible = false;
            this.transportLinksDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.transportLinksDataGridView.Size = new System.Drawing.Size(422, 259);
            this.transportLinksDataGridView.TabIndex = 0;
            this.transportLinksDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.transportLinksDataGridView_CellDoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Destination";
            this.dataGridViewTextBoxColumn1.HeaderText = "Destination";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn1.Width = 85;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Script";
            this.dataGridViewTextBoxColumn2.HeaderText = "Script";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // gameNodeBindingSource1
            // 
            this.gameNodeBindingSource1.DataSource = typeof(RomViewer.Model.GameNode);
            // 
            // gameNodeBindingSource
            // 
            this.gameNodeBindingSource.DataSource = typeof(RomViewer.Model.GameNode);
            // 
            // idTextBox
            // 
            this.idTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsObject, "Id", true));
            this.idTextBox.Location = new System.Drawing.Point(43, 12);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(100, 20);
            this.idTextBox.TabIndex = 7;
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsObject, "Name", true));
            this.nameTextBox.Location = new System.Drawing.Point(247, 12);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.nameTextBox.TabIndex = 8;
            // 
            // xbHouse
            // 
            this.xbHouse.AutoSize = true;
            this.xbHouse.Location = new System.Drawing.Point(352, 29);
            this.xbHouse.Name = "xbHouse";
            this.xbHouse.Size = new System.Drawing.Size(64, 17);
            this.xbHouse.TabIndex = 4;
            this.xbHouse.Text = "HouseK";
            this.xbHouse.UseVisualStyleBackColor = true;
            this.xbHouse.CheckedChanged += new System.EventHandler(this.xbVendorGeneral_CheckedChanged);
            // 
            // ctrlGameObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.idTextBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ctrlGameObject";
            this.Size = new System.Drawing.Size(452, 466);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transportLinksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsObject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transportLinksDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameNodeBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameNodeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox xbVendorPet;
        private System.Windows.Forms.CheckBox xbAuctionHouse;
        private System.Windows.Forms.CheckBox xbVendorGeneral;
        private System.Windows.Forms.CheckBox xbMailBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.BindingSource gameNodeBindingSource;
        private System.Windows.Forms.BindingSource gameNodeBindingSource1;
        private System.Windows.Forms.DataGridView transportLinksDataGridView;
        private System.Windows.Forms.BindingSource transportLinksBindingSource;
        private System.Windows.Forms.BindingSource bsObject;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.DataGridViewLinkColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.CheckBox xbHouse;
    }
}
