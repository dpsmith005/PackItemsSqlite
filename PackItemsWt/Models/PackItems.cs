using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PackItemsWt
{
    public class PackItem
    {
        //[Browsable(false)]
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string Item { get; set; }
        public int grams { get; set; }
        public decimal ounces { get; set; } //calculate before storing  //calculated: grams * 28.3495 (This i grams per ounce.  0.035274 is oz/gm)
        public int lb { get; set; }         //calculate before storing  //calculated: ounces % 16
        public decimal oz { get; set; }     //calculate before storing  //calculated: ounces - ((ounces % 16) * 16)
        public bool New { get; set; }
        public bool Selected { get; set; }
        public string Tags { get; set; }
        public string Notes { get; set; }
        public PackItem()
        {

        }
        public PackItem(int id, string groupName, string item, int grams, decimal ounces, int lb, decimal oz, bool @new, bool selected, string tags, string notes)
        {

            Id = id;
            GroupName = groupName;
            Item = item;
            this.grams = grams;
            this.ounces = ounces;   //grams * 28.3495
            this.lb = lb;           //ounces % 16
            this.oz = oz;           //ounces - ((ounces % 16) * 16)
            New = @new;
            Selected = selected;
            Tags = tags;
            Notes = notes;
        }
    }
    public class PackItemList
    {
        public int ListOrder { get; set; }
        public string GroupName { get; set; }
        public string Item { get; set; }
        public int grams { get; set; }
        public decimal ounces { get; set; } //calculate before storing  //calculated: grams * 28.3495 (This i grams per ounce.  0.035274 is oz/gm)
        public int lb { get; set; }         //calculate before storing  //calculated: ounces % 16
        public decimal oz { get; set; }     //calculate before storing  //calculated: ounces - ((ounces % 16) * 16)
        public bool New { get; set; }
        public bool Selected { get; set; }
        public string Tags { get; set; }
        public string Notes { get; set; }
        public PackItemList()
        {

        }
        public PackItemList(int listOrder, string groupName, string item, int grams, decimal ounces, int lb, decimal oz, bool @new, bool selected, string tags, string notes)
        {

            ListOrder = listOrder;
            GroupName = groupName;
            Item = item;
            this.grams = grams;
            this.ounces = ounces;   //grams * 28.3495
            this.lb = lb;           //ounces % 16
            this.oz = oz;           //ounces - ((ounces % 16) * 16)
            New = @new;
            Selected = selected;
            Tags = tags;
            Notes = notes;
        }

    }
    public class PackItemDGV
    {
        //[Browsable(false)]
        public string Item { get; set; }
        public string GroupName { get; set; }
        public string Tags { get; set; }
        public int Id { get; set; }
        public PackItemDGV()
        {
        }
        public PackItemDGV(string item, string groupName, string tags, int id)
        {
            Item = item;
            GroupName = groupName;
            Tags = tags;
            Id = id;
        }
    }
    public class GroupItem
    {
        public string GroupName { get; set; }
        public int ListOrder { get; set; }
        public GroupItem()
        {

        }
        public GroupItem(string groupName, int listOrder)
        {
            GroupName = groupName;
            ListOrder = listOrder;
        }
    }
    public class TagItem
    {
        public string TagName { get; set; }
        public TagItem()
        {

        }
        public TagItem(string tagName)
        {
            TagName = tagName;
        }
    }
}
