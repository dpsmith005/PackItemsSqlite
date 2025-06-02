using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackItemsSqlite
{
    public partial class MainForm : Form
    {
        private PackItemsManager _packItemsManager;
        private BindingSource _packItemsBindingSource = new BindingSource();
        private BindingSource _groupItemsBindingSource = new BindingSource();
        private BindingSource _tagItemsBindingSource = new BindingSource();
        private Boolean _formLoaded = false;
        const Double gramsPerOunce = 28.3495;
        const Double ouncesPerGram = 0.035274;
        bool dgvItemEditChanged = false;
        public MainForm()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            _Form1 = this;

            _packItemsManager = new PackItemsManager(new PackItemsRepository());

            label1.Visible = false;
        }
        public static MainForm _Form1;
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
            return label1.Text;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DatabaseHelper status = new DatabaseHelper();
            ItemsData itemsData = new ItemsData();

            // Populate Group combo box and Group data grid view
            UpdateGroupsGridview();

            // Populate Tag combo box and Tags data grid view
            UpdateTagsGridview();

            // Populate the Items data grid view
            UpdateItemsGridview();

            _formLoaded = true;
            updateStatus("Main form load");
        }
        public string Status
        {
            get { return tbStatus.Text; }
            set { tbStatus.Text = value; }
        }
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpInfo helpInfo = new HelpInfo();
            helpInfo.Show();
        }
        private void labelClose_Click(object sender, EventArgs e)
        {
            DatabaseHelper.closeDB();
            this.Close();
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public void panelHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void AddGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Group data added from CSV
            DatabaseHelper.AddGroupsFromCsv(DatabaseHelper.csvGroupsFile);
            updateStatus("Added Groups from CSV");
            UpdateGroupsGridview();
        }
        private void AddTagsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Tags data added from CSV
            DatabaseHelper.AddTagsFromCsv(DatabaseHelper.csvTagsFile);
            //MessageBox.Show("Added Tags from CSV file");
            updateStatus("Added Tags from CSV");
            UpdateTagsGridview();
        }
        private void AddItemsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Items data added from CSV
            DatabaseHelper.AddItemsFromCsv(DatabaseHelper.csvDataFile);
            updateStatus("Added Items from CSV");
            UpdateItemsGridview();
            UpdateGroupsGridview();
            UpdateTagsGridview();
        }
        private void AddDataToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Items data added from CSV
            DatabaseHelper.AddDataFromCsv(DatabaseHelper.csvDataFile);
            updateStatus("Added Items from CSV");
            UpdateItemsGridview();
            UpdateGroupsGridview();
            UpdateTagsGridview();
        }
        private void deleteAllDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete all the data?", "Confirm Delete Data", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                tbStatus.Clear();
                DatabaseHelper.DeleteAllData();
                Status = "Deleted all rows from tables\r\n";
                UpdateItemsGridview();
                UpdateGroupsGridview();
                UpdateTagsGridview();
            }
            else
            {
                Status = "Data not deleted";
            }
        }
        private void exportDataToCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DataTable dt = DatabaseHelper.GetAllItems();
            List<PackItem> items = new List<PackItem>();
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
        private void tabControl1_Click(object sender, EventArgs e)
        {
            lblExistingTags.Visible = false;
            lbTagsList.Visible = false;

            string tabName = tabControl1.SelectedTab.Text;
            updateStatus("Tab control clicked - " + tabName);
            if (tabControl1.SelectedTab.Text == "Items")
            {
                panel4.Visible = true;
            }
            else if (tabControl1.SelectedTab.Text == "Groups")
            {
                panel4.Visible = false;
                UpdateGroupsGridview();
            }
            else if (tabControl1.SelectedTab.Text == "Tags")
            {
                panel4.Visible = false;
                UpdateTagsGridview();
            }
            else if (tabControl1.SelectedTab.Text == "Items Edit")
            {
                panel4.Visible = true;
                lblExistingTags.Visible = true;
                lbTagsList.Visible = true;
                lbTagsList.Items.Clear();
                foreach (TagItem item in _packItemsManager.Tags)
                {
                    lbTagsList.Items.Add(item.TagName);
                }
                lbTagsList.ClearSelected();
                UpdateItemsEditGridview();
            }
            else if (tabControl1.SelectedTab.Text == "Admin")
            {
                // Add Admin items
                PackItem item = new PackItem();
                item.Item = "New Item";
                item.GroupName = "NewGroup";
                item.grams = 100;

                //_packitems.Add(item.Id, item);
            }
        }
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl1.SelectedTab.Text == "Items" | tabControl1.SelectedTab.Text == "Items Edit")
            {
                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
                cbGroups.Visible = true;
                cbTags.Visible = true;
                tbItemInput.Visible = true;
            }
            else
            {
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                cbGroups.Visible = false;
                cbTags.Visible = false;
                tbItemInput.Visible = false;
            }
        }
        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            // Add dialog to input new Group and insert into database
            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter new Group", "New Group", "", 500, 500);
            if (string.IsNullOrEmpty(input))
            {
                Status = "No group entered";
            }
            else
            {
                DatabaseHelper.AddGroup(input);
            }
            UpdateGroupsGridview();

        }
        private void btnAddTags_Click(object sender, EventArgs e)
        {
            // Add dialog to input new Tags and insert into database
            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter new Tag", "New Tag", "", 500, 500);
            if (string.IsNullOrEmpty(input))
            {
                Status = "No tag entered";
            }
            else
            {
                DatabaseHelper.AddTag(input);
            }
            UpdateTagsGridview();
        }
        public void UpdateItemsEditGridview()
        {
            dgvItems.DataSource = null;
            dgvItems.Rows.Clear();
            dgvItems.Columns.Clear();
            dgvItems.DataBindings.Clear();
            //dgvItems.DataSource = DatabaseHelper.GetItems();
            _packItemsBindingSource.DataSource = _packItemsManager.Items;
            dgvItemsEdit.DataSource = _packItemsBindingSource.DataSource;
            //dgvItemsEdit.Columns["GroupName"].Visible = false;

            DataGridViewComboBoxColumn groupNameColumn = (DataGridViewComboBoxColumn)dgvItemsEdit.Columns["GroupName"];
            //_groupItemsBindingSource.DataSource = _packItemsManager.Groups;
            groupNameColumn.DataSource = _packItemsManager.Groups;   //_groupItemsBindingSource.DataSource;
            groupNameColumn.DisplayMember = "GroupName";
            groupNameColumn.ValueMember = "GroupName";
            groupNameColumn.DataPropertyName = "GroupName";
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
        public void UpdateItemsGridview()
        {
            // Populate the Items data grid view
            dgvItems.DataSource = null;
            dgvItems.Rows.Clear();
            dgvItems.Columns.Clear();
            dgvItems.DataBindings.Clear();
            //dgvItems.DataSource = DatabaseHelper.GetItems();
            _packItemsBindingSource.DataSource = _packItemsManager.ItemsDGV;
            dgvItems.DataSource = _packItemsBindingSource.DataSource;
            //dgvItems.DataSource = _packItemsManager.ItemsDGV;

            dgvItems.Columns[0].Width = 175;
            dgvItems.Columns[1].Width = 100;
            dgvItems.Columns[2].Width = 125;
            dgvItems.Columns[3].Visible = false;
            DataGridViewButtonColumn bc = new DataGridViewButtonColumn();
            bc.HeaderText = "Action";
            bc.Text = "Details";
            bc.Name = "Details";
            bc.UseColumnTextForButtonValue = true;
            bc.Width = 50;
            dgvItems.Columns.Add(bc);
            dgvItems.Refresh();
            panel4.Visible = true;
        }
        private bool IsHandleAdded;
        private void UpdateGroupsGridview()
        {
            // Populate the Groups data grid view
            dgvGroups.DataSource = null;
            dgvGroups.Columns.Clear();
            dgvGroups.Rows.Clear();
            dgvGroups.DataBindings.Clear();
            dgvGroups.Refresh();

            _groupItemsBindingSource.DataSource = _packItemsManager.Groups;
            cbGroups.DataSource = _groupItemsBindingSource.DataSource;
            cbGroups.DisplayMember = "GroupName";
            cbGroups.ValueMember = "GroupName";
            if (_groupItemsBindingSource.Count > 0)
            {
                dgvGroups.DataSource = _groupItemsBindingSource.DataSource;
                dgvGroups.Columns[0].Width = 200;
                dgvGroups.Columns[1].Width = 70;
                dgvGroups.Columns[1].ReadOnly = false;
                dgvGroups.Columns[1].Visible = false;
                //DataGridTextBox dgTextBox = new DataGridTextBox();
                DataGridViewTextBoxColumn tbc = new DataGridViewTextBoxColumn();
                tbc.HeaderText = "Order";
                tbc.Name = "Order";
                tbc.Width = 50;
                dgvGroups.Columns.Add(tbc);
                //dgTextBox.Text = dgvGroups.Columns[1].

                DataGridViewButtonColumn bc = new DataGridViewButtonColumn();
                bc.HeaderText = "Action";
                bc.Text = "Delete";
                bc.Name = "Delete";
                bc.UseColumnTextForButtonValue = true;
                bc.Width = 50;
                dgvGroups.Columns.Add(bc);

                foreach (DataGridViewRow row in dgvGroups.Rows)
                {
                    int val = (int)row.Cells["ListOrder"].Value;
                    row.Cells["Order"].Value = val;
                    row.Cells["Order"].ReadOnly = false;
                }
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
        private void UpdateTagsGridview()
        {
            // Populate the Tags data grid view
            dgvTags.DataSource = null;
            dgvTags.Columns.Clear();
            dgvTags.Rows.Clear();
            dgvTags.DataBindings.Clear();
            dgvTags.Refresh();
            //TagItem tagItem = new TagItem();
            _tagItemsBindingSource.DataSource = _packItemsManager.Tags;
            cbTags.DataSource = _tagItemsBindingSource.DataSource;
            cbTags.DisplayMember = "TagName";
            cbTags.ValueMember = "TagName";
            if (_tagItemsBindingSource.Count > 0)
            {
                dgvTags.DataSource = _tagItemsBindingSource.DataSource;
                dgvTags.Columns[0].Width = 200;
                DataGridViewButtonColumn bc = new DataGridViewButtonColumn();
                bc.HeaderText = "Action";
                bc.Text = "Delete";
                bc.Name = "Delete";
                bc.UseColumnTextForButtonValue = true;
                bc.Width = 50;
                dgvTags.Columns.Add(bc);
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
        private void cbGroups_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!_formLoaded) { return; }
            if (cbGroups.Items.Count > 0)
            {
                if (cbGroups.SelectedValue == null) { return; }

                string selValue = cbGroups.SelectedValue.ToString();
                updateStatus(selValue);
                //List<PackItemDGV> packItemDGVs = new List<PackItemDGV>();
                //packItemDGVs = _packItemsManager.GetItemsFilter("Group",selValue);
                // Add search for group selected and update items data grid view
                dgvItems.DataSource = _packItemsManager.GetItemsFilter("Group", selValue);
                //updateStatus("Filtered by Group - " + selValue);
            }
        }
        private void cbTags_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!_formLoaded) { return; }
            if (cbTags.Items.Count > 0)
            {
                if (cbTags.SelectedItem == null) { return; }
                string selValue = cbTags.SelectedValue.ToString();
                updateStatus(selValue);
                // Add search for tag selected and update items data grid view
                //dgvItems.DataSource = DatabaseHelper.GetItem("Tag", selValue);
                dgvItems.DataSource = _packItemsManager.GetItemsFilter("Tag", selValue);
                //updateStatus("Filtered by Tag - " + selValue);
            }
        }
        private void tbItemInput_Leave(object sender, EventArgs e)
        {
            string selValue = tbItemInput.Text;
            updateStatus("Leaving item input.  Value is " + selValue);
            // Add search for item (%selValue%) entered and update items data grid view
            //dgvItems.DataSource = DatabaseHelper.GetItem("Item", selValue);
            dgvItems.DataSource = _packItemsManager.GetItemsFilter("Item", selValue);
            //updateStatus("Filtered by Item - " + selValue);
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
                dgvGroups.BeginEdit(true);

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
        private void dgvTags_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                //TODO - Button Clicked - Execute Code Here
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
                UpdateTagsGridview();
                //updateStatus(val);
            }
        }
        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                //TODO - Button Clicked - Execute Code Here
                int idx = e.RowIndex;
                DataGridViewRow dr = senderGrid.Rows[idx];
                string val = Convert.ToString(dr.Cells["Id"].Value);
                label1.Text = val;

                // Display a form to Edit, Add, and Delete Items
                panel4.BorderStyle = BorderStyle.Fixed3D;
                ItemsData itemsData = new ItemsData();
                itemsData.TopLevel = false;


                if (panel4.Controls.Count > 0)
                {
                    panel4.Controls.Clear();
                }
                panel4.Controls.Add(itemsData);
                itemsData.BringToFront();
                itemsData.Show();
            }
        }
        private void tbStatus_TextChanged(object sender, EventArgs e)
        {
            string val = Status;
            if (val.Contains("Deleted item from table"))
            {
                UpdateItemsGridview();
                dgvItems.DataSource = _packItemsManager.GetItemsFilter("Item", "");
            }
            else if (val.Contains("Updated item in table"))
            {
                dgvItems.DataSource = _packItemsManager.GetItemsFilter("Item", "");
                //UpdateItemsGridview();
            }
            else if (val.Contains("Inserted item into table"))
            {
                dgvItems.DataSource = _packItemsManager.GetItemsFilter("Item", "");
                //UpdateItemsGridview();
            }

        }
        void dgvGroups_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (!IsHandleAdded && dgvGroups.CurrentCell.ColumnIndex == 2)
            {
                TextBox tx = e.Control as TextBox;
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
        private void dgvGroups_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                updateStatus("Leaving Order column cell in Groups gridview. Row: " + e.RowIndex);
                DataGridViewRow row = dgvGroups.Rows[e.RowIndex];
                string groupName = ((PackItemsSqlite.GroupItem)dgvGroups.Rows[e.RowIndex].DataBoundItem).GroupName;
                string val = Convert.ToString(dgvGroups.Rows[e.RowIndex].Cells["Order"].Value);
                if (String.IsNullOrEmpty(val)) { val = "0"; }
                string valedit = Convert.ToString(dgvGroups.Rows[e.RowIndex].Cells["Order"].EditedFormattedValue);
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
        private void dgvItemsEdit_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            updateStatus("Leaving Cell Column:" + e.ColumnIndex + " Row:" + e.RowIndex);
            DataGridViewRow row = dgvItemsEdit.CurrentRow;
            if (e.ColumnIndex == dgvItemsEdit.Columns["grams"].Index)
            {
                updateStatus("grams modified");
                Int32 gm = Convert.ToInt32(row.Cells["grams"].EditedFormattedValue);
                double ounces = gm / gramsPerOunce;
                int pound = (int)(ounces / 16);
                double oz = ounces % 16;

                row.Cells["ounces"].Value = ounces.ToString("0.##"); //String.Format("{0.N2}",ounces);
                row.Cells["lb"].Value = String.Format("{0}", pound); ;
                row.Cells["oz"].Value = oz.ToString("0.00");  //String.Format("{0.##}", oz);

            }
            string val = Convert.ToString(row.Cells[e.ColumnIndex].Value);
            string valEdit = Convert.ToString(row.Cells[e.ColumnIndex].EditedFormattedValue);
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
            //Change ItemsData to the new row selected
            //UpdateItemsEditGridview();
        }
        private void SaveItem(DataGridViewRow row)
        {
            // Write code to update current selected entry in SQLite table
            PackItem packItem = new PackItem();
            packItem.Id = Convert.ToInt32(row.Cells["id"].Value);
            packItem.GroupName = Convert.ToString(row.Cells["groupName"].Value);

            packItem.grams = Convert.ToInt32(row.Cells["grams"].EditedFormattedValue);
            packItem.ounces = Convert.ToDecimal(row.Cells["ounces"].EditedFormattedValue);
            packItem.lb = Convert.ToInt32(row.Cells["lb"].EditedFormattedValue);
            packItem.oz = Convert.ToDecimal(row.Cells["oz"].EditedFormattedValue);
            packItem.Tags = Convert.ToString(row.Cells["tags"].EditedFormattedValue);
            packItem.New = Convert.ToBoolean(row.Cells["_new"].EditedFormattedValue);
            packItem.Selected = Convert.ToBoolean(row.Cells["selected"].EditedFormattedValue);
            packItem.Notes = Convert.ToString(row.Cells["notes"].EditedFormattedValue);
            packItem.Item = Convert.ToString(row.Cells["item"].EditedFormattedValue);
            _packItemsManager.ItemUpdate(packItem);
            // Update DataGridView row
        }

        private void dgvItemsEdit_KeyDown(object sender, KeyEventArgs e)
        {
            int idx = ((System.Windows.Forms.DataGridView)sender).CurrentRow.Index;
            int id = Convert.ToInt32(((System.Windows.Forms.DataGridView)sender).CurrentRow.Cells["Id"].Value);
            string item = Convert.ToString(((System.Windows.Forms.DataGridView)sender).CurrentRow.Cells["Item"].Value);
            updateStatus("Key Down event.  Row: " + idx + "  Item:" + item);
            if (e.KeyCode == Keys.Delete)
            {
                updateStatus("Delete this record with a prompt");
                _packItemsManager.ItemDelete(item);
                UpdateItemsEditGridview();
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

            updateStatus("Enter new row. Display row in ItemsData edit form.  Row: " + e.RowIndex);
            int idx = e.RowIndex;
            DataGridViewRow dr = senderGrid.Rows[idx];
            string val = Convert.ToString(dr.Cells["Id"].Value);
            label1.Text = val;

            // Display a form to Edit, Add, and Delete Items
            panel4.BorderStyle = BorderStyle.Fixed3D;
            ItemsData itemsData = new ItemsData();
            itemsData.TopLevel = false;


            if (panel4.Controls.Count > 0)
            {
                panel4.Controls.Clear();
            }
            panel4.Controls.Add(itemsData);
            itemsData.BringToFront();
            itemsData.Show();
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {

        }
    }
}
