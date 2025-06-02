namespace PackItemsWt
{
    partial class formMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbStatus = new System.Windows.Forms.TextBox();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelClose = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.AddToDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddDataToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addItemsFromCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddGroupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddTagsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAllDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportDataToCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelView = new System.Windows.Forms.Panel();
            this.labelInfo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSearchItem = new System.Windows.Forms.TextBox();
            this.btnSearchItem = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSearchGroupName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSearchTag = new System.Windows.Forms.TextBox();
            this.btnSearchGroupName = new System.Windows.Forms.Button();
            this.btnSearchTag = new System.Windows.Forms.Button();
            this.btnSearchNew = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.panelControls = new System.Windows.Forms.Panel();
            this.btnSearchSelected = new System.Windows.Forms.Button();
            this.Tags = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTags = new System.Windows.Forms.DataGridView();
            this.btnAddTags = new System.Windows.Forms.Button();
            this.Groups = new System.Windows.Forms.TabPage();
            this.dgvGroups = new System.Windows.Forms.DataGridView();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.Items = new System.Windows.Forms.TabPage();
            this.dgvItemsEdit = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grams = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ounces = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._new = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.panelHeader.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panelControls.SuspendLayout();
            this.Tags.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTags)).BeginInit();
            this.Groups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroups)).BeginInit();
            this.Items.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemsEdit)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbStatus
            // 
            this.tbStatus.Location = new System.Drawing.Point(0, 673);
            this.tbStatus.Multiline = true;
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbStatus.Size = new System.Drawing.Size(1324, 87);
            this.tbStatus.TabIndex = 2;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.Navy;
            this.panelHeader.Controls.Add(this.labelClose);
            this.panelHeader.Controls.Add(this.label2);
            this.panelHeader.Controls.Add(this.menuStrip1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1324, 40);
            this.panelHeader.TabIndex = 3;
            // 
            // labelClose
            // 
            this.labelClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelClose.AutoSize = true;
            this.labelClose.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClose.ForeColor = System.Drawing.Color.White;
            this.labelClose.Location = new System.Drawing.Point(1292, 10);
            this.labelClose.Name = "labelClose";
            this.labelClose.Size = new System.Drawing.Size(20, 23);
            this.labelClose.TabIndex = 1;
            this.labelClose.Text = "X";
            this.labelClose.Click += new System.EventHandler(this.labelClose_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(378, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(267, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Backpacking Weight Calculations";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddToDBToolStripMenuItem,
            this.listViewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(9, 9);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(214, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // AddToDBToolStripMenuItem
            // 
            this.AddToDBToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddDataToolStripMenuItem1,
            this.addItemsFromCSVToolStripMenuItem,
            this.AddGroupsToolStripMenuItem,
            this.AddTagsToolStripMenuItem,
            this.deleteAllDataToolStripMenuItem,
            this.exportDataToCSVToolStripMenuItem});
            this.AddToDBToolStripMenuItem.Name = "AddToDBToolStripMenuItem";
            this.AddToDBToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.AddToDBToolStripMenuItem.Text = "Add CSV to DB";
            // 
            // AddDataToolStripMenuItem1
            // 
            this.AddDataToolStripMenuItem1.Name = "AddDataToolStripMenuItem1";
            this.AddDataToolStripMenuItem1.Size = new System.Drawing.Size(190, 22);
            this.AddDataToolStripMenuItem1.Text = "Add Data from CSV";
            this.AddDataToolStripMenuItem1.Click += new System.EventHandler(this.AddDataToolStripMenuItem1_Click);
            // 
            // addItemsFromCSVToolStripMenuItem
            // 
            this.addItemsFromCSVToolStripMenuItem.Name = "addItemsFromCSVToolStripMenuItem";
            this.addItemsFromCSVToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.addItemsFromCSVToolStripMenuItem.Text = "Add Items from CSV";
            this.addItemsFromCSVToolStripMenuItem.Click += new System.EventHandler(this.AddItemsToolStripMenuItem1_Click);
            // 
            // AddGroupsToolStripMenuItem
            // 
            this.AddGroupsToolStripMenuItem.Name = "AddGroupsToolStripMenuItem";
            this.AddGroupsToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.AddGroupsToolStripMenuItem.Text = "Add Groups from CSV";
            this.AddGroupsToolStripMenuItem.Click += new System.EventHandler(this.AddGroupsToolStripMenuItem_Click);
            // 
            // AddTagsToolStripMenuItem
            // 
            this.AddTagsToolStripMenuItem.Name = "AddTagsToolStripMenuItem";
            this.AddTagsToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.AddTagsToolStripMenuItem.Text = "Add Tags from CSV";
            this.AddTagsToolStripMenuItem.Click += new System.EventHandler(this.AddTagsToolStripMenuItem_Click);
            // 
            // deleteAllDataToolStripMenuItem
            // 
            this.deleteAllDataToolStripMenuItem.Name = "deleteAllDataToolStripMenuItem";
            this.deleteAllDataToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.deleteAllDataToolStripMenuItem.Text = "Delete All Data";
            this.deleteAllDataToolStripMenuItem.Click += new System.EventHandler(this.deleteAllDataToolStripMenuItem_Click);
            // 
            // exportDataToCSVToolStripMenuItem
            // 
            this.exportDataToCSVToolStripMenuItem.Name = "exportDataToCSVToolStripMenuItem";
            this.exportDataToCSVToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.exportDataToCSVToolStripMenuItem.Text = "Export Data to CSV";
            this.exportDataToCSVToolStripMenuItem.Click += new System.EventHandler(this.exportDataToCSVToolStripMenuItem_Click);
            // 
            // listViewToolStripMenuItem
            // 
            this.listViewToolStripMenuItem.Name = "listViewToolStripMenuItem";
            this.listViewToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.listViewToolStripMenuItem.Text = "List View";
            this.listViewToolStripMenuItem.Click += new System.EventHandler(this.listViewToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // panelView
            // 
            this.panelView.Location = new System.Drawing.Point(875, 49);
            this.panelView.Name = "panelView";
            this.panelView.Size = new System.Drawing.Size(445, 480);
            this.panelView.TabIndex = 7;
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(684, 43);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(35, 13);
            this.labelInfo.TabIndex = 9;
            this.labelInfo.Text = "label3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Search for Item";
            // 
            // tbSearchItem
            // 
            this.tbSearchItem.Location = new System.Drawing.Point(134, 5);
            this.tbSearchItem.Name = "tbSearchItem";
            this.tbSearchItem.Size = new System.Drawing.Size(137, 20);
            this.tbSearchItem.TabIndex = 12;
            // 
            // btnSearchItem
            // 
            this.btnSearchItem.Location = new System.Drawing.Point(277, 3);
            this.btnSearchItem.Name = "btnSearchItem";
            this.btnSearchItem.Size = new System.Drawing.Size(52, 23);
            this.btnSearchItem.TabIndex = 13;
            this.btnSearchItem.Text = "Search";
            this.btnSearchItem.UseVisualStyleBackColor = true;
            this.btnSearchItem.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Search for Group Name";
            // 
            // tbSearchGroupName
            // 
            this.tbSearchGroupName.Location = new System.Drawing.Point(134, 37);
            this.tbSearchGroupName.Name = "tbSearchGroupName";
            this.tbSearchGroupName.Size = new System.Drawing.Size(137, 20);
            this.tbSearchGroupName.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Search for Tag";
            // 
            // tbSearchTag
            // 
            this.tbSearchTag.Location = new System.Drawing.Point(134, 70);
            this.tbSearchTag.Name = "tbSearchTag";
            this.tbSearchTag.Size = new System.Drawing.Size(137, 20);
            this.tbSearchTag.TabIndex = 17;
            // 
            // btnSearchGroupName
            // 
            this.btnSearchGroupName.Location = new System.Drawing.Point(277, 34);
            this.btnSearchGroupName.Name = "btnSearchGroupName";
            this.btnSearchGroupName.Size = new System.Drawing.Size(52, 23);
            this.btnSearchGroupName.TabIndex = 18;
            this.btnSearchGroupName.Text = "Search";
            this.btnSearchGroupName.UseVisualStyleBackColor = true;
            this.btnSearchGroupName.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnSearchTag
            // 
            this.btnSearchTag.Location = new System.Drawing.Point(277, 68);
            this.btnSearchTag.Name = "btnSearchTag";
            this.btnSearchTag.Size = new System.Drawing.Size(52, 23);
            this.btnSearchTag.TabIndex = 19;
            this.btnSearchTag.Text = "Search";
            this.btnSearchTag.UseVisualStyleBackColor = true;
            this.btnSearchTag.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnSearchNew
            // 
            this.btnSearchNew.Location = new System.Drawing.Point(485, 1);
            this.btnSearchNew.Name = "btnSearchNew";
            this.btnSearchNew.Size = new System.Drawing.Size(54, 42);
            this.btnSearchNew.TabIndex = 20;
            this.btnSearchNew.Text = "Search New";
            this.btnSearchNew.UseVisualStyleBackColor = true;
            this.btnSearchNew.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(344, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(200, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Search on empty value will return all data";
            // 
            // panelControls
            // 
            this.panelControls.Controls.Add(this.btnSearchSelected);
            this.panelControls.Controls.Add(this.label6);
            this.panelControls.Controls.Add(this.btnSearchNew);
            this.panelControls.Controls.Add(this.btnSearchTag);
            this.panelControls.Controls.Add(this.btnSearchGroupName);
            this.panelControls.Controls.Add(this.tbSearchTag);
            this.panelControls.Controls.Add(this.label5);
            this.panelControls.Controls.Add(this.tbSearchGroupName);
            this.panelControls.Controls.Add(this.label4);
            this.panelControls.Controls.Add(this.btnSearchItem);
            this.panelControls.Controls.Add(this.tbSearchItem);
            this.panelControls.Controls.Add(this.label3);
            this.panelControls.Location = new System.Drawing.Point(20, 518);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(708, 142);
            this.panelControls.TabIndex = 23;
            // 
            // btnSearchSelected
            // 
            this.btnSearchSelected.Location = new System.Drawing.Point(544, 2);
            this.btnSearchSelected.Name = "btnSearchSelected";
            this.btnSearchSelected.Size = new System.Drawing.Size(60, 42);
            this.btnSearchSelected.TabIndex = 23;
            this.btnSearchSelected.Text = "Search Selected";
            this.btnSearchSelected.UseVisualStyleBackColor = true;
            // 
            // Tags
            // 
            this.Tags.Controls.Add(this.label1);
            this.Tags.Controls.Add(this.dgvTags);
            this.Tags.Controls.Add(this.btnAddTags);
            this.Tags.Location = new System.Drawing.Point(4, 22);
            this.Tags.Name = "Tags";
            this.Tags.Size = new System.Drawing.Size(848, 443);
            this.Tags.TabIndex = 2;
            this.Tags.Text = "Tags";
            this.Tags.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(320, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Only add and delete are allowed.  No Tag name edit is allowed.";
            // 
            // dgvTags
            // 
            this.dgvTags.AllowUserToAddRows = false;
            this.dgvTags.AllowUserToDeleteRows = false;
            this.dgvTags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTags.Location = new System.Drawing.Point(3, 4);
            this.dgvTags.MultiSelect = false;
            this.dgvTags.Name = "dgvTags";
            this.dgvTags.ReadOnly = true;
            this.dgvTags.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvTags.Size = new System.Drawing.Size(303, 436);
            this.dgvTags.TabIndex = 5;
            this.dgvTags.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTags_CellContentClick);
            // 
            // btnAddTags
            // 
            this.btnAddTags.Location = new System.Drawing.Point(312, 5);
            this.btnAddTags.Name = "btnAddTags";
            this.btnAddTags.Size = new System.Drawing.Size(89, 30);
            this.btnAddTags.TabIndex = 4;
            this.btnAddTags.Text = "Add Tags";
            this.btnAddTags.UseVisualStyleBackColor = true;
            this.btnAddTags.Click += new System.EventHandler(this.btnAddTags_Click);
            // 
            // Groups
            // 
            this.Groups.Controls.Add(this.dgvGroups);
            this.Groups.Controls.Add(this.btnAddGroup);
            this.Groups.Location = new System.Drawing.Point(4, 22);
            this.Groups.Name = "Groups";
            this.Groups.Padding = new System.Windows.Forms.Padding(3);
            this.Groups.Size = new System.Drawing.Size(848, 443);
            this.Groups.TabIndex = 1;
            this.Groups.Text = "Groups";
            this.Groups.UseVisualStyleBackColor = true;
            // 
            // dgvGroups
            // 
            this.dgvGroups.AllowUserToAddRows = false;
            this.dgvGroups.AllowUserToDeleteRows = false;
            this.dgvGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroups.Location = new System.Drawing.Point(5, 5);
            this.dgvGroups.MultiSelect = false;
            this.dgvGroups.Name = "dgvGroups";
            this.dgvGroups.Size = new System.Drawing.Size(369, 432);
            this.dgvGroups.TabIndex = 4;
            this.dgvGroups.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroups_CellContentClick);
            this.dgvGroups.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroups_CellLeave);
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.Location = new System.Drawing.Point(380, 6);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(90, 30);
            this.btnAddGroup.TabIndex = 3;
            this.btnAddGroup.Text = "Add Group";
            this.btnAddGroup.UseVisualStyleBackColor = true;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // Items
            // 
            this.Items.Controls.Add(this.dgvItemsEdit);
            this.Items.Location = new System.Drawing.Point(4, 22);
            this.Items.Name = "Items";
            this.Items.Padding = new System.Windows.Forms.Padding(3);
            this.Items.Size = new System.Drawing.Size(848, 443);
            this.Items.TabIndex = 0;
            this.Items.Text = "Items";
            this.Items.UseVisualStyleBackColor = true;
            // 
            // dgvItemsEdit
            // 
            this.dgvItemsEdit.AllowUserToAddRows = false;
            this.dgvItemsEdit.AllowUserToDeleteRows = false;
            this.dgvItemsEdit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemsEdit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.groupName,
            this.item,
            this.grams,
            this.ounces,
            this.lb,
            this.oz,
            this._new,
            this.selected,
            this.dataGridViewTextBoxColumn1,
            this.notes});
            this.dgvItemsEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItemsEdit.Location = new System.Drawing.Point(3, 3);
            this.dgvItemsEdit.MultiSelect = false;
            this.dgvItemsEdit.Name = "dgvItemsEdit";
            this.dgvItemsEdit.Size = new System.Drawing.Size(842, 437);
            this.dgvItemsEdit.TabIndex = 1;
            this.dgvItemsEdit.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItemsEdit_CellContentClick);
            this.dgvItemsEdit.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItemsEdit_CellLeave);
            this.dgvItemsEdit.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItemsEdit_CellValueChanged);
            this.dgvItemsEdit.CurrentCellChanged += new System.EventHandler(this.dgvItemsEdit_CurrentCellChanged);
            this.dgvItemsEdit.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItemsEdit_RowEnter);
            this.dgvItemsEdit.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItemsEdit_RowLeave);
            this.dgvItemsEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvItemsEdit_KeyDown);
            // 
            // id
            // 
            this.id.DataPropertyName = "Id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.id.Visible = false;
            this.id.Width = 30;
            // 
            // groupName
            // 
            this.groupName.DataPropertyName = "GroupName";
            this.groupName.HeaderText = "Group Name";
            this.groupName.Name = "groupName";
            this.groupName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.groupName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.groupName.Width = 120;
            // 
            // item
            // 
            this.item.DataPropertyName = "Item";
            this.item.HeaderText = "Item";
            this.item.Name = "item";
            this.item.Width = 140;
            // 
            // grams
            // 
            this.grams.DataPropertyName = "grams";
            this.grams.HeaderText = "Grams";
            this.grams.Name = "grams";
            this.grams.Width = 50;
            // 
            // ounces
            // 
            this.ounces.DataPropertyName = "ounces";
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ounces.DefaultCellStyle = dataGridViewCellStyle7;
            this.ounces.HeaderText = "Ounces";
            this.ounces.Name = "ounces";
            this.ounces.Width = 50;
            // 
            // lb
            // 
            this.lb.DataPropertyName = "lb";
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lb.DefaultCellStyle = dataGridViewCellStyle8;
            this.lb.HeaderText = "Pounds";
            this.lb.Name = "lb";
            this.lb.Width = 50;
            // 
            // oz
            // 
            this.oz.DataPropertyName = "oz";
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.oz.DefaultCellStyle = dataGridViewCellStyle9;
            this.oz.HeaderText = "Oz";
            this.oz.Name = "oz";
            this.oz.Width = 50;
            // 
            // _new
            // 
            this._new.DataPropertyName = "New";
            this._new.HeaderText = "New";
            this._new.Name = "_new";
            this._new.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._new.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this._new.Width = 40;
            // 
            // selected
            // 
            this.selected.DataPropertyName = "Selected";
            this.selected.HeaderText = "Selected";
            this.selected.Name = "selected";
            this.selected.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.selected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.selected.Width = 60;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Tags";
            this.dataGridViewTextBoxColumn1.HeaderText = "Tags";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // notes
            // 
            this.notes.DataPropertyName = "Notes";
            this.notes.HeaderText = "Notes";
            this.notes.Name = "notes";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Items);
            this.tabControl1.Controls.Add(this.Groups);
            this.tabControl1.Controls.Add(this.Tags);
            this.tabControl1.Location = new System.Drawing.Point(13, 47);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(856, 469);
            this.tabControl1.TabIndex = 8;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1324, 761);
            this.Controls.Add(this.panelControls);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panelView);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.tbStatus);
            this.Name = "formMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Backpacking Weight Calculations";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelControls.ResumeLayout(false);
            this.panelControls.PerformLayout();
            this.Tags.ResumeLayout(false);
            this.Tags.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTags)).EndInit();
            this.Groups.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroups)).EndInit();
            this.Items.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemsEdit)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox tbStatus;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem AddToDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddDataToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addItemsFromCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddGroupsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddTagsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAllDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportDataToCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Panel panelView;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSearchItem;
        private System.Windows.Forms.Button btnSearchItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbSearchGroupName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbSearchTag;
        private System.Windows.Forms.Button btnSearchGroupName;
        private System.Windows.Forms.Button btnSearchTag;
        private System.Windows.Forms.Button btnSearchNew;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Button btnSearchSelected;
        private System.Windows.Forms.ToolStripMenuItem listViewToolStripMenuItem;
        private System.Windows.Forms.TabPage Tags;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTags;
        private System.Windows.Forms.Button btnAddTags;
        private System.Windows.Forms.TabPage Groups;
        private System.Windows.Forms.DataGridView dgvGroups;
        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.TabPage Items;
        private System.Windows.Forms.DataGridView dgvItemsEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewComboBoxColumn groupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn item;
        private System.Windows.Forms.DataGridViewTextBoxColumn grams;
        private System.Windows.Forms.DataGridViewTextBoxColumn ounces;
        private System.Windows.Forms.DataGridViewTextBoxColumn lb;
        private System.Windows.Forms.DataGridViewTextBoxColumn oz;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _new;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn notes;
        private System.Windows.Forms.TabControl tabControl1;
    }
}

