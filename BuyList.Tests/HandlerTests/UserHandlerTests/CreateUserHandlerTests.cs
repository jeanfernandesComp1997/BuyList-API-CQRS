using System.Threading.Tasks;
using BuyList.Domain.Commands.Responses;
using BuyList.Domain.Commands.UserCommands;
using BuyList.Domain.Handlers;
using BuyList.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuyList.Tests.HandlerTests.UserHandlerTests
{
    [TestClass]
    public class CreateUserHandlerTests
    {
        private readonly CreateUserCommand _invalidCommand = new CreateUserCommand("", "", "");
        private readonly CreateUserCommand _validCommand = new CreateUserCommand("Jean Fernandes", "jeanfernandes10@hotmail.com", "123456");

        private readonly UserHandler _handler = new UserHandler(new FakeUserRepository());
        private GenericCommandResult _result = new GenericCommandResult();

        [TestMethod]
        public async Task Invalid_command_break_execution()
        {
            _result = (GenericCommandResult)await _handler.Handle(_invalidCommand);
            Assert.AreEqual(_result.Success, false);
        }

        [TestMethod]
        public async Task Valid_command_create_user()
        {
            _result = (GenericCommandResult)await _handler.Handle(_validCommand);
            Assert.AreEqual(_result.Success, true);
        }
    }
}
