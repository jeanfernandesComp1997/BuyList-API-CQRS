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
    public class UpdateItemHandlerTests
    {
        private readonly UpdateItemCommand _validCommand = new UpdateItemCommand(new Guid(), "Pão francês", 10, "un", (decimal)0.25, "Padaria");
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
