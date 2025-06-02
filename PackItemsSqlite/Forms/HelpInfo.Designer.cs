namespace PackItemsSqlite     //.Forms
{
    partial class HelpInfo
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
            this.rtbHelpInfo = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbHelpInfo
            // 
            this.rtbHelpInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbHelpInfo.Location = new System.Drawing.Point(0, 0);
            this.rtbHelpInfo.Name = "rtbHelpInfo";
            this.rtbHelpInfo.Size = new System.Drawing.Size(788, 486);
            this.rtbHelpInfo.TabIndex = 0;
            this.rtbHelpInfo.Text = "Rich Text box for help information";
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.Location = new System.Drawing.Point(0, 463);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(788, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // HelpInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(788, 486);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rtbHelpInfo);
            this.Name = "HelpInfo";
            this.Text = "HelpInfo";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbHelpInfo;
        private System.Windows.Forms.Button button1;
    }
}