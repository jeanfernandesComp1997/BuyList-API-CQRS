using BuyList.Domain.Commands.BuyListCommands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BuyList.Tests.CommandTests.BuyListCommandTests
{
    [TestClass]
    public class DeleteBuyListCommandTests
    {
        private readonly DeleteBuyListCommand _validCommand = new DeleteBuyListCommand(new Guid());

        public DeleteBuyListCommandTests()
        {
            this._validCommand.Validate();
        }

        [TestMethod]
        public void Valid_command()
        {
            Assert.AreEqual(this._validCommand.Valid, true);
        }
    }
}
