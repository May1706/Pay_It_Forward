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
                    centerText = "<a href=\"/Pages/DonationCenterEdit.aspx?center=" + d.CenterId + "\">" + d.CenterName + "</a><br />";
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
            decimal totalLow = 0;
            decimal totalHigh = 0;

            foreach (Donation d in donations)
            {
                retVal.Append(d.DonationDateTime.ToShortDateString());
                List<DonatedItem> items = d.Items;
                decimal lowSum = 0;
                decimal highSum = 0;
                foreach (DonatedItem item in items)
                {
                    lowSum += Convert.ToDecimal(item.ItemType.LowPrice * item.Quantity);
                    highSum += Convert.ToDecimal(item.ItemType.HighPrice * item.Quantity);
                }
                retVal.AppendFormat("- Estimated value = {0:C} to {0:C}", lowSum, highSum);
                retVal.Append("<br/>");
                totalLow += lowSum;
                totalHigh += highSum;

                foreach(DonatedItem item in items)
                {
                    retVal.Append(item.Quantity + "x " + item.ItemType.Name + " = ");
                    retVal.AppendFormat(" {0:C}-{0:C} - ", item.ItemType.LowPrice, item.ItemType.HighPrice);
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

            string firstLine = new StringBuilder().AppendFormat("Total Donation History = {0:C} to {0:C}", totalLow, totalHigh).Append("<br/>").ToString();
            return  firstLine + retVal.ToString();
        }
    }
}