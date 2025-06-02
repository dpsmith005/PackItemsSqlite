namespace PackItemsSqlite
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
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
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageItems = new System.Windows.Forms.TabPage();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPageGroups = new System.Windows.Forms.TabPage();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.dgvGroups = new System.Windows.Forms.DataGridView();
            this.ListOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupName0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPageTags = new System.Windows.Forms.TabPage();
            this.btnAddTags = new System.Windows.Forms.Button();
            this.dgvTags = new System.Windows.Forms.DataGridView();
            this.TagName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPageItemsEdit = new System.Windows.Forms.TabPage();
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
            this.tags = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageAdmin = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblExistingTags = new System.Windows.Forms.Label();
            this.lbTagsList = new System.Windows.Forms.ListBox();
            this.tbStatus = new System.Windows.Forms.TextBox();
            this.cbGroups = new System.Windows.Forms.ComboBox();
            this.cbTags = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.tbItemInput = new System.Windows.Forms.TextBox();
            this.panelHeader.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.tabPageGroups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroups)).BeginInit();
            this.tabPageTags.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTags)).BeginInit();
            this.tabPageItemsEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemsEdit)).BeginInit();
            this.tabPageAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(322, 460);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
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
            this.panelHeader.Size = new System.Drawing.Size(1262, 40);
            this.panelHeader.TabIndex = 2;
            this.panelHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelHeader_MouseMove);
            // 
            // labelClose
            // 
            this.labelClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelClose.AutoSize = true;
            this.labelClose.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClose.ForeColor = System.Drawing.Color.White;
            this.labelClose.Location = new System.Drawing.Point(1230, 10);
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
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(9, 9);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(149, 24);
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
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageItems);
            this.tabControl1.Controls.Add(this.tabPageGroups);
            this.tabControl1.Controls.Add(this.tabPageTags);
            this.tabControl1.Controls.Add(this.tabPageItemsEdit);
            this.tabControl1.Controls.Add(this.tabPageAdmin);
            this.tabControl1.Location = new System.Drawing.Point(12, 46);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(813, 339);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // tabPageItems
            // 
            this.tabPageItems.Controls.Add(this.dgvItems);
            this.tabPageItems.Controls.Add(this.label6);
            this.tabPageItems.Location = new System.Drawing.Point(4, 22);
            this.tabPageItems.Name = "tabPageItems";
            this.tabPageItems.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageItems.Size = new System.Drawing.Size(805, 313);
            this.tabPageItems.TabIndex = 0;
            this.tabPageItems.Text = "Items";
            this.tabPageItems.UseVisualStyleBackColor = true;
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AllowUserToResizeColumns = false;
            this.dgvItems.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Location = new System.Drawing.Point(6, 19);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.RowTemplate.ReadOnly = true;
            this.dgvItems.Size = new System.Drawing.Size(500, 288);
            this.dgvItems.TabIndex = 3;
            this.dgvItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellContentClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Items";
            // 
            // tabPageGroups
            // 
            this.tabPageGroups.Controls.Add(this.btnAddGroup);
            this.tabPageGroups.Controls.Add(this.dgvGroups);
            this.tabPageGroups.Controls.Add(this.label5);
            this.tabPageGroups.Location = new System.Drawing.Point(4, 22);
            this.tabPageGroups.Name = "tabPageGroups";
            this.tabPageGroups.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGroups.Size = new System.Drawing.Size(805, 313);
            this.tabPageGroups.TabIndex = 1;
            this.tabPageGroups.Text = "Groups";
            this.tabPageGroups.UseVisualStyleBackColor = true;
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.Location = new System.Drawing.Point(380, 30);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(90, 30);
            this.btnAddGroup.TabIndex = 2;
            this.btnAddGroup.Text = "Add Group";
            this.btnAddGroup.UseVisualStyleBackColor = true;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // dgvGroups
            // 
            this.dgvGroups.AllowUserToAddRows = false;
            this.dgvGroups.AllowUserToDeleteRows = false;
            this.dgvGroups.AllowUserToResizeColumns = false;
            this.dgvGroups.AllowUserToResizeRows = false;
            this.dgvGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ListOrder,
            this.GroupName0});
            this.dgvGroups.Location = new System.Drawing.Point(6, 19);
            this.dgvGroups.MultiSelect = false;
            this.dgvGroups.Name = "dgvGroups";
            this.dgvGroups.RowHeadersVisible = false;
            this.dgvGroups.RowTemplate.ReadOnly = true;
            this.dgvGroups.Size = new System.Drawing.Size(368, 288);
            this.dgvGroups.TabIndex = 1;
            this.dgvGroups.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroups_CellContentClick);
            this.dgvGroups.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroups_CellLeave);
            // 
            // ListOrder
            // 
            this.ListOrder.DataPropertyName = "ListOrder";
            this.ListOrder.HeaderText = "ListOrder";
            this.ListOrder.Name = "ListOrder";
            // 
            // GroupName0
            // 
            this.GroupName0.DataPropertyName = "GroupName";
            this.GroupName0.HeaderText = "Group Name";
            this.GroupName0.Name = "GroupName0";
            this.GroupName0.Width = 150;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Groups";
            // 
            // tabPageTags
            // 
            this.tabPageTags.Controls.Add(this.btnAddTags);
            this.tabPageTags.Controls.Add(this.dgvTags);
            this.tabPageTags.Controls.Add(this.label4);
            this.tabPageTags.Location = new System.Drawing.Point(4, 22);
            this.tabPageTags.Name = "tabPageTags";
            this.tabPageTags.Size = new System.Drawing.Size(805, 313);
            this.tabPageTags.TabIndex = 2;
            this.tabPageTags.Text = "Tags";
            this.tabPageTags.UseVisualStyleBackColor = true;
            // 
            // btnAddTags
            // 
            this.btnAddTags.Location = new System.Drawing.Point(380, 30);
            this.btnAddTags.Name = "btnAddTags";
            this.btnAddTags.Size = new System.Drawing.Size(89, 30);
            this.btnAddTags.TabIndex = 3;
            this.btnAddTags.Text = "Add Tags";
            this.btnAddTags.UseVisualStyleBackColor = true;
            this.btnAddTags.Click += new System.EventHandler(this.btnAddTags_Click);
            // 
            // dgvTags
            // 
            this.dgvTags.AllowUserToAddRows = false;
            this.dgvTags.AllowUserToDeleteRows = false;
            this.dgvTags.AllowUserToResizeColumns = false;
            this.dgvTags.AllowUserToResizeRows = false;
            this.dgvTags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTags.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TagName});
            this.dgvTags.Location = new System.Drawing.Point(6, 19);
            this.dgvTags.MultiSelect = false;
            this.dgvTags.Name = "dgvTags";
            this.dgvTags.RowHeadersVisible = false;
            this.dgvTags.RowTemplate.ReadOnly = true;
            this.dgvTags.Size = new System.Drawing.Size(300, 291);
            this.dgvTags.TabIndex = 2;
            this.dgvTags.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTags_CellContentClick);
            // 
            // TagName
            // 
            this.TagName.DataPropertyName = "TagName";
            this.TagName.HeaderText = "Tag";
            this.TagName.Name = "TagName";
            this.TagName.ReadOnly = true;
            this.TagName.Width = 250;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tags";
            // 
            // tabPageItemsEdit
            // 
            this.tabPageItemsEdit.Controls.Add(this.dgvItemsEdit);
            this.tabPageItemsEdit.Location = new System.Drawing.Point(4, 22);
            this.tabPageItemsEdit.Name = "tabPageItemsEdit";
            this.tabPageItemsEdit.Size = new System.Drawing.Size(805, 313);
            this.tabPageItemsEdit.TabIndex = 4;
            this.tabPageItemsEdit.Text = "Items Edit";
            this.tabPageItemsEdit.UseVisualStyleBackColor = true;
            // 
            // dgvItemsEdit
            // 
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
            this.tags,
            this.notes});
            this.dgvItemsEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItemsEdit.Location = new System.Drawing.Point(0, 0);
            this.dgvItemsEdit.Name = "dgvItemsEdit";
            this.dgvItemsEdit.Size = new System.Drawing.Size(805, 313);
            this.dgvItemsEdit.TabIndex = 0;
            this.dgvItemsEdit.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItemsEdit_CellLeave);
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
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ounces.DefaultCellStyle = dataGridViewCellStyle6;
            this.ounces.HeaderText = "Ounces";
            this.ounces.Name = "ounces";
            this.ounces.Width = 50;
            // 
            // lb
            // 
            this.lb.DataPropertyName = "lb";
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lb.DefaultCellStyle = dataGridViewCellStyle7;
            this.lb.HeaderText = "Pounds";
            this.lb.Name = "lb";
            this.lb.Width = 50;
            // 
            // oz
            // 
            this.oz.DataPropertyName = "oz";
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.oz.DefaultCellStyle = dataGridViewCellStyle8;
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
            // tags
            // 
            this.tags.DataPropertyName = "Tags";
            this.tags.HeaderText = "Tags";
            this.tags.Name = "tags";
            this.tags.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // notes
            // 
            this.notes.DataPropertyName = "Notes";
            this.notes.HeaderText = "Notes";
            this.notes.Name = "notes";
            // 
            // tabPageAdmin
            // 
            this.tabPageAdmin.Controls.Add(this.label3);
            this.tabPageAdmin.Location = new System.Drawing.Point(4, 22);
            this.tabPageAdmin.Name = "tabPageAdmin";
            this.tabPageAdmin.Size = new System.Drawing.Size(805, 313);
            this.tabPageAdmin.TabIndex = 3;
            this.tabPageAdmin.Text = "Admin";
            this.tabPageAdmin.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(443, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Add code to display lists of items based on Selected or Tags or All.  Format as P" +
    "DF or DOCX.";
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(822, 46);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(440, 445);
            this.panel4.TabIndex = 6;
            // 
            // lblExistingTags
            // 
            this.lblExistingTags.AutoSize = true;
            this.lblExistingTags.Location = new System.Drawing.Point(549, 441);
            this.lblExistingTags.Name = "lblExistingTags";
            this.lblExistingTags.Size = new System.Drawing.Size(70, 13);
            this.lblExistingTags.TabIndex = 14;
            this.lblExistingTags.Text = "Existing Tags";
            this.lblExistingTags.Visible = false;
            // 
            // lbTagsList
            // 
            this.lbTagsList.Enabled = false;
            this.lbTagsList.FormattingEnabled = true;
            this.lbTagsList.Location = new System.Drawing.Point(625, 390);
            this.lbTagsList.Name = "lbTagsList";
            this.lbTagsList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbTagsList.Size = new System.Drawing.Size(133, 121);
            this.lbTagsList.TabIndex = 13;
            this.lbTagsList.Visible = false;
            // 
            // tbStatus
            // 
            this.tbStatus.Location = new System.Drawing.Point(0, 521);
            this.tbStatus.Multiline = true;
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbStatus.Size = new System.Drawing.Size(1249, 87);
            this.tbStatus.TabIndex = 1;
            this.tbStatus.TextChanged += new System.EventHandler(this.tbStatus_TextChanged);
            // 
            // cbGroups
            // 
            this.cbGroups.FormattingEnabled = true;
            this.cbGroups.Location = new System.Drawing.Point(49, 406);
            this.cbGroups.Name = "cbGroups";
            this.cbGroups.Size = new System.Drawing.Size(206, 21);
            this.cbGroups.TabIndex = 7;
            this.cbGroups.SelectedValueChanged += new System.EventHandler(this.cbGroups_SelectedValueChanged);
            // 
            // cbTags
            // 
            this.cbTags.FormattingEnabled = true;
            this.cbTags.Location = new System.Drawing.Point(325, 404);
            this.cbTags.Name = "cbTags";
            this.cbTags.Size = new System.Drawing.Size(206, 21);
            this.cbTags.TabIndex = 8;
            this.cbTags.SelectedValueChanged += new System.EventHandler(this.cbTags_SelectedValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(338, 388);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Tags";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(61, 390);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Groups";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(61, 441);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Item";
            // 
            // tbItemInput
            // 
            this.tbItemInput.Location = new System.Drawing.Point(49, 457);
            this.tbItemInput.Name = "tbItemInput";
            this.tbItemInput.Size = new System.Drawing.Size(206, 20);
            this.tbItemInput.TabIndex = 12;
            this.tbItemInput.Leave += new System.EventHandler(this.tbItemInput_Leave);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 606);
            this.Controls.Add(this.lblExistingTags);
            this.Controls.Add(this.tbItemInput);
            this.Controls.Add(this.lbTagsList);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbTags);
            this.Controls.Add(this.cbGroups);
            this.Controls.Add(this.tbStatus);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Backpacking Weight Calculations";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageItems.ResumeLayout(false);
            this.tabPageItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.tabPageGroups.ResumeLayout(false);
            this.tabPageGroups.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroups)).EndInit();
            this.tabPageTags.ResumeLayout(false);
            this.tabPageTags.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTags)).EndInit();
            this.tabPageItemsEdit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemsEdit)).EndInit();
            this.tabPageAdmin.ResumeLayout(false);
            this.tabPageAdmin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageItems;
        private System.Windows.Forms.TabPage tabPageGroups;
        private System.Windows.Forms.TabPage tabPageTags;
        private System.Windows.Forms.TabPage tabPageAdmin;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem AddToDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddGroupsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddTagsToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Label labelClose;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ToolStripMenuItem AddDataToolStripMenuItem1;
        public System.Windows.Forms.TextBox tbStatus;
        private System.Windows.Forms.DataGridView dgvGroups;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridView dgvTags;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.ToolStripMenuItem deleteAllDataToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbGroups;
        private System.Windows.Forms.ComboBox cbTags;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStripMenuItem exportDataToCSVToolStripMenuItem;
        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.Button btnAddTags;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbItemInput;
        private System.Windows.Forms.TabPage tabPageItemsEdit;
        private System.Windows.Forms.DataGridView dgvItemsEdit;
        private System.Windows.Forms.ToolStripMenuItem addItemsFromCSVToolStripMenuItem;
        private System.Windows.Forms.ListBox lbTagsList;
        private System.Windows.Forms.Label lblExistingTags;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewComboBoxColumn groupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn item;
        private System.Windows.Forms.DataGridViewTextBoxColumn grams;
        private System.Windows.Forms.DataGridViewTextBoxColumn ounces;
        private System.Windows.Forms.DataGridViewTextBoxColumn lb;
        private System.Windows.Forms.DataGridViewTextBoxColumn oz;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _new;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn tags;
        private System.Windows.Forms.DataGridViewTextBoxColumn notes;
        private System.Windows.Forms.DataGridViewTextBoxColumn ListOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupName0;
        private System.Windows.Forms.DataGridViewTextBoxColumn TagName;
    }
}

