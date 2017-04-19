using PayItForward.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
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

                if (user.centersAsString != null)
                {
                    foreach (string s in user.centersAsString.Split(';'))
                    {
                        userCenters.InnerText += user.centersAsString;
                    } 
                }

                userHistory.InnerText = "No History";
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
    }
}