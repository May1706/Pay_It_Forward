using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PayItForward.Classes;

namespace PayItForward.Pages
{
    public partial class CreateList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            List<Item> items = new List<Item>();

            items.Add(new Item("Test 1", 0, 0));
            items.Add(new Item("Test 2", 0, 0));
            items.Add(new Item("Test 3", 0, 0));

            Session["donationItems"] = items;

            Response.BufferOutput = true;
            Response.Redirect("/Pages/ViewDonationCenters.aspx");
        }
    }
}