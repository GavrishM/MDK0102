using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

namespace _150926
{
    [TestClass]
    public class TImporter
    {
        List<User> TUsersList1 = new List<User>
        {
            new User("login6", "p6a9s8s6w4o2r1d"),
            new User("login7", "p6a9s8s6w4o2r1d"),
            new User("login8", "p6a9s8s6w4o2r1d"),
            new User("login9", "p6a9s8s6w4o2r1d"),
            new User("login10", "p6a9s8s6w4o2r1d")
        };
        [TestMethod]
        [DataRow(TUsersList1)]
        public void TestUsersImportTrue(List<User> users)
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

            string filePath = "path";

            var mockFile = new Mock<IFile>();
            mockFile.Setup(file => file.GetUsers(filePath))
                .Returns(users);
            var importer = new Importer(mockFile.Object, mockRepo.Object);

            bool expected = true;

            bool actual = importer.UsersImport(filePath);

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

            string filePath = "path";


            var mockFile = new Mock<IFile>();
            mockFile.Setup(file => file.GetUsers(filePath))
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

            bool actual = importer.UsersImport(filePath);

            Assert.AreEqual(expected, actual);
        }
    }
}
