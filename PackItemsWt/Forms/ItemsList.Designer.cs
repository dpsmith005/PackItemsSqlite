namespace PackItemsWt.Forms
{
    partial class formItemsList
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
            this.dgvItemsList = new System.Windows.Forms.DataGridView();
            this.btnrefresh = new System.Windows.Forms.Button();
            this.cbGroupName = new System.Windows.Forms.CheckBox();
            this.cbListOrder = new System.Windows.Forms.CheckBox();
            this.cbItem = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbGrams = new System.Windows.Forms.CheckBox();
            this.cbOunces = new System.Windows.Forms.CheckBox();
            this.cbLb = new System.Windows.Forms.CheckBox();
            this.cbOz = new System.Windows.Forms.CheckBox();
            this.cbNew = new System.Windows.Forms.CheckBox();
            this.cbSelected = new System.Windows.Forms.CheckBox();
            this.cbTags = new System.Windows.Forms.CheckBox();
            this.cbNotes = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFilterSelected = new System.Windows.Forms.CheckBox();
            this.cbFilterNew = new System.Windows.Forms.CheckBox();
            this.lboxTags = new System.Windows.Forms.ListBox();
            this.lboxGroupNames = new System.Windows.Forms.ListBox();
            this.cbWeightTotal = new System.Windows.Forms.CheckBox();
            this.cbGroupTotal = new System.Windows.Forms.CheckBox();
            this.btnGenerateList = new System.Windows.Forms.Button();
            this.cboxPrinters = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbCSV = new System.Windows.Forms.CheckBox();
            this.cbPrint = new System.Windows.Forms.CheckBox();
            this.rbMulti = new System.Windows.Forms.RadioButton();
            this.rbSingle = new System.Windows.Forms.RadioButton();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.richTextBoxEx1 = new PackItemsWt.Utils.RichTextBoxEx();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemsList)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvItemsList
            // 
            this.dgvItemsList.AllowUserToAddRows = false;
            this.dgvItemsList.AllowUserToDeleteRows = false;
            this.dgvItemsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvItemsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemsList.Location = new System.Drawing.Point(3, 28);
            this.dgvItemsList.MultiSelect = false;
            this.dgvItemsList.Name = "dgvItemsList";
            this.dgvItemsList.ReadOnly = true;
            this.dgvItemsList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItemsList.Size = new System.Drawing.Size(1335, 490);
            this.dgvItemsList.TabIndex = 0;
            this.dgvItemsList.TabStop = false;
            // 
            // btnrefresh
            // 
            this.btnrefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnrefresh.Location = new System.Drawing.Point(1272, 0);
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.Size = new System.Drawing.Size(65, 27);
            this.btnrefresh.TabIndex = 1;
            this.btnrefresh.Text = "Refresh";
            this.btnrefresh.UseVisualStyleBackColor = true;
            this.btnrefresh.Click += new System.EventHandler(this.btnrefresh_Click);
            // 
            // cbGroupName
            // 
            this.cbGroupName.AutoSize = true;
            this.cbGroupName.Checked = true;
            this.cbGroupName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbGroupName.Location = new System.Drawing.Point(173, 6);
            this.cbGroupName.Name = "cbGroupName";
            this.cbGroupName.Size = new System.Drawing.Size(55, 17);
            this.cbGroupName.TabIndex = 4;
            this.cbGroupName.Tag = "GroupName";
            this.cbGroupName.Text = "Group";
            this.cbGroupName.UseVisualStyleBackColor = true;
            this.cbGroupName.Click += new System.EventHandler(this.cbGroupName_Click);
            // 
            // cbListOrder
            // 
            this.cbListOrder.AutoSize = true;
            this.cbListOrder.Checked = true;
            this.cbListOrder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbListOrder.Location = new System.Drawing.Point(103, 6);
            this.cbListOrder.Name = "cbListOrder";
            this.cbListOrder.Size = new System.Drawing.Size(71, 17);
            this.cbListOrder.TabIndex = 5;
            this.cbListOrder.Tag = "ListOrder";
            this.cbListOrder.Text = "List Order";
            this.cbListOrder.UseVisualStyleBackColor = true;
            this.cbListOrder.Click += new System.EventHandler(this.cbGroupName_Click);
            // 
            // cbItem
            // 
            this.cbItem.AutoSize = true;
            this.cbItem.Checked = true;
            this.cbItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbItem.Location = new System.Drawing.Point(234, 6);
            this.cbItem.Name = "cbItem";
            this.cbItem.Size = new System.Drawing.Size(46, 17);
            this.cbItem.TabIndex = 6;
            this.cbItem.Tag = "Item";
            this.cbItem.Text = "Item";
            this.cbItem.UseVisualStyleBackColor = true;
            this.cbItem.Click += new System.EventHandler(this.cbGroupName_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Columns to display";
            // 
            // cbGrams
            // 
            this.cbGrams.AutoSize = true;
            this.cbGrams.Checked = true;
            this.cbGrams.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbGrams.Location = new System.Drawing.Point(286, 6);
            this.cbGrams.Name = "cbGrams";
            this.cbGrams.Size = new System.Drawing.Size(54, 17);
            this.cbGrams.TabIndex = 8;
            this.cbGrams.Tag = "grams";
            this.cbGrams.Text = "grams";
            this.cbGrams.UseVisualStyleBackColor = true;
            this.cbGrams.Click += new System.EventHandler(this.cbGroupName_Click);
            // 
            // cbOunces
            // 
            this.cbOunces.AutoSize = true;
            this.cbOunces.Checked = true;
            this.cbOunces.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOunces.Location = new System.Drawing.Point(346, 6);
            this.cbOunces.Name = "cbOunces";
            this.cbOunces.Size = new System.Drawing.Size(61, 17);
            this.cbOunces.TabIndex = 9;
            this.cbOunces.Tag = "ounces";
            this.cbOunces.Text = "ounces";
            this.cbOunces.UseVisualStyleBackColor = true;
            this.cbOunces.Click += new System.EventHandler(this.cbGroupName_Click);
            // 
            // cbLb
            // 
            this.cbLb.AutoSize = true;
            this.cbLb.Checked = true;
            this.cbLb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLb.Location = new System.Drawing.Point(413, 6);
            this.cbLb.Name = "cbLb";
            this.cbLb.Size = new System.Drawing.Size(34, 17);
            this.cbLb.TabIndex = 10;
            this.cbLb.Tag = "lb";
            this.cbLb.Text = "lb";
            this.cbLb.UseVisualStyleBackColor = true;
            this.cbLb.Click += new System.EventHandler(this.cbGroupName_Click);
            // 
            // cbOz
            // 
            this.cbOz.AutoSize = true;
            this.cbOz.Checked = true;
            this.cbOz.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOz.Location = new System.Drawing.Point(453, 6);
            this.cbOz.Name = "cbOz";
            this.cbOz.Size = new System.Drawing.Size(37, 17);
            this.cbOz.TabIndex = 11;
            this.cbOz.Tag = "oz";
            this.cbOz.Text = "oz";
            this.cbOz.UseVisualStyleBackColor = true;
            this.cbOz.Click += new System.EventHandler(this.cbGroupName_Click);
            // 
            // cbNew
            // 
            this.cbNew.AutoSize = true;
            this.cbNew.Checked = true;
            this.cbNew.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbNew.Location = new System.Drawing.Point(496, 6);
            this.cbNew.Name = "cbNew";
            this.cbNew.Size = new System.Drawing.Size(48, 17);
            this.cbNew.TabIndex = 12;
            this.cbNew.Tag = "New";
            this.cbNew.Text = "New";
            this.cbNew.UseVisualStyleBackColor = true;
            this.cbNew.Click += new System.EventHandler(this.cbGroupName_Click);
            // 
            // cbSelected
            // 
            this.cbSelected.AutoSize = true;
            this.cbSelected.Checked = true;
            this.cbSelected.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSelected.Location = new System.Drawing.Point(550, 5);
            this.cbSelected.Name = "cbSelected";
            this.cbSelected.Size = new System.Drawing.Size(68, 17);
            this.cbSelected.TabIndex = 13;
            this.cbSelected.Tag = "Selected";
            this.cbSelected.Text = "Selected";
            this.cbSelected.UseVisualStyleBackColor = true;
            this.cbSelected.Click += new System.EventHandler(this.cbGroupName_Click);
            // 
            // cbTags
            // 
            this.cbTags.AutoSize = true;
            this.cbTags.Checked = true;
            this.cbTags.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTags.Location = new System.Drawing.Point(624, 6);
            this.cbTags.Name = "cbTags";
            this.cbTags.Size = new System.Drawing.Size(50, 17);
            this.cbTags.TabIndex = 14;
            this.cbTags.Tag = "Tags";
            this.cbTags.Text = "Tags";
            this.cbTags.UseVisualStyleBackColor = true;
            this.cbTags.Click += new System.EventHandler(this.cbGroupName_Click);
            // 
            // cbNotes
            // 
            this.cbNotes.AutoSize = true;
            this.cbNotes.Checked = true;
            this.cbNotes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbNotes.Location = new System.Drawing.Point(680, 6);
            this.cbNotes.Name = "cbNotes";
            this.cbNotes.Size = new System.Drawing.Size(54, 17);
            this.cbNotes.TabIndex = 15;
            this.cbNotes.Tag = "Notes";
            this.cbNotes.Text = "Notes";
            this.cbNotes.UseVisualStyleBackColor = true;
            this.cbNotes.Click += new System.EventHandler(this.cbGroupName_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbNotes);
            this.panel1.Controls.Add(this.cbGroupName);
            this.panel1.Controls.Add(this.cbTags);
            this.panel1.Controls.Add(this.cbListOrder);
            this.panel1.Controls.Add(this.cbSelected);
            this.panel1.Controls.Add(this.cbItem);
            this.panel1.Controls.Add(this.cbNew);
            this.panel1.Controls.Add(this.cbGrams);
            this.panel1.Controls.Add(this.cbOz);
            this.panel1.Controls.Add(this.cbOunces);
            this.panel1.Controls.Add(this.cbLb);
            this.panel1.Location = new System.Drawing.Point(50, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(772, 25);
            this.panel1.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 521);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(494, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "Filter by Groups      --OR--       Tags       --OR--    New     --OR--        Sel" +
    "ected";
            // 
            // cbFilterSelected
            // 
            this.cbFilterSelected.AutoSize = true;
            this.cbFilterSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterSelected.Location = new System.Drawing.Point(429, 542);
            this.cbFilterSelected.Name = "cbFilterSelected";
            this.cbFilterSelected.Size = new System.Drawing.Size(117, 21);
            this.cbFilterSelected.TabIndex = 19;
            this.cbFilterSelected.Tag = "Selected";
            this.cbFilterSelected.Text = "Filter Selected";
            this.cbFilterSelected.UseVisualStyleBackColor = true;
            this.cbFilterSelected.Click += new System.EventHandler(this.cbFilterSelected_Click);
            // 
            // cbFilterNew
            // 
            this.cbFilterNew.AutoSize = true;
            this.cbFilterNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilterNew.Location = new System.Drawing.Point(328, 542);
            this.cbFilterNew.Name = "cbFilterNew";
            this.cbFilterNew.Size = new System.Drawing.Size(89, 21);
            this.cbFilterNew.TabIndex = 20;
            this.cbFilterNew.Tag = "New";
            this.cbFilterNew.Text = "Filter New";
            this.cbFilterNew.UseVisualStyleBackColor = true;
            this.cbFilterNew.Click += new System.EventHandler(this.cbFilterNew_Click);
            // 
            // lboxTags
            // 
            this.lboxTags.FormattingEnabled = true;
            this.lboxTags.Location = new System.Drawing.Point(181, 542);
            this.lboxTags.Name = "lboxTags";
            this.lboxTags.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lboxTags.Size = new System.Drawing.Size(131, 160);
            this.lboxTags.TabIndex = 21;
            this.lboxTags.Click += new System.EventHandler(this.lboxTags_Click);
            // 
            // lboxGroupNames
            // 
            this.lboxGroupNames.FormattingEnabled = true;
            this.lboxGroupNames.Location = new System.Drawing.Point(33, 542);
            this.lboxGroupNames.Name = "lboxGroupNames";
            this.lboxGroupNames.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lboxGroupNames.Size = new System.Drawing.Size(142, 160);
            this.lboxGroupNames.TabIndex = 22;
            this.lboxGroupNames.Click += new System.EventHandler(this.lboxGroupNames_Click);
            // 
            // cbWeightTotal
            // 
            this.cbWeightTotal.AutoSize = true;
            this.cbWeightTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbWeightTotal.Location = new System.Drawing.Point(318, 569);
            this.cbWeightTotal.Name = "cbWeightTotal";
            this.cbWeightTotal.Size = new System.Drawing.Size(107, 21);
            this.cbWeightTotal.TabIndex = 23;
            this.cbWeightTotal.Text = "Weight Total";
            this.cbWeightTotal.UseVisualStyleBackColor = true;
            // 
            // cbGroupTotal
            // 
            this.cbGroupTotal.AutoSize = true;
            this.cbGroupTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGroupTotal.Location = new System.Drawing.Point(318, 592);
            this.cbGroupTotal.Name = "cbGroupTotal";
            this.cbGroupTotal.Size = new System.Drawing.Size(103, 21);
            this.cbGroupTotal.TabIndex = 24;
            this.cbGroupTotal.Text = "Group Total";
            this.cbGroupTotal.UseVisualStyleBackColor = true;
            // 
            // btnGenerateList
            // 
            this.btnGenerateList.Enabled = false;
            this.btnGenerateList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateList.Location = new System.Drawing.Point(373, 672);
            this.btnGenerateList.Name = "btnGenerateList";
            this.btnGenerateList.Size = new System.Drawing.Size(119, 25);
            this.btnGenerateList.TabIndex = 25;
            this.btnGenerateList.Text = "Generate List";
            this.btnGenerateList.UseCompatibleTextRendering = true;
            this.btnGenerateList.UseVisualStyleBackColor = true;
            this.btnGenerateList.Click += new System.EventHandler(this.btnGenerateList_Click);
            // 
            // cboxPrinters
            // 
            this.cboxPrinters.FormattingEnabled = true;
            this.cboxPrinters.Location = new System.Drawing.Point(566, 595);
            this.cboxPrinters.Name = "cboxPrinters";
            this.cboxPrinters.Size = new System.Drawing.Size(228, 21);
            this.cboxPrinters.TabIndex = 26;
            this.cboxPrinters.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(562, 572);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 20);
            this.label4.TabIndex = 27;
            this.label4.Text = "Select printer";
            this.label4.Visible = false;
            // 
            // cbCSV
            // 
            this.cbCSV.AutoSize = true;
            this.cbCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCSV.Location = new System.Drawing.Point(318, 615);
            this.cbCSV.Name = "cbCSV";
            this.cbCSV.Size = new System.Drawing.Size(90, 21);
            this.cbCSV.TabIndex = 28;
            this.cbCSV.Text = "Save CSV";
            this.cbCSV.UseVisualStyleBackColor = true;
            this.cbCSV.Click += new System.EventHandler(this.cbCSV_Click);
            // 
            // cbPrint
            // 
            this.cbPrint.AutoSize = true;
            this.cbPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPrint.Location = new System.Drawing.Point(318, 638);
            this.cbPrint.Name = "cbPrint";
            this.cbPrint.Size = new System.Drawing.Size(56, 21);
            this.cbPrint.TabIndex = 29;
            this.cbPrint.Text = "Print";
            this.cbPrint.UseVisualStyleBackColor = true;
            this.cbPrint.Click += new System.EventHandler(this.cbCSV_Click);
            // 
            // rbMulti
            // 
            this.rbMulti.AutoSize = true;
            this.rbMulti.Location = new System.Drawing.Point(373, 639);
            this.rbMulti.Name = "rbMulti";
            this.rbMulti.Size = new System.Drawing.Size(85, 17);
            this.rbMulti.TabIndex = 31;
            this.rbMulti.TabStop = true;
            this.rbMulti.Text = "Multi-Column";
            this.rbMulti.UseVisualStyleBackColor = true;
            // 
            // rbSingle
            // 
            this.rbSingle.AutoSize = true;
            this.rbSingle.Checked = true;
            this.rbSingle.Location = new System.Drawing.Point(455, 639);
            this.rbSingle.Name = "rbSingle";
            this.rbSingle.Size = new System.Drawing.Size(92, 17);
            this.rbSingle.TabIndex = 32;
            this.rbSingle.TabStop = true;
            this.rbSingle.Text = "Single Column";
            this.rbSingle.UseVisualStyleBackColor = true;
            // 
            // printDocument1
            // 
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            this.printDocument1.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_EndPrint);
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.printDocument1;
            this.printDialog1.UseEXDialog = true;
            // 
            // richTextBoxEx1
            // 
            this.richTextBoxEx1.Location = new System.Drawing.Point(552, 527);
            this.richTextBoxEx1.Name = "richTextBoxEx1";
            this.richTextBoxEx1.ReadOnly = true;
            this.richTextBoxEx1.Size = new System.Drawing.Size(783, 175);
            this.richTextBoxEx1.TabIndex = 33;
            this.richTextBoxEx1.Text = "";
            this.richTextBoxEx1.Click += new System.EventHandler(this.rtfList_Click);
            // 
            // formItemsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1341, 709);
            this.Controls.Add(this.richTextBoxEx1);
            this.Controls.Add(this.rbSingle);
            this.Controls.Add(this.rbMulti);
            this.Controls.Add(this.cbPrint);
            this.Controls.Add(this.cbCSV);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboxPrinters);
            this.Controls.Add(this.btnGenerateList);
            this.Controls.Add(this.cbGroupTotal);
            this.Controls.Add(this.cbWeightTotal);
            this.Controls.Add(this.lboxGroupNames);
            this.Controls.Add(this.lboxTags);
            this.Controls.Add(this.cbFilterNew);
            this.Controls.Add(this.cbFilterSelected);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnrefresh);
            this.Controls.Add(this.dgvItemsList);
            this.Name = "formItemsList";
            this.ShowIcon = false;
            this.Text = "Items List";
            this.Load += new System.EventHandler(this.ItemsList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemsList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvItemsList;
        private System.Windows.Forms.Button btnrefresh;
        private System.Windows.Forms.CheckBox cbGroupName;
        private System.Windows.Forms.CheckBox cbListOrder;
        private System.Windows.Forms.CheckBox cbItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbGrams;
        private System.Windows.Forms.CheckBox cbOunces;
        private System.Windows.Forms.CheckBox cbLb;
        private System.Windows.Forms.CheckBox cbOz;
        private System.Windows.Forms.CheckBox cbNew;
        private System.Windows.Forms.CheckBox cbSelected;
        private System.Windows.Forms.CheckBox cbTags;
        private System.Windows.Forms.CheckBox cbNotes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbFilterSelected;
        private System.Windows.Forms.CheckBox cbFilterNew;
        private System.Windows.Forms.ListBox lboxTags;
        private System.Windows.Forms.ListBox lboxGroupNames;
        private System.Windows.Forms.CheckBox cbWeightTotal;
        private System.Windows.Forms.CheckBox cbGroupTotal;
        private System.Windows.Forms.Button btnGenerateList;
        private System.Windows.Forms.ComboBox cboxPrinters;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbCSV;
        private System.Windows.Forms.CheckBox cbPrint;
        private System.Windows.Forms.RadioButton rbMulti;
        private System.Windows.Forms.RadioButton rbSingle;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private Utils.RichTextBoxEx richTextBoxEx1;
    }
}