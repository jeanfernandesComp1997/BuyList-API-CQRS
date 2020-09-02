using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BuyList.Domain.Dtos;
using BuyList.Domain.Entities;
using BuyList.Domain.Interfaces.Repositories;

namespace BuyList.Tests.Repositories
{
    public class FakeItemRepository : IItemRepository
    {
        public Task Create(Item user)
        {
            return Task.FromResult(0);
        }

        public Task Delete(Item item)
        {
            return Task.FromResult(0);
        }

        public Task<IEnumerable<ItemDTO>> Get(Guid ownerId)
        {
            return null;
        }

        public async Task<Item> GetById(Guid id)
        {
            var owner = new User("Jean Fernandes", "jeanfernandes10@hotmail.com", "123456");
            return await Task.FromResult(new Item("Leite em pó", 5, "un", (decimal)2.50, "Padaria", owner));
        }

        public Task Update(Item item)
        {
            return Task.FromResult(0);
        }
    }
}