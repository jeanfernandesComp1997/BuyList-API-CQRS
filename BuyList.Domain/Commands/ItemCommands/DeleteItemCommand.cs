using BuyList.Domain.Interfaces.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace BuyList.Domain.Commands.ItemCommands
{
    public class DeleteItemCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }

        public DeleteItemCommand() { }

        public DeleteItemCommand(Guid id)
        {
            Id = id;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNull(Id, "Id", "O id do item não pode ser nulo!")
            );
        }
    }
}
