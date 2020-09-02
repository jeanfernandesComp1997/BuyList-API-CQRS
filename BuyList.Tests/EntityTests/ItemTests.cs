using BuyList.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuyList.Tests.EntityTests
{
    [TestClass]
    public class ItemTests
    {
        private User _owner;
        private readonly Item _validItem;

        public ItemTests()
        {
            _owner = new User("Jean Fernandes", "jeanfernandes10@hotmail.com", "123456");
            _validItem = new Item("Pão francês", 10, "un", (decimal)0.25, "Padaria", _owner);
        }

        [TestMethod]
        public void New_item_success()
        {
            Assert.AreEqual(_validItem, _validItem);
        }
    }
}