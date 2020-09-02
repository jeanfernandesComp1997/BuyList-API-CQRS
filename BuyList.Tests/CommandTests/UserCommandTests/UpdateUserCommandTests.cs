using BuyList.Domain.Commands.UserCommands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BuyList.Tests.CommandTests.UserCommandTests
{
    [TestClass]
    public class UpdateUserCommandTests
    {
        private readonly UpdateUserCommand _invalidCommand = new UpdateUserCommand(new Guid(), "");
        private readonly UpdateUserCommand _validCommand = new UpdateUserCommand(new Guid("08d8487e-e4e0-4811-82c3-0ae7064e67dd"), "Jean Fernandes");

        public UpdateUserCommandTests()
        {
            _invalidCommand.Validate();
            _validCommand.Validate();
        }

        [TestMethod]
        public void Invalid_command()
        {
            Assert.AreEqual(this._invalidCommand.Valid, false);
        }

        [TestMethod]
        public void Valid_command()
        {
            Assert.AreEqual(this._validCommand.Valid, true);
        }
    }
}
