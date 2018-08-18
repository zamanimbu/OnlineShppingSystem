using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineShoppingCartApp.BLL;
using OnlineShoppingCartApp.Model;

namespace ShoppingCartApp.Test
{
    [TestClass]
    public class UserBusinessLogicTest
    {
        UserBusinessLogic aUserBusinessLogic = new UserBusinessLogic();
        [TestMethod]
        [TestCategory("UserBusinessLogicTest")]
        public void AddUserTest()
        {
            User aUser = new User
            {
                UserName = "rimu",
                Password = "123",
                Name = "rimu",
                Email = "r@mail.com",
                UserType = "U"
            };

            string message = aUserBusinessLogic.addUser(aUser);
            string actual = "Save Successfuly";
            Assert.AreEqual(actual,message);
        }
        [TestMethod]
        [TestCategory("UserBusinessLogicTest")]
        public void IsUserExistTest()
        {
            string username = "ashraf";
            string password = "001";

            bool actual = true;
            bool predicted = aUserBusinessLogic.IsUserExist(username, password);

            Assert.AreEqual(actual,predicted);
        }

        [TestMethod]
        [TestCategory("UserBusinessLogicTest")]
        public void CheackRoleTest()
        {
            string username = "ashraf";
            string password = "001";

            string actual = "U";
            string predicted = aUserBusinessLogic.CheackRole(username, password);

            Assert.AreEqual(actual, predicted);
        }


    }
}
