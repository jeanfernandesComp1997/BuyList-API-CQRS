using BuyList.Domain.Interfaces.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace BuyList.Domain.Commands.BuyListCommands
{
    public class UpdateBuyListCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public UpdateBuyListCommand() { }

        public UpdateBuyListCommand(Guid id, string name, DateTime date)
        {
            Id = id;
            Name = name;
            Date = date;
        }


        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMinLen(Name, 2, "Nome", "Por favor insira o nome da lista com pelo menos 2 caracteres!")
                .HasMaxLen(Name, 40, "Nome", "O nome da lista não pode conter mais de 40 caracteres!")
            );
        }
    }
}
