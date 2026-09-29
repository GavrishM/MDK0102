using System;
using ClassLibrary;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace _15092026
{
    [TestClass]
    public class TImporter
    {
        /*
        List<User> TUsersList1 = new List<User>
        {
            new User("login6", "p6a9s8s6w4o2r1d"),
            new User("login7", "p6a9s8s6w4o2r1d"),
            new User("login8", "p6a9s8s6w4o2r1d"),
            new User("login9", "p6a9s8s6w4o2r1d"),
            new User("login10", "p6a9s8s6w4o2r1d")
        };*/
        [TestMethod]
        //[DataRow(TUsersList1)]
        public void TestUsersImportTrue(/*List<User> users*/)
        {
            var mockRepo = new Mock<IUsersRepository>();
            mockRepo.Setup(repo => repo.GetAllUsers())
                .Returns(new List<User>
                {
                    new User("login", "pass"),
                    new User("login2", "pass"),
                    new User("login3", "pass"),
                    new User("login4", "pass"),
                    new User("login5", "pass")
                });
            var servise = new UsersService(mockRepo.Object);

            string filePath = "path";

            var mockFile = new Mock<IFile>();
            mockFile.Setup(file => file.GetUsers(filePath))
                    .Returns(/*users*/ new List<User>
                    {
                        new User("login6", "p6a9s8s6w4o2r1d"),
                        new User("login7", "p6a9s8s6w4o2r1d"),
                        new User("login8", "p6a9s8s6w4o2r1d"),
                        new User("login9", "p6a9s8s6w4o2r1d"),
                        new User("login10", "p6a9s8s6w4o2r1d")
                    });
            var importer = new Importer(mockFile.Object, mockRepo.Object);

            List<User> users = new List<User>
            {
                new User("login", "pass"),
                new User("login2", "pass"),
                new User("login3", "pass"),
                new User("login4", "pass"),
                new User("login5", "pass"),
                new User("login6", "p6a9s8s6w4o2r1d"),
                new User("login7", "p6a9s8s6w4o2r1d"),
                new User("login8", "p6a9s8s6w4o2r1d"),
                new User("login9", "p6a9s8s6w4o2r1d"),
                new User("login10", "p6a9s8s6w4o2r1d")
            };
            var mockRepoChanged = new Mock<IUsersRepository>();
            mockRepoChanged.Setup(repo => repo.GetAllUsers())
                           .Returns(users);
            var serviceChanged = new UsersService(mockRepoChanged.Object);
            
            bool expectedBool = true;
            List<User> expected = users;

            bool actualBool = importer.UsersImport(filePath);
            List<User> actual = mockRepoChanged.Object.GetAllUsers();


            Assert.AreEqual(expectedBool, actualBool);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestUsersImportShortPassword()
        {
            var mockRepo = new Mock<IUsersRepository>();
            mockRepo.Setup(repo => repo.GetAllUsers())
                .Returns(new List<User>
                {
                    new User ("login", "pass"),
                    new User ("login2", "pass"),
                    new User ("login3", "pass"),
                    new User ("login4", "pass"),
                    new User ("login5", "pass")
                });
            var servise = new UsersService(mockRepo.Object);

            string filePath = "path";


            var mockFile = new Mock<IFile>();
            mockFile.Setup(file => file.GetUsers(filePath))
                .Returns(new List<User>
                {
                    new User ("login6", "pass"),
                    new User ("login7", "p6a9s8s6w4o2r1d"),
                    new User ("login8", "p6a9s8s6w4o2r1d"),
                    new User ("login9", "p6a9s8s6w4o2r1d"),
                    new User ("login10", "p6a9s8s6w4o2r1d")
                });
            var importer = new Importer(mockFile.Object, mockRepo.Object);

            bool expected = false;

            bool actual = importer.UsersImport(filePath);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestUsersImportEqualLogin()
        {
            var mockRepo = new Mock<IUsersRepository>();
            mockRepo.Setup(repo => repo.GetAllUsers())
                .Returns(new List<User>
                {
                    new User ("login", "pass"),
                    new User ("login2", "pass"),
                    new User ("login3", "pass"),
                    new User ("login4", "pass"),
                    new User ("login5", "pass")
                });
            var servise = new UsersService(mockRepo.Object);

            string filePath = "path";


            var mockFile = new Mock<IFile>();
            mockFile.Setup(file => file.GetUsers(filePath))
                .Returns(new List<User>
                {
                    new User ("login", "p6a9s8s6w4o2r1d"),
                    new User ("login7", "p6a9s8s6w4o2r1d"),
                    new User ("login8", "p6a9s8s6w4o2r1d"),
                    new User ("login9", "p6a9s8s6w4o2r1d"),
                    new User ("login10", "p6a9s8s6w4o2r1d")
                });
            var importer = new Importer(mockFile.Object, mockRepo.Object);

            bool expected = true;

            bool actual = importer.UsersImport(filePath);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestUsersImportEmptyLogin()
        {
            var mockRepo = new Mock<IUsersRepository>();
            mockRepo.Setup(repo => repo.GetAllUsers())
                .Returns(new List<User>
                {
                    new User ("login", "pass"),
                    new User ("login2", "pass"),
                    new User ("login3", "pass"),
                    new User ("login4", "pass"),
                    new User ("login5", "pass")
                });
            var servise = new UsersService(mockRepo.Object);

            string filePath = "path";


            var mockFile = new Mock<IFile>();
            mockFile.Setup(file => file.GetUsers(filePath))
                .Returns(new List<User>
                {
                    new User ("", "p6a9s8s6w4o2r1d"),
                    new User ("login7", "p6a9s8s6w4o2r1d"),
                    new User ("login8", "p6a9s8s6w4o2r1d"),
                    new User ("login9", "p6a9s8s6w4o2r1d"),
                    new User ("login10", "p6a9s8s6w4o2r1d")
                });
            var importer = new Importer(mockFile.Object, mockRepo.Object);

            bool expected = false;

            bool actual = importer.UsersImport(filePath);

            Assert.AreEqual(expected, actual);
        }
    }
}
