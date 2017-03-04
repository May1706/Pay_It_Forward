using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PayItForward.Classes;
using System.Data;
using System.Reflection;

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
                    availableItems.InnerHtml += "<div class='ditem'>" + c + "<i class='js-remove'>✖</i></div>";
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
                    availableItems.InnerHtml += "<div class='ditem'>" + i + "<i class='js-remove'>✖</i></div>";
                }
            }
        }

        //The user has finished their list and wants to see appicable donation centers
        protected void submitButton_Click(object sender, EventArgs e)
        {
            List<Item> items = new List<Item>();

            items.Add(new Item("Books", 0, 0));
            items.Add(new Item("Children", 0, 0));
            items.Add(new Item("Clothing", 0, 0));

            items[0].Category = new Category(0, "Books");
            items[1].Category = new Category(0, "Children");
            items[2].Category = new Category(0, "Clothing");


            Session["donationItems"] = items;

            Response.BufferOutput = true;
            Response.Redirect("/Pages/ViewDonationCenters.aspx");
        }
    }
}