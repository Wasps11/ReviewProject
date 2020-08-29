using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReviewProject.BL.Controller;
using ReviewProject.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewProject.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void UserControllerTest()
        {
            Assert.Fail();
        }
        [TestMethod()]
        public void SaveTest()
        {
            var userName = Guid.NewGuid().ToString();

            var controller = new UserController(userName);

            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }
        [TestMethod()]
        public void SetNewUserDataTest()
        {
            var userName = Guid.NewGuid().ToString();
            var genderName = Guid.NewGuid().ToString();
            DateTime birthDate = DateTime.Parse("10.02.1999");
            var rnd = new Random();
            var buys = Convert.ToInt32(rnd.Next(0, 100));
            var sumOfBuys = Convert.ToInt32(rnd.Next(101, 201));
            var controller = new UserController(userName);

            controller.SetNewUserData(genderName, birthDate, buys, sumOfBuys);
            var controller2 = new UserController(userName);
            var currentUser = controller.CurrentUser;

            Assert.AreEqual(currentUser.Name, userName);
            //Assert.AreEqual(currentUser.Gender.Name, genderName);
            Assert.AreEqual(currentUser.BirthDate, birthDate);
            Assert.AreEqual(currentUser.Buys, buys);
            Assert.AreEqual(currentUser.SumOfBuys, sumOfBuys);
        }

    }
}