using System;
using System.Collections.Generic;
using PayItForward.Classes;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace PayItForward.Pages
{
    public partial class ViewDonationCenters : System.Web.UI.Page
    {
        Dictionary<DonationCenter, List<Item>> centerItems = new Dictionary<DonationCenter, List<Item>>();

        protected void Page_Load(object sender, EventArgs e)
        {
            GenerateContent();
        }

        protected void imageClick(object sender, CommandEventArgs e)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                Session["donationCenter"] = db.GetCenter(e.CommandArgument.ToString());
            }
            
            Response.BufferOutput = true;
            Response.Redirect("/Pages/DonationCenterProfile.aspx");
        }

        protected void GenerateContent()
        {
            List<Item> items = (List<Item>)Session["donationItems"];

            if (items == null || items.Count == 0)
            {
                using (var db = new DatabaseContext())
                {
                    foreach (DonationCenter c in db.DonationCenters)
                    {
                        if(c.Status == DonationCenter.VISIBLE)
                        {
                            List<Item> temp = new List<Item>();
                            centerItems.Add(c, temp);

                        }
                    }
                }
            }
            else
            {
                using (var db = new DatabaseContext())
                {
                    foreach (Item i in items)
                    {
                        foreach (DonationCenter c in db.DonationCenters)
                        {
                            if (!c.CategoryNames.Contains(i.Category.Name) || c.Status != DonationCenter.VISIBLE)
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
            centerDisplay.InnerHtml = "";

            foreach (DonationCenter c in centerItems.Keys)
            {
                if(c.Status != DonationCenter.VISIBLE)
                {
                    continue;
                }
                //TODO: Need to programmatically grab this
                string dcImage = (c.ImageURL != null)? c.ImageURL : "/Images/DefaultDCImage.png";

                // Image
                Table centerInfo = new Table();
                ImageButton imageButton = new ImageButton();
                imageButton.CssClass = "dcThumb dcStuff";
                imageButton.Command += new CommandEventHandler(imageClick);
                imageButton.CommandArgument = c.CenterName;
                imageButton.ImageUrl = dcImage;

                // Donation Center Information
                centerInfo.CssClass = "dcInfo dcStuff";

                // Name
                TableRow nameRow = new TableRow();
                TableCell dcName = new TableCell();
                dcName.Text = c.CenterName;
                dcName.Font.Bold = true;
                nameRow.Cells.Add(dcName);
                centerInfo.Rows.Add(nameRow);

                // Address
                TableRow addressRow = new TableRow();
                TableCell dcAddress = new TableCell();
                if (c.Address != null)
                {
                    dcAddress.Text = "<a href =\"http://maps.google.com/?q=" + c.Address + "\" target=\"_blank\">" + c.Address + "</a>";
                }
                else
                {
                    dcAddress.Text = "NO ADDRESS";
                }
                addressRow.Cells.Add(dcAddress);
                centerInfo.Rows.Add(addressRow);

                // Hours
                TableRow hoursRow = new TableRow();
                TableCell dcHours = new TableCell();
                if (c.Hours != null)
                {
                    dcHours.Text = c.Hours.Split(';')[(int)DateTime.Now.DayOfWeek];
                }
                else
                {
                    dcHours.Text = "NO HOURS";
                }
                hoursRow.Cells.Add(dcHours);
                centerInfo.Rows.Add(hoursRow);

                // "Accepts"
                TableRow aRow = new TableRow();
                TableCell dcA = new TableCell();
                dcA.Text = "Accepts:";
                aRow.Cells.Add(dcA);
                centerInfo.Rows.Add(aRow);

                // Accepted Items
                TableRow itemsRow = new TableRow();
                TableCell dcItems = new TableCell();
                if (centerItems[c].Count > 0)
                {
                    foreach (Item i in centerItems[c])
                    {
                        dcItems.Text += "<em>" + i.Name + "</em>";
                        dcItems.Text += ", ";
                    }
                   dcItems.Text = dcItems.Text.Substring(0, dcItems.Text.Length - 2);
                }
                else
                {
                    dcItems.Text += "<em>" + c.CategoryNamesAsString.Replace(";", ", ") + "</em>";
                }
                itemsRow.Cells.Add(dcItems);
                centerInfo.Rows.Add(itemsRow);

                // Container
                Panel dcPanel = new Panel();
                dcPanel.CssClass = "dcBox";
                dcPanel.Controls.Add(imageButton);
                dcPanel.Controls.Add(centerInfo);

                // Add to page
                centerDisplay.Controls.Add(dcPanel);
            }
        }
    }
}