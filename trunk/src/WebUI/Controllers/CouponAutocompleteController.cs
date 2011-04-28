using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Core.Model;
using Core.Repository;
using Omu.Awesome.Mvc;

namespace WebUI.Controllers
{
    public class CouponAutocompleteController : Controller
    {
        private readonly IRepo<Coupon> r;

        public CouponAutocompleteController(IRepo<Coupon> r)
        {
            this.r = r;
        }

        public JsonResult Search(string searchText, int maxResults, bool recommend, IEnumerable<int> vendors)
        {
            var res = r.Where(o => o.Name.Contains(searchText));
            if (recommend) res = res.Where(o => o.IsRecommended == recommend);
            if (vendors != null) res = res.Where(o => vendors.All(m => o.VendorId.Equals(m)));

            return Json(res.Select(i => new IdTextItem { Text = i.Name, Id = i.Id })
                            .Take(maxResults));
        }
    }
}
