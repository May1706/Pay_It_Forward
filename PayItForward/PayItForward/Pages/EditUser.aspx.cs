using PayItForward.Classes;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI.WebControls;


namespace PayItForward.Pages
{
    public partial class EditUser : System.Web.UI.Page
    {
        private const int KEY_SIZE = 15; //bytes  

        protected String createStatus = "";
        protected String userEmail = "";
        protected Boolean valid;
        private String userPassword1 = "";
        private String userPassword2 = "";
        private String existingPassword = "";
        private User user;
        private static String key = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["activeUser"] == null)
            {
                Response.BufferOutput = true;
                Response.Redirect("/Pages/Login.aspx");
            }
            using (var db = new DatabaseContext())
            {
                user = (User)Session["activeUser"];
                
            }
            if (!Page.IsPostBack)
            {
                Email.Text = user.Username;
            }
            
        }
        protected void Button_Click(object sender, EventArgs e)
        {
            SaveButton.Click += new EventHandler(this.SaveButton_Click);
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            valid = true;

            //attempt to create user
            userEmail = Email.Text.ToLower();
            existingPassword = Password.Text;

            userPassword1 = NewPassword.Text;
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
                using (var db = new DatabaseContext())
                {
                    String s = Encrypt(existingPassword, user.Username);

                    if (user == null || user.Password != s)
                    {
                        valid = false;
                        createStatus = "Exsisting password incorrect";
                    }
                }
            }
            
            if (valid && (userPassword1 != "" && userPassword1 != null) && (userPassword2 != "" && userPassword2 != null))
            {
                //check if userPasswords match if they are changing the password
                if (userPassword1 != userPassword2)
                {
                    valid = false;
                    createStatus = "Password entries do not match";
                }
            }

            if (valid && (userPassword1 != "" && userPassword1 != null) && (userPassword2 != "" && userPassword2 != null))
            {
                
                if (userPassword1.Length < 6)
                {
                    valid = false;
                    createStatus = "New password is too short";
                }
            }

            if (valid)
            {
                //add user to db
                // newUser = new User(userEmail, Encrypt(userPassword1, userEmail), key);
                
                if((userPassword1 != "" && userPassword1 != null) && (userPassword2 != "" && userPassword2 != null))
                {
                    //if changed use new email and password to set
                    user.Password = Encrypt(userPassword1, userEmail);
                }
                else
                {
                    // if not changed, email still couldve changed so need to reencrypt password
                    user.Password = Encrypt(existingPassword, userEmail);
                }


                user.Username = userEmail;

                DatabaseContext db = new DatabaseContext();
                

                createStatus = "Account updated.";
                Email.Text = "";
                Password.Text = "";
                NewPassword.Text = "";
                RePassword.Text = "";

                Session["activeUser"] = user;
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                Response.BufferOutput = true;
                Response.Redirect("/Pages/UserProfile.aspx");
            }

            ErrorMsg.Text = createStatus;
        }

        static private string Encrypt(string plainText, string keyPart)
        {
            string added = keyPart.Split('@')[0];
            string key = "MAkv2SPbnI9u212";
            string EncryptionKey = key.Substring(added.Length) + added;
            byte[] plainBytes = Encoding.Unicode.GetBytes(plainText);

            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(plainBytes, 0, plainBytes.Length);
                        cs.Close();
                    }
                    plainText = Convert.ToBase64String(ms.ToArray());
                }
            }

            return plainText;
        }

    }
}