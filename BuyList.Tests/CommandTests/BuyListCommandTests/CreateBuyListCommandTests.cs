using BuyList.Domain.Commands.BuyListCommands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BuyList.Tests.CommandTests.BuyListCommandTests
{
    [TestClass]
    public class CreateBuyListCommandTests
    {
        private readonly CreateBuyListCommand _validCommand;

        public CreateBuyListCommandTests()
        {
            _validCommand = new CreateBuyListCommand("Lista de compras da tarde", DateTime.Now, "7c9e6679-7425-40de-944b-e07fc1f90ae7");
            this._validCommand.Validate();
        }

        [TestMethod]
        public void Valid_command()
        {
            Assert.AreEqual(this._validCommand.Valid, true);
        }
    }
}