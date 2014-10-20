using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using sb_admin.web.Domain;
using sb_admin.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace sb_admin.web.Controllers
{
    public class AccountController : Controller
    {       
        IAuthenticationManager Authentication
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }
        
        // GET: Account
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new LoginViewModel());
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var data = new Data();
            var users = data.users();

            if (users.Any(p => p.user == model.UserName && p.password == model.Password))
            {
                var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, model.UserName),}, DefaultAuthenticationTypes.ApplicationCookie);

                Authentication.SignIn(new AuthenticationProperties
                {
                    IsPersistent = model.RememberMe
                }, identity);
                
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Authentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    
    }
}