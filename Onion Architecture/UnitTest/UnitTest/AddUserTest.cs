using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class AddUserTest
    {
        [TestMethod]
        public void AddUser_IsIdGreaterThanZero_ReturnsTrue()
        {
            //Arrange
            var adduser = new AddUserTest();

            //Act
            var result = adduser.AddUser(new UserViewModel { IdGreater = true});

            Assert.IsTrue(result);


        }

    }
    }


