using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayItForward.Classes
{
    public class Item
    {
        #region Fields

        private int _itemId;
        private string _name;
        private double _weight;
        private Category _category; //do we want a singular catagory for an item?

        #endregion

        public Item()
        {
            Name = "";
            LowPrice = 0;
            HighPrice = 0;
            Weight = 0.0;
        }

        public Item(string name, decimal lowValue, decimal highValue, double weight)
        {
            Name = name;
            LowPrice = lowValue;
            HighPrice = highValue;
            Weight = weight;
        }

        #region Methods

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

        public decimal LowPrice
        {
            get; set;
        }

        public decimal HighPrice
        {
            get; set;
        }

        public double Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        [NotMapped]
        public Category Category
        {
            get
            {
                using (var db = new DatabaseContext())
                {
                    return db.GetCategory(StringCategory);
                }
            }
            set
            {
                _category = value;
            }
        }

        public string StringCategory { get; set; }

        #endregion
    }
}