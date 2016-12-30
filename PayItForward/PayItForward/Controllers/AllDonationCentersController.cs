using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayItForward.Controllers
{
    public class AllDonationCentersController : Controller
    {
        // GET: AllDonationCenters
        public ActionResult Index()
        {
            return View();
        }
    }
}