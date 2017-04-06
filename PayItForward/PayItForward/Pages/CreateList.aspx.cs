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

        //Change the available items based on the selected category
        protected void categoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
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

        [WebMethod]
        public static string GetItemsFromCategory(string value)
        {
            string c = value.Replace('\"', ' ').Replace('}', ' ').Trim();

            List<string> items;

            using (var db = new DatabaseContext())
            {
                items = (from category in db.Categories
                         where category.Name == c
                         select category.itemString).ToList()[0].Split(';').ToList();
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

                //string[] strings = Regex.Split(ditems, "<[^>]*>");
                string[] strings = Regex.Split(ditems, ";");

                // TODO: Should be switched to GetItem() when that is implemented
                foreach (string s in strings)
                {
                    if (s.Trim() != "✖" && s.Trim().Length > 0)
                    {
                        //items.Add(new Item(s.Trim(), 0, 0));
                        using (var db = new DatabaseContext())
                        {
                            items.Add(db.GetItem(s.Trim()));
                        }
                    }
                }

                /*
                foreach (Item i in items)
                {
                    i.Category = items[0].Category = new Category(0, i.Name);
                }
                */

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