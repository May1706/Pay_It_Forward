using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayItForward.Classes
{
    public class Category
    {
        public int Id { get; }
        public string Name { get; set; }

        public virtual List<Item> Items { get; set; }

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