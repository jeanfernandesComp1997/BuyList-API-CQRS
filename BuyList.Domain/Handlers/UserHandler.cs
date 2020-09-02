using System.Threading.Tasks;
using BuyList.Domain.Commands.Responses;
using BuyList.Domain.Commands.UserCommands;
using BuyList.Domain.Entities;
using BuyList.Domain.Interfaces.Commands;
using BuyList.Domain.Interfaces.Handlers;
using BuyList.Domain.Interfaces.Repositories;
using Flunt.Notifications;

namespace BuyList.Domain.Handlers
{
    public class UserHandler : Notifiable, IHandler<CreateUserCommand>, IHandler<UpdateUserCommand>, IHandler<LoginUserCommand>
    {
        private readonly IUserRepository _userRepository;
        public UserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IResponse> Handle(CreateUserCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados de usuário inválidos", command.Notifications);

            var existUser = await _userRepository.GetByEmail(command.Email);

            if (existUser != null)
                return new GenericCommandResult(false, "Já existe um usuário com este e-mail!", null);

            var user = new User(command.Name, command.Email, command.Password);

            await _userRepository.Create(user);

            return new GenericCommandResult(true, "Ok", user);
        }

        public async Task<IResponse> Handle(UpdateUserCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados de usuário inválidos", command.Notifications);

            var user = await _userRepository.GetById(command.Id);

            if (user == null)
                return new GenericCommandResult(false, "Usuário inválido!", null);

            user.UpdateName(command.Name);

            await _userRepository.Update(user);

            return new GenericCommandResult(true, "Ok", user);
        }

        public async Task<IResponse> Handle(LoginUserCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados de login inválidos!", command.Notifications);

            var user = await _userRepository.GetByEmailAndPassword(command.Email, command.Password);

            if (user == null)
                return new GenericCommandResult(false, "E-mail ou senha inválidos!", null);

            return new GenericCommandResult(true, "Ok", user);
        }
    }
}