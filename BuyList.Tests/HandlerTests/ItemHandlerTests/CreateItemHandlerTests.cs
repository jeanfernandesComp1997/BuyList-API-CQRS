using System.Threading.Tasks;
using BuyList.Domain.Commands.ItemCommands;
using BuyList.Domain.Commands.Responses;
using BuyList.Domain.Handlers;
using BuyList.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuyList.Tests.HandlerTests.ItemHandlerTests
{
    [TestClass]
    public class CreateItemHandlerTests
    {
        private readonly CreateItemCommand _validCommand = new CreateItemCommand("Pão francês", 10, "un", (decimal)0.25, "Padaria", "7c9e6679-7425-40de-944b-e07fc1f90ae7");
        private readonly ItemHandler _handler = new ItemHandler(new FakeItemRepository(), new FakeUserRepository());
        private GenericCommandResult _result = new GenericCommandResult();

        [TestMethod]
        public async Task Valid_command_create_item()
        {
            _result = (GenericCommandResult)await _handler.Handle(_validCommand);
            Assert.AreEqual(_result.Success, true);
        }
    }
}