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
        public const int VISIBLE = 1;
        public const int INVISIBLE = 0;

        private int _centerId;
        private string _centerName;
        private string _hours;
        private string _address;
        private string _pickup;
        private string _phoneNumber;
        private string _description;
        private string _website;
        private string _imageURL;
        private string _contactEmail;
        private DateTime _lastUpdate;
        private int _status;

        // Lazy instantiation
        private List<Item> _items;

        // Auto-populated from the concatenated string stored in DB
        private List<string> _itemNames;

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

        public string statusToString()
        {
            switch(_status)
            {
                case INVISIBLE:
                    return "invisible";
                case VISIBLE:
                    return "visible";
                default:
                    return "Error occured on Donation Center status";
            }
        }

        public Item GetCenter(string name)
        {
            //build query, query, return
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            var other = obj as DonationCenter;

            return CenterId == other.CenterId;
        }

        public override int GetHashCode()
        {
            return CenterId.GetHashCode();
        }
        #endregion

        #region Properties

        [Key]
        public int CenterId
        {
            get { return _centerId; }
            set { _centerId = value; }
        }

        public int UserId { get; set; }

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

        public List<string> ItemNames
        {
            get { return _itemNames; }
            set { _itemNames = value; }
        }

        public string ItemNamesAsString
        {
            get { return string.Join(",", ItemNames); }
            set { ItemNames = (value != null)?value.Split(',').ToList():new List<string>(); }
        }
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public string Website
        {
            get { return _website; }
            set { _website = value; }
        }
        public string ImageURL
        {
            get { return _imageURL; }
            set { _imageURL = value; }
        }
        public string ContactEmail
        {
            get { return _contactEmail; }
            set { _contactEmail = value; }
        }

        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
        #endregion

    }
}