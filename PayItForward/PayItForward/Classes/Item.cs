using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PayItForward.Classes
{
    public class Item
    {
        #region Fields

        private int _itemId;
        private string _name;
        private double _price;
        private double _weight;
        private Category _category; //do we want a singular catagory for an item?

        #endregion

        public Item()
        {
            Name = "";
            Price = 0.0;
            Weight = 0.0;
        }

        public Item(string name, double price, double weight)
        {
            Name    = name;
            Price   = price;
            Weight  = weight;
        }

        #region Methods

        public Item GetItem(string name)
        {
            //build query, query, return
            throw new NotImplementedException();
            
        }

        #endregion

        #region Properties

        [Key]
        public int itemId
        {
            get { return _itemId; }
            set { _itemId = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public double Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }
        public Category Category
        {
            get { return _category; }
            set { _category = value; }
        }

        #endregion
    }
}