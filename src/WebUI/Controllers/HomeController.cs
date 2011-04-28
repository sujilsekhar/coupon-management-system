using System.Linq;
using System.Web.Mvc;
using Core.Model;
using Core.Service;
using Omu.Awesome.Mvc;

namespace WebUI.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ICrudService<Category> s;
        private readonly ICrudService<Vendor> vs;
        private readonly ICrudService<Coupon> cs;

        public HomeController(ICrudService<Category> s, ICrudService<Vendor> vs, ICrudService<Coupon> cs)
        {
            this.s = s;
            this.vs = vs;
            this.cs = cs;
        }

        public ActionResult Index()
        {
            return View(s.GetAll());
        }

        public ActionResult ShowTabContent(int id = 1, int page = 1, int ps = 5)
        {
            var vendors = vs.Where(o => o.CategoryId.Equals(id)).Select(v => v.Id);
            var coupons = cs.Where(o => vendors.Contains(o.VendorId));
            var rows = this.RenderView("rows", coupons.OrderByDescending(u => u.Id).Skip((page - 1) * ps).Take(ps));

            return Json(new { rows, more = coupons.Count() > page * ps }, JsonRequestBehavior.AllowGet);
        }

        public virtual ActionResult Search(string search, int page = 1, int ps = 5)
        {
            var src = s.Where(o => o.Name.StartsWith(search), User.IsInRole("admin"));
            var rows = this.RenderView("rows", src.OrderBy(u => u.Id).Skip((page - 1) * ps).Take(ps));

            return Json(new { rows, more = src.Count() > page * ps });
        }

        public ActionResult About()
        {
            return View();
        }

    }
}
