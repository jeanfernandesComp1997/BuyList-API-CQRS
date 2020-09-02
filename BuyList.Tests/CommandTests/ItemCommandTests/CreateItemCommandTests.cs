using BuyList.Domain.Commands.ItemCommands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuyList.Tests.CommandTests.ItemCommandTests
{
    [TestClass]
    public class CreateItemCommandTests
    {
        private readonly CreateItemCommand _validCommand = new CreateItemCommand("Pão francês", 10, "un", (decimal)0.25, "Padaria", "123456789");
        private readonly CreateItemCommand _invalidCommand = new CreateItemCommand("Pão francês", 10, "un", (decimal)0.25, "", "123456789");

        public CreateItemCommandTests()
        {
            this._validCommand.Validate();
            this._invalidCommand.Validate();
        }

        [TestMethod]
        public void Valid_command()
        {
            Assert.AreEqual(this._validCommand.Valid, true);
        }

        [TestMethod]
        public void Invalid_command()
        {
            Assert.AreEqual(this._invalidCommand.Valid, false);
        }
    }
}