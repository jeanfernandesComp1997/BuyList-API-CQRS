using BuyList.Domain.Interfaces.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace BuyList.Domain.Commands.BuyListCommands
{
    public class CreateBuyListCommand : Notifiable, ICommand
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string OwnerId { get; set; }

        public CreateBuyListCommand() { }

        public CreateBuyListCommand(string name, DateTime date, string ownerId)
        {
            Name = name;
            Date = date;
            OwnerId = ownerId;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMinLen(Name, 2, "Nome", "Por favor insira o nome da lista com pelo menos 2 caracteres!")
                .HasMaxLen(Name, 40, "Nome", "O nome da lista não pode conter mais de 40 caracteres!")
                .IsNotNull(OwnerId, "Usuário", "O usuário não pode ser nulo!")
            );
        }
    }
}