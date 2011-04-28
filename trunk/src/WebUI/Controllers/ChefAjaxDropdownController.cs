using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Core.Model;
using Core.Repository;
using Resources;

namespace WebUI.Controllers
{
    public class ChefIdAjaxDropdownController : Controller
    {
        private IRepo<Chef> r;

        public ChefIdAjaxDropdownController(IRepo<Chef> r)
        {
            this.r = r;
        }

        public ActionResult GetItems(int? key)
        {
            var list = new List<SelectListItem> { new SelectListItem { Text = Mui.not_selected, Value = "" } };


            list.AddRange(r.GetAll().Select(o => new SelectListItem
                                                     {
                                                         Text = string.Format("{0} {1}", o.FirstName, o.LastName),
                                                         Value = o.Id.ToString(),
                                                         Selected = o.Id == key
                                                     }));
            return Json(list);
        }
    }
}