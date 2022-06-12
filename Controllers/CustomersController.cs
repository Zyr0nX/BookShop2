using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customer
        ApplicationDbContext _context = new ApplicationDbContext();

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModels model)
        {
            if (ModelState.IsValid)
            {
                if (IsExistUsername(model.Username))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else
                {
                    var customer = new Customer();
                    customer.Username = model.Username;
                    customer.Password = model.Password;
                    _context.Customers.Add(customer);
                    _context.SaveChanges();
                    ViewBag.Success = 0;
                }
            }
            return View(model);
        }

        public bool IsExistUsername(string username)
        {
            return _context.Customers.Count(x => x.Username == username) > 0;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModels model)
        {
            if (ModelState.IsValid)
            {
                var result = CheckLogin(model.Username, model.Password);
                if (result == true)
                {
                    var user = _context.Customers.SingleOrDefault(x => x.Username == model.Username);
                    Session.Add("USER_SESSION", user.Id);
                    Session.Add("USERNAME", user.Username);
                    return Redirect("/");
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản/Mật khẩu không đúng");
                }
            }
            return View(model);
        }

        public bool CheckLogin(string username, string password)
        {
            var result = _context.Customers.SingleOrDefault(x => x.Username == username);
            if (result == null)
            {
                return false;
            }
            else
            {
                if (result.Password == password)
                    return true;
                else
                    return false;
            }
        }

        public ActionResult Logout()
        {
            Session["USER_SESSION"] = null;
            Session["USERNAME"] = null;
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}