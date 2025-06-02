using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PackItemsWt;
using PackItemsWt.Utils;

namespace PackItemsWt
{
    public class PackItemsManager
    {
        private static string connectionString = @"Data Source=..\..\Files\SQLitePack.db;Version=3";

        public BindingList<PackItem> Items
        {
            get
            {
                SortableBindingList<PackItem> PackItem = new SortableBindingList<PackItem>();

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT [PackItems].[Id]
	  ,[Groups].ListOrder
      ,[PackItems].[GroupName]
      ,[PackItems].[Item]
      ,[PackItems].[grams]
      ,[PackItems].[ounces]
      ,[PackItems].[lb]
      ,[PackItems].[oz]
      ,[PackItems].[Notes]
      ,[PackItems].[New]
      ,[PackItems].[Selected]
      ,[PackItems].[Tags]
  FROM [PackItems]
  JOIN [Groups] on [Groups].GroupName = [PackItems].GroupName
  ORDER BY [Groups].ListOrder, [PackItems].[Item]";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(reader.GetOrdinal("Id"));
                                string item = reader.GetString(reader.GetOrdinal("Item"));
                                string groupName = reader.GetString(reader.GetOrdinal("GroupName"));
                                string tags = reader.GetString(reader.GetOrdinal("Tags"));
                                string notes = reader.GetString(reader.GetOrdinal("Notes"));
                                int grams = reader.GetInt32(reader.GetOrdinal("grams"));
                                decimal ounces = reader.GetDecimal(reader.GetOrdinal("ounces"));    //calculated: grams * 28.3495 (This i grams per ounce.  0.035274 is oz/gm)
                                int lb = reader.GetInt32(reader.GetOrdinal("lb"));                //calculated: ounces % 16
                                decimal oz = reader.GetDecimal(reader.GetOrdinal("oz"));            //calculated: ounces - ((ounces % 16) * 16)
                                bool _new = reader.GetBoolean(reader.GetOrdinal("New"));
                                bool selected = reader.GetBoolean(reader.GetOrdinal("Selected")); ;
                                PackItem.Add(new PackItem(id, groupName, item, grams, ounces, lb, oz, _new, selected, tags, notes));
                            }
                        }
                    }
                    return PackItem;    //.ToList();
                }
            }
        }
        public BindingList<PackItem> ItemsFilter(string kind, string value)
        {

            SortableBindingList<PackItem> PackItem = new SortableBindingList<PackItem>();
            string varWhere;
            switch (kind)
            {
                case "Item":
                    varWhere = "WHERE [PackItems].Item like '%" + value + "%'";
                    break;
                case "Group":
                    varWhere = "WHERE [PackItems].GroupName like '%" + value + "%'";
                    break;
                case "Tag":
                    varWhere = "WHERE [PackItems].Tags like '%" + value + "%'";
                    break;
                case "New":
                    varWhere = "WHERE [PackItems].New = 1";
                    break;
                case "Selected":
                    varWhere = "WHERE [PackItems].Selected = 1";
                    break;
                default:
                    varWhere = "WHERE Item like '%'";
                    break;
            }

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT [PackItems].[Id]
	  ,[Groups].ListOrder
      ,[PackItems].[GroupName]
      ,[PackItems].[Item]
      ,[PackItems].[grams]
      ,[PackItems].[ounces]
      ,[PackItems].[lb]
      ,[PackItems].[oz]
      ,[PackItems].[Notes]
      ,[PackItems].[New]
      ,[PackItems].[Selected]
      ,[PackItems].[Tags]
  FROM [PackItems]
  JOIN [Groups] on [Groups].GroupName = [PackItems].GroupName
  " + varWhere + @"
  ORDER BY [Groups].ListOrder, [PackItems].[Item]";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(reader.GetOrdinal("Id"));
                            string item = reader.GetString(reader.GetOrdinal("Item"));
                            string groupName = reader.GetString(reader.GetOrdinal("GroupName"));
                            string tags = reader.GetString(reader.GetOrdinal("Tags"));
                            string notes = reader.GetString(reader.GetOrdinal("Notes"));
                            int grams = reader.GetInt32(reader.GetOrdinal("grams"));
                            decimal ounces = reader.GetDecimal(reader.GetOrdinal("ounces"));    //calculated: grams * 28.3495 (This i grams per ounce.  0.035274 is oz/gm)
                            int lb = reader.GetInt32(reader.GetOrdinal("lb"));                //calculated: ounces % 16
                            decimal oz = reader.GetDecimal(reader.GetOrdinal("oz"));            //calculated: ounces - ((ounces % 16) * 16)
                            bool _new = reader.GetBoolean(reader.GetOrdinal("New"));
                            bool selected = reader.GetBoolean(reader.GetOrdinal("Selected")); ;
                            PackItem.Add(new PackItem(id, groupName, item, grams, ounces, lb, oz, _new, selected, tags, notes));
                        }
                    }
                }
                return PackItem;    //.ToList();
            }

        }
        public BindingList<GroupItem> Groups
        {
            get
            {

                SortableBindingList<GroupItem> grpItems = new SortableBindingList<GroupItem>();
                //List<GroupItem> grpItems = new List<GroupItem>();

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "select * from Groups order by ListOrder,GroupName;";             //string query = "select Distinct GroupName from PackItems where GroupName<> '' ORDER BY GroupName;";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string groupName = reader.GetString(reader.GetOrdinal("GroupName"));
                                int listOrder = reader.GetInt32(reader.GetOrdinal("ListOrder"));
                                grpItems.Add(new GroupItem(groupName, listOrder));
                            }
                        }
                    }
                }
                return grpItems;  //.ToList();
            }
        }
        public BindingList<TagItem> Tags
        {
            get
            {
                SortableBindingList<TagItem> tagItems = new SortableBindingList<TagItem>();
                //List<TagItem> tagItems = new List<TagItem>();

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = "select * from Tags order by TagName;";             //string query = "select Distinct GroupName from PackItems where GroupName<> '' ORDER BY GroupName;";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string tagName = reader.GetString(reader.GetOrdinal("TagName"));
                                tagItems.Add(new TagItem(tagName));
                            }
                        }
                    }
                }
                return tagItems;    //.ToList();
            }

        }
        public void GroupItemUpdate(string GroupName, int ListOrder)
        {
            formMain._Form1.updateStatus("Updating Groups order number.  Item: " + GroupName + " Order: " + ListOrder);
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = $@"UPDATE [Groups] 
                    SET [ListOrder] = {ListOrder}
                    WHERE [GroupName] = '{GroupName}'
            ";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    try
                    {
                        formMain._Form1.updateStatus("Updating Groups order number.  Item: " + GroupName + " Order: " + ListOrder);
                        command.ExecuteNonQuery();
                        //MainForm._Form1.updateStatus("");  //Clear Status Windows
                        formMain._Form1.updateStatus("Updated item in Groups table.  Item: " + GroupName + " Order: " + ListOrder);
                    }
                    catch
                    {
                        formMain._Form1.updateStatus("Failed to update Group item for " + GroupName);
                    }
                }
            }
        }
        public List<PackItem> GetSinglePackItem(string value)
        {
            List<PackItem> PackItem = new List<PackItem>();
            //SortableBindingList<PackItem> PackItem = new SortableBindingList<PackItem>();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM PackITems WHERE Id == '" + value + "' order by GroupName,Item";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(reader.GetOrdinal("Id"));
                            string item = reader.GetString(reader.GetOrdinal("Item"));
                            string groupName = reader.GetString(reader.GetOrdinal("GroupName"));
                            string tags = reader.GetString(reader.GetOrdinal("Tags"));
                            string notes = reader.GetString(reader.GetOrdinal("Notes"));
                            int grams = reader.GetInt32(reader.GetOrdinal("grams"));
                            decimal ounces = reader.GetDecimal(reader.GetOrdinal("ounces"));    //calculated: grams * 28.3495 (This i grams per ounce.  0.035274 is oz/gm)
                            int lb = reader.GetInt32(reader.GetOrdinal("lb"));                //calculated: ounces % 16
                            decimal oz = reader.GetDecimal(reader.GetOrdinal("oz"));            //calculated: ounces - ((ounces % 16) * 16)
                            bool _new = reader.GetBoolean(reader.GetOrdinal("New"));
                            bool selected = reader.GetBoolean(reader.GetOrdinal("Selected")); ;
                            PackItem.Add(new PackItem(id, groupName, item, grams, ounces, lb, oz, _new, selected, tags, notes));
                        }
                    }
                }
            }

            return PackItem;
        }
        public void PackItemDelete(string item)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM[PackItems] WHERE Item = '" + item + "'";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    formMain._Form1.updateStatus("About to delete this item - " + item);
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this item?", "Confirm Delete Data", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {
                        command.ExecuteNonQuery();
                        formMain._Form1.updateStatus("");  //Clear Status Windows
                        formMain._Form1.updateStatus("Deleted item from table - " + item);
                    }
                    else
                    {
                        formMain._Form1.updateStatus("Item delete canceled");
                    }
                }
            }
        }
        public void PackItemInsert(PackItem packItem)
        {
            formMain._Form1.updateStatus("Inserting item into table");
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string values = "'" + packItem.GroupName + "','" + packItem.Item + "'," + packItem.grams + "," + packItem.ounces + "," + packItem.lb + "," + packItem.oz + ",'" + packItem.Notes + "'," + packItem.New + "," + packItem.Selected + ",'" + packItem.Tags + "'";
                string query = "INSERT INTO [PackItems] ([GroupName], [Item], [grams], [ounces], [lb], [oz], [Notes], [New], [Selected], [Tags]) VALUES (" + values + ");";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    try
                    {
                        formMain._Form1.updateStatus("About to insert this item - " + packItem.Item);
                        command.ExecuteNonQuery();
                        formMain._Form1.updateStatus("");  //Clear Status Windows
                        formMain._Form1.updateStatus("Inserted item to table - " + packItem.Item);
                    }
                    catch
                    {
                        formMain._Form1.updateStatus("Failed to insert item");
                    }
                }
            }
        }
        public void PackItemUpdate(PackItem packItem)
        {
            formMain._Form1.updateStatus("Updating item in table");
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = $@"UPDATE [PackItems] 
                       SET [GroupName] = '{packItem.GroupName}'
                          ,[Item] = '{packItem.Item}'
                          ,[grams] = {packItem.grams}
                          ,[ounces] = {packItem.ounces}
                          ,[lb] = {packItem.lb}
                          ,[oz] = {packItem.oz}
                          ,[Notes] = '{packItem.Notes}'
                          ,[New] = {packItem.New}
                          ,[Selected] = {packItem.Selected}
                          ,[Tags] = '{packItem.Tags}'
                     WHERE id = {packItem.Id};
                 ";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    try
                    {
                        formMain._Form1.updateStatus("About to update this item - " + packItem.Item);
                        command.ExecuteNonQuery();
                        formMain._Form1.updateStatus("");  //Clear Status Windows
                        formMain._Form1.updateStatus("Updated item in table - " + packItem.Item);
                    }
                    catch
                    {
                        formMain._Form1.updateStatus("Failed to update item");
                    }
                }
            }
        }
        public DataTable ItemsList
           //public BindingList<PackItemList> ItemsList
        {
            get
            {
                //SortableBindingList<PackItemList> PackItemList = new SortableBindingList<PackItemList>();
                DataTable dt = new DataTable();
                dt.Columns.Add("ListOrder", typeof(int));
                dt.Columns.Add("GroupName", typeof(String));
                dt.Columns.Add("Item", typeof(String));
                dt.Columns.Add("grams", typeof(String));
                dt.Columns.Add("ounces", typeof(String));
                dt.Columns.Add("lb", typeof(String));
                dt.Columns.Add("oz", typeof(String));
                dt.Columns.Add("Notes", typeof(String));
                dt.Columns.Add("New", typeof(String));
                dt.Columns.Add("Selected", typeof(String));
                dt.Columns.Add("Tags", typeof(String));

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT 
	  [Groups].ListOrder
      ,[PackItems].[GroupName]
      ,[PackItems].[Item]
      ,[PackItems].[grams]
      ,[PackItems].[ounces]
      ,[PackItems].[lb]
      ,[PackItems].[oz]
      ,[PackItems].[Notes]
      ,[PackItems].[New]
      ,[PackItems].[Selected]
      ,[PackItems].[Tags]
  FROM [PackItems]
  JOIN [Groups] on [Groups].GroupName = [PackItems].GroupName
  ORDER BY [Groups].ListOrder, [PackItems].[Item]";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            /* if (reader.HasRows)
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    dt.Columns.Add(new DataColumn(reader.GetName(i)));
                                }
                            }
                            */
                            int j = 0;
                            while (reader.Read())
                            {
                                DataRow dr = dt.NewRow();
                                dt.Rows.Add(dr);

                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    if (i == 0)
                                    {
                                        dt.Rows[j][i] = Convert.ToInt32(reader.GetValue(i));
                                    } else
                                    {
                                        dt.Rows[j][i] = (reader.GetValue(i));
                                    }
                                }

                                j++;

/*                                
                                //int id = reader.GetInt32(reader.GetOrdinal("Id"));
                                int listOrder = reader.GetInt32(reader.GetOrdinal("ListOrder"));
                                string item = reader.GetString(reader.GetOrdinal("Item"));
                                string groupName = reader.GetString(reader.GetOrdinal("GroupName"));
                                string tags = reader.GetString(reader.GetOrdinal("Tags"));
                                string notes = reader.GetString(reader.GetOrdinal("Notes"));
                                int grams = reader.GetInt32(reader.GetOrdinal("grams"));
                                decimal ounces = reader.GetDecimal(reader.GetOrdinal("ounces"));    //calculated: grams * 28.3495 (This i grams per ounce.  0.035274 is oz/gm)
                                int lb = reader.GetInt32(reader.GetOrdinal("lb"));                //calculated: ounces % 16
                                decimal oz = reader.GetDecimal(reader.GetOrdinal("oz"));            //calculated: ounces - ((ounces % 16) * 16)
                                bool _new = reader.GetBoolean(reader.GetOrdinal("New"));
                                bool selected = reader.GetBoolean(reader.GetOrdinal("Selected")); ;
                                //PackItemList.Add(new PackItemList(listOrder, groupName, item, grams, ounces, lb, oz, _new, selected, tags, notes));
*/                                
                            }
                        }
                    }
                    //return PackItemList;
                    return dt;
                }
            }
        }

    }
}
