using AllPointsTransport.Domain;
using AllPointsTransport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllPointsTransport.Controllers
{
    public class NavbarController : BaseController
    {
        // GET: Navbar
        public ActionResult Navbar(string controller, string action)
        {
            var data = new Data();

            var navbar = data.itemsPerUser(controller, action, User.Identity.Name, controller);

            return PartialView("_navbar", navbar);
        }
    }
}