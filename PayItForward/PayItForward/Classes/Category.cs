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

        public virtual List<Item> Items { get; set; }

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