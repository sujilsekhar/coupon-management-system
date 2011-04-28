using System.Linq;
using System.Web.Mvc;
using Core.Model;
using Core.Security;
using Core.Service;
using Infra.Dto;

namespace WebUI.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IFormsAuthentication formsAuth;
        private readonly IUserService us;

        public AccountController(IFormsAuthentication formsAuth, IUserService us)
        {
            this.formsAuth = formsAuth;
            this.us = us;
        }

        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(SignInInput input)
        {
            if (!ModelState.IsValid)
            {
                input.Password = null;
                input.Login = null;
                return View(input);
            }

            var user = us.Get(input.Login, input.Password);

            //ACHTUNG: remove this line in a real app
            if (user == null && input.Login == "o" && input.Password == "1") user = new User { Login = "o", Roles = new[] { new Role { Name = "admin" } } };

            if (user == null)
            {
                ModelState.AddModelError("", "Try Login: o and Password: 1");
                return View();
            }

            formsAuth.SignIn(user.Login, input.Remember, user.Roles.Select(o => o.Name));

            return RedirectToAction("index", "home");
        }

        public ActionResult SignOff()
        {
            formsAuth.SignOut();
            return RedirectToAction("SignIn", "Account");
        }
    }
}