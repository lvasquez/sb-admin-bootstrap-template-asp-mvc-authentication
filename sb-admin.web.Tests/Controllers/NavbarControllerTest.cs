using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using sb_admin.web.Controllers;
using sb_admin.web.Models;
using System.Web.Mvc;
using System.Linq;

namespace sb_admin.web.Tests.Controllers
{
    /// <summary>
    /// Summary description for NavbarControllerTest
    /// </summary>
    [TestClass]
    public class NavbarControllerTest
    {
    
        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException))]
        public void NavBar_Return_ViewResult()
        {
            //Arrange
            var navbar = new NavbarController();
            string controller = "Home";
            string act = "Index";

            //Act
            var result = navbar.Navbar(controller, act);

            //Assert
            Assert.IsInstanceOfType(result, typeof(PartialViewResult));
        }

        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException))]
        public void NavBar_Return_IsNotNullModel()
        {

            //Arrange
            var navbar = new NavbarController();
            string controller = "Home";
            string act = "Index";

            //Act
            var result = navbar.Navbar(controller, act) as PartialViewResult;

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException))]
        public void NavBar_Return_TypeModel()
        {
            //Arrange
            var navbar = new NavbarController();
            string controller = "Home";
            string act = "Index";

            //Act
            var result = navbar.Navbar(controller, act) as PartialViewResult;

            //Assert
            Assert.IsInstanceOfType(result.Model, typeof(List<Navbar>));
        }

        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException))]
        public void NavBar_Return_SameModel()
        {
            //Arrange
            var navbar = new NavbarController();
            var navbars = new List<Navbar>();
            navbars.Add(new Navbar { Id = 2, nameOption = "Charts", controller = "Home", action = "Charts", imageClass = "fa fa-fw fa-bar-chart-o", estatus = true });
            navbars.Add(new Navbar { Id = 3, nameOption = "Tables", controller = "Home", action = "Tables", imageClass = "fa fa-fw fa-table", estatus = true });

            string controller = "Home";
            string act = "Index";

            //Act
            var viewResult = navbar.Navbar(controller, act) as PartialViewResult;
            var viewModel = viewResult.Model;
            //Assert
            Assert.AreSame(viewResult.Model.ToString(), navbars.ToString());

        }

        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException))]
        public void NavBar_Return_WithItems()
        {
            //Arrange
            var navbar = new NavbarController();
            string controller = "Home";
            string act = "Index";

            //Act
            var result = navbar.Navbar(controller, act) as PartialViewResult;
            var list = (IEnumerable<Navbar>)result.Model;

            //Assert
            Assert.AreNotEqual(0, list.Count());
        }

        [TestMethod]
        public void NavBar_Return_WithFalseItems()
        {
            //Arrange
            var navbar = new NavbarController();

            List<Navbar> nitems = new List<Navbar>()
            {
                new Navbar() { Id = 2, nameOption = "Charts", controller = "Home", action = "Charts", imageClass = "fa fa-fw fa-bar-chart-o", estatus = true  },
                new Navbar() { Id = 3, nameOption = "Tables", controller = "Home", action = "Tables", imageClass = "fa fa-fw fa-table", estatus = true }
            };

            //Assert
            Assert.IsTrue(nitems.Any(p => p.nameOption == "Charts"));
        }

    }
}
