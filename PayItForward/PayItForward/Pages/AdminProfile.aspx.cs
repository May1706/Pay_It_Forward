using PayItForward.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Newtonsoft.Json;

namespace PayItForward.Pages
{
    public partial class AdminProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadTables();
            loadDropdowns();
        }

        [WebMethod]
        public static String AcceptRequest(String type, String uid)
        {
            int id = Convert.ToInt32(uid);

            using (var db = new DatabaseContext())
            {
                var result = db.Requests.Single(r => r.RequestId == id);
                if (result != null)
                {
                    //using (var db2 = new DatabaseContext())
                    //{
                    //    var dc = db2.DonationCenters.Single(d => d.CenterId == result.CallingId);

                    //    //Todo Change visibility
                    //    db2.SaveChanges();

                    //}
                    result.LastUpdateTime = DateTime.Now;
                    result.Status = Classes.Request.APPROVED;
                    db.SaveChanges();
                    return JsonConvert.SerializeObject(result.LastUpdateTime.ToString());
                }
            }
            return "";
        }

        [WebMethod]
        public static String DenyRequest(String type, String uid)
        {
            int id = Convert.ToInt32(uid);

            using (var db = new DatabaseContext())
            {
                var result = db.Requests.Single(r => r.RequestId == id);
                if (result != null)
                {
                    //using (var db2 = new DatabaseContext())
                    //{
                    //    var dc = db2.DonationCenters.Single(d => d.CenterId == result.CallingId);

                    //    //Todo Remove from table if type is create
                    //    //Todo Change dc to invisible
                    //    db2.SaveChanges();

                    //}
                    result.LastUpdateTime = DateTime.Now;
                    result.Status = Classes.Request.DENIED;
                    db.SaveChanges();
                    return JsonConvert.SerializeObject(result.LastUpdateTime.ToString());
                }
            }
            return "";
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

        private void loadDropdowns()
        {
            // Category list in "Manage Items"
            using (var db = new DatabaseContext())
            {
                itemCategory.Items.Clear();

                List<string> categories = (from c in db.Categories select c.Name).ToList();

                foreach (string c in categories)
                {
                    itemCategory.Items.Add(new ListItem(c));
                }
            }
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
                listPending.InnerHtml += "<th style=\"display:none\">RequestId</th>";
                listPending.InnerHtml += "<th style=\"display:none\">CallingId</th>";
                listPending.InnerHtml += "<th>Type</th>";
                listPending.InnerHtml += "<th>Time Created</th>";
                listPending.InnerHtml += "<th>Message</th>";
                listPending.InnerHtml += "</tr></thead>";
                listPending.InnerHtml += "<tbody>";

                foreach (Request r in requests)
                {
                    listPending.InnerHtml += "<tr>";
                    listPending.InnerHtml += "<td style=\"display:none\">" + r.RequestId + "</td>";
                    listPending.InnerHtml += "<td style=\"display:none\">" + r.CallingId + "</td>";
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
                requests = requests.OrderByDescending(x => x.LastUpdateTime).ToList();


                listHistory.InnerHtml = "";
                listHistory.InnerHtml += "<table id=\"historyRequestTable\" class=\"table table-striped table-bordered\">";
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

        protected void addItemButton_Click(object sender, EventArgs e)
        {
            bool flag = false;

            float weight = 0.0f;
            float low    = 0.0f;
            float high   = 0.0f;

            if (itemName.Text   == null || itemName.Text.Length <= 0    || !itemName.Text.Trim().All(char.IsLetterOrDigit))
            {
                flag = true;
            }
            if (itemWeight.Text == null || itemWeight.Text.Length <= 0  || !float.TryParse(itemWeight.Text.Trim(), out weight))
            {
                flag = true;
            }
            if (itemLow.Text    == null || itemLow.Text.Length <= 0     || !float.TryParse(itemLow.Text.Trim(), out low))
            {
                flag = true;
            }
            if (itemHigh.Text   == null || itemHigh.Text.Length <= 0    || !float.TryParse(itemHigh.Text.Trim(), out high))
            {
                flag = true;
            }
            if (flag)
            {
                itemErrorText.Visible = true;
                return;
            }

            itemErrorText.Visible = false;

            using (DatabaseContext db = new DatabaseContext())
            {
                Item newItem = new Item();

                newItem.Name              = itemName.Text.Trim();
                newItem.Weight            = weight;
                newItem.StringCategory    = itemCategory.SelectedItem.Text.Trim();
                newItem.Category          = db.GetCategory(newItem.StringCategory);
                newItem.LowPrice          = low;
                newItem.HighPrice         = high;

                db.AddItem(newItem);

                Category c = newItem.Category;
                c.itemString += ";" + newItem.Name;

                db.Categories.Attach(c);
                db.Entry(c).Property(x => x.itemString).IsModified = true;
                db.SaveChanges();
            }
        }

        protected void addCategoryButton_Click(object sender, EventArgs e)
        {
            bool flag = false;

            if (categoryName.Text == null || categoryName.Text.Length <= 0 || !categoryName.Text.Trim().All(char.IsLetterOrDigit))
            {
                flag = true;
            }
            if (flag)
            {
                categoryErrorText.Visible = true;
                return;
            }

            categoryErrorText.Visible = false;

            using (DatabaseContext db = new DatabaseContext())
            {
                Category newCategory = new Category();

                newCategory.Name = categoryName.Text.Trim();
                newCategory.ItemNames = new List<string>();
                newCategory.Items = new List<Item>();

                db.AddCategory(newCategory);
            }
        }
    }
}