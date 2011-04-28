using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class NavController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}