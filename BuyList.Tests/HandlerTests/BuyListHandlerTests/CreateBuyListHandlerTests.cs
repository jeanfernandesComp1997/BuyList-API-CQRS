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
    public class CreateBuyListHandlerTests
    {
        private readonly CreateBuyListCommand _validCommand;
        private readonly BuyListHandler _handler = new BuyListHandler(new FakeBuyListRepository(), new FakeUserRepository(), new FakeItemRepository());
        private GenericCommandResult _result = new GenericCommandResult();

        public CreateBuyListHandlerTests()
        {
            _validCommand = new CreateBuyListCommand("Lista de compras da tarde", DateTime.Now, "7c9e6679-7425-40de-944b-e07fc1f90ae7");
        }

        [TestMethod]
        public async Task Valid_command_create_buylist()
        {
            _result = (GenericCommandResult)await _handler.Handle(_validCommand);
            Assert.AreEqual(_result.Success, true);
        }
    }
}