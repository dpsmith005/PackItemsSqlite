using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackItemsSqlite
{
    internal static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string DatabaseFile = ConfigurationManager.AppSettings["DatabaseFile"];

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //if (!File.Exists(@"..\..\Files\SQLitePack.db"))
            if (!File.Exists(DatabaseFile))
            {
                DatabaseHelper.InitializeDatabase();
            }
            // Sample data adds to tables
            //DatabaseHelper.AddSampleTags();
            //DatabaseHelper.AddSampleGroups();
            //DatabaseHelper.AddSamplePackItems();
            // Data adds from CSV
            //DatabaseHelper.AddItemsFromCsv(csvDataFile);
            //DatabaseHelper.AddGroupsFromCsv(csvGroupsFile);
            //DatabaseHelper.AddTagsFromCsv(csvTagsFile);
            // Add the items above as selections in the form to import csv files & export data to csv


            Application.Run(new MainForm());
        }
    }
}
