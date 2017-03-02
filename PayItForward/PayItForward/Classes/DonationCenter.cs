using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PayItForward.Classes
{
    public class DonationCenter
    {
        #region Fields

        private int _centerId;
        private int _userId;
        private string _centerName;
        private string _hours;
        private string _address;
        private string _pickup;
        private DateTime _lastUpdate;
        private int _status;

        // Lazy instantiation
        private List<Category> _categories;

        // Auto-populated from the concatenated string stored in DB
        private List<string> _cateogyNames;

        #endregion

        public DonationCenter(int requestorId)
        {
            CenterName = "";
            UserId = requestorId;
        }

        public DonationCenter()
        {

        }

        #region Methods

        public Item GetCenter(string name)
        {
            //build query, query, return
            throw new NotImplementedException();
        }

        #endregion

        #region Properties

        [Key]
        public int CenterId
        {
            get { return _centerId; }
            set { _centerId = value; }
        }

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public string CenterName
        {
            get { return _centerName; }
            set { _centerName = value; }
        }

        public string Hours
        {
            get { return _hours; }
            set { _hours = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string Pickup
        {
            get { return _pickup; }
            set { _pickup = value; }
        }

        public DateTime LastUpdate
        {
            get { return _lastUpdate; }
            set { _lastUpdate = value; }
        }

        public List<string> CategoryNames
        {
            get { return _cateogyNames; }
            set { _cateogyNames = value; }
        }

        public string CategoryNamesAsString
        {
            get { return string.Join(",", CategoryNames); }
            set { CategoryNames = value.Split(',').ToList(); }
        }

        #endregion

    }
}