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
                            foreach (Item i in db.Items)
                            {
                                ListItem li = new ListItem(i.Name, i.Name, true);
                                li.Selected = center.ItemNames.Contains(i.Name);
                                Items.Items.Add(li);
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
                if (center != null)
                {
                    center.LastUpdate = DateTime.Now;
                    String requestMessage = "Edited: ";

                    if (center.CenterName != CenterName.Text)
                    {
                        center.CenterName = CenterName.Text;
                        requestMessage += "center name, ";

                    }

                    if (ImageUpload.HasFile)
                    {
                        if (!IsImage(ImageUpload.PostedFile))
                        {
                            ErrMsg.Text = "File uploaded is not an image. Changes not saved.";
                            return;
                        }
                        string fileExt = System.IO.Path.GetExtension(ImageUpload.PostedFile.FileName);
                        ImageUpload.SaveAs(Server.MapPath("~/Images/") + center.CenterName + fileExt);
                        center.ImageURL = "/Images/" + center.CenterName + fileExt;
                        if (center.ImageURL != null)
                            dcImage.ImageUrl = center.ImageURL;
                        requestMessage += "image, ";
                    }



                    String hoursText = GetHoursText();
                    if (center.Hours != hoursText)
                    {
                        center.Hours = hoursText;
                        requestMessage += "hours, ";
                    }
                    if (center.Address != Address.Text)
                    {
                        center.Address = Address.Text;
                        requestMessage += "address, ";
                    }
                    if (center.PhoneNumber != PhoneNumber.Text)
                    {
                        center.PhoneNumber = PhoneNumber.Text;
                        requestMessage += "phone number, ";
                    }
                    if (center.Description != Description.Text)
                    {
                        center.Description = Description.Text;
                        requestMessage += "description, ";
                    }
                    if (center.ContactEmail != Email.Text)
                    {
                        center.ContactEmail = Email.Text;
                        requestMessage += "contact email, ";
                    }
                    if (center.Website != Website.Text)
                    {
                        center.Website = Website.Text;
                        requestMessage += "website, ";
                    }
                    List<String> tempItems = new List<string>();
                    foreach(ListItem i in Items.Items)
                    {
                        if(i.Selected)
                            tempItems.Add(i.Text);
                    }
                    if(tempItems != center.ItemNames)
                    {
                        center.ItemNames = tempItems;
                        requestMessage += "items, ";
                    }
                    //remove the trailing comma space
                    requestMessage = requestMessage.Substring(0, requestMessage.Length - 2);

                    db.Entry(center).State = System.Data.Entity.EntityState.Modified;
                    Request req = new Request();

                    // Add info to req
                    req.CreatedTime = DateTime.Now;
                    req.LastUpdateTime = DateTime.Now;
                    req.Type = "Edit";
                    req.Status = Classes.Request.PENDING;
                    req.CallingId = center.CenterId;

                    req.MessageInfo = requestMessage;

                    db.Requests.Add(req);
                    int l = db.SaveChanges();

                    Session["donationCenter"] = center;
                    Response.BufferOutput = true;
                    Response.Redirect("/Pages/DonationCenterProfile.aspx");
                }
                else
                {
                    ErrMsg.Text = "Error Saving Changes";
                }
            }
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