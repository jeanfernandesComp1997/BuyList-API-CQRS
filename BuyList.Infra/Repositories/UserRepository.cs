using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuyList.Domain.Dtos;
using BuyList.Domain.Entities;
using BuyList.Domain.Interfaces.Repositories;
using BuyList.Infra.Contexts;
using Dapper;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace BuyList.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public async Task Create(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserDTO>> Get()
        {
            IEnumerable<UserDTO> user = new List<UserDTO>();

            using (MySqlConnection connection = new MySqlConnection(_context.GetConnStr()))
            {
                user = connection.QueryAsync<UserDTO>($"SELECT * FROM User").Result.ToList();
            }

            return await Task.FromResult(user);
        }

        public async Task<User> GetByEmail(string email)
        {
            User user = null;

            using (MySqlConnection connection = new MySqlConnection(_context.GetConnStr()))
            {
                user = connection.QueryFirstOrDefaultAsync<User>($"SELECT * FROM User WHERE User.Email = '{email}'").Result;
            }

            return await Task.FromResult(user);
        }

        public async Task<User> GetByEmailAndPassword(string email, string password)
        {
            var result = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

            return result;
        }

        public async Task<User> GetById(Guid id)
        {
            var result = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == id);

            return result;
        }

        public async Task Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}