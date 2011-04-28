using System;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI;
using Core.Model;
using Core.Service;
using Infra.Builder;
using Infra.Dto;
using Omu.Awesome.Mvc;
using Omu.Drawing;

namespace WebUI.Controllers
{
    public class VendorController : Cruder<Vendor, VendorInput>
    {
        private new readonly IVendorService s;
        private readonly IUtilService us;

        public VendorController(IVendorService s, IBuilder<Vendor, VendorInput> v, IUtilService us) : base(s, v)
        {
            this.s = s;
            this.us = us;
        }

        public override ActionResult Index()
        {
            ViewBag.UseList = true;
            return base.Index();
        }

        public virtual ActionResult Search(string search, int? categoryId, int page = 1, int ps = 5)
        {
            var src = s.Where(o => o.Name.StartsWith(search) || o.PinYin.Contains(search), User.IsInRole("admin"));
            if (categoryId != null) src = src.Where(o => o.CategoryId == categoryId);
            var rows = this.RenderView("rows", src.OrderBy(u => u.Id).Skip((page - 1) * ps).Take(ps));

            return Json(new { rows, more = src.Count() > page * ps });
        }

        [OutputCache(Location = OutputCacheLocation.None)]
        public ActionResult Picture(int id)
        {
            return View(s.Get(id));
        }

        [HttpPost]
        public ActionResult Picture()
        {
            var file = Request.Files["fileUpload"];
            var id = Convert.ToInt32(Request.Form["id"]);
            if (file.ContentLength > 0)
            {
                var filePath = @ConfigurationManager.AppSettings["storagePath"] + @"\Vendors\temp\" + id + ".jpg";
                using (var image = Image.FromStream(file.InputStream))
                {
                    var resized = Imager.Resize(image, 640, 480, true);
                    Imager.SaveJpeg(filePath, resized);
                    return RedirectToAction("Crop", new CropInput { ImageWidth = resized.Width, ImageHeight = resized.Height, Id = id });
                }
            }

            return RedirectToAction("Index");
        }

        [OutputCache(Location = OutputCacheLocation.None)]
        public ActionResult Crop(CropInput cropDisplay)
        {
            return View(cropDisplay);
        }

        [HttpPost]
        public ActionResult Crop(int x, int y, int w, int h, int id)
        {
            using (var image = Image.FromFile(@ConfigurationManager.AppSettings["storagePath"] + @"\Vendors\temp\" + id + ".jpg"))
            {
                var img = Imager.Crop(image, new Rectangle(x, y, w, h));
                var resized = Imager.Resize(img, 200, 200, true);
                var small = Imager.Resize(img, 100, 100, true);
                var mini = Imager.Resize(img, 45, 45, true);
                Imager.SaveJpeg(@ConfigurationManager.AppSettings["storagePath"] + @"\Vendors\" + id + ".jpg", resized);
                Imager.SaveJpeg(@ConfigurationManager.AppSettings["storagePath"] + @"\Vendors\" + id + "s.jpg", small);
                Imager.SaveJpeg(@ConfigurationManager.AppSettings["storagePath"] + @"\Vendors\" + id + "m.jpg", mini);

                s.HasPic(id);
            }
            return RedirectToAction("Picture", new { id });
        }

        public override ActionResult Create(VendorInput input)
        {
            input.PinYin = us.ConvertChsToPinYin(input.Name);
            return base.Create(input);
        }

        public override ActionResult Edit(VendorInput input)
        {
            input.PinYin = us.ConvertChsToPinYin(input.Name);
            return base.Edit(input);
        }

    }
}
