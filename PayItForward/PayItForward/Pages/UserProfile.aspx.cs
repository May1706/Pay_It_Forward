using PayItForward.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PayItForward.Pages
{
    public partial class UserProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["activeUser"] == null)
            {
                Response.BufferOutput = true;
                Response.Redirect("/Pages/Login.aspx");
            }

            userName.Font.Size = 30;

            using (var db = new DatabaseContext())
            {
                User user = (User)Session["activeUser"];

                userName.Text = user.Username;

                List<DonationCenter> centers = db.DonationCenters.Where(c => c.UserId == user.UserID).ToList();
                String centerText = "";
                foreach(DonationCenter d in centers)
                {
                    centerText += "<a href=\"/Pages/DonationCenterEdit.aspx?center=" + d.CenterId + "\">" + d.CenterName + "</a><br />";
                }
                userCenters.InnerHtml = centerText;
                userHistory.InnerHtml = getDonationHistoryText();
            }
        }

        protected void createCenter_Click(object sender, EventArgs e)
        {
            Response.BufferOutput = true;
            Response.Redirect("/Pages/DonationCenterCreate.aspx");
        }

        protected void logoutButton_Click(object sender, EventArgs e)
        {
            Session["activeUser"] = null;

            Response.BufferOutput = true;
            Response.Redirect("/Pages/Home.aspx");
        }

        private string getDonationHistoryText()
        {
            User user = (User)Session["activeUser"];
            List<Donation> donations = user.getDonations();

            if (donations == null ||  donations.Count == 0)
            {
                return "No History";
            }

            StringBuilder retVal = new StringBuilder();

            foreach (Donation d in donations)
            {
                retVal.AppendLine(d.DonationDateTime.ToShortDateString() + "<br />");
                List<DonatedItem> items = d.Items;
                foreach(DonatedItem item in items)
                {
                    retVal.Append(item.Quantity + "x " + item.ItemType.Name + " - ");
                    if (item.Center == null)
                    {
                        retVal.Append("Donation center not specified at time of donation");
                    }
                    else
                    {
                        retVal.Append("Donated to " + item.Center.CenterName);
                    }
                    retVal.Append("<br />");
                }
                retVal.Append("<br/>");
            }

            return retVal.ToString();
        }
    }
}