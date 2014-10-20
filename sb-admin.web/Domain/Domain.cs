using sb_admin.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sb_admin.web.Domain
{
    public class Data
    {
        public IEnumerable<Navbar> navbarItems()
        {
            var menu = new List<Navbar>();
            menu.Add(new Navbar { Id = 1, nameOption = "Dashboard", controller = "Home", action = "Index", imageClass = "fa fa-fw fa-dashboard", estatus = true });
            menu.Add(new Navbar { Id = 2, nameOption = "Charts", controller = "Home", action = "Charts", imageClass = "fa fa-fw fa-bar-chart-o", estatus = true });
            menu.Add(new Navbar { Id = 3, nameOption = "Tables", controller = "Home", action = "Tables", imageClass = "fa fa-fw fa-table", estatus = true });
            menu.Add(new Navbar { Id = 4, nameOption = "Forms", controller = "Home", action = "Forms", imageClass = "fa fa-fw fa-edit", estatus = true });
            menu.Add(new Navbar { Id = 5, nameOption = "Bootstrap Elements", controller = "Home", action = "BootstrapElements", imageClass = "fa fa-fw fa-desktop", estatus = true });
            menu.Add(new Navbar { Id = 6, nameOption = "Bootstrap Grid", controller = "Home", action = "BootstrapGrid", imageClass = "fa fa-fw fa-wrench", estatus = true });
            menu.Add(new Navbar { Id = 7, nameOption = "Blank Page", controller = "Home", action = "BlankPage", imageClass = "fa fa-fw fa-file", estatus = true });

            return menu.ToList();
        }

        public IEnumerable<User> users()
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, user = "admin", password = "12345", estatus = true, RememberMe = true });
            users.Add(new User { Id = 2, user = "lvasquez", password = "lvasquez", estatus = true, RememberMe = false });
            users.Add(new User { Id = 3, user = "invite", password = "12345", estatus = false, RememberMe = false });

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

        public IEnumerable<Navbar> itemsPerUser(string controller, string action, string userName)
        {
            
            IEnumerable<Navbar> items = navbarItems();
            IEnumerable<Roles> rolesNav = roles();
            IEnumerable<User> usersNav = users();

            var navbar =  items.Where(p => p.controller == controller && p.action == action).Select(c => { c.activeli = "active"; return c; }).ToList();

            navbar = (from nav in items
                      join rol in rolesNav on nav.Id equals rol.idMenu
                      join user in usersNav on rol.idUser equals user.Id
                      where user.user == userName
                      select new Navbar
                      {
                          Id = nav.Id,
                          nameOption = nav.nameOption,
                          controller = nav.controller,
                          action = nav.action,
                          imageClass = nav.imageClass,
                          estatus = nav.estatus,
                          activeli = nav.activeli
                      }).ToList();

            return navbar.ToList();
        }

    }
}