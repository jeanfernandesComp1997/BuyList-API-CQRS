using BuyList.Domain.Commands.ItemCommands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BuyList.Tests.CommandTests.ItemCommandTests
{
    [TestClass]
    public class UpdateItemCommandTests
    {
        private readonly UpdateItemCommand _validCommand = new UpdateItemCommand(new Guid(), "Pão francês", 10, "un", (decimal)0.25, "Padaria");
        private readonly UpdateItemCommand _invalidCommand = new UpdateItemCommand(new Guid(), "Pão francês", 10, "un", (decimal)0.25, "");

        public UpdateItemCommandTests()
        {
            this._validCommand.Validate();
            this._invalidCommand.Validate();
        }

        [TestMethod]
        public void Valid_command()
        {
            Assert.AreEqual(this._validCommand.Valid, true);
        }

        [TestMethod]
        public void Invalid_command()
        {
            Assert.AreEqual(this._invalidCommand.Valid, false);
        }
    }
}
