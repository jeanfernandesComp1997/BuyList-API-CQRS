using BuyList.Domain.Interfaces.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace BuyList.Domain.Commands.BuyListCommands
{
    public class RemoveItemBuyListCommand : Notifiable, ICommand
    {
        public Guid OwnerId { get; set; }
        public Guid ItemId { get; set; }
        public Guid BuyListId { get; set; }

        public RemoveItemBuyListCommand() { }

        public RemoveItemBuyListCommand(Guid ownerId, Guid itemId, Guid buyListId)
        {
            OwnerId = ownerId;
            ItemId = itemId;
            BuyListId = buyListId;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotEmpty(OwnerId, "OwnerId", "O usuário não pode ser vazio!")
                .IsNotEmpty(ItemId, "ItemId", "O item não pode ser vazio!")
                .IsNotEmpty(BuyListId, "BuyListId", "A lista não pode ser vazia!")
            );
        }
    }
}
