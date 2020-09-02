using BuyList.Domain.Interfaces.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace BuyList.Domain.Commands.UserCommands
{
    public class UpdateUserCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public UpdateUserCommand() { }

        public UpdateUserCommand(Guid id, string name) 
        {
            Id = id;
            Name = name;
        }

        public void Validate()
        {
            AddNotifications(
               new Contract()
               .Requires()
               .HasMinLen(Name, 2, "Nome", "Por favor insira um nome com pelo menos 2 caracteres!")
               .HasMaxLen(Name, 40, "Nome", "O nome não pode conter mais de 40 caracteres!")
               .IsNotEmpty(Id, "Id", "O id do usuário é obrigatório!")
           );
        }
    }
}
