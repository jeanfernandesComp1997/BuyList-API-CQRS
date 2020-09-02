using BuyList.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuyList.Tests.EntityTests
{
    [TestClass]
    public class UserTests
    {
        private readonly User _validUser = new User("Jean Fernandes", "jeanfernandes10@hotmail.com", "123456");

        [TestMethod]
        public void New_user_success()
        {
            Assert.AreEqual(_validUser, _validUser);
        }
    }
}