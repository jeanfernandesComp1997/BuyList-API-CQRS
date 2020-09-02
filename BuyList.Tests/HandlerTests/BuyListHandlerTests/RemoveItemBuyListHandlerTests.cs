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
    public class RemoveItemBuyListHandlerTests
    {
        private readonly RemoveItemBuyListCommand _validCommand;
        private readonly BuyListHandler _handler = new BuyListHandler(new FakeBuyListRepository(), new FakeUserRepository(), new FakeItemRepository());
        private GenericCommandResult _result = new GenericCommandResult();

        public RemoveItemBuyListHandlerTests()
        {
            _validCommand = new RemoveItemBuyListCommand(new Guid("08d8487e-e4e0-4811-82c3-0ae7064e67dd"), new Guid("08d8487f-4387-472f-842a-e3781b550a58"), new Guid("08d84886-c9fa-403f-83e9-2e97ce6d852b"));
        }

        [TestMethod]
        public async Task Valid_remove_item_buylist()
        {
            _result = (GenericCommandResult)await _handler.Handle(_validCommand);
            Assert.AreEqual(_result.Success, true);
        }
    }
}
