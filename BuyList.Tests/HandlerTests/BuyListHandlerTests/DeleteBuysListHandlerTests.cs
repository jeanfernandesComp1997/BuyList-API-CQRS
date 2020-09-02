using BuyList.Domain.Commands.BuyListCommands;
using BuyList.Domain.Commands.Responses;
using BuyList.Domain.Handlers;
using BuyList.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace BuyList.Tests.HandlerTests.BuyListHandlerTests
{
    [TestClass]
    public class DeleteBuysListHandlerTests
    {
        private readonly DeleteBuyListCommand _validCommand = new DeleteBuyListCommand(new Guid());
        private readonly BuyListHandler _handler = new BuyListHandler(new FakeBuyListRepository(), new FakeUserRepository(), new FakeItemRepository());
        private GenericCommandResult _result = new GenericCommandResult();

        [TestMethod]
        public async Task Valid_command_delete_buylist()
        {
            _result = (GenericCommandResult)await _handler.Handle(_validCommand);
            Assert.AreEqual(_result.Success, true);
        }
    }
}
