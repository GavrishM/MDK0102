using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

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
            string password = "1234823648632487";

            bool expected = true;

            bool actual = service.Registration(login, password);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRegistrationRepositoryContainsTheLogin()
        {
            var mock = new Mock<IUsersRepository>();
            mock.Setup(repo => repo.GetUser("login"))
                .Returns(new User { Login = "login", Password = "pass" });
            var service = new UsersService(mock.Object);
            string login = "login";
            string password = "12324242424234432";

            bool expected = false;

            bool actual = service.Registration(login, password);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestRegistrationLoginEmpty()
        {
            var mock = new Mock<IUsersRepository>();
            mock.Setup(repo => repo.GetUser("login"))
                .Returns(new User { Login = "login", Password = "pass" });
            var service = new UsersService(mock.Object);
            string login = "";
            string password = "123456789";

            bool expected = false;

            bool actual = service.Registration(login, password);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestRegistrationShrotPassword()
        {
            var mock = new Mock<IUsersRepository>();
            mock.Setup(repo => repo.GetUser("login"))
                .Returns(new User { Login = "login", Password = "pass" });
            var service = new UsersService(mock.Object);
            string login = "login";
            string password = "123";

            bool expected = false;

            bool actual = service.Registration(login, password);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestUsersImportTrue()
        {
            var mockRepo = new Mock<IUsersRepository>();
            mockRepo.Setup(repo => repo.GetAllUsers())
                .Returns(new List<User>
                {
                    new User { Login = "login",  Password = "pass" },
                    new User { Login = "login2", Password = "pass" },
                    new User { Login = "login3", Password = "pass" },
                    new User { Login = "login4", Password = "pass" },
                    new User { Login = "login5", Password = "pass" }
                });
            var servise = new UsersService(mockRepo.Object);

            var mockFile = new Mock<IFile>();
            mockFile.Setup(file => file.GetUsers())
                .Returns(new List<User>
                {
                    new User { Login = "login6",  Password = "p6a9s8s6w4o2r1d" },
                    new User { Login = "login7",  Password = "p6a9s8s6w4o2r1d" },
                    new User { Login = "login8",  Password = "p6a9s8s6w4o2r1d" },
                    new User { Login = "login9",  Password = "p6a9s8s6w4o2r1d" },
                    new User { Login = "login10", Password = "p6a9s8s6w4o2r1d" }
                });
            var importer = new Importer(mockFile.Object, mockRepo.Object);

            bool expected = true;

            bool actual = importer.UsersImport();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestUsersImportFalse()
        {
            var mockRepo = new Mock<IUsersRepository>();
            mockRepo.Setup(repo => repo.GetAllUsers())
                .Returns(new List<User>
                {
                    new User { Login = "login",  Password = "pass" },
                    new User { Login = "login2", Password = "pass" },
                    new User { Login = "login3", Password = "pass" },
                    new User { Login = "login4", Password = "pass" },
                    new User { Login = "login5", Password = "pass" }
                });
            var servise = new UsersService(mockRepo.Object);

            var mockFile = new Mock<IFile>();
            mockFile.Setup(file => file.GetUsers())
                .Returns(new List<User>
                {
                    new User { Login = "login6",  Password = "pass" },
                    new User { Login = "login7",  Password = "p6a9s8s6w4o2r1d" },
                    new User { Login = "login8",  Password = "p6a9s8s6w4o2r1d" },
                    new User { Login = "login9",  Password = "p6a9s8s6w4o2r1d" },
                    new User { Login = "login10", Password = "p6a9s8s6w4o2r1d" }
                });
            var importer = new Importer(mockFile.Object, mockRepo.Object);

            bool expected = false;

            bool actual = importer.UsersImport();

            Assert.AreEqual(expected, actual);
        }
    }
}
