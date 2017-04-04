using PayItForward.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PayItForward.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginB_Click(object sender, EventArgs e)
        {
            string userEmail    = Email.Text;
            string userPassword = Password.Text;
            
            using (var db = new DatabaseContext())
            {
                User u = db.Users.FirstOrDefault(user => user.Username == userEmail);
                
                if (u != null && u.Password == userPassword)
                {
                    Session["activeUser"] = u;

                    Response.BufferOutput = true;
                    Response.Redirect("/Pages/Home.aspx");
                }
                else
                {
                    ErrMsg.Text = "Username or password is incorrect";
                }
            }
        }
    }
}