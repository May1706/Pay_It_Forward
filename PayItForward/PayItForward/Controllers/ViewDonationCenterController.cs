using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayItForward.Controllers
{
    public class ViewDonationCenterController : Controller
    {
        // GET: ViewDonationCenter
        public ActionResult Index()
        {
            return View();
        }
    }
}