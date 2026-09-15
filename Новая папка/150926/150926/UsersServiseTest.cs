using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using System.Security.Cryptography.X509Certificates;

namespace _150926
{
    [TestClass]
    public class UsersServiseTest
    {
        
        [TestMethod]
        public void TAutorization()
        {
            var mock = new Mock<IUsersRepository>();
            mock.Setup(repo => repo.GetUser("login"))
                .Returns(new User { Login = "login", Password = "pass" });
            var service = new UsersService(mock.Object);
            string login = "login";
            string password = "pass";

            string expected = "true";

            string actual = service.Autorization(login, password);

            Assert.AreEqual(expected, actual);
        }
    }
}
