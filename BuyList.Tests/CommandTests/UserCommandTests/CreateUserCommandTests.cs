using BuyList.Domain.Commands.UserCommands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuyList.Tests.CommandTests.UserCommandTests
{
    [TestClass]
    public class CreateUserCommandTests
    {
        private readonly CreateUserCommand _invalidCommand = new CreateUserCommand("", "", "");
        private readonly CreateUserCommand _validCommand = new CreateUserCommand("Jean Fernandes", "jeanfernandes10@hotmail.com", "123456");

        public CreateUserCommandTests()
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