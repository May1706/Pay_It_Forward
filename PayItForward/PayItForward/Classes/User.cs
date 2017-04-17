using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Text;

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
        private String _key;

        // Bitwise tracking of privileges user has
        private int _privileges;

        // List of donation centers for which user has edit privileges
        private List<DonationCenter> _centers;

        // Stores names of donation centers to avoid unnecessary queries
        private List<string> _centerNames;

        // Donations made by this user
        private List<Donation> _donations;

        #endregion

        public User(string email, string password, string key)
        {
            setDefaults();
            Username = email;
            Password = password;
        }

        public User()
        {
            setDefaults();
        }

        #region Methods

        private void setDefaults()
        {
            DonationsString = "";
            _privileges = 0;
            centersAsString = "";
        }
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

        /**
         * Adds a donation to the list of donations attached to this account
         */
        public void addDonation(Donation donation)
        {
            _donations.Add(donation);
        }

        /**
         * Returns a list of the donations this user has made
         */
        public List<Donation> getDonations() { return _donations; }

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

        /**
         * Stores the donations attached to this User in a comma separated
         * list of the donation ID's
         */
        public string DonationsString
        {
            get
            {
                if (_donations == null || _donations.Count == 0) { return ""; }

                StringBuilder sb = new StringBuilder();
                sb.Append(_donations[0].Id);

                for (int i = 1; i < _donations.Count; i++)
                {
                    sb.Append("," + _donations[i].Id);
                }

                return sb.ToString();
            }

            set
            {
                _donations = new List<Donation>();

                if (value == null) return;

                string[] splitString = value.Split(',');
                foreach (string donationId in splitString)
                {
                    try
                    {
                        int id = int.Parse(donationId);
                        using (var db = new DatabaseContext())
                        {

                            Donation don = db.Donations
                                .Where(d => d.Id == id)
                                .FirstOrDefault();
                            _donations.Add(don);
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("User db entry formatted incorrectly"
                            + ": Expected int for donation id, got "
                            + donationId);
                    }
                }
            }
        }

        #endregion
    }
}