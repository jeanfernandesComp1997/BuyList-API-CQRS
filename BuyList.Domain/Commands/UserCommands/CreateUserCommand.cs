using System.Collections.Generic;
using BuyList.Domain.Entities;
using BuyList.Domain.Interfaces.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace BuyList.Domain.Commands.UserCommands
{
    public class CreateUserCommand : Notifiable, ICommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IEnumerable<ListBuy> BuyLists { get; set; }

        public CreateUserCommand() { }

        public CreateUserCommand(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMinLen(Name, 2, "Nome", "Por favor insira um nome com pelo menos 2 caracteres!")
                .HasMaxLen(Name, 40, "Nome", "O nome não pode conter mais de 40 caracteres!")
                .IsEmail(Email, "Email", "Por favor insira um email válido!")
                .HasMinLen(Password, 6, "Senha", "Por favor insira uma senha com pelo menos 6 caracteres!")
            );
        }
    }
}