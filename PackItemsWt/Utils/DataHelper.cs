using PackItemsWt;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

public class DatabaseHelper
{
    private static string connectionString = @"Data Source=..\..\Files\SQLitePack.db;Version=3";
    public static string DatabaseFile = ConfigurationManager.AppSettings["DatabaseFile"];

    public static string configvalue1 = ConfigurationManager.AppSettings["GramsPerOunce"];
    public static decimal GramsPerOunce = decimal.Parse(configvalue1);
    public static string configvalue2 = ConfigurationManager.AppSettings["OuncesPerGram"];
    public static decimal OuncesPerGram = decimal.Parse(configvalue2);

    public static string csvDataFile = ConfigurationManager.AppSettings["csvData"];
    public static string csvGroupsFile = ConfigurationManager.AppSettings["csvGroups"];
    public static string csvTagsFile = ConfigurationManager.AppSettings["csvTags"];

    public static void InitializeDatabase()
    {
        //if (!File.Exists(@"..\..\Files\SQLitePack.db"))
        if (!File.Exists(DatabaseFile))
        {
            //SQLiteConnection.CreateFile(@"..\..\Files\SQLitePack.db");
            SQLiteConnection.CreateFile(DatabaseFile);

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Create Tables for the data
                string createPackTableQuery = @"
                CREATE TABLE IF NOT EXISTS PackItems (
                    [Id] integer primary key,
                    [GroupName] text NOT NULL,
                    [Item] text NOT NULL UNIQUE,
                    [grams] int NOT NULL,
                    [ounces] real NULL,
                    [lb] int NULL,
                    [oz] real NULL,
                    [Notes] ntext NULL,
                    [New] BOOLEAN NOT NULL CHECK(New IN (0,1)),
                    [Selected] BOOLEAN NOT NULL CHECK(Selected IN (0,1)),
                    [Tags] Text NULL
                );";

                /*  No longer using Group and Tag tables.  These are queried from the PackItems GroupName and Tags columns.  
                 *  This allows for adding any tags or groups without tracking in a table.
                 *  Views are used to gather this data.
                 *  This may not work and may need to have the groups and tags added before using.
                 */
                string createGroupsTableQuery = @"
                CREATE TABLE IF NOT EXISTS Groups (
                    [GroupName] text PRIMARY KEY UNIQUE,
                    [ListOrder] int NULL
                );";

                string createTagsTableQuery = @"
                CREATE TABLE IF NOT EXISTS Tags (
                    [TagName] text PRIMARY KEY UNIQUE
                );";

                string createvGroupNames = @"
                CREATE VIEW vDistinctGroups(GroupName)
                AS
                    select Distinct GroupName from PackItems where GroupName<> '' ORDER BY GroupName;
                ";

                string createvTagNames = @"
                CREATE VIEW vDistinctTags(TagName) 
                    AS 
                WITH RECURSIVE split(TagName, str) AS( 
                    SELECT '', TagName || ',' FROM(select Distinct Tags as TagName from PackItems where Tags<> '') 
                    UNION ALL SELECT 
                        substr(str, 0, instr(str, ',')), 
                        substr(str, instr(str, ',') + 1) 
                        FROM split WHERE str != '') 
                SELECT TagName 
                FROM split 
                WHERE TagName!= '' 
                ORDER BY TagName ASC;
                ";

                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = createPackTableQuery;
                    command.ExecuteNonQuery();

                    command.CommandText = createGroupsTableQuery;
                    command.ExecuteNonQuery();

                    command.CommandText = createTagsTableQuery;
                    command.ExecuteNonQuery();

                    command.CommandText = createvGroupNames;
                    command.ExecuteNonQuery();

                    command.CommandText = createvTagNames;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
    public static void AddItemsFromCsv(string csvPath)
    {
        if (File.Exists(csvPath))
        {
            formMain._Form1.updateStatus("");   // Clear the status textbox

            string[] lines = File.ReadAllLines(csvPath);

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    bool firstRow = true;
                    foreach (string line in lines)
                    {
                        if (firstRow)
                        {
                            firstRow = false;
                            continue; // Skip the header line
                        }
                        string[] values = line.Split(',');
                        string group = values[0];
                        string tags = values[1];
                        string selected = values[2];
                        int grams = Convert.ToInt32(values[3]);
                        double ounces = Convert.ToDouble(values[4]);
                        string item = values[5];
                        int lb = Convert.ToInt32(values[6]);
                        double oz = Convert.ToDouble(values[7]);
                        string notes = values[8];
                        string new_ = values[9];
                        command.CommandText = @"INSERT INTO PackItems (GroupName, Item, grams, ounces, lb, oz, Notes, New, Selected, Tags)
                          VALUES('" + group + "','" + item + "'," + grams + "," + ounces + "," + lb + "," + oz + ",'" + notes + "'," + new_ + "," + selected + ",'" + tags + "');";
                        string errMsg = "";

                        // Add Item to database table PackItems
                        try
                        {
                            command.ExecuteNonQuery();
                            formMain._Form1.updateStatus("Added Item " + item);
                        }
                        catch
                        {
                            errMsg = item + " is a duplicate";
                            formMain._Form1.updateStatus(errMsg);
                        }
                    }
                }
            }
        }
        else
        {
            System.Console.WriteLine($"CSV file not found at {csvPath}");
        }
    }
    public static void AddDataFromCsv(string csvPath)
    {
        if (File.Exists(csvPath))
        {
            formMain._Form1.updateStatus("");   // Clear the status textbox

            string[] lines = File.ReadAllLines(csvPath);

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    bool firstRow = true;
                    foreach (string line in lines)
                    {
                        if (firstRow)
                        {
                            firstRow = false;
                            continue; // Skip the header line
                        }
                        string[] values = line.Split(',');
                        string group = values[0];
                        string tags = values[1];
                        string selected = values[2];
                        int grams = Convert.ToInt32(values[3]);
                        double ounces = Convert.ToDouble(values[4]);
                        string item = values[5];
                        int lb = Convert.ToInt32(values[6]);
                        double oz = Convert.ToDouble(values[7]);
                        string notes = values[8];
                        string new_ = values[9];
                        command.CommandText = @"INSERT INTO PackItems (GroupName, Item, grams, ounces, lb, oz, Notes, New, Selected, Tags)
                          VALUES('" + group + "','" + item + "'," + grams + "," + ounces + "," + lb + "," + oz + ",'" + notes + "'," + new_ + "," + selected + ",'" + tags + "');";
                        //  VALUES(@group, @item,@grams, @ounces, @lb, @oz, @notes, @new_, @selected, @tags);"";
                        //command.Parameters.AddWithValue("@group", group);
                        //command.Parameters.AddWithValue("@tags", tags);
                        //command.Parameters.AddWithValue("@selected", selected);
                        //command.Parameters.AddWithValue("@grams", grams);
                        //command.Parameters.AddWithValue("@ounces", ounces);
                        //command.Parameters.AddWithValue("@item", item);
                        //command.Parameters.AddWithValue("@lb", lb);
                        //command.Parameters.AddWithValue("@oz", oz);
                        //command.Parameters.AddWithValue("@notes", notes);
                        //command.Parameters.AddWithValue("@new_", new_);
                        string errMsg = "";

                        // Add Item to database table PackItems
                        try
                        {
                            command.ExecuteNonQuery();
                            formMain._Form1.updateStatus("Added Item " + item);
                        }
                        catch
                        {
                            errMsg = item + " is a duplicate";
                            formMain._Form1.updateStatus(errMsg);
                        }
                    }

                    // Add group to database table Groups
                    DataTable dt = new DataTable();
                    string query = "select * FROM vDistinctGroups";
                    SQLiteDataAdapter sqlda = new SQLiteDataAdapter(query, connection);
                    sqlda.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        string group = row["GroupName"].ToString();
                        command.CommandText = "INSERT INTO Groups (GroupName,ListOrder) VALUES (@group,0);";
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@group", group);
                        try
                        {
                            command.ExecuteNonQuery();
                            formMain._Form1.updateStatus("Added group " + group);
                        }
                        catch
                        {
                            string errMsg = group + " already added group";
                            formMain._Form1.updateStatus(errMsg);
                        }
                    }

                    // Add tags to database table Tags
                    dt = new DataTable();
                    query = "select * FROM vDistinctTags";
                    sqlda = new SQLiteDataAdapter(query, connection);
                    sqlda.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        string tags = row["TagName"].ToString();
                        command.CommandText = "INSERT INTO Tags (TagName) VALUES (@tags);";
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@tags", tags);
                        try
                        {
                            command.ExecuteNonQuery();
                            formMain._Form1.updateStatus("Added tag " + tags);
                        }
                        catch
                        {
                            string errMsg = tags + " already added tag";
                            formMain._Form1.updateStatus(errMsg);
                        }
                    }

                }
            }
        }
        else
        {
            System.Console.WriteLine($"CSV file not found at {csvPath}");
        }
    }
    public static void AddGroupsFromCsv(string csvPath)
    {
        if (File.Exists(csvPath))
        {
            formMain._Form1.updateStatus("");   // Clear the status textbox

            string[] lines = File.ReadAllLines(csvPath);

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    bool firstRow = true;
                    foreach (string line in lines)
                    {
                        if (firstRow)
                        {
                            firstRow = false;
                            continue; // Skip the header line
                        }

                        string[] values = line.Split(',');
                        string group = values[0];
                        int order = Convert.ToInt32(values[1]);
                        command.CommandText = "INSERT INTO Groups (GroupName,ListOrder) VALUES ('" + group + "'," + order + ");";
                        //command.Parameters.AddWithValue("@group", group);
                        //command.Parameters.AddWithValue("@order", order);

                        string errMsg = "";
                        try
                        {
                            command.ExecuteNonQuery();
                            formMain._Form1.updateStatus("Added group " + group);
                        }
                        catch
                        {
                            errMsg = group + " is a duplicate";
                            formMain._Form1.updateStatus(errMsg);
                        }

                    }
                }
            }
        }
        else
        {
            System.Console.WriteLine($"CSV file not found at {csvPath}");
        }
    }
    public static void AddTagsFromCsv(string csvPath)
    {
        if (File.Exists(csvPath))
        {
            formMain._Form1.updateStatus("");   // Clear the status textbox

            string[] lines = File.ReadAllLines(csvPath);

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    bool firstRow = true;
                    foreach (string line in lines)
                    {
                        if (firstRow)
                        {
                            firstRow = false;
                            continue; // Skip the header line
                        }

                        string[] values = line.Split(',');
                        string tags = values[0];
                        command.CommandText = "INSERT INTO Tags (TagName) VALUES (@tags);";
                        command.Parameters.AddWithValue("@tags", tags);

                        string errMsg = "";
                        try
                        {
                            command.ExecuteNonQuery();
                            formMain._Form1.updateStatus("Added tag " + tags);
                        }
                        catch
                        {
                            errMsg = tags + " is a duplicate";
                            formMain._Form1.updateStatus(errMsg);
                        }

                    }
                }
            }
        }
        else
        {
            System.Console.WriteLine($"CSV file not found at {csvPath}");
        }
    }
    public static void DeleteAllData()
    {
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                // Delete all rows from table Tags
                command.CommandText = "DELETE FROM Tags";
                try
                {
                    command.ExecuteNonQuery();
                    formMain._Form1.updateStatus("Deleted all rows from Tags");
                }
                catch
                {
                    string errMsg = "Error deleting all Tags";
                    formMain._Form1.updateStatus(errMsg);
                }

                // Delete all rows from table Groups
                command.CommandText = "DELETE FROM Groups";
                try
                {
                    command.ExecuteNonQuery();
                    formMain._Form1.updateStatus("Deleted all rows from Groups");
                }
                catch
                {
                    string errMsg = "Error deleting all Groups";
                    formMain._Form1.updateStatus(errMsg);
                }

                // Delete all rows from table PackItems
                command.CommandText = "DELETE FROM PackItems";
                try
                {
                    command.ExecuteNonQuery();
                    formMain._Form1.updateStatus("Deleted all rows from PackItems");
                }
                catch
                {
                    string errMsg = "Error deleting all PackItems";
                    formMain._Form1.updateStatus(errMsg);
                }

            }
        }
    }
    public static void DeleteGroupName(string group)
    {
        // Delete the selected group
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                command.CommandText = "DELETE FROM [Groups] WHERE GroupName = '" + group + "'";
                try
                {
                    command.ExecuteNonQuery();
                    formMain._Form1.updateStatus("Deleted specified group - " + group);
                }
                catch
                {
                    string errMsg = "Error deleting spegified group - " + group;
                    formMain._Form1.updateStatus(errMsg);
                }
            }
        }
    }
    public static void DeleteTagName(string tag)
    {
        // Delete the selected group
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                command.CommandText = "DELETE FROM [Tags] WHERE TagName = '" + tag + "'";
                try
                {
                    command.ExecuteNonQuery();
                    formMain._Form1.updateStatus("Deleted specified tag - " + tag);
                }
                catch
                {
                    string errMsg = "Error deleting spegified tag - " + tag;
                    formMain._Form1.updateStatus(errMsg);
                }
            }
        }
    }
    public static void closeDB()
    {
        SQLiteConnection connection = new SQLiteConnection(connectionString);
        connection.Close();
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
    public static void AddGroup(string group)
    {
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                command.CommandText =
                    @"INSERT INTO Groups (GroupName,ListOrder)
                              VALUES ('" + group + "',0);";
                try
                {
                    command.ExecuteNonQuery();
                    formMain._Form1.updateStatus("Added group  " + group);
                }
                catch
                {
                    formMain._Form1.updateStatus("Failed to add group  " + group + ". Could be a duplicate");
                }

            }
        }
    }
    public static void AddTag(string tag)
    {
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                command.CommandText =
                    @"INSERT INTO Tags (TagName)
                              VALUES ('" + tag + "');";
                try
                {
                    command.ExecuteNonQuery();
                    formMain._Form1.updateStatus("Added tag  " + tag);
                }
                catch
                {
                    formMain._Form1.updateStatus("Failed to add tag  " + tag + ". Could be a duplicate");
                }

            }
        }
    }
    public static void ListToCSV<T>(BindingList<T> genericList, string strFilePath)
    {
        var sb = new StringBuilder();
        //var basePath = AppDomain.CurrentDomain.BaseDirectory;
        //var finalPath = Path.Combine(basePath, fileName + ".csv");
        var header = "";
        var info = typeof(T).GetProperties();
        if (File.Exists(strFilePath))
        {
            File.Delete(strFilePath);
        }
        // Create file and write header
        var file = File.Create(strFilePath);
        file.Close();
        foreach (var prop in typeof(T).GetProperties())
        {
            header += prop.Name + ",";
        }
        header = header.Substring(0, header.Length - 1);
        sb.AppendLine(header);
        TextWriter sw = new StreamWriter(strFilePath, true);
        sw.Write(sb.ToString());
        sw.Close();

        foreach (var obj in genericList)
        {
            sb = new StringBuilder();
            var line = "";
            foreach (var prop in info)
            {
                line += prop.GetValue(obj, null) + ",";
            }
            line = line.Substring(0, line.Length - 2);
            sb.AppendLine(line);
            TextWriter sw2 = new StreamWriter(strFilePath, true);
            sw2.Write(sb.ToString());
            sw2.Close();
        }
    }
}