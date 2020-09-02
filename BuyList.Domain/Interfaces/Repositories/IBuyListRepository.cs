using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BuyList.Domain.Dtos;
using BuyList.Domain.Entities;

namespace BuyList.Domain.Interfaces.Repositories
{
    public interface IBuyListRepository
    {
        Task Create(ListBuy buyList);
        Task<IEnumerable<ListBuyDTO>> Get(Guid ownerId);
        Task<ListBuy> GetById(Guid id);
        Task AddItem(ListBuyItem listBuyItem);
        Task RemoveItem(Guid itemId, Guid listBuyId);
        Task Update(ListBuy buyList);
        Task Delete(ListBuy buyList);
    }
}