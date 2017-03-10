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

            //check if user in database
            DatabaseContext db = new DatabaseContext();
            int count = db.CheckForUser(userEmail);
            if (count == 0)
            {
                errorMessage = "This user does not exist yet";
            }
            else
            {
                errorMessage = "User " + userEmail + " is logged in";
            }
            
            ErrMsg.Text = errorMessage;
        }
    }
}