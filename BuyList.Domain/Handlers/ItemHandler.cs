using System;
using System.Threading.Tasks;
using BuyList.Domain.Commands.ItemCommands;
using BuyList.Domain.Commands.Responses;
using BuyList.Domain.Entities;
using BuyList.Domain.Interfaces.Commands;
using BuyList.Domain.Interfaces.Handlers;
using BuyList.Domain.Interfaces.Repositories;
using Flunt.Notifications;

namespace BuyList.Domain.Handlers
{
    public class ItemHandler : Notifiable, IHandler<CreateItemCommand>, IHandler<UpdateItemCommand>, IHandler<DeleteItemCommand>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IUserRepository _userRepository;
        public ItemHandler(IItemRepository itemRepository, IUserRepository userRepository)
        {
            _itemRepository = itemRepository;
            _userRepository = userRepository;
        }

        public async Task<IResponse> Handle(CreateItemCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados do item inválidos", command.Notifications);

            var user = await _userRepository.GetById(new Guid(command.OwnerId));
            if (user == null)
                return new GenericCommandResult(false, "Usuário inválido", user);

            var item = new Item(command.Name, command.Quantity, command.TypeOfMeasure, command.Value, command.Category, user);
            await _itemRepository.Create(item);

            return new GenericCommandResult(true, "Ok", item);
        }

        public async Task<IResponse> Handle(UpdateItemCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados do item inválidos", command.Notifications);

            var item = await _itemRepository.GetById(command.Id);

            if (item == null)
                return new GenericCommandResult(false, "Item inválido", item);

            item.UpdateItem(command.Name, command.Quantity, command.TypeOfMeasure, command.Value, command.Category);

            await _itemRepository.Update(item);

            return new GenericCommandResult(true, "Ok", item);
        }

        public async Task<IResponse> Handle(DeleteItemCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados do item inválidos", command.Notifications);

            var item = await _itemRepository.GetById(command.Id);

            if (item == null)
                return new GenericCommandResult(false, "Item inválido", item);

            await _itemRepository.Delete(item);

            return new GenericCommandResult(true, "Ok", item);
        }
    }
}