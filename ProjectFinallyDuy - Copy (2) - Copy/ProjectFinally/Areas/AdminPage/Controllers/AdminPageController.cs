using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectFinally.DAO;
using ProjectFinally.Models;

namespace ProjectFinally.Areas.AdminPage.Controllers
{
    public class AdminPageController : Controller
    {
        // GET: AdminPage/AdminPage
        WebsiteBanHangEntities db = new WebsiteBanHangEntities();
        public ActionResult Error()
        {
            return View();
        }
        public ActionResult Index()
        {
            if (Session["Admin"] != null)
                return View();
            else
                return View("Error");
        }
    }
}
