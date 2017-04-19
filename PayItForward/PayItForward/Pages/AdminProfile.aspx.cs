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
            updateGridView();
        }

        protected void Accept_Click(object sender, EventArgs e)
        {
            //Todo
        }

        protected void Deny_Click(object sender, EventArgs e)
        {
            //Todo
        }

        protected void Generate_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Adding entry!");
            using (var dbctx = new DatabaseContext())
            {
                for (int i = 0; i < 10; i++)
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

                updateGridView();
            }
        }

        protected void Remove_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Removing entry!");

            using (var db = new DatabaseContext())
            {
                var query = from b in db.Requests orderby b.RequestId select b;

                foreach (var r in query)
                {
                    db.Requests.Remove(r);
                }
                db.SaveChanges();
            }

            updateGridView();
        }


        private void updateGridView()
        {
            DatabaseContext db = new DatabaseContext();

            var requests = db.Requests;
            
            requestsGridView.DataSource = requests.ToList();
            requestsGridView.DataBind();
        }
    }
}