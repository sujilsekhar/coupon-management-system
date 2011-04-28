using System;
using System.Web.Mvc;
using Core;
using Infra.Dto;

namespace WebUI.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index(Exception error)
        {
            var m = error.Message;
            if (error.InnerException != null) m += " | " + error.InnerException.Message;
            ViewBag.Message = m;
            if (Request.IsAjaxRequest())
            {
                if (error is sArtException)
                    return View("Expectedp");
                return View("Errorp");
            }

            if (error is sArtException)
                return View("Expected", new ErrorDisplay { Message = error.Message });
            return View("Error", new ErrorDisplay { Message = error.Message });
        }

        public ActionResult HttpError404(Exception error)
        {
            return View();
        }

        public ActionResult HttpError505(Exception error)
        {
            return View();
        }
    }
}