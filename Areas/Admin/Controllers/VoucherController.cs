using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop.Areas.Admin.Controllers
{
    [Authorize]
    public class VoucherController : Controller
    {
        private ApplicationDbContext _context;

        public VoucherController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var voucher = _context.Vouchers.ToList();
            return View(voucher);
        }

        public JsonResult IsExist(string Name)
        {
            return Json(!_context.Vouchers.Any(x => x.Name == Name), JsonRequestBehavior.AllowGet);
        }

        public ViewResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            var voucher = _context.Vouchers.SingleOrDefault(c => c.Id == id);
            if (voucher == null)
                return HttpNotFound();
            return View(voucher);
        }

        public ActionResult Delete(int id)
        {
            var voucher = _context.Vouchers.SingleOrDefault(c => c.Id == id);
            if (voucher == null)
                return HttpNotFound();
            else
            {
                _context.Vouchers.Remove(voucher);
                _context.SaveChanges();
                return RedirectToAction("Index", "voucher");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Voucher voucher)
        {
            if (voucher.Id == 0)
                _context.Vouchers.Add(voucher);
            else
            {
                var voucherInDb = _context.Vouchers.Single(c => c.Id == voucher.Id);
                voucherInDb.Name = voucher.Name;
                voucherInDb.Discount = voucher.Discount;
                voucherInDb.StartDate = voucher.StartDate;
                voucherInDb.EndDate = voucher.EndDate;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Voucher");
        }
    }
}