using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookShop.Models;
using System.Web.Script.Serialization;

namespace BookShop.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        private const string CartSession = "CartSession";

        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartViewModels>();
            if (cart != null)
            {
                list = (List<CartViewModels>)cart;
            }
            return View(list);
        }

        public ActionResult Add(int id, int amount)
        {
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartViewModels>)cart;
                if (list.Exists(x => x.Book.Id == id))
                {
                    foreach (var item in list)
                    {
                        if (item.Book.Id == id)
                        {
                            item.amount += amount;
                        }
                    }
                }
                else
                {
                    var item = new CartViewModels();
                    item.Book = _context.Books.Find(id);
                    item.amount = amount;
                    list.Add(item);
                }
                Session[CartSession] = list;
            }
            else
            {
                var item = new CartViewModels();
                item.Book = _context.Books.Find(id);
                item.amount = amount;
                var list = new List<CartViewModels>();
                list.Add(item);
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }

        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartViewModels>>(cartModel);
            var sessionCart = (List<CartViewModels>)Session[CartSession];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Book.Id == item.Book.Id);
                if (jsonItem != null)
                {
                    if (jsonItem.amount <= 0)
                    {
                        sessionCart.RemoveAll(x => x.Book.Id == jsonItem.Book.Id);
                    }
                    item.amount = jsonItem.amount;
                }
            }
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Delete(int id)
        {
            var sessionCart = (List<CartViewModels>)Session[CartSession];
            sessionCart.RemoveAll(x => x.Book.Id == id);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        [HttpGet]
        public ActionResult Checkout(int id)
        {
            var model = new CheckoutViewModels();
            model.CartViewModels = (List<CartViewModels>)Session[CartSession];
            model.Information = _context.Informations.FirstOrDefault(x => x.Customer.Id == id);
            if (model.Information == null)
            {
                Models.Information information = new Information();
                information.Name = "";
                information.Address = "";
                information.Sdt = "";
                information.IdCustomer = (int?)Session["USER_SESSION"];
                _context.Informations.Add(information);
                _context.SaveChanges();
                model.Information = _context.Informations.FirstOrDefault(x => x.Customer.Id == id);
            }
            return View(model);
        }

        public int InsertOrder(int idInformation)
        {
            var order = new Order();
            order.IdCustomer = (int?)Session["USER_SESSION"];
            order.IdInformation = idInformation;
            order.OrderDate = DateTime.Now;
            order.PaymentMethod = "COD";
            order.IdState = 1;
            _context.Orders.Add(order);
            _context.SaveChanges();

            return order.Id;
        }

        public ActionResult Order(int idInformation)
        {
            var idOrder = InsertOrder(idInformation);
            var cart = (List<CartViewModels>)Session[CartSession];
            foreach (var item in cart)
            {
                var orderDetail = new DetailOrder();
                orderDetail.IdBook = item.Book.Id;
                orderDetail.IdOrder = idOrder;
                orderDetail.Amount = item.amount;
                orderDetail.Price = item.Book.Price * (100 - item.Book.Discount) / 100;
                _context.DetailOrders.Add(orderDetail);
                _context.SaveChanges();
            }
            return RedirectToAction("Success", new
            {
                orderid = idOrder
            });
        }
        /*
        public ActionResult RenderInformation(int id)
        {
            var model = _context.Informations.Where(x=>x.Customer.Id==id);
            return PartialView(model);
        }

        public ActionResult RenderProductOrdered()
        {
            var cart = Session[CartSession];
            var list = new List<CartViewModels>();
            if (cart != null)
            {
                list = (List<CartViewModels>)cart;
            }
            return View(list);
        }
        */
        public ActionResult Success(int orderid)
        {
            var model = _context.DetailOrders.Where(x => x.Order.Id == orderid);
            Session[CartSession] = null;
            return View(model);
        }

        public ActionResult Information(string name, string address, string Sdt)
        {
            var information = new Information();
            information.Name = name;
            information.Address = address;
            information.Sdt = Sdt;
            information.IdCustomer = (int?)Session["USER_SESSION"];
            Information temp = (from x in _context.Informations
                                where x.IdCustomer == information.IdCustomer
                                select x).SingleOrDefault();
            if (temp == null)
            {
                _context.Informations.Add(information);
            }
            else
            {
                temp.Name = information.Name;
                temp.Address = information.Address;
                temp.Sdt = information.Sdt;
                temp.IdCustomer = information.IdCustomer;
            }
            _context.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult RenderInformation()
        {

            return PartialView();
        }
    }
}