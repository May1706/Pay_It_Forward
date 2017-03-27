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

namespace PayItForward.Pages
{
    public partial class CreateList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            populateCategories();
            //populateCategoriesDropdown();
        }

        //Populate the categories dropdown with database categories
        protected void populateCategoriesDropdown()
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
                List<string> items = (from category in db.Categories
                                      where category.Name == categoryList.SelectedItem.Text
                                      select category.ItemNames).ToString().Split(',').ToList<string>();

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
        
        //The user has finished their list and wants to see appicable donation centers
        protected void submitButton_Click(object sender, EventArgs e)
        {
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
                        items.Add(new Item(s.Trim(), 0, 0));
                        //items.Add(Item.GetItem(s.Trim()));
                    }
                }

                foreach (Item i in items)
                {
                    i.Category = items[0].Category = new Category(0, i.Name);
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