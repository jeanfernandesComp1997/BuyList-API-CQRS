using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BuyList.Domain.Dtos;
using BuyList.Domain.Entities;

namespace BuyList.Domain.Interfaces.Repositories
{
    public interface IItemRepository
    {
        Task Create(Item item);
        Task Update(Item item);
        Task Delete(Item item);
        Task<IEnumerable<ItemDTO>> Get(Guid ownerId);
        Task<Item> GetById(Guid id);
    }
}