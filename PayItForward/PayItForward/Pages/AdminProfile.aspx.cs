using PayItForward.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
            loadDonationCenterTable();
            if (!Page.IsPostBack)
            {
                loadDropdowns();
            }
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
                    using (var db2 = new DatabaseContext())
                    {
                        var dc = db2.DonationCenters.Single(d => d.CenterId == result.CallingId);

                        //Todo Change visibility
                        dc.Status = Classes.DonationCenter.VISIBLE;
                        dc.LastUpdate = DateTime.Now;
                        db2.SaveChanges();

                    }
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
                    using (var db2 = new DatabaseContext())
                    {
                        var dc = db2.DonationCenters.Single(d => d.CenterId == result.CallingId);

                        //Remove from table if type is create
                        if (type == "New Donation Center")
                        {
                            db2.DonationCenters.Remove(dc);
                        }
                        else
                        {
                            //Change dc to invisible
                            dc.Status = Classes.DonationCenter.INVISIBLE;
                            dc.LastUpdate = DateTime.Now;
                        }
                        db2.SaveChanges();

                    }
                    result.LastUpdateTime = DateTime.Now;
                    result.Status = Classes.Request.DENIED;
                    db.SaveChanges();
                    return JsonConvert.SerializeObject(result.LastUpdateTime.ToString());
                }
            }
            return "";
        }

        [WebMethod]
        public static String CheckVisibility(String id)
        {
            int i = Convert.ToInt32(id);
            using (var db = new DatabaseContext())
            {
                var result = db.DonationCenters.Single(d => d.CenterId == i);
                if(result != null)
                {
                    var vis = result.statusToString();
                    return JsonConvert.SerializeObject(vis);
                }
            }
            return "";
        }

        [WebMethod]
        public static String MakeVisible(String id)
        {
            int i = Convert.ToInt32(id);
            using (var db = new DatabaseContext())
            {
                var result = db.DonationCenters.Single(d => d.CenterId == i);
                if(result != null)
                {
                    result.Status = Classes.DonationCenter.VISIBLE;
                    result.LastUpdate = DateTime.Now;
                    db.SaveChanges();
                    return JsonConvert.SerializeObject("true");
                }
            }
            return "";
        }

        [WebMethod]
        public static String MakeInvisible(String id)
        {
            int i = Convert.ToInt32(id);
            using (var db = new DatabaseContext())
            {
                var result = db.DonationCenters.Single(d => d.CenterId == i);
                if (result != null)
                {
                    result.Status = Classes.DonationCenter.INVISIBLE;
                    result.LastUpdate = DateTime.Now;
                    db.SaveChanges();
                    return JsonConvert.SerializeObject("true");
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

            decimal low    = 0;
            decimal high   = 0;

            if (itemName.Text == null || itemName.Text.Trim().Length <= 0 || !(new Regex("^[A-Za-z0-9()' ]+$").IsMatch(itemName.Text.Trim())))
            {
                flag = true;
            }
            if (itemWeight.Text == null || itemWeight.Text.Trim().Length <= 0 || !float.TryParse(itemWeight.Text.Trim(), out weight))
            {
                flag = true;
            }

            if (itemLow.Text    == null || itemLow.Text.Trim().Length <= 0     || !decimal.TryParse(itemLow.Text.Trim(), out low))
            {
                flag = true;
            }
            if (itemHigh.Text   == null || itemHigh.Text.Trim().Length <= 0    || !decimal.TryParse(itemHigh.Text.Trim(), out high))
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
                newItem.StringCategory    = itemCategory.SelectedItem.ToString().Trim();
                newItem.Category          = db.GetCategory(newItem.StringCategory);
                newItem.LowPrice          = low;
                newItem.HighPrice         = high;

                var existingEntity = db.Items.Where(c => c.Name == newItem.Name).AsQueryable().FirstOrDefault();
                if (existingEntity == null)
                {
                    db.AddItem(newItem);

                    Category c = newItem.Category;
                    c.addItem(newItem);

                    db.Categories.Attach(c);
                    db.Entry(c).Property(x => x.itemString).IsModified = true;
                }
                else
                {
                    // If we change the category
                    if (!newItem.StringCategory.Equals(existingEntity.StringCategory))
                    {
                        // Remove this item from old category
                        Category oldCat = existingEntity.Category;
                        oldCat.removeItem(existingEntity);

                        db.Categories.Attach(oldCat);
                        db.Entry(oldCat).Property(x => x.itemString).IsModified = true;

                        // Add this item to the new category
                        Category newCat = newItem.Category;
                        newCat.addItem(newItem);

                        db.Categories.Attach(newCat);
                        db.Entry(newCat).Property(x => x.itemString).IsModified = true;
                    }

                    newItem.itemId = existingEntity.itemId;
                    db.Entry(existingEntity).CurrentValues.SetValues(newItem);
                }

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

        private void loadDonationCenterTable()
        {
            DatabaseContext db = new DatabaseContext();
            dcGrid.DataSource = (from d in db.DonationCenters select new { d.CenterId, d.CenterName}).ToList();
            dcGrid.DataBind();
        }
    }
}