using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PayItForward.Classes
{
    public class Category
    {

        #region Properties

        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        // TODO Will need to perform a search if we ever actually need the
        // objects. Operating under assumption, we usually need just the item names
        public virtual List<Item> Items { get; set; }

        // Stored as a formatted string of the names of items
        public List<string> ItemNames { get; set; }

        public string itemString
        {
            get { return ItemNames != null ? string.Join(",", ItemNames) : null; }
            set
            {
                if (value != null && !value.Equals(""))
                    ItemNames = value.Split(',').ToList();
                else
                    ItemNames = null;
            }
        }

        #endregion

        public Category(int id, string name, List<Item> items)
        {
            ID = id;
            Name = name;
            Items = items;
        }
        public Category(int id, string name)
        {
            ID = id;
            Name = name;
            Items = new List<Item>();
        }
        public Category()
        {

        }
    }
}