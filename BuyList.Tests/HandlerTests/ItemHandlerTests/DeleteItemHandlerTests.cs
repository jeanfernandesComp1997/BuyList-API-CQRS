using BuyList.Domain.Commands.ItemCommands;
using BuyList.Domain.Commands.Responses;
using BuyList.Domain.Handlers;
using BuyList.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace BuyList.Tests.HandlerTests.ItemHandlerTests
{
    [TestClass]
    public class DeleteItemHandlerTests
    {
        private readonly DeleteItemCommand _validCommand = new DeleteItemCommand(new Guid());
        private readonly ItemHandler _handler = new ItemHandler(new FakeItemRepository(), new FakeUserRepository());
        private GenericCommandResult _result = new GenericCommandResult();

        [TestMethod]
        public async Task Valid_command_update_item()
        {
            _result = (GenericCommandResult)await _handler.Handle(_validCommand);
            Assert.AreEqual(_result.Success, true);
        }
    }
}
