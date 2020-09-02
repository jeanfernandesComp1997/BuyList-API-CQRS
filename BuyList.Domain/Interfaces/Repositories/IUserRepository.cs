using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BuyList.Domain.Dtos;
using BuyList.Domain.Entities;

namespace BuyList.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task Create(User user);
        Task<IEnumerable<UserDTO>> Get();
        Task<User> GetById(Guid id);
        Task<User> GetByEmail(string email);
        Task Update(User user);
        Task<User> GetByEmailAndPassword(string email, string password);
    }
}