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
            loadTables();
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
                    req.Status = i % 2;

                    dbctx.Requests.Add(req);
                    dbctx.SaveChanges();
                }
                loadTables();
            }
        }

        protected void Remove_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Removing entry!");

            using (var db = new DatabaseContext())
            {
                var query = from b in db.Requests select b;

                foreach (var r in query)
                {
                    db.Requests.Remove(r);
                }
                db.SaveChanges();
            }
            loadTables();
        }

        private void loadTables()
        {
            loadHistoryTable();
            loadPendingRequestsTable();
        }

        private void loadPendingRequestsTable()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                List<Request> requests = (from req in db.Requests
                                          where req.Status == Classes.Request.PENDING
                                          orderby req.CreatedTime select req).ToList();

                listPending.InnerHtml = "";
                listPending.InnerHtml += "<table id=\"pendingRequestTable\" class=\"table table-hover table-striped table-bordered\">";
                listPending.InnerHtml += "<thead><tr>";
                listPending.InnerHtml += "<th>Type</th>";
                listPending.InnerHtml += "<th>Time Created</th>";
                listPending.InnerHtml += "<th>Message</th>";
                listPending.InnerHtml += "</tr></thead>";
                listPending.InnerHtml += "<tbody>";

                foreach (Request r in requests)
                {
                    listPending.InnerHtml += "<tr>";
                    listPending.InnerHtml += "<td>" + r.Type + "</td>";
                    listPending.InnerHtml += "<td>" + r.CreatedTime.ToString() + "</td>";
                    listPending.InnerHtml += "<td>" + r.MessageInfo + "</td>";
                    listPending.InnerHtml += "</td></tr>";
                }

                listPending.InnerHtml += "</tbody></table>";
            }
        }

        private void loadHistoryTable()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                List<Request> requests = (from req in db.Requests
                                          where req.Status != Classes.Request.PENDING
                                          orderby req.LastUpdateTime select req).ToList();
                requests = requests.OrderByDescending(x => x.CreatedTime).ToList();


                listHistory.InnerHtml = "";
                listHistory.InnerHtml += "<table class=\"table table-hover table-striped table-bordered\">";
                listHistory.InnerHtml += "<thead><tr>";
                listHistory.InnerHtml += "<th>Type</th>";
                listHistory.InnerHtml += "<th>Time Created</th>";
                listHistory.InnerHtml += "<th>Last Updated</th>";
                listHistory.InnerHtml += "<th>Message</th>";
                listHistory.InnerHtml += "<th>Status</th>";
                listHistory.InnerHtml += "</tr></thead>";
                listHistory.InnerHtml += "<tbody>";

                foreach (Request r in requests)
                {
                    listHistory.InnerHtml += "<tr>";
                    listHistory.InnerHtml += "<td>" + r.Type + "</td>";
                    listHistory.InnerHtml += "<td>" + r.CreatedTime.ToString() + "</td>";
                    listHistory.InnerHtml += "<td>" + r.LastUpdateTime.ToString() + "</td>";
                    listHistory.InnerHtml += "<td>" + r.MessageInfo + "</td>";
                    listHistory.InnerHtml += "<td>" + r.statusToString() + "</td>";
                    listHistory.InnerHtml += "</td></tr>";
                }

                listHistory.InnerHtml += "</tbody></table>";
            }
        }
    }
}