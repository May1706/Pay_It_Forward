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
    public partial class UserProfile : System.Web.UI.Page
    {
        string userEmail;
        string userPassword;
        string errorMessage = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            LoginB.Click += new EventHandler(this.LoginB_Click);
        }

        protected void LoginB_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            userEmail = Email.Text;
            userPassword = Password.Text;
            using (var db = new DatabaseContext())
            {
                //check if user exists in database
                try
                {
                    var u = (from us in db.Users
                             where us.Username == Email.Text
                             select us).FirstOrDefault<User>();
                    if (u == null)
                    {
                        errorMessage = "Currently no account for this email";
                    }
                //check password
            }
                catch (System.Reflection.TargetInvocationException)
            {
                errorMessage = "Currently login is unavailable";
            }
        }
            ErrMsg.Text = errorMessage;
        }
    }
}