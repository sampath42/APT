using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using AllPointsTransport.Domain;
using AllPointsTransport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AllPointsTransport.Common;

namespace AllPointsTransport.Controllers
{
    public class AccountController : BaseController
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

            model.Password = AESEncryption.Encrypt(model.Password);
            var response = model.PostRequest(WebApiRequests.AuthenticateUser); // call to webapi to authenticate user
            if (response)
            {
                var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, model.UserName),}, DefaultAuthenticationTypes.ApplicationCookie);
                FormsAuthentication.SetAuthCookie(model.UserName, true);
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
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Authentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    
    }
}