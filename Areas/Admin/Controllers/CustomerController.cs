using BookShop.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using PagedList;


namespace BookShop.Areas.Admin.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index(int? pageNum, string name = null, string email = null, string sdt = null, string username = null)
        {
            if (name == null && email == null && sdt == null && username == null)
                return View("Search");

            IQueryable<Customer> customerQuery = _context.Customers;

            if (!String.IsNullOrWhiteSpace(name))
                customerQuery = customerQuery.Where(c => c.Name.Contains(name));

            if (!String.IsNullOrWhiteSpace(email))
                customerQuery = customerQuery.Where(c => c.Email.Contains(email));

            if (!String.IsNullOrWhiteSpace(sdt))
                customerQuery = customerQuery.Where(c => c.Sdt.Contains(sdt));

            if (!String.IsNullOrWhiteSpace(username))
                customerQuery = customerQuery.Where(c => c.Username.Contains(username));

            var customer = customerQuery.ToList();
            return View("Index", customer.ToPagedList(pageNum ?? 1, 5));
        }
    }
}