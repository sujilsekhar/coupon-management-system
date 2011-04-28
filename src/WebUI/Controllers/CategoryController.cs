using System.Linq;
using System.Web.Mvc;
using Core.Model;
using Core.Service;
using Infra.Builder;
using Infra.Dto;
using Omu.Awesome.Mvc;

namespace WebUI.Controllers
{
    public class CategoryController : Cruder<Category, CategoryInput>
    {

        private readonly IUtilService us;

        public CategoryController(ICrudService<Category> s, IBuilder<Category, CategoryInput> v, IUtilService us)
            : base(s, v)
        {
            this.us = us;
        }

        public virtual ActionResult Search(string search, int page = 1, int ps = 5)
        {
            var src = s.Where(o => o.Name.StartsWith(search) || o.PinYin.Contains(search), User.IsInRole("admin"));
            var rows = this.RenderView("rows", src.OrderBy(u => u.Id).Skip((page - 1) * ps).Take(ps));

            return Json(new { rows, more = src.Count() > page * ps });
        }

        public override ActionResult Create(CategoryInput input)
        {
            input.PinYin = us.ConvertChsToPinYin(input.Name);
            return base.Create(input);
        }

        public override ActionResult Edit(CategoryInput input)
        {
            input.PinYin = us.ConvertChsToPinYin(input.Name);
            return base.Edit(input);
        }

    }
}
