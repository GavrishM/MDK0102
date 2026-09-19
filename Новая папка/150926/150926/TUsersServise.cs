using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using System.Security.Cryptography.X509Certificates;

namespace _150926
{
    [TestClass]
    public class TUsersServise
    {

        [TestMethod]
        public void TestAutorizationTrue()
        {
            var mock = new Mock<IUsersRepository>();
            mock.Setup(repo => repo.GetUser("login"))
                .Returns(new User { Login = "login", Password = "pass" });
            var service = new UsersService(mock.Object);
            string login = "login";
            string password = "pass";

            bool expected = true;

            bool actual = service.Autorization(login, password);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAutorizationFalse()
        {
            var mock = new Mock<IUsersRepository>();
            mock.Setup(repo => repo.GetUser("login"))
                .Returns(new User { Login = "login", Password = "pass" });
            var service = new UsersService(mock.Object);
            string login = "login";
            string password = "123";

            bool expected = false;

            bool actual = service.Autorization(login, password);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRegistrationTrue()
        {
            var mock = new Mock<IUsersRepository>();
            mock.Setup(repo => repo.GetUser("login"))
                .Returns(new User { Login = "login", Password = "pass" });
            var service = new UsersService(mock.Object);
            string login = "login2";
            string password = "123";

            bool expected = true;

            bool actual = service.Registation(login, password);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRegistrationFalse()
        {
            var mock = new Mock<IUsersRepository>();
            mock.Setup(repo => repo.GetUser("login"))
                .Returns(new User { Login = "login", Password = "pass" });
            var service = new UsersService(mock.Object);
            string login = "login";
            string password = "123";

            bool expected = false;

            bool actual = service.Registation(login, password);

            Assert.AreEqual(expected, actual);
        }
    }
}
