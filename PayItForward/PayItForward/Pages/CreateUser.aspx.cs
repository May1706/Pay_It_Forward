using PayItForward.Classes;
using System;
using System.Web.UI.WebControls;


namespace PayItForward.Pages
{
    public partial class CreateUser : System.Web.UI.Page
    {
        protected String createStatus = "not doing anything";
        protected String userEmail = "";
        protected Boolean valid;
        private String userPassword1 = "";
        private String userPassword2 = "";
        private User newUser;

        protected void Button_Click(object sender, EventArgs e)
        {
            LoginButton.Click += new EventHandler(this.LoginButton_Click);
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            valid = true;

            //attempt to create user
            userEmail = Email.Text;
            userPassword1 = Password.Text;
            userPassword2 = RePassword.Text;


            //check if username is valid
            try
            {
                System.Net.Mail.MailAddress address = new System.Net.Mail.MailAddress(userEmail);
            }
            catch
            {
                valid = false;
                createStatus = "Email is not a valid format";
            }
            if (valid)
            {
                //check if userName is already in db
                using (var db = new DatabaseContext())
                {
                    if (!valid)
                    {
                        valid = false;
                        createStatus = "User already exists";
                    }
                }
            }
            if (valid)
            {
                //check if userPasswords match
                if (userPassword1 != userPassword2)
                {
                    valid = false;
                    createStatus = "Password entries do not match";
                }
            }
            if (valid)
            {
                //check that userPassword is the correct format
                //TODO
            }
            if (valid)
            {

                //add user to db
                newUser = new User(userEmail, userPassword1);
                DatabaseContext db = new DatabaseContext();
                db.AddUser(newUser);


                createStatus = "New user created";
                Email.Text = "";
                Password.Text = "";
                RePassword.Text = "";

            }
            ErrorMsg.Text = createStatus;

        }
    }
}