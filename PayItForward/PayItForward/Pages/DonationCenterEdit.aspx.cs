using PayItForward.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PayItForward.Pages
{
    public partial class DonationCenterEdit : System.Web.UI.Page
    {
        public const int ImageMinimumBytes = 512;
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
                            PhoneNumber.Text = center.PhoneNumber;
                            Description.Text = center.Description;
                            Email.Text = center.ContactEmail;
                            Website.Text = center.Website;
                            if (center.ImageURL != null)
                                dcImage.ImageUrl = center.ImageURL;
                            foreach (Category c in db.Categories)
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
            ErrMsg.Text = "";
            using (var db = new DatabaseContext())
            {
                DonationCenter center = db.DonationCenters.FirstOrDefault(c => c.CenterId == centerId);
                if(center != null)
                {
                    if (ImageUpload.HasFile)
                    {
                        if (!IsImage(ImageUpload.PostedFile))
                        {
                            ErrMsg.Text = "File uploaded is not an image. Changes not saved.";
                            return;
                        }
                        string fileExt = System.IO.Path.GetExtension(ImageUpload.PostedFile.FileName);
                        ImageUpload.SaveAs(Server.MapPath("~/Images/") + center.CenterName + fileExt );
                        center.ImageURL = "/Images/" + center.CenterName + fileExt;
                        if (center.ImageURL != null)
                            dcImage.ImageUrl = center.ImageURL;
                    }
                    center.CenterName = CenterName.Text;
                    System.Diagnostics.Debug.WriteLine(CenterName.Text);
                    center.Hours = GetHoursText();
                    center.Address = Address.Text;
                    center.PhoneNumber = PhoneNumber.Text;
                    center.Description = Description.Text;
                    center.ContactEmail = Email.Text;
                    center.Website = Website.Text;
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
            TextBox[] boxes = { SundayHours, MondayHours, TuesdayHours, WednesdayHours, ThursdayHours, FridayHours, SaturdayHours};
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
        protected bool IsImage(HttpPostedFile postedFile)
        {
            // Based off:
            //http://stackoverflow.com/questions/11063900/determine-if-uploaded-file-is-image-any-format-on-mvc
            
            if (postedFile.ContentType.ToLower() != "image/jpg" &&
                        postedFile.ContentType.ToLower() != "image/jpeg" &&
                        postedFile.ContentType.ToLower() != "image/pjpeg" &&
                        postedFile.ContentType.ToLower() != "image/gif" &&
                        postedFile.ContentType.ToLower() != "image/x-png" &&
                        postedFile.ContentType.ToLower() != "image/png")
            {
                return false;
            }
            
            if (Path.GetExtension(postedFile.FileName).ToLower() != ".jpg"
                && Path.GetExtension(postedFile.FileName).ToLower() != ".png"
                && Path.GetExtension(postedFile.FileName).ToLower() != ".gif"
                && Path.GetExtension(postedFile.FileName).ToLower() != ".jpeg")
            {
                return false;
            }
            
            try
            {
                if (!postedFile.InputStream.CanRead)
                {
                    return false;
                }

                if (postedFile.ContentLength < ImageMinimumBytes)
                {
                    return false;
                }

                byte[] buffer = new byte[512];
                postedFile.InputStream.Read(buffer, 0, 512);
                string content = System.Text.Encoding.UTF8.GetString(buffer);
                if (Regex.IsMatch(content, @"<script|<html|<head|<title|<body|<pre|<table|<a\s+href|<img|<plaintext|<cross\-domain\-policy",
                    RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Multiline))
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            

            try
            {
                using (var bitmap = new System.Drawing.Bitmap(postedFile.InputStream))
                {
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                postedFile.InputStream.Position = 0;
            }

            return true;
        }
    }
   
}