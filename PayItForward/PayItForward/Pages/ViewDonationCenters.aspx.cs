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
        Dictionary<DonationCenter, List<Item>> centerItems = new Dictionary<DonationCenter, List<Item>>();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Item> items = (List<Item>)Session["donationItems"];

            if(items == null || items.Count == 0)
            {

                using (var db = new DatabaseContext())
                {
                    foreach (DonationCenter c in db.DonationCenters)
                    {
                        List<Item> temp = new List<Item>();
                        centerItems.Add(c, temp);
                    }
                }
            }
            else
            {
                using (var db = new DatabaseContext())
                {
                    foreach (Item i in items)
                    {
                        foreach(DonationCenter c in db.DonationCenters)
                        {
                            if (!c.CategoryNames.Contains(i.Category.Name))
                            {
                                continue;
                            }
                            if (centerItems.ContainsKey(c))
                            {
                                if (!centerItems[c].Contains(i))
                                {
                                    centerItems[c].Add(i);
                                }
                            }
                            else
                            {
                                List<Item> temp = new List<Item>();
                                temp.Add(i);
                                centerItems.Add(c, temp);
                            }
                        }
                    }
                }
            }
            Create_Table();
        }
        protected void Create_Table()
        {
            /* there's probably a better way to do this */
            centerDisplay.InnerHtml  = "";
            foreach(DonationCenter c in centerItems.Keys)
            {
                centerDisplay.InnerHtml += "<table>";
                centerDisplay.InnerHtml += "<tr><td><strong>";
                centerDisplay.InnerHtml += c.CenterName;
                centerDisplay.InnerHtml += "</strong></td></tr>";

                if(c.Address != null)
                {
                    centerDisplay.InnerHtml += "<tr><td><a href=\"http://maps.google.com/?q=" + c.Address + "\" target=\"_blank\">" + c.Address + "</a></td></tr>";
                }
                if(c.Hours != null)
                {
                    centerDisplay.InnerHtml += "<tr><td>" + c.Hours +"</td></tr>";
                }


                centerDisplay.InnerHtml += "<tr><td>Takes: ";
                if (centerItems[c].Count > 0)
                {
                    foreach(Item i in centerItems[c])
                    {
                        centerDisplay.InnerHtml += "<em>" + i.Name + "</em>";
                        centerDisplay.InnerHtml += ", ";
                    }
                    centerDisplay.InnerHtml = centerDisplay.InnerHtml.Substring(0, centerDisplay.InnerHtml.Length - 2);
                }
                else
                {
                    centerDisplay.InnerHtml += "<em>" + c.CategoryNamesAsString.Replace(",",", ") + "</em>";
                }

                centerDisplay.InnerHtml += "</td></tr>";


                centerDisplay.InnerHtml += "</table><br />";
            }
        }

    }
}