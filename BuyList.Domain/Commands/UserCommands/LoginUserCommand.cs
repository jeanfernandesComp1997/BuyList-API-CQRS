using BuyList.Domain.Interfaces.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace BuyList.Domain.Commands.UserCommands
{
    public class LoginUserCommand : Notifiable, ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginUserCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNullOrEmpty(Email, "E-mail", "Email não pode ser vazio!")
                .IsNotNullOrEmpty(Password, "Senha", "Senha não pode ser vazia!")
            );
        }
    }
}
