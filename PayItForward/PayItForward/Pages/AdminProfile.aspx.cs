using PayItForward.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PayItForward.Pages
{
    public partial class AdminProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Adding entry!");
            using (var dbctx = new DatabaseContext())
            {
                Request req = new Request();

                // Add info to req
                req.CreatedTime = DateTime.Now;
                req.LastUpdateTime = DateTime.Now;
                req.MessageInfo = "Testing";
                req.RequestId = 1;
                req.Type = "Insert";
                req.Status = 1;

                dbctx.Requests.Add(req);
                dbctx.SaveChanges();
            }
        }
    }
}