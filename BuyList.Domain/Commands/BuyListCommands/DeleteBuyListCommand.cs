using BuyList.Domain.Interfaces.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace BuyList.Domain.Commands.BuyListCommands
{
    public class DeleteBuyListCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }

        public DeleteBuyListCommand() { }

        public DeleteBuyListCommand(Guid id)
        {
            Id = id;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNull(Id, "Id", "O id da lista não pode ser nulo!")
            );
        }
    }
}
