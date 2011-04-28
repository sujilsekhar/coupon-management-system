using System.Web.Mvc;
using Omu.Awesome.Mvc;
using Core.Model;
using Core.Repository;

namespace WebUI.Controllers
{
    public class CountryIdLookupController : LookupController
    {
        private readonly IRepo<Country> r;

        public CountryIdLookupController(IRepo<Country> r)
        {
            this.r = r;
        }

        [HttpPost]
        public ActionResult Search(string search)
        {
            return View(@"Awesome\LookupList", r.Where(o => o.Name.StartsWith(search)));
        }

        public ActionResult Get(int id)
        {
            return Content((r.Get(id) ?? new Country()).Name);
        }
    }
}