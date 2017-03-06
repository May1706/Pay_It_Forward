﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PayItForward.Classes
{
    public class User
    {
        #region Constants
        // User can perform admin functions
        public const int AdminPrivilege = 1;

        // There exists one or more donation centers the user can edit
        public const int DonationCenterPrivilege = 2;

        #endregion

        #region Fields
        private int _userID;
        private String _username;
        private String _password;

        // Bitwise tracking of privileges user has
        private int _privileges;

        // List of donation centers for which user has edit privileges
        private List<DonationCenter> _centers;

        // Stores names of donation centers to avoid unnecessary queries
        private List<string> _centerNames;

        #endregion

        public User() {}

        // todo: make specified constructor, nothing specified
        public User(string email, string password)
        {
            Username = email;
            Password = password;
        }

        #region Methods

        public void addAdminPrivilege(User grantingUser)
        {
            //todo: implement
            // Check that granting user has admin privilege
            if (grantingUser.isAdmin())
            {
                // Add privilege
            }
        }

        public bool isAdmin()
        {
            return (_privileges & AdminPrivilege) == AdminPrivilege;
        }

        public void addDonationCenter(User grantingUser, DonationCenter center)
        {
            //todo:  Check if grantingUser is admin or also has privilege for that center
            _centers.Add(center);
            _privileges = _privileges | DonationCenterPrivilege;
        }

        public bool hasDonationCenterPrivilege()
        {
            return (_privileges & DonationCenterPrivilege) 
                == DonationCenterPrivilege;
        }

        #endregion

        #region Properties

        [Key]
        public int UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        public String Username
        {
            get { return _username; }
            set { _username = value; }
        }


        // TODO: Make util for checking password w/ attempt counter
        public String Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string centersAsString
        {
            get
            {
                if (_centerNames != null)
                {
                    return string.Join(",", _centerNames); 
                }
                return null;
            }
            set { _centerNames = value.Split(',').ToList(); }
        }

        #endregion
    }
}