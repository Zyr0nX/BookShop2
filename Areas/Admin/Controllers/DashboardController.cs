using BookShop.Areas.Admin.Notification;
using BookShop.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using BookShop.Areas.Admin.Dao;

namespace BookShop.Areas.Admin.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {

        private ApplicationDbContext _context;

        public DashboardController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            ViewBag.NewOrder = _context.Orders.Where(c => c.IdState == 1).Count();
            ViewBag.Book = _context.Books.Count();
            ViewBag.Customer = _context.Customers.Count();
            ViewBag.Cancel = _context.Orders.Where(c => c.IdState == 3).Count();
            ViewBag.Suscess = _context.Orders.Where(c => c.IdState == 5).Count();
            var dao = new DeliveryDAO();
            ViewBag.List = dao.getTopList();
            return View();
        }

        public JsonResult GetNotificationOrders()
        {
            var notificationRegisterTime = Session["LastUpdated"] != null ? Convert.ToDateTime(Session["LastUpdated"]) : DateTime.Now;
            NotificationComponent NC = new NotificationComponent();
            var list = NC.GetOrders(notificationRegisterTime);
            Session["LastUpdate"] = DateTime.Now;
            return new JsonResult { Data = list, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult SetVariable(string key, string value)
        {
            Session[key] = value;

            return this.Json(new { success = true });
        }
    }
}