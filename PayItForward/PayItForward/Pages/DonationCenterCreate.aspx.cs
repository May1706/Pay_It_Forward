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
                LoadCategories();
            }
            else
            {
                //Must be logged in
                Response.Redirect("Login.aspx");
            }
        }

        protected void CreateCenter_Click(object sender, EventArgs e)
        {
            using (var db = new DatabaseContext())
            {
                string centerName = Name.Text;
                string description = Description.Text;
                //make string of hours out of things
                string sun = "closed;";
                string mon = "closed;";
                string tue = "closed;";
                string wed = "closed;";
                string thu = "closed;";
                string fri = "closed;";
                string sat = "closed;";
                if (!DropDownList1.SelectedValue.Equals("-1") && !DropDownList2.SelectedValue.Equals("-1"))
                {
                    sun = DropDownList1.SelectedItem + " - " + DropDownList2.SelectedItem + ";";
                }
                if (!DropDownList3.SelectedValue.Equals("-1") && !DropDownList4.SelectedValue.Equals("-1"))
                {
                    mon = DropDownList3.SelectedItem + " - " + DropDownList4.SelectedItem + ";";
                }
                if (!DropDownList5.SelectedValue.Equals("-1") && !DropDownList6.SelectedValue.Equals("-1"))
                {
                    tue = DropDownList5.SelectedItem + " - " + DropDownList6.SelectedItem + ";";
                }
                if (!DropDownList7.SelectedValue.Equals("-1") && !DropDownList8.SelectedValue.Equals("-1"))
                {
                    wed = DropDownList7.SelectedItem + " - " + DropDownList8.SelectedItem + ";";
                }
                if (!DropDownList9.SelectedValue.Equals("-1") && !DropDownList10.SelectedValue.Equals("-1"))
                {
                    thu = DropDownList9.SelectedItem + " - " + DropDownList10.SelectedItem + ";";
                }
                if (!DropDownList11.SelectedValue.Equals("-1") && !DropDownList12.SelectedValue.Equals("-1"))
                {
                    fri = DropDownList11.SelectedItem + " - " + DropDownList12.SelectedItem + ";";
                }
                if (!DropDownList13.SelectedValue.Equals("-1") && !DropDownList14.SelectedValue.Equals("-1"))
                {
                    sat = DropDownList13.SelectedItem + " - " + DropDownList14.SelectedItem + ";";
                }

                string hours = sun + mon + tue + wed + thu + fri + sat;
                string address = Address.Text;
                string phone = PhoneNumber.Text;
                string pickup = PickupTextBox.Text;
                //deal with categories
                List<string> categories = new List<string>();
                foreach (ListItem item in CheckBoxList.Items)
                {
                    if (item.Selected)
                    {
                        categories.Add(item.Text);
                    }
                }
                DonationCenter center = new DonationCenter(u.UserID, centerName, description, hours, address, phone, pickup, categories);
                db.AddCenter(center);

                u.addDonationCenter(center);

                db.Users.Attach(u);
                db.Entry(u).State = System.Data.Entity.EntityState.Modified;

                string info = "Name: " + center.CenterName + " Description: " + center.Description + " Hours: " + hours + " Address: " + address + " Phone: " + phone + " Pickup: " + pickup;

                Request req = new Classes.Request();
                req.CreatedTime = DateTime.Now;
                req.LastUpdateTime = DateTime.Now;
                req.MessageInfo = info;
                req.CallingId = center.CenterId;
                req.Type = "New Donation Center";
                req.Status = 0;

                db.Requests.Add(req);
                db.SaveChanges();

                //redirect to user profile
                Response.Redirect("UserProfile.aspx");
            }
        }

        private void LoadCategories()
        {
            using (var db = new DatabaseContext())
            {
                foreach (Category c in db.Categories)
                {
                    if (c.Name != null)
                    {
                        ListItem newItem = new ListItem(c.Name);
                        CheckBoxList.Items.Add(newItem);
                    }
                }
            }
        }

        protected void CenterExists()
        {
            ExistsPanel.Visible = true;
        }

        }
    }
