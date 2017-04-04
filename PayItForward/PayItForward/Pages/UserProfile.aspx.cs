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
            userName.Font.Size = 30;

            using (var db = new DatabaseContext())
            {
                User user = db.Users.Find(1);

                if (Session["activeUser"] != null)
                {
                    user = (User)Session["activeUser"];
                }

                userName.Text = user.Username;

                foreach (string s in user.centersAsString.Split(';'))
                {
                    userCenters.InnerText += user.centersAsString;
                }

                userHistory.InnerText = "No History";
            }
        }

        protected void createCenter_Click(object sender, EventArgs e)
        {
            Response.BufferOutput = true;
            Response.Redirect("/Pages/DonationCenterCreate.aspx");
        }
    }
}