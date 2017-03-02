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
        public int Id { get; set; }
        public string Name { get; set; }

        // TODO Will need to perform a search if we ever actually need the
        // objects. Operating under assumption, we usually need just the item names
        public virtual List<Item> Items { get; set; }

        // Stored as a formatted string of the names of items
        public List<string> ItemNames { get; set; }

        public string itemString
        {
            get { return string.Join(",", ItemNames); }
            set { ItemNames = value.Split(',').ToList(); }
        }

        #endregion

        public Category(int id, string name, List<Item> items)
        {
            Id = id;
            Name = name;
            Items = items;
        }
        public Category(int id, string name)
        {
            Id = id;
            Name = name;
            Items = new List<Item>();
        }

    }
}