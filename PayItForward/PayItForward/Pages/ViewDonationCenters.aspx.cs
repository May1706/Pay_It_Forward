using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PayItForward.Classes;

namespace PayItForward.Pages
{
    public partial class ViewDonationCenters : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Item> items = (List<Item>)Session["donationItems"];

            foreach (Item i in items)
            {
                results.InnerText += i.Name + ", ";
            }
        }
    }
}