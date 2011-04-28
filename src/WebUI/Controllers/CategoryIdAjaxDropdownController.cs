using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Core.Model;
using Core.Repository;
using Resources;

namespace WebUI.Controllers
{
    public class CategoryIdAjaxDropdownController : Controller
    {
        private IRepo<Category> r;

        public CategoryIdAjaxDropdownController(IRepo<Category> r)
        {
            this.r = r;
        }

        public ActionResult GetItems(int? key)
        {
            var list = new List<SelectListItem> { new SelectListItem { Text = Mui.not_selected, Value = "" } };

            list.AddRange(r.GetAll().Select(o => new SelectListItem
                                                 {
                                                     Text = o.Name,
                                                     Value = o.Id.ToString(),
                                                     Selected = o.Id == key
                                                 }));
            return Json(list);
        }

    }
}
