using PayItForward.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PayItForward.Pages
{
    public partial class DonationCenterCreate : System.Web.UI.Page
    {
        User u;
        protected void Page_Load(object sender, EventArgs e)
        {
            u = (User)Session["activeUser"];

            if (u != null)
            {
                //load page normally
            }
            else
            {
                //Must be logged in
                //Response.Redirect("Login.aspx");
            }
        }

        protected void CreateCenter_Click(object sender, EventArgs e)
        {
            using (var db = new DatabaseContext())
            {
                string centerName = Name.Text;
                //make string of hours out of things
                string sun = "Sunday: closed ";
                string mon = "Monday: closed ";
                string tue = "Tuesday: closed ";
                string wed = "Wednesday: closed ";
                string thu = "Thursday: closed ";
                string fri = "Friday: closed ";
                string sat = "Saturday: closed ";
                if (DropDownList1.SelectedValue.Equals(-1) || DropDownList2.SelectedValue.Equals(-1))
                {
                    sun = "Sunday " + DropDownList1.Text + " " + DropDownList2.Text + ";";
                }
                
                string hours = sun + mon + tue + wed + thu + fri + sat;
                string address = Address.Text;
                string pickup = PickupTextBox.Text;
                //deal with categories
                List<string> categories;
                DonationCenter center = new DonationCenter(u.UserID, centerName, hours, address, pickup, categories);
            }
        }

        protected void CenterExists()
        {
            ExistsPanel.Visible = true;
        }
    }
}