using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class StuffController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}