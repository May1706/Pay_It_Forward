using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PayItForward
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void createListButton_Click(object sender, EventArgs e)
        {
            Response.BufferOutput = true;
            Response.Redirect("/Pages/CreateList.aspx");
        }

        protected void viewCentersButton_Click(object sender, EventArgs e)
        {
            Response.BufferOutput = true;
            Response.Redirect("/Pages/ViewDonationCenters.aspx");
        }
    }
}