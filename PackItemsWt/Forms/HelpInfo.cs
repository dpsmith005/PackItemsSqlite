using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackItemsWt   //.Forms
{
    public partial class HelpInfo : Form
    {
        public HelpInfo()
        {
            InitializeComponent();
            //FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            string helpFile = ConfigurationManager.AppSettings["helpTextFile"];
            string helpFileRtf = ConfigurationManager.AppSettings["helpRtfFile"];
            try
            {
                if (File.Exists(helpFileRtf))
                {
                    //rtbHelpInfo.Text = File.ReadAllText(helpFile);
                    rtbHelpInfo.Rtf = File.ReadAllText(helpFileRtf);
                }
                else
                {
                    MessageBox.Show("the help file does not exist ({helpFile})");
                }
            }
            catch
            {
                //Handle missing file or failure to read
                MessageBox.Show("Error retrieving the help file ({helpFile})");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
