using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PayItForward.Classes;
using System.Data;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Text;
using System.IO;
using System.Web.Services;
using Newtonsoft.Json;
using System.Data.Entity;

namespace PayItForward.Pages
{
    public partial class CreateList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Response.Cache.SetNoStore();
            //Response.Cache.SetExpires(DateTime.MinValue);

            //cart.InnerHtml = "";
           

            if (Session["donationItems"] != null)
            {
                foreach (Item i in (List<Item>)Session["donationItems"])
                {
                    cart.InnerHtml += @"<div class='ditem' draggable='false'>
                                        <div>" + i.Name + @"</div>
                                        <i class='js-remove'>✖</i>
                                        </div>";
                }
            }

            //populateCategories();
            populateCategoriesDropdown();
        }

        //Populate the categories dropdown with database categories
        protected void populateCategoriesDropdown()
        {
            if (categoryList.Items.Count < 1)
            {
                using (var db = new DatabaseContext())
                {
                    List<string> categories = (from c in db.Categories select c.Name).ToList();

                    foreach (string c in categories)
                    {
                        categoryList.Items.Add(new ListItem(c));
                    }
                }
            }

            using (var db = new DatabaseContext())
            {
                string[] items = (from category in db.Categories
                                  where category.Name == categoryList.SelectedItem.Text
                                  select category.itemString).ToList()[0].Split(';');

                availableItems.InnerHtml = "";

                foreach (string i in items)
                {
                    availableItems.InnerHtml += @"<div class='ditem' draggable='false'>
                                                <div>" + i + @"</div>
                                                <i class='js-remove'>✖</i>
                                                </div>";
                }
            }
        }

        //Populate the available items list with categories; this is in place of specific items
        protected void populateCategories()
        {
            using (var db = new DatabaseContext())
            {
                List<string> categories = (from c in db.Categories select c.Name).ToList();

                availableItems.InnerHtml = "";
                foreach (string c in categories)
                {
                    availableItems.InnerHtml += @"<div class='ditem' draggable='false'>
                                                <div>" + c + @"</div>
                                                <i class='js-remove'>✖</i>
                                                </div>";
                }
            }
        }

        [WebMethod]
        public static string GetItemsFromCategory(string value)
        {
            string c = value.Replace('\"', ' ').Replace('}', ' ').Trim();

            List<string> items;

            using (var db = new DatabaseContext())
            {
                items = (from category in db.Categories
                         where category.Name == c
                         select category.itemString).ToList();

                if (items[0] != null)
                {
                    items = items[0].Split(';').ToList();
                }
                else
                {
                    items = null;
                }
            }

            return JsonConvert.SerializeObject(items);
        }

        //The user has finished their list and wants to see appicable donation centers
        protected void submitButton_Click(object sender, EventArgs e)
        {
            Session["donationItems"] = null;

            if (cartText.Text != null && cartText.Text.Length > 0)
            {
                List<Item> items = new List<Item>();

                string ditems = cartText.Text;
                
                string[] strings = Regex.Split(ditems, ";");
                
                foreach (string s in strings)
                {
                    if (s.Trim() != "✖" && s.Trim().Length > 0)
                    {
                        using (var db = new DatabaseContext())
                        {
                            items.Add(db.GetItem(s.Trim()));
                        }
                    }
                }

                Session["donationItems"] = items;

                Response.BufferOutput = true;
                Response.Redirect("/Pages/ViewDonationCenters.aspx");
            }
            else
            {
                string message = "You must add at least one item to your donation cart!";
                Response.Write("<script language='javascript'>alert('" + message + "');</script>");
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            Session["donationItems"] = null;
            if (cartText.Text != null && cartText.Text.Length > 0)
            {
                List<Item> items = new List<Item>();

                string ditems = cartText.Text;

                string[] strings = Regex.Split(ditems, ";");

                foreach (string s in strings)
                {
                    if (s.Trim() != "✖" && s.Trim().Length > 0)
                    {
                        using (var db = new DatabaseContext())
                        {
                            items.Add(db.GetItem(s.Trim()));
                        }
                    }
                }
                
                if (Session["activeUser"] != null)
                {
                    Donation donation = new Donation();

                    items.Sort((x, y) => x.Name.CompareTo(y.Name));
                    // Add each item to donation
                    if (items.Count == 1)
                    {
                        donation.addItem(items[0], null, 1);
                    }
                    else if (items.Count > 0)
                    {
                        Item lastItem = items[0];
                        int count = 1;

                        for (int i = 1; i < items.Count; i++)
                        {
                            // TODO: dynamically add donation center
                            Item thisItem = items[i];
                            if (lastItem.Name.Equals(thisItem.Name))
                            {
                                count++;
                            }
                            else
                            {
                                donation.addItem(lastItem, null, count);
                                lastItem = thisItem;
                                count = 1;
                            }

                            if (i + 1 >= items.Capacity)
                            {
                                donation.addItem(thisItem, null, count);
                            }
                        }
                    }
                    

                    donation.DonationDateTime = DateTime.Now;

                    using (var db = new DatabaseContext())
                    {
                        // Write donation to database
                        db.Donations.Add(donation);
                        db.SaveChanges();

                        // Add donation to user and update
                        User currentUser = (User)Session["activeUser"];
                        currentUser.addDonation(donation);
                        db.Users.Attach(currentUser);
                        db.Entry(currentUser).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                else
                {
                    //if not logged in redirect to log in page
                    Response.BufferOutput = true;
                    Response.Redirect("/Pages/Login.aspx");
                }
                Session["donationItems"] = items;
                Response.BufferOutput = true;
                Response.Redirect("/Pages/ViewDonationCenters.aspx");
            }
            else
            {
                string message = "You must add at least one item to your donation cart!";
                Response.Write("<script language='javascript'>alert('" + message + "');</script>");
            }
        }
    }
}