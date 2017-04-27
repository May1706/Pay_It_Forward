using PayItForward.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PayItForward.Pages
{
    public partial class DonationCenterEdit : System.Web.UI.Page
    {
        int centerId;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            User u = (User)Session["activeUser"];
            String centerIdString = Request.QueryString["center"];

            if (u != null && int.TryParse(centerIdString, out centerId))
            {
                using (var db = new DatabaseContext())
                {
                    DonationCenter center = db.DonationCenters.FirstOrDefault(c => c.UserId == u.UserID && c.CenterId == centerId);
                    if (center != null)
                    {
                        if (!Page.IsPostBack)
                        {
                            // fill in the data if we didn't just press the button
                            CenterName.Text = center.CenterName;
                            SetHoursText(center.Hours);
                            Address.Text = center.Address;
                            foreach(Category c in db.Categories)
                            {
                                ListItem i = new ListItem(c.Name, c.Name, true);
                                i.Selected = center.CategoryNames.Contains(c.Name);
                                Categories.Items.Add(i);
                            }
                            
                            //Pickup.Checked = Int32.Parse(center.Pickup) > 0; // why is center.Pickup a string???
                        }
                    }
                    else
                    {
                        CenterNotFound();
                    }

                }
            }
            else if (u == null)
            {
                //Can't edit if not logged in.
                Response.Redirect("Login.aspx");
            }
            else
            {
                CenterNotFound();
            }
           
        }

        protected void CenterNotFound()
        {
            EditPanel.Visible = false;
            NotFoundPanel.Visible = true;
        }

        protected void SaveChanges_Click(object sender, EventArgs e)
        {
            using (var db = new DatabaseContext())
            {
                DonationCenter center = db.DonationCenters.FirstOrDefault(c => c.CenterId == centerId);
                if(center != null)
                {
                    center.CenterName = CenterName.Text;
                    System.Diagnostics.Debug.WriteLine(CenterName.Text);
                    center.Hours = GetHoursText();
                    center.Address = Address.Text;
                    center.CategoryNames = new List<string>();
                    foreach(ListItem i in Categories.Items)
                    {
                        if(i.Selected)
                            center.CategoryNames.Add(i.Text);
                    }
                    db.Entry(center).State = System.Data.Entity.EntityState.Modified;
                    int l = db.SaveChanges();
                }
                else
                {
                    ErrMsg.Text = "Error Saving Changes";
                }
            }

           // Response.Redirect(Request.RawUrl);
        }

        protected void SetHoursText(String hours)
        {
            TextBox[] boxes = { SundayHours, MondayHours, TuesdayHours, WednesdayHours, ThursdayHours, FridayHours, SaturdayHours };
            List<String> days = hours.Split(';').ToList();
            
            // iterate through the count of the shorter of the two.
            // This prevents problems if only the first few hours are there or there is a trailing semicolon
            int count = (days.Count < boxes.Length) ? days.Count : boxes.Length;
            for (int i = 0; i < count; i++)
            {
                boxes[i].Text = days[i];
            }
        }

        protected String GetHoursText()
        {
            return SundayHours.Text + ";" + MondayHours.Text + ";" + TuesdayHours.Text + ";" + WednesdayHours.Text + ";" + ThursdayHours.Text + ";" + FridayHours.Text + ";" + SaturdayHours.Text;
        }
    }
   
}