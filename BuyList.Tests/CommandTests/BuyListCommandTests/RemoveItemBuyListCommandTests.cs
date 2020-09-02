using BuyList.Domain.Commands.BuyListCommands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BuyList.Tests.CommandTests.BuyListCommandTests
{
    [TestClass]
    public class RemoveItemBuyListCommandTests
    {
        private readonly RemoveItemBuyListCommand _validCommand = new RemoveItemBuyListCommand(new Guid("08d8487e-e4e0-4811-82c3-0ae7064e67dd"), new Guid("08d8487f-4387-472f-842a-e3781b550a58"), new Guid("08d84886-c9fa-403f-83e9-2e97ce6d852b"));

        public RemoveItemBuyListCommandTests()
        {
            _validCommand.Validate();
        }

        [TestMethod]
        public void Valid_command()
        {
            Assert.AreEqual(_validCommand.Valid, true);
        }
    }
}
