using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.InteropServices;

namespace PackItemsWt.Forms
{
    public partial class formItemsList : Form
    {
        private PackItemsManager _packItemsManager;
        private BindingSource _packItemsListBindingSource = new BindingSource();
        private BindingSource _groupItemsBindingSource = new BindingSource();
        private BindingSource _tagItemsBindingSource = new BindingSource();
        private System.Data.DataTable dt = new System.Data.DataTable();
        const Double gramsPerOunce = 28.3495;
        const Double ouncesPerGram = 0.035274;
        // Create a Dictionary of items per group for printing
        Dictionary<string, List<string>> itemsPrint = new Dictionary<string, List<string>>();
        // Create a new dictionary of decimal, with key of group name for group grams total
        Dictionary<string, decimal> grpTotals = new Dictionary<string, decimal>();
        // Generate a list that can be displayed and printed
        List<string> rowList = new List<string>();
        private int firstCharOnPage;

        public formItemsList()
        {
            InitializeComponent();
            //this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.OnPrintPage);

            _packItemsManager = new PackItemsManager();

            // Initialize Group Names combo box
            _groupItemsBindingSource.DataSource = _packItemsManager.Groups;
            lboxGroupNames.DataSource = _groupItemsBindingSource.DataSource;
            lboxGroupNames.DisplayMember = "GroupName";
            lboxGroupNames.ValueMember = "GroupName";
            lboxGroupNames.ClearSelected();    //Sets to nothing selected

            // Initialize tags list box
            _tagItemsBindingSource.DataSource = _packItemsManager.Tags;
            lboxTags.DataSource = _packItemsManager.Tags;
            lboxTags.ValueMember = "tagName";
            /*  foreach (TagItem item in _packItemsManager.Tags) { lboxTags.Items.Add(item.TagName);  }       */
            lboxTags.ClearSelected();
        }
        private void ItemsList_Load(object sender, EventArgs e)
        {
            UpdateItemsListGridview();

            foreach (String printer in PrinterSettings.InstalledPrinters)
            {
                cboxPrinters.Items.Add(printer.ToString());
            }


        }
        private void UpdateItemsListGridview()
        {
            dgvItemsList.DataSource = null;
            dgvItemsList.Rows.Clear();
            dgvItemsList.Columns.Clear();
            dgvItemsList.DataBindings.Clear();
            dgvItemsList.ReadOnly = false;



            dt = _packItemsManager.ItemsList;
            _packItemsListBindingSource.DataSource = dt;     // _packItemsManager.ItemsList;
            _packItemsListBindingSource.Sort = "ListOrder ASC, Item ASC";    //"Item ASC";   // "Item ASC, ListOrder ASC";
            dgvItemsList.DataSource = _packItemsListBindingSource.DataSource;
            dgvItemsList.Columns["ListOrder"].HeaderText = "LO";
            dgvItemsList.Columns["ListOrder"].Width = 40;
            dgvItemsList.Columns["ListOrder"].DisplayIndex = 0;
            dgvItemsList.Columns["ListOrder"].SortMode = DataGridViewColumnSortMode.Automatic;
            dgvItemsList.Columns["GroupName"].Width = 100;
            dgvItemsList.Columns["GroupName"].DisplayIndex = 1;
            dgvItemsList.Columns["GroupName"].SortMode = DataGridViewColumnSortMode.Automatic;
            dgvItemsList.Columns["Item"].Width = 200;
            dgvItemsList.Columns["Item"].DisplayIndex = 2;
            dgvItemsList.Columns["Item"].SortMode = DataGridViewColumnSortMode.Automatic;
            dgvItemsList.Columns["grams"].Width = 50;
            dgvItemsList.Columns["grams"].DisplayIndex = 3;
            dgvItemsList.Columns["grams"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvItemsList.Columns["ounces"].Width = 50;
            dgvItemsList.Columns["ounces"].DisplayIndex = 4;
            dgvItemsList.Columns["ounces"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvItemsList.Columns["lb"].Width = 40;
            dgvItemsList.Columns["lb"].DisplayIndex = 5;
            dgvItemsList.Columns["lb"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvItemsList.Columns["oz"].Width = 40;
            dgvItemsList.Columns["oz"].DisplayIndex = 6;
            dgvItemsList.Columns["oz"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvItemsList.Columns["New"].Width = 65;
            dgvItemsList.Columns["New"].DisplayIndex = 7;
            dgvItemsList.Columns["New"].SortMode = DataGridViewColumnSortMode.Automatic;
            dgvItemsList.Columns["Selected"].Width = 75;
            dgvItemsList.Columns["Selected"].DisplayIndex = 8;
            dgvItemsList.Columns["Selected"].SortMode = DataGridViewColumnSortMode.Automatic;
            dgvItemsList.Columns["Tags"].Width = 160;
            dgvItemsList.Columns["Tags"].DisplayIndex = 9;
            dgvItemsList.Columns["Tags"].SortMode = DataGridViewColumnSortMode.Automatic;
            dgvItemsList.Columns["Notes"].Width = 450;
            dgvItemsList.Columns["Notes"].DisplayIndex = 10;
            dgvItemsList.Columns["Notes"].SortMode = DataGridViewColumnSortMode.Automatic;
        }
        private void btnrefresh_Click(object sender, EventArgs e)
        {
            UpdateItemsListGridview();

            _packItemsListBindingSource.Filter = null;
            cbFilterNew.Checked = false;
            cbFilterSelected.Checked = false;
            lboxTags.SelectedItems.Clear();
            lboxGroupNames.SelectedItems.Clear();
        }
        private void cbGroupName_Click(object sender, EventArgs e)
        {
            var senderCB = (System.Windows.Forms.CheckBox)sender;
            string cName = senderCB.Name;
            string cbText = senderCB.Text;
            string cbTag = senderCB.Tag.ToString();
            bool isChecked = senderCB.Checked;

            dgvItemsList.Columns[cbTag].Visible = isChecked;
        }

        private void cbFilterSelected_Click(object sender, EventArgs e)
        {
            var senderCB = (System.Windows.Forms.CheckBox)sender;
            string cbName = senderCB.Name;
            string cbText = senderCB.Text;
            string cbTag = senderCB.Tag.ToString();
            bool isChecked = senderCB.Checked;
            if (isChecked)
            {
                // select only items with Selected = 1
                _packItemsListBindingSource.Filter = string.Format("Selected = 'True'");
            }
            else
            {
                _packItemsListBindingSource.Filter = null;
            }
            cbFilterNew.Checked = false;
            lboxTags.SelectedItems.Clear();
            lboxGroupNames.SelectedItems.Clear();
        }

        private void cbFilterNew_Click(object sender, EventArgs e)
        {
            var senderCB = (System.Windows.Forms.CheckBox)sender;
            string cbName = senderCB.Name;
            string cbText = senderCB.Text;
            string cbTag = senderCB.Tag.ToString();
            bool isChecked = senderCB.Checked;
            if (isChecked)
            {
                // select only items with New = 1
                _packItemsListBindingSource.Filter = string.Format("New = 'True'");
            }
            else
            {
                _packItemsListBindingSource.Filter = null;
            }
            cbFilterSelected.Checked = false;
            lboxTags.SelectedItems.Clear();
            lboxGroupNames.SelectedItems.Clear();
        }

        private void lboxTags_Click(object sender, EventArgs e)
        {
            var senderLB = (System.Windows.Forms.ListBox)sender;
            string lbName = senderLB.Name;
            string lbText = senderLB.Text;
            var lbItems = senderLB.SelectedItems;
            int ct = 1;
            string filter = null;
            if (lbItems.Count > 0)
            {
                foreach (var item in lbItems)
                {
                    //_packItemsListBindingSource.Filter = string.Format("Tags = '{0}'", ((PackItemsWt.TagItem)item).TagName);
                    if (ct > 1)
                    {
                        filter += " or " + string.Format("Tags = '{0}'", ((PackItemsWt.TagItem)item).TagName);
                    }
                    else
                    {
                        filter = string.Format("Tags = '{0}'", ((PackItemsWt.TagItem)item).TagName);
                    }
                    // Have to build out filer for multiple selections
                    ct++;
                    // Have to build out filer for multiple selections
                }
                _packItemsListBindingSource.Filter = filter;
            }
            else
            {
                _packItemsListBindingSource.Filter = null;
            }
            cbFilterNew.Checked = false;
            cbFilterSelected.Checked = false;
            lboxGroupNames.SelectedItems.Clear();
        }

        private void lboxGroupNames_Click(object sender, EventArgs e)
        {
            var senderLB = (System.Windows.Forms.ListBox)sender;
            string lbName = senderLB.Name;
            string lbText = senderLB.Text;
            var lbItems = senderLB.SelectedItems;
            int ct = 1;
            string filter = null;
            if (lbItems.Count > 0)
            {
                foreach (var item in lbItems)
                {
                    //_packItemsListBindingSource.Filter = string.Format("GroupName = '{0}'", ((PackItemsWt.GroupItem)item).GroupName);
                    if (ct > 1)
                    {
                        filter += " or " + string.Format("GroupName = '{0}'", ((PackItemsWt.GroupItem)item).GroupName);
                    }
                    else
                    {
                        filter = string.Format("GroupName = '{0}'", ((PackItemsWt.GroupItem)item).GroupName);
                    }
                    // Have to build out filer for multiple selections
                    ct++;
                }
                _packItemsListBindingSource.Filter = filter;
            }
            else
            {
                _packItemsListBindingSource.Filter = null;
            }
            cbFilterNew.Checked = false;
            cbFilterSelected.Checked = false;
            lboxTags.SelectedItems.Clear();
        }

        private void cbCSV_Click(object sender, EventArgs e)
        {
            var senderCB = (System.Windows.Forms.CheckBox)sender;
            if (senderCB.Checked)
            {
                btnGenerateList.Enabled = true;
            }
            if (!cbPrint.Checked && !cbCSV.Checked)
            {
                btnGenerateList.Enabled = false;
            }
            if (senderCB.Name == "cbPrint")
            {
                GenerateListItems();
                richTextBoxEx1.Rtf = GenerateRtfList();
            }

        }
        private void rtfList_Click(object sender, EventArgs e)
        {
            GenerateListItems();
            richTextBoxEx1.Rtf = GenerateRtfList();
        }
        private void btnGenerateList_Click(object sender, EventArgs e)
        {
            // Create the list items to save as CSV
            GenerateListItems();

            // Export list data to csv if CSV checkbox is checked
            if (cbCSV.Checked)
            {
                SaveFileDialog fileSelect = new SaveFileDialog();
                fileSelect.Title = "Browse File Location";
                fileSelect.DefaultExt = "csv";
                fileSelect.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
                fileSelect.FilterIndex = 0;
                fileSelect.CheckPathExists = true;
                if (fileSelect.ShowDialog() == DialogResult.OK)
                {
                    string filenameCSV = fileSelect.FileName;
                    if (File.Exists(filenameCSV))
                    {
                        File.Delete(filenameCSV);
                    }
                    // Create file and write rows
                    var file = File.Create(filenameCSV);
                    file.Close();
                    foreach (string row in rowList)
                    {
                        TextWriter sw = new StreamWriter(filenameCSV, true);
                        sw.WriteLine(row.ToString());
                        sw.Close();
                    }
                }
            }

            // Save the list to a RTF file and PDF file
            if (cbPrint.Checked)
            {
                // Create RTF as single column or multi column
                if (rbSingle.Checked)
                {
                    richTextBoxEx1.Rtf = GenerateRtfList();
                }

                // Select file name to save PDF
                SaveFileDialog fileSelect = new SaveFileDialog();
                fileSelect.Title = "Browse File Location";
                fileSelect.DefaultExt = "pdf";
                fileSelect.Filter = "pdf files (*.pdf)|*.pdf|All files (*.*)|*.*";
                fileSelect.FilterIndex = 0;
                fileSelect.CheckPathExists = true;
                if (fileSelect.ShowDialog() == DialogResult.OK)
                {
                    string filenamePDF = fileSelect.FileName;
                    if (File.Exists(filenamePDF))
                    {
                        File.Delete(filenamePDF);
                    }
                    // Create file and write rows
                    var file = File.Create(filenamePDF);
                    file.Close();

                    if (cboxPrinters.SelectedItem != null) { string printerName = cboxPrinters.SelectedItem.ToString(); }

                    // Next create a list that is pdf format and send to 'Microsoft Print to PDF'
                    //if (printDialog1.ShowDialog() == DialogResult.OK)  { }
                    printDocument1.PrinterSettings = new PrinterSettings()
                    {
                        // set the printer to 'Microsoft Print to PDF'
                        PrinterName = "Microsoft Print to PDF",

                        // tell the object this document will print to file
                        PrintToFile = true,

                        // set the filename to whatever you like (full path)
                        PrintFileName = filenamePDF   //Path.Combine(directory, file + ".pdf"),
                    };
                    printDocument1.Print();

                    string rtfText = GenerateRtfList();

                    // Save as RTF file
                    //string rtfFileName = ".\\..\\Files\\" + Path.GetFileNameWithoutExtension(file.Name) + ".rtf";
                    string rtfFileName = (file.Name).Replace(".pdf", ".rtf");
                    File.WriteAllText(rtfFileName, rtfText);
                    var rtfData = File.ReadAllText(rtfFileName);
                }
            }
        }

        private void GenerateListItems()
        {
            // Clear all dictionary items used for CSV and PDF
            itemsPrint.Clear();
            grpTotals.Clear();
            rowList.Clear();

            // Weights to display
            bool wtTotal = cbWeightTotal.Checked;
            bool wtGroup = cbGroupTotal.Checked;

            // Variable for total weight in grams.  Add conversions for total ounces, pounds & ounces.  All set to 0 to start
            decimal total = 0;
            string prevGroup = null;
            foreach (var grp in _packItemsManager.Groups)
            {
                if (grpTotals.ContainsKey(grp.GroupName))
                {
                    grpTotals[grp.GroupName] = total;
                }
                else
                {
                    grpTotals.Add(grp.GroupName, total);
                }
            }

            // Build Headers
            List<string> headerItems = new List<string>();
            foreach (DataGridViewColumn column in dgvItemsList.Columns)
            {
                if (column.Visible)
                {
                    headerItems.Add(column.Name);
                }
            }
            string header = String.Join(",", headerItems);
            rowList.Add(header);    //AddingNewEventArgs the header for CSV output or rowlist
            _packItemsListBindingSource.Sort = "ListOrder ASC, Item ASC";     // the list order is string so sorting is wrong
            foreach (DataGridViewRow row in dgvItemsList.Rows)
            {
                string grpName = row.Cells["GroupName"].Value.ToString();
                if (prevGroup == null)
                {
                    prevGroup = grpName;
                }

                // Add items to dictionary for printing
                if (itemsPrint.ContainsKey(grpName))
                {
                    itemsPrint[grpName].Add(row.Cells["Item"].Value.ToString());
                }
                else
                {
                    itemsPrint.Add(grpName, new List<string> { row.Cells["Item"].Value.ToString() });
                }

                // calculate the running total weight in grams
                decimal grams = Convert.ToDecimal(row.Cells["grams"].Value);
                total = decimal.Add(total, grams);

                // build the CSV line based on column visible
                List<string> rowItems = new List<string>();
                foreach (DataGridViewColumn column in dgvItemsList.Columns)
                {
                    // Calculate the group weight total
                    if (column.Name == "grams")
                    {
                        grpTotals[grpName] = decimal.Add(grpTotals[grpName], grams);
                    }

                    // If the column is visible, include the value
                    if (column.Visible)
                    {
                        rowItems.Add(row.Cells[column.Name].Value.ToString());
                    }
                    //row.Cells[column.Name].Visible    row.Cells[column.Name].Value     column.Name     column.Visible
                }
                string line = String.Join(",", rowItems);
                rowList.Add(line);

                // Check if new group, then add group total if checkbox is selected
                if (grpName != prevGroup)
                {
                    prevGroup = grpName;
                    if (wtGroup)
                    {
                        Int32 gm = Convert.ToInt32(total);
                        double ounces = gm / gramsPerOunce;
                        string strOunces = ounces.ToString("N2");
                        int pound = (int)(ounces / 16);
                        double oz = ounces % 16;
                        string strOz = oz.ToString("N2");
                        string strFormat = String.Format("Group Total grams,{0},Ounces,{1},total lb,{2},total oz,{3}", gm, strOunces, pound, strOz);
                        rowList.Add(strFormat);
                    }
                }
            }
            //itemsPrint["Pack"].Count % 3;  itemsPrint["Pack"].Count /3+1

            if (wtTotal)
            {
                Int32 gm = Convert.ToInt32(total);
                double ounces = (gm / gramsPerOunce);
                string strOunces = ounces.ToString("N2");
                int pound = (int)(ounces / 16);
                double oz = ounces % 16;
                string strOz = oz.ToString("N2");
                string strFormat = String.Format("Total grams,{0},Total ounces,{1},total lb,{2},total oz,{3}", gm, strOunces, pound, strOz);
                rowList.Add(strFormat);
            }
        }
        private string GenerateRtfList()
        {

            // Weights to display
            bool wtTotal = cbWeightTotal.Checked;
            bool wtGroup = cbGroupTotal.Checked;
            decimal total = 0;

            string rtfText;
            string top = @"{\rtf1\ansi\ansicpg1252\deff0\nouicompat{\fonttbl{\f0\fnil\fcharset0 Calibri;}{\f1\fnil\fcharset2 Wingdings;}}
{\colortbl ;\red0\green0\blue0;}
{\*\generator Riched20 10.0.19041}\viewkind4\uc1 
\paperw12240\paperh15840\margl720\margr720\margt720\margb720\gutter0\ltrsect 
\pard\sa200\sl276\slmult1\b\f0\fs28\lang9 Packing List \b0\fs22\par
";
            rtfText = top;

            foreach (var grpName in itemsPrint.Keys)   // _packItemsManager.Groups)
            {
                //string grpName = grp.GroupName;
                string subGroup = "\r\n\\pard\\sl276\\slmult1\\b\\fs24 " + grpName + " \\b0\\par\r\n";
                rtfText = rtfText + subGroup;
                string line = "";
                bool firstLine = true;
                bool firstColumn = true;
                int colCount = 1;
                // calculate the running total weight in grams
                total = decimal.Add(total, grpTotals[grpName]);
                foreach (string item in itemsPrint[grpName])
                {
                    if (rbSingle.Checked)
                    {

                        if (firstLine)
                        {
                            firstLine = false;
                            line = "\r\n\\pard\\sl276\\slmult1\\tx3600\\tx6480\\cf1\\f1\\fs22\\'a8\\cf0\\f0 " + item + "\\par\r\n";
                        }
                        else
                        {
                            line += "\\cf1\\f1\\'a8\\cf0\\f0 " + item + "\\par\r\n";
                        }
                    }
                    else if (rbMulti.Checked)
                    {
                        if (firstColumn)
                        {
                            firstColumn = false;
                            line = "\\trowd\\trgaph10\\trpaddl10\\trpaddr10\\trpaddfl3\\trpaddfr3\r\n\\cellx3475\\cellx6770\\cellx10450 \r\n\\pard\\intbl\\sa200\\sl276\\slmult1\r\n";
                        }
                        line += "\\cf1\\f1\\'a8\\cf0\\f0  " + item + "\\cell";
                        colCount++;
                        if (colCount == 4)
                        {
                            colCount = 1;
                            line += "\\row\r\n";
                        }
                    }
                }
                if (rbMulti.Checked) { rtfText += line + "\\row\r\n"; }
                if (rbSingle.Checked) { rtfText += line; }

                if (wtGroup)
                {
                    Int32 gm = Convert.ToInt32(grpTotals[grpName]);
                    double ounces = (gm / gramsPerOunce);
                    string strOunces = ounces.ToString("N2");
                    int pound = (int)(ounces / 16);
                    double oz = ounces % 16;
                    string strOz = oz.ToString("N2");
                    string subGroupWt = String.Format("\r\n\\pard\\sa200\\sl276\\slmult1\\b Group Weight - {0} grams   {1} ounces  :  {2} lb {3} oz \\b0\\par", gm.ToString(), strOunces, pound.ToString(), strOz);
                    rtfText += subGroupWt;
                } else
                {
                    rtfText += "\r\n\\pard\\sl276\\slmult1\\tx3600\\tx6480 \\par\r\n"; 
                }

            }
            if (wtTotal)
            {
                Int32 gm = Convert.ToInt32(total);
                double ounces = (gm / gramsPerOunce);
                string strOunces = ounces.ToString("N2");
                int pound = (int)(ounces / 16);
                double oz = ounces % 16;
                string strOz = oz.ToString("N2");
                //string strFormat = String.Format("Total grams:{0}   Total ounces: {1}   total lb: {2}   total oz: {3}", gm, strOunces, pound, strOz);
                string footer = String.Format("\r\n\\pard\\sl276\\b\\slmult1 Total Weight - Total grams:{0}   Total ounces: {1}   total lb: {2}   total oz: {3} \\par\r\n\\b0\\par \r\n\\par\r\n}}", gm.ToString(), strOunces, pound.ToString(), strOz);
                rtfText += footer;
            }
            richTextBoxEx1.Rtf = rtfText;
            return rtfText;
        }

        private void printDocument1_BeginPrint(object sender, PrintEventArgs e)
        {
            // Start at the beginning of the text
            firstCharOnPage = 0;
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            firstCharOnPage = richTextBoxEx1.FormatRange(false, e, firstCharOnPage, richTextBoxEx1.TextLength);
            // check if there are more pages to print
            if (firstCharOnPage < richTextBoxEx1.TextLength)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
        }

        private void printDocument1_EndPrint(object sender, PrintEventArgs e)
        {
            // Clean up cached information
            richTextBoxEx1.FormatRangeDone();
        }

    }
}
