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
            String centerIdString = Session["donationCenter"];

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
                            Hours.Text = center.Hours;
                            Address.Text = center.Address;
                            //Pickup.Checked = Int32.Parse(center.Pickup) > 0; // why is center.Pickup a string???

                            //CategoryNamesAsString.Text = center.CategoryNames.ToString(); //not sure how to do this yet
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
                    center.Hours = Hours.Text;
                    center.Address = Address.Text;
                    db.Entry(center).State = System.Data.Entity.EntityState.Modified;
                    int l = db.SaveChanges();
                    ErrMsg.Text = l.ToString();
                }
                else
                {
                    ErrMsg.Text = "Error Saving Changes";
                }
            }
                
                

           // Response.Redirect(Request.RawUrl);
        }
    }
}