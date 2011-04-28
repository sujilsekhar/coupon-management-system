using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Resources;

namespace WebUI.Controllers
{
    //http://www.screwturn.eu/ResxSync.ashx
    public class MuiController : Controller
    {
        readonly IDictionary<string, string> langs = new Dictionary<string, string>
                                                    {
                                                        {"en", Mui.English},
                                                        {"zh-cn", Mui.Chinese},
                                                        {"auto", Mui.DefaultLang},//browser default
                                                    };
        public ActionResult Index()
        {
            var c = Request.Cookies["lang"];

            var k = c == null ? "auto" : c.Value;
            ViewBag.lang = langs[k];
            return View();
        }

        public ActionResult Langs()
        {
            return View(langs);
        }

        [HttpPost]
        public ActionResult Change(string l)
        {
            var aCookie = new HttpCookie("lang") { Value = l, Expires = DateTime.Now.AddYears(1) };
            Response.Cookies.Add(aCookie);

            return Content("");
        }
    }
}