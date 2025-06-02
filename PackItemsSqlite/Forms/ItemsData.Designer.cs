namespace PackItemsSqlite     //.Forms
{
    partial class ItemsData
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbItem = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbGrams = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbOunces = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbLb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbOz = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbNotes = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cbGroupNames = new System.Windows.Forms.ComboBox();
            this.cbNew = new System.Windows.Forms.CheckBox();
            this.cbSelected = new System.Windows.Forms.CheckBox();
            this.lbTags = new System.Windows.Forms.ListBox();
            this.lbStatus = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblSelectedItem = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Group Name";
            // 
            // tbItem
            // 
            this.tbItem.Location = new System.Drawing.Point(76, 39);
            this.tbItem.Name = "tbItem";
            this.tbItem.Size = new System.Drawing.Size(259, 20);
            this.tbItem.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Item";
            // 
            // tbGrams
            // 
            this.tbGrams.Location = new System.Drawing.Point(76, 65);
            this.tbGrams.Name = "tbGrams";
            this.tbGrams.Size = new System.Drawing.Size(50, 20);
            this.tbGrams.TabIndex = 3;
            this.tbGrams.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbGrams_KeyPress);
            this.tbGrams.Leave += new System.EventHandler(this.tbGrams_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Grams";
            // 
            // tbOunces
            // 
            this.tbOunces.Location = new System.Drawing.Point(76, 91);
            this.tbOunces.Name = "tbOunces";
            this.tbOunces.ReadOnly = true;
            this.tbOunces.Size = new System.Drawing.Size(50, 20);
            this.tbOunces.TabIndex = 8;
            this.tbOunces.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ounces";
            // 
            // tbLb
            // 
            this.tbLb.Location = new System.Drawing.Point(76, 117);
            this.tbLb.Name = "tbLb";
            this.tbLb.ReadOnly = true;
            this.tbLb.Size = new System.Drawing.Size(50, 20);
            this.tbLb.TabIndex = 10;
            this.tbLb.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "lb";
            // 
            // tbOz
            // 
            this.tbOz.Location = new System.Drawing.Point(76, 143);
            this.tbOz.Name = "tbOz";
            this.tbOz.ReadOnly = true;
            this.tbOz.Size = new System.Drawing.Size(50, 20);
            this.tbOz.TabIndex = 12;
            this.tbOz.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(52, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "oz";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "New";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 198);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Selected";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(43, 224);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Tags";
            // 
            // tbNotes
            // 
            this.tbNotes.Location = new System.Drawing.Point(36, 325);
            this.tbNotes.Multiline = true;
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.Size = new System.Drawing.Size(382, 102);
            this.tbNotes.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 325);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Notes";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(315, 143);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(315, 113);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(315, 171);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cbGroupNames
            // 
            this.cbGroupNames.FormattingEnabled = true;
            this.cbGroupNames.Location = new System.Drawing.Point(76, 12);
            this.cbGroupNames.Name = "cbGroupNames";
            this.cbGroupNames.Size = new System.Drawing.Size(259, 21);
            this.cbGroupNames.TabIndex = 1;
            // 
            // cbNew
            // 
            this.cbNew.AutoSize = true;
            this.cbNew.Location = new System.Drawing.Point(76, 173);
            this.cbNew.Name = "cbNew";
            this.cbNew.Size = new System.Drawing.Size(166, 17);
            this.cbNew.TabIndex = 4;
            this.cbNew.Text = "New item to make / purchase";
            this.cbNew.UseVisualStyleBackColor = true;
            // 
            // cbSelected
            // 
            this.cbSelected.AutoSize = true;
            this.cbSelected.Location = new System.Drawing.Point(76, 194);
            this.cbSelected.Name = "cbSelected";
            this.cbSelected.Size = new System.Drawing.Size(142, 17);
            this.cbSelected.TabIndex = 5;
            this.cbSelected.Text = "Select for pack contents";
            this.cbSelected.UseVisualStyleBackColor = true;
            // 
            // lbTags
            // 
            this.lbTags.FormattingEnabled = true;
            this.lbTags.Location = new System.Drawing.Point(76, 217);
            this.lbTags.Name = "lbTags";
            this.lbTags.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbTags.Size = new System.Drawing.Size(142, 95);
            this.lbTags.TabIndex = 6;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.ForeColor = System.Drawing.Color.Red;
            this.lbStatus.Location = new System.Drawing.Point(138, 68);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(80, 13);
            this.lbStatus.TabIndex = 31;
            this.lbStatus.Text = "status message";
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(315, 200);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(315, 84);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblSelectedItem
            // 
            this.lblSelectedItem.AutoSize = true;
            this.lblSelectedItem.Location = new System.Drawing.Point(341, 9);
            this.lblSelectedItem.Name = "lblSelectedItem";
            this.lblSelectedItem.Size = new System.Drawing.Size(75, 13);
            this.lblSelectedItem.TabIndex = 34;
            this.lblSelectedItem.Text = "LabelSelected";
            // 
            // ItemsData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 436);
            this.Controls.Add(this.lblSelectedItem);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.lbTags);
            this.Controls.Add(this.cbSelected);
            this.Controls.Add(this.cbNew);
            this.Controls.Add(this.cbGroupNames);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbNotes);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbOz);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbLb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbOunces);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbGrams);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbItem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ItemsData";
            this.Text = "Pack Items";
            this.Load += new System.EventHandler(this.ItemsData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbGrams;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbOunces;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbLb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbOz;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbNotes;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cbGroupNames;
        private System.Windows.Forms.CheckBox cbNew;
        private System.Windows.Forms.CheckBox cbSelected;
        private System.Windows.Forms.ListBox lbTags;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblSelectedItem;
    }
}