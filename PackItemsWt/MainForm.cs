using PackItemsWt.Forms;
using PackItemsWt.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PackItemsWt
{
    public partial class formMain : Form
    {
        private PackItemsManager _packItemsManager;
        private BindingSource _packItemsBindingSource = new BindingSource();
        private BindingSource _groupItemsBindingSource = new BindingSource();
        private BindingSource _tagItemsBindingSource = new BindingSource();
        private BindingSource _packItemsListBindingSource = new BindingSource();
        private Boolean _formLoaded = false;
        private bool IsHandleAdded;
        const Double gramsPerOunce = 28.3495;
        const Double ouncesPerGram = 0.035274;
        bool dgvItemEditChanged = false;
        public DataGridViewRow currentRow;
        private int controlPanelWidth;
        public formMain()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            _Form1 = this;

            _packItemsManager = new PackItemsManager();

            labelInfo.Visible = false;
        }
        public static formMain _Form1;
        private void MainForm_Load(object sender, EventArgs e)
        {
            DatabaseHelper status = new DatabaseHelper();

            // Populate Group combo box and Group data grid view
            UpdateGroupsGridview();

            // Populate Tag combo box and Tags data grid view
            UpdateTagsGridView();

            // Populate the Items data grid view
            UpdateItemsEditGridview();

            _formLoaded = true;
            updateStatus("Main form load");

            // Get the first item in the Items data grid
            if (dgvItemsEdit.RowCount > 0)
            {
                dgvItemsEdit.CurrentCell = dgvItemsEdit.Rows[0].Cells[2];
                currentRow = dgvItemsEdit.CurrentRow;
                string val = Convert.ToString(currentRow.Cells["Id"].Value);
                labelInfo.Text = val;

                // Populate the ItemsData form
                ItemsData itemsData = new ItemsData();
                itemsData.TopLevel = false;


                if (panelView.Controls.Count > 0)
                {
                    panelView.Controls.Clear();
                }
                panelView.Controls.Add(itemsData);
                itemsData.BringToFront();
                itemsData.Show();
            }
            controlPanelWidth = tabControl1.Width;

        }
        public void updateStatus(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                tbStatus.Text = "";
                //tbStatus.AppendText("\r\n");
            }
            else
            {
                tbStatus.AppendText(message + "\r\n");
            }
        }
        public string selectedItem()
        {
            return labelInfo.Text;
        }
        public DataGridViewRow selectedRow()
        {
            if (dgvItemsEdit.CurrentRow == null)
            {
                dgvItemsEdit.Rows[0].Selected = true;
            }
            return dgvItemsEdit.CurrentRow;
        }
        public string Status
        {
            get { return tbStatus.Text; }
            set { tbStatus.Text = value; }
        }
        private void labelClose_Click(object sender, EventArgs e)
        {
            DatabaseHelper.closeDB();
            this.Close();
        }

        public static HelpInfo helpInfo; 
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (helpInfo == null || helpInfo.IsDisposed)
            {
                helpInfo = new HelpInfo();
            }
            helpInfo.BringToFront();
            helpInfo.Show();
        }

        private void AddDataToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Items data added from CSV
            DatabaseHelper.AddDataFromCsv(DatabaseHelper.csvDataFile);
            updateStatus("Added Items from CSV");
            //UpdateItemsGridview();
            UpdateGroupsGridview();
            UpdateTagsGridView();
        }

        private void AddItemsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Items data added from CSV
            DatabaseHelper.AddItemsFromCsv(DatabaseHelper.csvDataFile);
            updateStatus("Added Items from CSV");
            //UpdateItemsGridview();
            UpdateGroupsGridview();
            UpdateTagsGridView();
        }

        private void AddGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Group data added from CSV
            DatabaseHelper.AddGroupsFromCsv(DatabaseHelper.csvGroupsFile);
            updateStatus("Added Groups from CSV");
            UpdateTagsGridView();
        }

        private void AddTagsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Tags data added from CSV
            DatabaseHelper.AddTagsFromCsv(DatabaseHelper.csvTagsFile);
            updateStatus("Added Tags from CSV");
            UpdateTagsGridView();

        }

        private void deleteAllDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete all the data?", "Confirm Delete Data", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                tbStatus.Clear();
                DatabaseHelper.DeleteAllData();
                Status = "Deleted all rows from tables\r\n";
                //UpdateItemsGridview();
                UpdateTagsGridView();
            }
            else
            {
                Status = "Data not deleted";
            }
        }

        private void exportDataToCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DataTable dt = DatabaseHelper.GetAllItems();
            BindingList<PackItem> items = new BindingList<PackItem>();
            items = _packItemsManager.Items;

            SaveFileDialog fileSelect = new SaveFileDialog();
            fileSelect.Title = "Browse File Location";
            fileSelect.DefaultExt = "csv";
            fileSelect.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            fileSelect.FilterIndex = 0;
            fileSelect.CheckPathExists = true;
            if (fileSelect.ShowDialog() == DialogResult.OK)
            {
                string filename = fileSelect.FileName;
                DatabaseHelper.ListToCSV(items, filename);
            }
        }

        private static DialogResult ShowInputDialog(ref string input)
        {
            System.Drawing.Size size = new System.Drawing.Size(200, 70);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = "Name";

            System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox();
            textBox.Size = new System.Drawing.Size(size.Width - 10, 23);
            textBox.Location = new System.Drawing.Point(5, 5);
            textBox.Text = input;
            inputBox.Controls.Add(textBox);

            System.Windows.Forms.Button okButton = new System.Windows.Forms.Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 39);
            inputBox.Controls.Add(okButton);

            System.Windows.Forms.Button cancelButton = new System.Windows.Forms.Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 39);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            input = textBox.Text;
            return result;
        }
        private void tabControl1_Click(object sender, EventArgs e)
        {
            string tabName = tabControl1.SelectedTab.Text;
            updateStatus("Tab control clicked - " + tabName);
            if (tabControl1.SelectedTab.Text == "Items")
            {
                panelView.Visible = true;
                tabControl1.Width = controlPanelWidth;
                UpdateItemsEditGridview();
            }
            else if (tabControl1.SelectedTab.Text == "Groups")
            {
                panelView.Visible = false;
                tabControl1.Width = controlPanelWidth;
                UpdateGroupsGridview();
            }
            else if (tabControl1.SelectedTab.Text == "Tags")
            {
                panelView.Visible = false;
                tabControl1.Width = controlPanelWidth;
                UpdateTagsGridView();
            }
        }
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            updateStatus("Tab control selected - " + tabControl1.SelectedTab.Text);
            if (tabControl1.SelectedTab.Text == "Items")
            {
                panelControls.Visible = true;
            } 
            else
            {
                panelControls.Visible = false;
            }
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            // Add dialog to input new Group and insert into database
            // string input = Microsoft.VisualBasic.Interaction.InputBox("Enter new Group", "New Group", "", 500, 500);   // Old Visual Basic input box
            string inputValue = null;
            DialogResult input = ShowInputDialog(ref inputValue);       //  C# function for dialog box
            if (input == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(inputValue))
                {
                    Status = "NULL. No Group entered";
                }
                else
                {
                    DatabaseHelper.AddGroup(inputValue);
                    UpdateGroupsGridview();
                }
            }
            else
            {
                Status = "Cancel. No Group entered";
            }
        }
        private void UpdateGroupsGridview()
        {

            // Populate the Groups data grid view
            dgvGroups.DataSource = null;
            dgvGroups.Columns.Clear();
            dgvGroups.Rows.Clear();
            dgvGroups.DataBindings.Clear();
            dgvGroups.Refresh();

            _groupItemsBindingSource.DataSource = _packItemsManager.Groups;

            //cbGroups.DataSource = _groupItemsBindingSource.DataSource;
            //cbGroups.DisplayMember = "GroupName";
            //cbGroups.ValueMember = "GroupName";
            if (_groupItemsBindingSource.Count > 0)
            {
                dgvGroups.DataSource = _groupItemsBindingSource.DataSource;
                dgvGroups.Columns["GroupName"].Width = 200;
                dgvGroups.Columns["GroupName"].HeaderText = "Group Name";
                dgvGroups.Columns["GroupName"].SortMode = DataGridViewColumnSortMode.Automatic;
                dgvGroups.Columns["ListOrder"].Width = 75;
                dgvGroups.Columns["ListOrder"].HeaderText = "List Order";
                dgvGroups.Columns["ListOrder"].SortMode = DataGridViewColumnSortMode.Automatic;
                DataGridViewButtonColumn bc = new DataGridViewButtonColumn();
                bc.HeaderText = "Action";
                bc.Text = "Delete";
                bc.Name = "Delete";
                bc.HeaderText = "Delete";
                bc.SortMode = DataGridViewColumnSortMode.NotSortable;
                bc.UseColumnTextForButtonValue = true;
                bc.Width = 50;
                dgvGroups.Columns.Add(bc);
                dgvGroups.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dgvGroups_EditingControlShowing);
            }
            else
            {
                //dt.Columns.Add("TagName", typeof(string));
                DataTable dt = new DataTable();
                dt.Columns.Add("GroupName");
                DataRow dr = dt.NewRow();
                dr["GroupName"] = "No Groups";
                dt.Rows.Add(dr);
                dgvGroups.DataSource = dt;
            }
            dgvGroups.Refresh();
        }
        void dgvGroups_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (!IsHandleAdded && dgvGroups.CurrentCell.ColumnIndex == 1)
            {
                System.Windows.Forms.TextBox tx = e.Control as System.Windows.Forms.TextBox;
                if (tx != null)
                {
                    tx.KeyPress += new KeyPressEventHandler(tx_KeyPress);
                    this.IsHandleAdded = true;
                }
            }
        }
        void tx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || e.KeyChar == '\b'))
            {
                e.Handled = true;
                //e.Handled = !char.IsDigit(e.KeyChar);   // allows digits only, integer (no decimal)
            }
        }
        private void dgvGroups_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                //TODO - Button Clicked - Execute Code Here
                int idx = e.RowIndex;
                DataGridViewRow dr = senderGrid.Rows[idx];
                string val = Convert.ToString(dr.Cells["GroupName"].Value);

                DialogResult result = MessageBox.Show("Are you sure you want to delete group " + val + "?", "Confirm Delete Data", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    DatabaseHelper.DeleteGroupName(val);
                    Status = "Deleted Group " + val;
                }
                else
                {
                    Status = "Not deleting group " + val;
                }
                UpdateGroupsGridview();
                updateStatus("Selected Item - " + val);
            }
            else if (senderGrid.Columns[e.ColumnIndex] is DataGridViewTextBoxColumn && e.RowIndex >= 0)
            {
                int idx = e.RowIndex;
                DataGridViewRow dr = senderGrid.Rows[idx];
                string val = Convert.ToString(dr.Cells["GroupName"].Value);
                updateStatus("DataGridViewTextBoxColumn Selected. Order value is " + val);
                //dgvGroups.BeginEdit(true);

                //dgvGroups.EndEdit();
            }
            else if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            {
                int idx = e.RowIndex;
                DataGridViewRow dr = senderGrid.Rows[idx];
                string val = Convert.ToString(dr.Cells["GroupName"].Value);
                updateStatus("Selected order - " + val);
            }
        }
        private void dgvGroups_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                updateStatus("Leaving ListOrder column cell in Groups gridview. Row: " + e.RowIndex);
                DataGridViewRow row = dgvGroups.Rows[e.RowIndex];
                string groupName = ((PackItemsWt.GroupItem)dgvGroups.Rows[e.RowIndex].DataBoundItem).GroupName;
                string val = Convert.ToString(dgvGroups.Rows[e.RowIndex].Cells["ListOrder"].Value);
                if (String.IsNullOrEmpty(val)) { val = "0"; }
                string valedit = Convert.ToString(dgvGroups.Rows[e.RowIndex].Cells["ListOrder"].EditedFormattedValue);
                if (String.IsNullOrEmpty(valedit)) { valedit = "0"; }
                int listOrder = 0;
                if (val == valedit)
                {
                    listOrder = Convert.ToInt32(val);
                }
                else
                {
                    listOrder = Int32.Parse(valedit);
                    _packItemsManager.GroupItemUpdate(groupName, listOrder);
                }
            }
        }

        private void btnAddTags_Click(object sender, EventArgs e)
        {
            // Add dialog to input new Tags and insert into database
            string inputValue = null;
            DialogResult input = ShowInputDialog(ref inputValue);       //  C# function for dialog box
            if (input == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(inputValue))
                {
                    Status = "NULL. No Tag entered";
                }
                else
                {
                    DatabaseHelper.AddTag(inputValue);
                    UpdateTagsGridView();
                }
            }
            else
            {
                Status = "Cancel. No Tag entered";
            }
        }
        private void UpdateTagsGridView() {
            // Populate the Tags data grid view
            dgvTags.DataSource = null;
            dgvTags.Columns.Clear();
            dgvTags.Rows.Clear();
            dgvTags.DataBindings.Clear();
            dgvTags.Refresh();
            //TagItem tagItem = new TagItem();
            _tagItemsBindingSource.DataSource = _packItemsManager.Tags;
            //cbTags.DataSource = _tagItemsBindingSource.DataSource;
            //cbTags.DisplayMember = "TagName";
            //cbTags.ValueMember = "TagName";
            if (_tagItemsBindingSource.Count > 0)
            {
                dgvTags.DataSource = _tagItemsBindingSource.DataSource;
                dgvTags.Columns[0].Width = 200;
                dgvTags.Columns["TagName"].HeaderText = "Tag Name";
                dgvTags.Columns["TagName"].SortMode = DataGridViewColumnSortMode.Automatic;
                DataGridViewButtonColumn bc = new DataGridViewButtonColumn();
                bc.HeaderText = "Action";
                bc.Text = "Delete";
                bc.Name = "Delete";
                bc.HeaderText = "Delete";
                bc.SortMode = DataGridViewColumnSortMode.NotSortable;
                bc.UseColumnTextForButtonValue = true;
                bc.Width = 50;
                dgvTags.Columns.Add(bc);
                dgvTags.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dgvTags_EditingControlShowing);
            }
            else
            {
                //dt.Columns.Add("TagName", typeof(string));
                DataTable dt = new DataTable();
                dt.Columns.Add("TagName");
                DataRow dr = dt.NewRow();
                dr["TagName"] = "No Tags";
                dt.Rows.Add(dr);
                dgvTags.DataSource = dt;
            }
            dgvTags.Refresh();
        }
        void dgvTags_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (!IsHandleAdded && dgvTags.CurrentCell.ColumnIndex == 0)
            {
                System.Windows.Forms.TextBox tx = e.Control as System.Windows.Forms.TextBox;
                if (tx != null)
                {
                    tx.KeyPress += new KeyPressEventHandler(tx_KeyPress);
                    this.IsHandleAdded = true;
                }
            }
        }
        private void dgvTags_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                //TODO - Button Clicked - Execute Code Here  ///// Delete button is no longer in the Data Grid View.  This is unused. //////
                int idx = e.RowIndex;
                DataGridViewRow dr = senderGrid.Rows[idx];
                string val = Convert.ToString(dr.Cells["TagName"].Value);

                DialogResult result = MessageBox.Show("Are you sure you want to delete tag " + val + "?", "Confirm Delete Data", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    DatabaseHelper.DeleteTagName(val);
                    Status = "Deleted tag " + val;
                }
                else
                {
                    Status = "Not deleting tag " + val;
                }
                UpdateTagsGridView();
                updateStatus(val);
            }
            else if (senderGrid.Columns[e.ColumnIndex] is DataGridViewTextBoxColumn && e.RowIndex >= 0)
            {
                int idx = e.RowIndex;
                DataGridViewRow dr = senderGrid.Rows[idx];
                string val = Convert.ToString(dr.Cells["TagName"].Value);
                updateStatus("DataGridViewTextBoxColumn Selected. Order value is " + val);
            }
        }
        
        private void dgvItemsEditSetup() {
            dgvItemsEdit.DataSource = null;
            dgvItemsEdit.Rows.Clear();
            dgvItemsEdit.Columns.Clear();
            dgvItemsEdit.DataBindings.Clear();
            dgvItemsEdit.ReadOnly = false;

            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            cmb.DisplayMember = "GroupName";
            cmb.ValueMember = "GroupName";
            cmb.DataPropertyName = "GroupName";
            cmb.HeaderText = "Group Name";
            cmb.Width = 120;
            cmb.SortMode = DataGridViewColumnSortMode.Automatic;
            cmb.DataSource = _packItemsManager.Groups;
            dgvItemsEdit.Columns.Add(cmb);
        }
        private void dgvItemsEditFormat() {
            // Change DataGridView
            dgvItemsEdit.Columns["Id"].Visible = false;
            //dgvItemsEdit.Columns["GroupName"].Width = 120;
            //dgvItemsEdit.Columns["GroupName"].ReadOnly = true;
            //dgvItemsEdit.Columns["GroupName"].Visible = false;
            dgvItemsEdit.Columns["Item"].Width = 140;
            dgvItemsEdit.Columns["Item"].ReadOnly = false;
            dgvItemsEdit.Columns["Item"].SortMode = DataGridViewColumnSortMode.Automatic;
            dgvItemsEdit.Columns["grams"].Width = 50;
            dgvItemsEdit.Columns["grams"].ReadOnly = false;
            dgvItemsEdit.Columns["grams"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvItemsEdit.Columns["ounces"].Width = 50;
            dgvItemsEdit.Columns["ounces"].ReadOnly = true;
            dgvItemsEdit.Columns["ounces"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvItemsEdit.Columns["lb"].Width = 40;
            dgvItemsEdit.Columns["lb"].ReadOnly = true;
            dgvItemsEdit.Columns["lb"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvItemsEdit.Columns["oz"].Width = 40;
            dgvItemsEdit.Columns["oz"].ReadOnly = true;
            dgvItemsEdit.Columns["oz"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvItemsEdit.Columns["New"].Width = 40;
            dgvItemsEdit.Columns["New"].ReadOnly = false;
            dgvItemsEdit.Columns["New"].SortMode = DataGridViewColumnSortMode.Automatic;
            dgvItemsEdit.Columns["Selected"].Width = 50;
            dgvItemsEdit.Columns["Selected"].SortMode = DataGridViewColumnSortMode.Automatic;
            dgvItemsEdit.Columns["Selected"].ReadOnly = false;
            dgvItemsEdit.Columns["Tags"].Width = 120;
            dgvItemsEdit.Columns["Tags"].ReadOnly = true;
            dgvItemsEdit.Columns["Tags"].SortMode = DataGridViewColumnSortMode.Automatic;
            dgvItemsEdit.Columns["Notes"].Width = 120;
            dgvItemsEdit.Columns["Notes"].ReadOnly = false;
            dgvItemsEdit.Columns["Notes"].SortMode = DataGridViewColumnSortMode.Automatic;


            //dgvItemsEdit.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dgvItemsEdit_EditingControlShowing);

            //   DataGridViewComboBoxColumn groupNameColumn = (DataGridViewComboBoxColumn)dgvItemsEdit.Columns["GroupName"];
            //_groupItemsBindingSource.DataSource = _packItemsManager.Groups;
            //  groupNameColumn.DataSource = _packItemsManager.Groups;   //_groupItemsBindingSource.DataSource;
            //  groupNameColumn.DisplayMember = "GroupName";
            //  groupNameColumn.ValueMember = "GroupName";
            //  groupNameColumn.DataPropertyName = "GroupName";
            //dgvItemsEdit.Columns["GroupName"].DataPropertyName = "GroupName";
            //dgvItemsEdit.Columns["GroupName"].Visible = false;

            //DataGridViewComboBoxColumn tagsColumn = (DataGridViewComboBoxColumn)dgvItemsEdit.Columns["tagName"];
            //tagsColumn.DataSource = _packItemsManager.Tags; 
            //tagsColumn.DisplayMember = "TagName";
            //tagsColumn.ValueMember = "TagName";
            //tagsColumn.DataPropertyName = "TagName";
            //dgvItemsEdit.Columns["Tags"].Visible = false;

            //id, groupName, item, grams, ounces, lb, oz, notes, _new, selected, tags
            
        }
        public void UpdateItemsEditGridview()
        {
            dgvItemsEditSetup();
            
            //_packItemsBindingSource.SupportsFiltering - BindingList does not supprt this
            _packItemsBindingSource.DataSource = _packItemsManager.Items;
            dgvItemsEdit.DataSource = _packItemsBindingSource.DataSource;

            dgvItemsEditFormat();
        }

        void dgvItemsEdit_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (!IsHandleAdded && dgvGroups.CurrentCell.ColumnIndex == 1)
            {
                System.Windows.Forms.TextBox tx = e.Control as System.Windows.Forms.TextBox;
                if (tx != null)
                {
                    tx.KeyPress += new KeyPressEventHandler(dgvItemsEdit_tx_KeyPress);
                    this.IsHandleAdded = true;
                }
            }
        }
        void dgvItemsEdit_tx_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || e.KeyChar == '\b'))
            {
                e.Handled = true;
                //e.Handled = !char.IsDigit(e.KeyChar);   // allows digits only, integer (no decimal)
            }
        }
        private void dgvItemsEdit_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            updateStatus("Leaving Cell Column:" + e.ColumnIndex + " Row:" + e.RowIndex);
            currentRow = dgvItemsEdit.CurrentRow;
            if (e.ColumnIndex == dgvItemsEdit.Columns["grams"].Index)
            {
                updateStatus("grams modified");
                Int32 gm = Convert.ToInt32(currentRow.Cells["grams"].EditedFormattedValue);
                double ounces = gm / gramsPerOunce;
                int pound = (int)(ounces / 16);
                double oz = ounces % 16;

                currentRow.Cells["ounces"].Value = ounces.ToString("0.##"); //String.Format("{0.N2}",ounces);
                currentRow.Cells["lb"].Value = String.Format("{0}", pound); ;
                currentRow.Cells["oz"].Value = oz.ToString("0.00");  //String.Format("{0.##}", oz);

            }
            string val = Convert.ToString(currentRow.Cells[e.ColumnIndex].Value);
            string valEdit = Convert.ToString(currentRow.Cells[e.ColumnIndex].EditedFormattedValue);
            if (val != valEdit)
            {
                dgvItemEditChanged = true;
                // value in cell changed.  Save the row
            }
        }
        private void dgvItemsEdit_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            updateStatus("CellValueChanged.  Column:" + e.ColumnIndex + " Row:" + e.RowIndex);

        }
        private void dgvItemsEdit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                //TODO - Button Clicked - Execute Code Here
                //int idx = e.RowIndex;
                //DataGridViewRow dr = senderGrid.Rows[idx];
                currentRow = dgvItemsEdit.CurrentRow;
                string val = Convert.ToString(currentRow.Cells["Id"].Value);
                labelInfo.Text = val;

                dgvItemsEdit.CurrentCell = dgvItemsEdit.Rows[e.RowIndex].Cells[2];
/*
                // Display a form to Edit, Add, and Delete Items
                panelView.BorderStyle = BorderStyle.Fixed3D;
                if (_formLoaded)
                {
                    ItemsData itemsData = new ItemsData();
                    itemsData.TopLevel = false;

                    if (panelView.Controls.Count > 0)
                    {
                        panelView.Controls.Clear();
                    }
                    panelView.Controls.Add(itemsData);
                    itemsData.BringToFront();
                    itemsData.Show();
                }
*/
            }
        }
         private void dgvItemsEdit_KeyDown(object sender, KeyEventArgs e)
        {
            int idx = ((System.Windows.Forms.DataGridView)sender).CurrentRow.Index;
            int id = Convert.ToInt32(((System.Windows.Forms.DataGridView)sender).CurrentRow.Cells["Id"].Value);
            string item = Convert.ToString(((System.Windows.Forms.DataGridView)sender).CurrentRow.Cells["Item"].Value);
            updateStatus("Key Down event.  Row: " + idx + "  Item:" + item + " Id:" + id);
            if (e.KeyCode == Keys.Delete)
            {
                updateStatus("Delete this record with a prompt");
                _packItemsManager.PackItemDelete(item);
                UpdateItemsEditGridview();
                dgvItemsEdit.CurrentCell = dgvItemsEdit.Rows[0].Cells[2];
                // remove row from data grid view

            }
            if (e.KeyCode == Keys.Insert)
            {
                updateStatus("Insert new record");
                // Dislpay Items form as Add
            }
        }

        private void dgvItemsEdit_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            //senderGrid.SelectedRows[0].Cells[0].Value
            //var dtr0 = senderGrid.CurrentRow;
            //var dtr1 = senderGrid.SelectedRows[0];
            //((PackItemsWt.PackItem)dr.DataBoundItem).GroupName

            updateStatus("Enter new row. Display row in ItemsData edit form.  Row: " + e.RowIndex);
            //int idx = e.RowIndex;
            //DataGridViewRow dr = senderGrid.Rows[idx];
            //PackItem currentRow = ((PackItemsWt.PackItem)dr.DataBoundItem);

            currentRow = dgvItemsEdit.CurrentRow;
            string val = "0";
            if (dgvItemsEdit.CurrentRow != null)
            {
                val = Convert.ToString(currentRow.Cells["Id"].Value);
            }
            labelInfo.Text = val;
            
/*
            // Display a form to Edit, Add, and Delete Items
            panelView.BorderStyle = BorderStyle.Fixed3D;
            if (_formLoaded)
            {
                dgvItemsEdit.CurrentCell = dgvItemsEdit.Rows[e.RowIndex].Cells[2];
                ItemsData itemsData = new ItemsData();
                itemsData.TopLevel = false;


                if (panelView.Controls.Count > 0)
                {
                    panelView.Controls.Clear();
                }
                panelView.Controls.Add(itemsData);
                itemsData.BringToFront();
                itemsData.Show();
            }
*/
        }

        private void dgvItemsEdit_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            updateStatus("Leaving Row " + e.RowIndex);
            DataGridViewRow row = dgvItemsEdit.CurrentRow;
            if (dgvItemEditChanged)
            {
                // The values have changed in this row.  Save the record
                SaveItem(row);
                dgvItemEditChanged = false;
            }
            //Change ItemsData to the new row selected.  Done in RowEnter
            //UpdateItemsEditGridview();
        }
        private void SaveItem(DataGridViewRow row)
        {
            // Write code to update current selected entry in SQLite table
            PackItem packItem = new PackItem();  
            
            packItem.Id = Convert.ToInt32(row.Cells["id"].Value);
            packItem.grams = Convert.ToInt32(row.Cells["grams"].EditedFormattedValue);
            packItem.ounces = Convert.ToDecimal(row.Cells["ounces"].EditedFormattedValue);
            packItem.lb = Convert.ToInt32(row.Cells["lb"].EditedFormattedValue);
            packItem.oz = Convert.ToDecimal(row.Cells["oz"].EditedFormattedValue);
            packItem.Tags = Convert.ToString(row.Cells["tags"].EditedFormattedValue);
            packItem.New = Convert.ToBoolean(row.Cells["new"].EditedFormattedValue);
            packItem.Selected = Convert.ToBoolean(row.Cells["selected"].EditedFormattedValue);
            packItem.Notes = Convert.ToString(row.Cells["notes"].EditedFormattedValue);
            packItem.Item = Convert.ToString(row.Cells["item"].EditedFormattedValue);
            packItem.GroupName = Convert.ToString(row.Cells[1].Value);    //GroupName
            _packItemsManager.PackItemUpdate(packItem);
            // Update DataGridView row
        }

        private void dgvItemsEdit_CurrentCellChanged(object sender, EventArgs e)
        {
            //DataGRidViewRow sndr = DataGridViewRow sender;
            // Display a form to Edit, Add, and Delete Items
            panelView.BorderStyle = BorderStyle.Fixed3D;
            if (_formLoaded)
            {
                ItemsData itemsData = new ItemsData();
                itemsData.TopLevel = false;


                if (panelView.Controls.Count > 0)
                {
                    panelView.Controls.Clear();
                }
                panelView.Controls.Add(itemsData);
                itemsData.BringToFront();
                itemsData.Show();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvItemsEditSetup();   // See if the e sends the value of the search button to select the type of search //
            
            var senderBtn = (System.Windows.Forms.Button)sender;
            //Search Item field
            switch (senderBtn.Name)
            {
                case "btnSearchItem":
                    if (tbSearchItem.Text == null || tbSearchItem.Text == "") { 
                        UpdateItemsEditGridview(); 
                    } else {
                        _packItemsBindingSource.DataSource = _packItemsManager.ItemsFilter("Item", tbSearchItem.Text);
                        dgvItemsEdit.DataSource = _packItemsBindingSource.DataSource;
                    }
                    break;
                case "btnSearchGroupName":
                    if (tbSearchGroupName.Text == null || tbSearchGroupName.Text == "") { 
                        UpdateItemsEditGridview(); 
                    } else {
                        _packItemsBindingSource.DataSource = _packItemsManager.ItemsFilter("Group", tbSearchGroupName.Text);
                        dgvItemsEdit.DataSource = _packItemsBindingSource.DataSource;

                    }
                    break;
                case "btnSearchTag":
                    if (tbSearchTag.Text == null || tbSearchTag.Text == "") { 
                        UpdateItemsEditGridview(); 
                    } else {
                        _packItemsBindingSource.DataSource = _packItemsManager.ItemsFilter("Tag", tbSearchTag.Text);
                        dgvItemsEdit.DataSource = _packItemsBindingSource.DataSource;

                    }
                    break;
                case "btnSearchNew":
                    _packItemsBindingSource.DataSource = _packItemsManager.ItemsFilter("New", tbSearchTag.Text);
                    dgvItemsEdit.DataSource = _packItemsBindingSource.DataSource;
                    break;
                case "btnSearchSelected":
                    _packItemsBindingSource.DataSource = _packItemsManager.ItemsFilter("Selected", tbSearchTag.Text);
                    dgvItemsEdit.DataSource = _packItemsBindingSource.DataSource;
                    break;
                default:
                    UpdateItemsEditGridview();
                    break;
            }
            
            dgvItemsEditFormat();
        }
        public static formItemsList itemsList;
        private void listViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (itemsList == null || itemsList.IsDisposed)
            {
                itemsList = new formItemsList();
            }
            itemsList.BringToFront();
            itemsList.Show();
        }
    }
}