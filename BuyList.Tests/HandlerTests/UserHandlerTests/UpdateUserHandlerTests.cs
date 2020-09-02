using BuyList.Domain.Commands.Responses;
using BuyList.Domain.Commands.UserCommands;
using BuyList.Domain.Handlers;
using BuyList.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace BuyList.Tests.HandlerTests.UserHandlerTests
{
    [TestClass]
    public class UpdateUserHandlerTests
    {
        private readonly UpdateUserCommand _invalidCommand = new UpdateUserCommand(new Guid(), "");
        private readonly UpdateUserCommand _validCommand = new UpdateUserCommand(new Guid("08d8487e-e4e0-4811-82c3-0ae7064e67dd"), "Jean Fernandes");

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
