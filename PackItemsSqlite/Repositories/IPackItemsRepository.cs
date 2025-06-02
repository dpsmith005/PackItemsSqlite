using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace PackItemsSqlite
{
    public interface IPackItemsRepository
    {
        IEnumerable<PackItemDGV> GetGridItems(string kind, string value);
        IEnumerable<PackItem> GetAllPackItems();
        IEnumerable<PackItem> GetSinglePackItem(string value);
        IEnumerable<GroupItem> GetAllGroups();
        IEnumerable<TagItem> GetAllTags();
        void PackItemDelete(string item);
        void PackItemInsert(PackItem packItem);
        void PackItemUpdate(PackItem packItem);
        void GroupItemUpdate(string GroupName, int ListOrder);
    }

    public class PackItemsRepository : IPackItemsRepository
    {
        private static string connectionString = @"Data Source=..\..\Files\SQLitePack.db;Version=3";

        public IEnumerable<PackItemDGV> GetGridItems(string kind, string value)
        {
            List<PackItemDGV> PackItemDGV = new List<PackItemDGV>();
            string query;

            switch (kind)
            {
                case "Item":
                    query = "select Item, GroupName, Tags, Id from PackItems where Item like '%" + value + "%' order by GroupName,Item";
                    break;
                case "Group":
                    query = "select Item, GroupName, Tags, Id from PackItems where GroupName = '" + value + "' order by GroupName,Item";
                    break;
                case "Tag":
                    query = "select Item, GroupName, Tags, Id from PackItems where Tags like '%" + value + "%' order by GroupName,Item";
                    break;
                default:
                    query = "select Item, GroupName, Tags, Id from PackItems order by GroupName,Item";
                    break;
            }
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

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
                            PackItemDGV.Add(new PackItemDGV(item, groupName, tags, id));
                        }
                    }
                }
            }
            return PackItemDGV;
        }
        public IEnumerable<PackItem> GetAllPackItems()
        {
            List<PackItem> PackItem = new List<PackItem>();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM PackITems order by GroupName,Item";

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
        public IEnumerable<PackItem> GetSinglePackItem(string value)
        {
            List<PackItem> PackItem = new List<PackItem>();

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
        public IEnumerable<GroupItem> GetAllGroups()
        {
            List<GroupItem> grpItems = new List<GroupItem>();
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
            return grpItems;
        }
        public IEnumerable<TagItem> GetAllTags()
        {
            List<TagItem> tagItems = new List<TagItem>();
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
            return tagItems;
        }
        public void PackItemDelete(string item)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM[PackItems] WHERE Item = '" + item + "'";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    MainForm._Form1.updateStatus("About to delete this item - " + item);
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this item?", "Confirm Delete Data", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {
                        command.ExecuteNonQuery();
                        MainForm._Form1.updateStatus("");  //Clear Status Windows
                        MainForm._Form1.updateStatus("Deleted item from table - " + item);
                    }
                    else
                    {
                        MainForm._Form1.updateStatus("Item delete canceled");
                    }
                }
            }
        }
        public void PackItemInsert(PackItem packItem)
        {
            MainForm._Form1.updateStatus("Inserting item into table");
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string values = "'" + packItem.GroupName + "','" + packItem.Item + "'," + packItem.grams + "," + packItem.ounces + "," + packItem.lb + "," + packItem.oz + ",'" + packItem.Notes + "'," + packItem.New + "," + packItem.Selected + ",'" + packItem.Tags + "'";
                string query = "INSERT INTO [PackItems] ([GroupName], [Item], [grams], [ounces], [lb], [oz], [Notes], [New], [Selected], [Tags]) VALUES (" + values + ");";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    try
                    {
                        MainForm._Form1.updateStatus("About to insert this item - " + packItem.Item);
                        command.ExecuteNonQuery();
                        MainForm._Form1.updateStatus("");  //Clear Status Windows
                        MainForm._Form1.updateStatus("Inserted item to table - " + packItem.Item);
                    }
                    catch
                    {
                        MainForm._Form1.updateStatus("Failed to insert item");
                    }
                }
            }
        }
        public void PackItemUpdate(PackItem packItem)
        {
            MainForm._Form1.updateStatus("Updating item in table");
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
                        MainForm._Form1.updateStatus("About to update this item - " + packItem.Item);
                        command.ExecuteNonQuery();
                        MainForm._Form1.updateStatus("");  //Clear Status Windows
                        MainForm._Form1.updateStatus("Updated item in table - " + packItem.Item);
                    }
                    catch
                    {
                        MainForm._Form1.updateStatus("Failed to update item");
                    }
                }
            }
        }
        public void GroupItemUpdate(string GroupName, int ListOrder)
        {
            MainForm._Form1.updateStatus("Updating Groups order number.  Item: " + GroupName + " Order: " + ListOrder);
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
                        MainForm._Form1.updateStatus("Updating Groups order number.  Item: " + GroupName + " Order: " + ListOrder);
                        command.ExecuteNonQuery();
                        //MainForm._Form1.updateStatus("");  //Clear Status Windows
                        MainForm._Form1.updateStatus("Updated item in Groups table.  Item: " + GroupName + " Order: " + ListOrder);
                    }
                    catch
                    {
                        MainForm._Form1.updateStatus("Failed to update Group item for " + GroupName);
                    }
                }
            }
        }
    }
}
