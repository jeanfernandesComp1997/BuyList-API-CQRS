using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BuyList.Domain.Dtos;
using BuyList.Domain.Entities;
using BuyList.Domain.Interfaces.Repositories;

namespace BuyList.Tests.Repositories
{
    public class FakeBuyListRepository : IBuyListRepository
    {
        public Task Create(ListBuy buyList)
        {
            return Task.FromResult(0);
        }

        Task<IEnumerable<ListBuyDTO>> IBuyListRepository.Get(Guid ownerId)
        {
            return null;
        }

        public async Task<ListBuy> GetById(Guid id)
        {
            var owner = new User("Jean Fernandes", "jeanfernandes10@hotmail.com", "123456");
            return await Task.FromResult(new ListBuy("Lista", DateTime.Now, owner));
        }

        public Task AddItem(ListBuyItem listBuyItem)
        {
            return Task.FromResult(0);
        }

        public Task Update(ListBuy buyList)
        {
            return Task.FromResult(0);
        }

        public Task RemoveItem(Guid itemId, Guid listBuyId)
        {
            return Task.FromResult(0);
        }

        public Task Delete(ListBuy buyList)
        {
            return Task.FromResult(0);
        }
    }
}