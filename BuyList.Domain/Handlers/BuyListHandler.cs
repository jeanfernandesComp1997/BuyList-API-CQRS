using BuyList.Domain.Commands.BuyListCommands;
using BuyList.Domain.Commands.Responses;
using BuyList.Domain.Entities;
using BuyList.Domain.Interfaces.Commands;
using BuyList.Domain.Interfaces.Handlers;
using BuyList.Domain.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace BuyList.Domain.Handlers
{
    public class BuyListHandler : IHandler<CreateBuyListCommand>, IHandler<AddItemBuyListCommand>, IHandler<UpdateBuyListCommand>, IHandler<RemoveItemBuyListCommand>, IHandler<DeleteBuyListCommand>
    {
        private readonly IBuyListRepository _buyListRepository;
        private readonly IUserRepository _userRepository;
        private readonly IItemRepository _itemRepository;

        public BuyListHandler(IBuyListRepository buyListRepository, IUserRepository userRepository, IItemRepository itemRepository)
        {
            _buyListRepository = buyListRepository;
            _userRepository = userRepository;
            _itemRepository = itemRepository;
        }

        public async Task<IResponse> Handle(CreateBuyListCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados da lista inválidos", command.Notifications);

            var user = await _userRepository.GetById(new Guid(command.OwnerId));
            if (user == null)
                return new GenericCommandResult(false, "Usuário inválido", user);

            var buyList = new ListBuy(command.Name, command.Date, user);

            await _buyListRepository.Create(buyList);

            return new GenericCommandResult(true, "Ok", buyList);
        }

        public async Task<IResponse> Handle(AddItemBuyListCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);

            var user = await _userRepository.GetById(command.OwnerId);
            if (user == null)
                return new GenericCommandResult(false, "Usuário inválido", user);

            var item = await _itemRepository.GetById(command.ItemId);
            if (item == null)
                return new GenericCommandResult(false, "Item inválido", item);

            var list = await _buyListRepository.GetById(command.BuyListId);
            if (list == null)
                return new GenericCommandResult(false, "Lista inválida", list);

            if (list.Owner.Id != user.Id && item.Owner.Id != user.Id)
                return new GenericCommandResult(false, "Item e lista não pertencem ao usuário especificado!", null);

            list.SumTotalValue(item);

            var listBuyIitem = new ListBuyItem
            {
                Item = item,
                ListBuy = list
            };

            await _buyListRepository.AddItem(listBuyIitem);

            return new GenericCommandResult(true, "Ok", listBuyIitem);
        }

        public async Task<IResponse> Handle(UpdateBuyListCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados da lista inválidos", command.Notifications);

            var buyList = await _buyListRepository.GetById(command.Id);

            if (buyList == null)
                return new GenericCommandResult(false, "Lista inválida", buyList);

            buyList.UpdateBuyList(command.Name, command.Date);

            await _buyListRepository.Update(buyList);

            return new GenericCommandResult(true, "Ok", buyList);
        }

        public async Task<IResponse> Handle(RemoveItemBuyListCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados inválidos", command.Notifications);

            var user = await _userRepository.GetById(command.OwnerId);
            if (user == null)
                return new GenericCommandResult(false, "Usuário inválido", user);

            var item = await _itemRepository.GetById(command.ItemId);
            if (item == null)
                return new GenericCommandResult(false, "Item inválido", item);

            var list = await _buyListRepository.GetById(command.BuyListId);
            if (list == null)
                return new GenericCommandResult(false, "Lista inválida", list);

            if (list.Owner.Id != user.Id && item.Owner.Id != user.Id)
                return new GenericCommandResult(false, "Item e lista não pertencem ao usuário especificado!", null);

            list.SubTotalValue(item);

            await _buyListRepository.RemoveItem(command.ItemId, command.BuyListId);

            return new GenericCommandResult(true, "Ok", null);
        }

        public async Task<IResponse> Handle(DeleteBuyListCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new GenericCommandResult(false, "Dados da lista inválidos!", command.Notifications);

            var list = await _buyListRepository.GetById(command.Id);

            if (list == null)
                return new GenericCommandResult(false, "Lista inválida!", list);

            await _buyListRepository.Delete(list);

            return new GenericCommandResult(true, "Ok", list);
        }
    }
}