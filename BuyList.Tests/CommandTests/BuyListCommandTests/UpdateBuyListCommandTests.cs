using BuyList.Domain.Commands.BuyListCommands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BuyList.Tests.CommandTests.BuyListCommandTests
{
    [TestClass]
    public class UpdateBuyListCommandTests
    {
        private readonly UpdateBuyListCommand _validCommand;

        public UpdateBuyListCommandTests()
        {
            _validCommand = new UpdateBuyListCommand(new Guid(), "Lista de compras da tarde", DateTime.Now);
            this._validCommand.Validate();
        }

        [TestMethod]
        public void Valid_command()
        {
            Assert.AreEqual(this._validCommand.Valid, true);
        }
    }
}
