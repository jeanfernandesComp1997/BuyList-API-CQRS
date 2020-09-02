using System;
using System.Collections.Generic;
using BuyList.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuyList.Tests.EntityTests
{
    [TestClass]
    public class BuyListTests
    {
        private User _owner;
        private readonly ListBuy _validBuyList;

        public BuyListTests()
        {
            _owner = new User("Jean Fernandes", "jeanfernandes10@hotmail.com", "123456");
            _validBuyList = new ListBuy("Lista de compras da tarde", new DateTime(), _owner);
        }

        [TestMethod]
        public void New_buylist_success()
        {
            Assert.AreEqual(_validBuyList, _validBuyList);
        }
    }
}