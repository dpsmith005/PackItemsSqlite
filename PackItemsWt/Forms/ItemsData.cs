using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PackItemsWt    //.Forms
{
    public partial class ItemsData : Form
    {
        private PackItemsManager _packItemsManager;
        private BindingSource _packItemsBindingSource = new BindingSource();
        private BindingSource _groupItemsBindingSource = new BindingSource();
        private BindingSource _tagItemsBindingSource = new BindingSource();
        //private string _selItem;
        public DataGridViewRow _selectedRow;
        const Double gramsPerOunce = 28.3495;
        const Double ouncesPerGram = 0.035274;
        public ItemsData()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            _formItemsData = this;

            _packItemsManager = new PackItemsManager();

            lbStatus.Text = ""; // No status message unless errors detected during save.

            // Populate Group combo box
            //cbGroupNames.DataSource = DatabaseHelper.GetGroups();
            //GroupItem groupItem = new GroupItem();
            _groupItemsBindingSource.DataSource = _packItemsManager.Groups;
            cbGroupNames.DataSource = _groupItemsBindingSource.DataSource;
            cbGroupNames.DisplayMember = "GroupName";
            cbGroupNames.ValueMember = "GroupName";
            cbGroupNames.SelectedIndex = -1;    //Sets to nothing selected

            // Populate the Tags ListBox
            TagItem tagItem = new TagItem();
            _tagItemsBindingSource.DataSource = _packItemsManager.Tags;
            //DataTable dt = DatabaseHelper.GetTags();
            //foreach(DataRow dr in dt.Rows)
            //{
            //    lbTags.Items.Add(Convert.ToString(dr["TagName"]));
            //}
            foreach (TagItem item in _packItemsManager.Tags)
            {
                lbTags.Items.Add(item.TagName);
            }
            lbTags.ClearSelected();

        }

        public static ItemsData _formItemsData;
        private void ItemsData_Load(object sender, EventArgs e)
        {

            LoadItemsData();

            // Need Add and Edit mode
            // Add mode has Save and Cancel
            // Edit mode has Save.  To cancel select another item
            // Delete button will delete the selected item.  Pop-up to confirm delete.  No delete button for Add mode
            // https://www.youtube.com/watch?v=sXjwdF26QMk&list=PLnlZRDFqtSn3EbRcRPn_LBDzj97p0H0U4&index=38  videos 38-59 in the list OOP

        }
        private void LoadItemsData()
        {

            //_selItem = MainForm._Form1.selectedItem();
            _selectedRow = formMain._Form1.selectedRow();
            //_selectedRow = MainForm._Form1.currentRow;
            if (_selectedRow == null)
            {
                lbStatus.Text = "Error retrieving record";
            } else
            {
                lblSelectedItem.Text = Convert.ToString(_selectedRow.Cells["Id"].Value);  //_selItem; 

                if (_selectedRow.Cells.Count == 11)
                {
                    //dt = DatabaseHelper.GetItem("SingleItem", selItem);
                    //List<PackItem> packItem = new List<PackItem>();
                    //packItem = _packItemsManager.GetSinglePackItem(_selItem);
                    //var dtr = packItem[0];

                    //DataRow dr = dt.Rows[0];
                    // parse dr in class PackItems.PackItem
                    PackItem item = new PackItem();
                    item.Id = Convert.ToInt32(_selectedRow.Cells["Id"].Value);    // dtr.Id;
                    lblSelectedItem.Text = item.Id.ToString();
                    item.GroupName = Convert.ToString(_selectedRow.Cells[1].Value);     //dtr.GroupName;
                    item.Item = Convert.ToString(_selectedRow.Cells["Item"].Value);     //dtr.Item;
                    item.grams = Convert.ToInt32(_selectedRow.Cells["grams"].Value);    //dtr.grams;        // Validate this is a number
                    item.ounces = Convert.ToDecimal(_selectedRow.Cells["ounces"].Value);  // dtr.ounces;      //calculate before storing  
                    item.lb = Convert.ToInt32(_selectedRow.Cells["lb"].Value);          //dtr.lb;           //calculate before storing  
                    item.oz = Convert.ToDecimal(_selectedRow.Cells["oz"].Value);          //dtr.oz;            //calculate before storing  
                    item.Notes = Convert.ToString(_selectedRow.Cells["Notes"].Value);   //dtr.Notes;
                    item.New = Convert.ToBoolean(_selectedRow.Cells["New"].Value);      //dtr.New;
                    item.Selected = Convert.ToBoolean(_selectedRow.Cells["Selected"].Value); //dtr.Selected;
                    item.Tags = Convert.ToString(_selectedRow.Cells["Tags"].Value);     //dtr.Tags;

                    cbGroupNames.SelectedIndex = cbGroupNames.FindString(item.GroupName);
                    tbItem.Text = item.Item;
                    tbGrams.Text = Convert.ToString(item.grams);
                    tbOunces.Text = Convert.ToString(item.ounces);  //calculated: grams * 28.3495 (This i grams per ounce.  0.035274 is oz/gm)
                    tbLb.Text = Convert.ToString(item.lb);          //calculated: ounces % 16
                    tbOz.Text = Convert.ToString(item.oz);          //calculated: ounces - ((ounces % 16) * 16)
                    tbNotes.Text = item.Notes;
                    cbNew.Checked = item.New;
                    cbSelected.Checked = item.Selected;
                    lbTags.ClearSelected();   // Need to check items in comma seperated tags list

                    if (!String.IsNullOrEmpty(item.Tags))
                    {
                        string[] tags = item.Tags.Split(',');
                        foreach (string tag in tags)
                        {
                            int idx = lbTags.FindString(tag);
                            if (idx >= 0)
                            {
                                lbTags.SetSelected(idx, true);
                            }
                        }
                    }
                    // Loop through item.Tags to check the box for the tags.

                    lblSelectedItem.Visible = false;
                }
                else
                {
                    lbStatus.Text = "No Record Selected in Items data grid view";
                }
            }
        }
        private void tbGrams_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar);   // allows digits only, integer (no decimal)
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            // clear will enable the Add and Cancel, disable the Save, Delete and Clear
            btnClear.Enabled = false;
            btnAdd.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnCancel.Enabled = true;
            // Clear the data from the form to all new item to be entered
            lblSelectedItem.Text = "";
            cbGroupNames.SelectedIndex = -1;
            tbItem.Text = "";
            tbGrams.Text = "";
            tbOunces.Text = "";  //calculated: grams * 28.3495 (This i grams per ounce.  0.035274 is oz/gm)
            tbLb.Text = "";      //calculated: ounces % 16
            tbOz.Text = "";      //calculated: ounces - ((ounces % 16) * 16)
            tbNotes.Text = "";
            cbNew.Checked = false;
            cbSelected.Checked = false;
            lbTags.ClearSelected();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Write code to insert new entry in SQLite table
            PackItem packItem = new PackItem();
            //packItem.Id = Convert.ToInt32(lblSelectedItem.Text);
            if (cbGroupNames.SelectedIndex == -1)//Nothing selected
            {
                MessageBox.Show("You must select a group", "Error");
                return;
            }
            else
            {
                packItem.GroupName = cbGroupNames.SelectedValue.ToString();
            }
            if (String.IsNullOrEmpty(tbItem.Text))
            {
                MessageBox.Show("You must enter Item name", "Error");
                return;
            }
            else
            {
                packItem.Item = tbItem.Text;
            }
            if (String.IsNullOrEmpty(tbGrams.Text))
            {
                packItem.grams = 0;
                packItem.ounces = 0;
                packItem.lb = 0;
                packItem.oz = 0;

            }
            else
            {
                packItem.grams = Convert.ToInt32(tbGrams.Text);
                packItem.ounces = Convert.ToDecimal(tbOunces.Text);
                packItem.lb = Convert.ToInt32(tbLb.Text);
                packItem.oz = Convert.ToDecimal(tbOz.Text);

            }
            packItem.Notes = tbNotes.Text;
            packItem.New = cbNew.Checked;
            packItem.Selected = cbSelected.Checked;
            //string finalStr = String.Join(", ", lbTags.SelectedItems);  // s.Cast<string>);   //.Cast<string>());
            string finalStr = "";
            foreach (var item in lbTags.SelectedItems)
            {
                //finalStr += string.Join(", ", lbTags.GetItemText(item));
                finalStr += lbTags.GetItemText(item) + ",";
            }
            finalStr = finalStr.TrimEnd(',');
            packItem.Tags = finalStr;

            _packItemsManager.PackItemInsert(packItem);

            // Add new item.  Cancel button should appear.  Delete button should be hidden
            btnClear.Enabled = true;
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnDelete.Enabled = true;
            btnCancel.Enabled = false;

            // Update items datagridview ???
            formMain._Form1.UpdateItemsEditGridview();

            // *****HERE*****
            // Refresh Items Edit
            /*
                        if (MainForm._Form1.tabControl1.SelectedTab.Text == "Items")
                        {
                            MainForm._Form1.UpdateItemsGridview();
                        }
                        else if (MainForm._Form1.tabControl1.SelectedTab.Text == "Items Edit")
                        {
                            MainForm._Form1.UpdateItemsEditGridview();
                        }
            */
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            btnClear.Enabled = true;
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnDelete.Enabled = true;
            btnCancel.Enabled = false;
            // Write code to update current selected entry in SQLite table
            PackItem packItem = new PackItem();
            packItem.Id = Convert.ToInt32(lblSelectedItem.Text);
            packItem.GroupName = cbGroupNames.SelectedValue.ToString();
            packItem.Item = tbItem.Text;
            packItem.grams = Convert.ToInt32(tbGrams.Text);
            packItem.ounces = Convert.ToDecimal(tbOunces.Text);
            packItem.lb = Convert.ToInt32(tbLb.Text);
            packItem.oz = Convert.ToDecimal(tbOz.Text);
            packItem.Notes = tbNotes.Text;
            packItem.New = cbNew.Checked;
            packItem.Selected = cbSelected.Checked;
            //string finalStr = String.Join(", ", lbTags.SelectedItems);  // s.Cast<string>);   //.Cast<string>());
            string finalStr = "";
            foreach (var item in lbTags.SelectedItems)
            {
                //finalStr += string.Join(", ", lbTags.GetItemText(item));
                finalStr += lbTags.GetItemText(item) + ",";
            }
            finalStr = finalStr.TrimEnd(',');
            packItem.Tags = finalStr;

            _packItemsManager.PackItemUpdate(packItem);
            // Update items datagridview ???
            formMain._Form1.UpdateItemsEditGridview();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            btnClear.Enabled = true;
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnDelete.Enabled = true;
            btnCancel.Enabled = false;
            // code to delete item from table, with prompt "Are you sure you want to delete this item"
            _packItemsManager.PackItemDelete(tbItem.Text);
            formMain._Form1.UpdateItemsEditGridview();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Cancel button should only be visible with add button
            btnClear.Enabled = true;
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnDelete.Enabled = true;
            btnCancel.Enabled = false;
            // populate previously selected item
            LoadItemsData();
        }

        private void tbGrams_Leave(object sender, EventArgs e)
        {
            //Update the ounces, lb and oz fields
            if (!String.IsNullOrEmpty(tbGrams.Text))
            {
                Int32 gm = Convert.ToInt32(tbGrams.Text);
                double ounces = gm / gramsPerOunce;
                int pound = (int)(ounces / 16);
                double oz = ounces % 16;
                tbOunces.Text = ounces.ToString("0.##"); //String.Format("{0.N2}",ounces);
                tbLb.Text = String.Format("{0}", pound);
                tbOz.Text = oz.ToString("0.00");  //String.Format("{0.##}", oz);
            }
        }

        private void lbTags_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
