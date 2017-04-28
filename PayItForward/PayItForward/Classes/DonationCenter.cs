﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PayItForward.Classes
{
    public class DonationCenter
    {
        private readonly int VISIBLE = 1;
        private readonly int INVISIBLE = 0;
        
        #region Fields

        private int _centerId;
        private string _centerName;
        private string _hours;
        private string _address;
        private string _phoneNumber;
        private string _pickup;
        private string _description;
        private string _website;
        private string _imageURL;
        private string _contactEmail;
        private DateTime _lastUpdate;
        private List<string> _categories;
        private int _status;

        private string _categoryNamesAsString;

        // Lazy instantiation
        //private List<Category> _categories;

        // Auto-populated from the concatenated string stored in DB
        private List<string> _categoryNames;

        #endregion

        public DonationCenter(int requestorId)
        {
            CenterName = "";
            UserId = requestorId;
        }

        public DonationCenter(int requestorId, string name, string description, string hours, string address, string phone, string pickup, List<string> categories)
        {
            _centerName = name;
            _hours = hours;
            _address = address;
            _phoneNumber = phone;
            _pickup = pickup;
            _categories = categories;
            _description = Description;
            _categoryNamesAsString = String.Join(";", categories.ToArray());

            UserId = requestorId;
            updateTime();
            _status = INVISIBLE;
        }

        #region Methods

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

        public DateTime updateTime()
        {
            _lastUpdate = DateTime.Now; 
            return _lastUpdate;
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

        public List<string> CategoryNames
        {
            get { return _categoryNames; }
            set { _categoryNames = value; }
        }

        public string CategoryNamesAsString
        {
            get { return string.Join(",", CategoryNames); }
            set { CategoryNames = value.Split(',').ToList(); }
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