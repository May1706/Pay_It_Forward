using PayItForward.Classes;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI.WebControls;


namespace PayItForward.Pages
{
    public partial class CreateUser : System.Web.UI.Page
    {
        private const int KEY_SIZE = 15; //bytes  

        protected String createStatus = "";
        protected String userEmail = "";
        protected Boolean valid;
        private String userPassword1 = "";
        private String userPassword2 = "";
        private User newUser;
        private static String key = "";

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
                if (userPassword1.Length < 6)
                {
                    valid = false;
                    createStatus = "Password is too short";
                }
            }
            if (valid)
            {

                //add user to db
                newUser = new User(userEmail, Encrypt(userPassword1, userEmail), key);
                DatabaseContext db = new DatabaseContext();
                db.AddUser(newUser);


                createStatus = "New user created";
                Email.Text = "";
                Password.Text = "";
                RePassword.Text = "";

            }
            ErrorMsg.Text = createStatus;

        }

        static private string Encrypt(string plainText, string keyPart)
        {
            string EncryptionKey = "MAkv2SPbnI9u212" + keyPart;
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