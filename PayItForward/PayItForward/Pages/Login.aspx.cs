﻿using PayItForward.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
            string userEmail    = Email.Text.ToLower();
            string userPassword = Password.Text;
            
            using (var db = new DatabaseContext())
            {
                User u = db.Users.FirstOrDefault(user => user.Username == userEmail);

                String s = Encrypt(userPassword, userEmail);

                if (u != null && u.Password == s)
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

        static private string Decrypt(string cipherText, string keyPart)
        {
            string added = keyPart.Split('@')[0];
            string key = "MAkv2SPbnI9u212";
            string EncryptionKey = key.Substring(added.Length) + keyPart;
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                encryptor.Padding = PaddingMode.Zeros;
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {

                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
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