using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayItForward.Classes
{
    public class Category
    {
        #region Fields

        private string _name;
        private int _id;

        #endregion

        public Category()
        {
            Name = "";
            Id = 0;
        }

        public Category(int id, string name)
        {
            Name    = name;
            Id = id;
        }

        #region Methods

        public bool GetCategory(string query)
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

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        #endregion
    }
}