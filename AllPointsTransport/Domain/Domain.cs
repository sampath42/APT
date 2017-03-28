using AllPointsTransport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllPointsTransport.Domain
{
    public class Data
    {
        public IEnumerable<Navbar> navbarItems(string activeTab, string activeTabAction)
        {
            var menu = new List<Navbar>();
            menu.Add(new Navbar { Id = 1, nameOption = "Dashboard", controller = "Home", action = "Index", imageClass = "icon-dashboard", estatus = true });
            menu.Add(new Navbar { Id = 2, nameOption = "Rate Quotes", controller = "RateQuotes", action = "Index", imageClass = "icon-list-alt", estatus = true });
            menu.Add(new Navbar { Id = 2, nameOption = "Employees", controller = "Employees", action = "Index", imageClass = "icon-user", estatus = true });
            menu.Add(new Navbar { Id = 3, nameOption = "Work Orders", controller = "WorkOrders", action = "Index", imageClass = "icon-shopping-cart", estatus = true });
            menu.Add(new Navbar { Id = 4, nameOption = "Templates", controller = "Templates", action = "Index", imageClass = "icon-th", estatus = true });
            menu.Add(new Navbar { Id = 5, nameOption = "CSR Screen", controller = "Home", action = "CSRScreen", imageClass = "icon-question-sign", estatus = true });
            menu.Add(new Navbar { Id = 6, nameOption = "Scheduler", controller = "Home", action = "Scheduler", imageClass = "icon-calendar", estatus = true });
            menu.Add(new Navbar { Id = 7, nameOption = "Dispatch", controller = "Dispatch", action = "Index", imageClass = "icon-plane", estatus = true });
            menu.Add(new Navbar { Id = 8, nameOption = "Inventory (All)", controller = "Home", action = "Inventory", imageClass = "icon-briefcase", estatus = true });
          

            foreach (Navbar navBarItem in menu)
            {
                if ((navBarItem.controller == activeTab) && (navBarItem.action == activeTabAction))
                {
                    navBarItem.activeli = "active";
                }
                else
                {
                    navBarItem.activeli = "";
                }
            }

            return menu.ToList();
        }

        public IEnumerable<User> users()
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, user = "admin", password = "Wj7VoVOy/+7ytLNAvim/Yw==", estatus = true, RememberMe = true });
            users.Add(new User { Id = 2, user = "sampath", password = "oY5rNfysZLhBOAy8cs/OgQ==", estatus = true, RememberMe = false });
            users.Add(new User { Id = 3, user = "invite", password = "Wj7VoVOy/+7ytLNAvim/Yw==", estatus = false, RememberMe = false });

            return users.ToList();
        }

        public IEnumerable<Roles> roles()
        {
            var roles = new List<Roles>();
            roles.Add(new Roles { rowid = 1, idUser = 1, idMenu = 1, status = true });
            roles.Add(new Roles { rowid = 2, idUser = 1, idMenu = 2, status = true });
            roles.Add(new Roles { rowid = 3, idUser = 1, idMenu = 3, status = true });
            roles.Add(new Roles { rowid = 4, idUser = 1, idMenu = 4, status = true });
            roles.Add(new Roles { rowid = 5, idUser = 1, idMenu = 5, status = true });
            roles.Add(new Roles { rowid = 6, idUser = 1, idMenu = 6, status = true });
            roles.Add(new Roles { rowid = 7, idUser = 1, idMenu = 7, status = true });
            roles.Add(new Roles { rowid = 8, idUser = 2, idMenu = 1, status = true });
            roles.Add(new Roles { rowid = 9, idUser = 2, idMenu = 2, status = true });
            roles.Add(new Roles { rowid = 10, idUser = 2, idMenu = 3, status = true });
            roles.Add(new Roles { rowid = 11, idUser = 2, idMenu = 4, status = true });
            roles.Add(new Roles { rowid = 12, idUser = 2, idMenu = 5, status = true });
            roles.Add(new Roles { rowid = 13, idUser = 3, idMenu = 1, status = true });
            roles.Add(new Roles { rowid = 14, idUser = 3, idMenu = 2, status = true });

            return roles.ToList();
        }

        public IEnumerable<Navbar> itemsPerUser(string controller, string action, string userName, string activeTab)
        {
            
            IEnumerable<Navbar> items = navbarItems(activeTab, action);
            IEnumerable<Roles> rolesNav = roles();
            IEnumerable<User> usersNav = users();

            var navbar = items;
            //var navbar =  items.Where(p => p.controller == controller && p.action == action).Select(c => { c.activeli = "active"; return c; }).ToList();

            //navbar = (from nav in items
            //          join rol in rolesNav on nav.Id equals rol.idMenu
            //          join user in usersNav on rol.idUser equals user.Id
            //          where user.user == userName
            //          select new Navbar
            //          {
            //              Id = nav.Id,
            //              nameOption = nav.nameOption,
            //              controller = nav.controller,
            //              action = nav.action,
            //              imageClass = nav.imageClass,
            //              estatus = nav.estatus,
            //              activeli = nav.activeli
            //          }).ToList();

            return navbar.ToList();
        }

    }
}