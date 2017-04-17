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
        private double _low_value;
        private double _high_value;
        private double _weight;
        private Category _category; //do we want a singular catagory for an item?

        #endregion

        public Item()
        {
            Name = "";
            LowPrice = 0.0;
            HighPrice = 0.0;
            Weight = 0.0;
        }

        public Item(string name, double lowValue, double highValue, double weight)
        {
            Name = name;
            LowPrice = lowValue;
            HighPrice = highValue;
            Weight = weight;
        }

        #region Methods

        public Item GetItem(string name)
        {
            //build query, query, return
            throw new NotImplementedException();
            
        }

        public override bool Equals(object obj)
        {
            var other = obj as Item;

            return itemId == other.itemId;
        }

        public override int GetHashCode()
        {
            return itemId.GetHashCode();
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

        public double LowPrice
        {
            get { return _low_value; }
            set { _low_value = value; }
        }

        public double HighPrice
        {
            get { return _high_value; }
            set { _high_value = value; }
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