﻿using System;
using PayItForward.Classes;

namespace PayItForward.Pages
{
    public partial class DonationCenterProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dcName.Font.Size = 30;

            using (var db = new DatabaseContext())
            {
                DonationCenter dc = db.DonationCenters.Find(0);

                if (Session["donationCenter"] != null)
                {
                    dc = (DonationCenter)Session["donationCenter"];
                }

                dcName.Text         = dc.CenterName;
                dcAddress.Text      = dc.Address;
                if (dc.ImageURL != null)
                    dcImage.ImageUrl = dc.ImageURL;
                dcPhone.Text        = "No Phone";
                dcDescription.Text  = "No Description";

                string[] hours = dc.Hours.Split(';');
                sundayHours.Text    = hours[0];
                mondayHours.Text    = hours[1];
                tuesdayHours.Text   = hours[2];
                wednesdayHours.Text = hours[3];
                thursdayHours.Text  = hours[4];
                fridayHours.Text    = hours[5];
                saturdayHours.Text  = hours[6];

                foreach (string s in dc.CategoryNamesAsString.Split(';'))
                {
                    dcItems.InnerHtml += s + "<br/>";
                }

                dcUpdated.Text = dc.LastUpdate.ToString();
            }
        }
    }
}