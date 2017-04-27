using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PayItForward.Classes
{
    public class Category
    {

        #region Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }

        // TODO Will need to perform a search if we ever actually need the
        // objects. Operating under assumption, we usually need just the item names
        public virtual List<Item> Items { get; set; }

        // Stored as a formatted string of the names of items
        public List<string> ItemNames { get; set; }

        public string itemString
        {
            get { return ItemNames != null ? string.Join(";", ItemNames) : null; }
            set {
                if (value != null && !value.Equals(""))
                    ItemNames = value.Split(';').ToList();
                else
                    ItemNames = null;
            }
        }

        #endregion

        #region Constructors

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

        #endregion

        #region Methods

        public void addItem(Item item)
        {
            if (ItemNames == null)
            {
                ItemNames = new List<string>();
            }

            ItemNames.Add(item.Name);
        }

        public void removeItem(Item item)
        {
            if (ItemNames == null) return;

            if (ItemNames.Contains(item.Name))
            {
                ItemNames.Remove(item.Name);
            }
        }

        #endregion
    }
}