using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BuyList.Domain.Dtos;
using BuyList.Domain.Entities;
using BuyList.Domain.Interfaces.Repositories;

namespace BuyList.Tests.Repositories
{
    public class FakeUserRepository : IUserRepository
    {
        public Task Create(User user)
        {
            return Task.FromResult(0);
        }

        public Task<IEnumerable<UserDTO>> Get()
        {
            return null;
        }

        public Task<User> GetByEmail(string email)
        {
            return Task.FromResult<User>(null);
        }

        public Task<User> GetByEmailAndPassword(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(Guid id)
        {
            return Task.FromResult(new User("Jean Fernandes", "jeanfernandes10@hotmail.com", "123456"));
        }

        public Task Update(User user)
        {
            return Task.FromResult(0);
        }
    }
}