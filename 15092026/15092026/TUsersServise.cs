using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15092026
{
    [TestClass]
    public class TUsersServise
    {

        [TestMethod]
        [DataRow("login", "pass", true)]
        [DataRow("login", "123", false)]
        public void TestAutorization(string login, string password, bool expected)
        {
            var mock = new Mock<IUsersRepository>();
            mock.Setup(repo => repo.GetUser("login"))
                .Returns(new User ("login", "pass"));
            var service = new UsersService(mock.Object);

            bool actual = service.Autorization(login, password);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("login2", "1234823648632487", true)] // true
        [DataRow("login", "12324242424234432", false)] // repo contains the login
        [DataRow("", "123456789", false)] // empty login
        [DataRow("login2", "123", false)] // short password
        public void TestRegistration(string login, string password, bool expected)
        {
            var mock = new Mock<IUsersRepository>();
            mock.Setup(repo => repo.GetUser("login"))
                .Returns(new User ("login", "pass"));
            var service = new UsersService(mock.Object);

            bool actual = service.Registration(login, password);

            Assert.AreEqual(expected, actual);
        }
    }
}
