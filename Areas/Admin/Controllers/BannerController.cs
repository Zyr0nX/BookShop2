using BookShop.Models;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop.Areas.Admin.Controllers
{
    [Authorize]
    public class BannerController : Controller
    {
        private ApplicationDbContext _context;

        public BannerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var Banner = _context.Banners.ToList();
            return View(Banner);
        }

        //public JsonResult IsExist(string Name)
        //{
        //    return Json(!_context.Banners.Any(x => x.Name == Name), JsonRequestBehavior.AllowGet);
        //}

        public ViewResult Create()
        {
            ViewBag.Max = _context.Banners.Where(c => c.State == "Dynamic").Max(c => c.Stt);
            if (ViewBag.Max == null)
                ViewBag.Max = 0;
            return View();
        }

        public ActionResult Edit(int id)
        {
            var Banner = _context.Banners.SingleOrDefault(c => c.Id == id);
            if (Banner == null)
                return HttpNotFound();
            ViewBag.Max = _context.Banners.Where(c => c.State == "Dynamic").Max(c => c.Stt);
            if (ViewBag.Max == null)
                ViewBag.Max = 0;
            return View(Banner);
        }

        public ActionResult Delete(int id)
        {
            var Banner = _context.Banners.SingleOrDefault(c => c.Id == id);
            if (Banner == null)
                return HttpNotFound();
            else
            {
                if (Banner.State == "Dynamic")
                {
                    SapXepDynamic(Banner, 1);
                }
                _context.Banners.Remove(Banner);
                _context.SaveChanges();
                return RedirectToAction("Index", "Banner");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Banner Banner, HttpPostedFileBase photo)
        {

            if (Banner.Id == 0)
            {
                if (photo != null && photo.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Areas/Admin/Data/BannerImage/"),
                                            System.IO.Path.GetFileName(photo.FileName));
                    photo.SaveAs(path);

                    Banner.Photo = photo.FileName;

                }
                else
                    return HttpNotFound();
                _context.Banners.Add(Banner);

                if (Banner.State == "Dynamic")
                {
                    SapXepDynamic(Banner, 2);
                }
                if (Banner.State == "Static")
                {
                    SapXepStatic(Banner);
                }

            }

            else
            {
                var BannerInDb = _context.Banners.Single(c => c.Id == Banner.Id);
                if (BannerInDb.State == Banner.State)
                {
                    if (Banner.State == "Static" && Banner.Stt != BannerInDb.Stt)
                    {
                        SapXepStatic(Banner);
                    }
                    if (Banner.State == "Dynamic" && Banner.Stt != BannerInDb.Stt)
                    {
                        var bannerDynamic = _context.Banners.SingleOrDefault(c => c.State == "Dynamic" && c.Stt == Banner.Stt);
                        if (bannerDynamic != null)
                        {
                            bannerDynamic.Stt = BannerInDb.Stt;
                        }
                    }
                }
                else
                {
                    var stt = _context.Banners.Where(c => c.State == "Dynamic").Max(c => c.Stt);
                    if (BannerInDb.State == "Dynamic")
                    {
                        SapXepDynamic(Banner, 1);
                    }
                    if (Banner.State == "Dynamic")
                    {
                        SapXepDynamic(Banner, 2);
                    }
                    if (Banner.State == "Static")
                        SapXepStatic(Banner);


                }
                BannerInDb.RefLink = Banner.RefLink;
                BannerInDb.State = Banner.State;
                BannerInDb.Stt = Banner.Stt;
                if (photo != null && photo.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Areas/Admin/Data/BannerImage/"),
                                            System.IO.Path.GetFileName(photo.FileName));
                    photo.SaveAs(path);

                    Banner.Photo = photo.FileName;
                }

            }


            _context.SaveChanges();
            return RedirectToAction("Index", "Banner");

        }
        void SapXepStatic(Banner Banner)
        {
            var bannerStatic = _context.Banners.SingleOrDefault(c => c.State == "Static" && c.Stt == Banner.Stt);
            if (bannerStatic != null)
            {
                bannerStatic.State = "None";
                bannerStatic.Stt = null;
            }
        }
        void SapXepDynamic(Banner Banner, int x)
        {
            var stt = _context.Banners.Where(c => c.State == "Dynamic").Max(c => c.Stt);

            if (x == 1)
            {
                if (Banner.Stt < stt)
                {
                    var bannerList = _context.Banners.Where(c => c.State == "Dynamic" && c.Stt > Banner.Stt).ToList();
                    foreach (var item in bannerList)
                    {
                        item.Stt = item.Stt - 1;
                    }
                }
            }
            if (x == 2)
            {
                if (stt != null && stt >= Banner.Stt)
                {
                    var bannerList = _context.Banners.Where(c => c.State == "Dynamic" && c.Stt >= Banner.Stt).ToList();
                    foreach (var item in bannerList)
                    {
                        item.Stt = item.Stt + 1;
                    }
                }
            }
        }
    }
}

