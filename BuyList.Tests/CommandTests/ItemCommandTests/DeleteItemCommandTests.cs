using BuyList.Domain.Commands.ItemCommands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BuyList.Tests.CommandTests.ItemCommandTests
{
    [TestClass]
    public class DeleteItemCommandTests
    {
        private readonly DeleteItemCommand _validCommand = new DeleteItemCommand(new Guid());

        public DeleteItemCommandTests()
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
