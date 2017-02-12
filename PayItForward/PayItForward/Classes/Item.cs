using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayItForward.Classes
{
    public class Item
    {
        #region Fields

        private string _name;
        private double _price;
        private double _weight;
        private List<Category> _categories;

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

        public bool GetItem(string query)
        {
            return false;
        }

        #endregion

        #region Properties

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
        public List<Category> Categories
        {
            get { return _categories; }
            set { _categories = value; }
        }

        #endregion
    }
}