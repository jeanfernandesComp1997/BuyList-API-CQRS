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
    public class ItemRepository : IItemRepository
    {
        private readonly DataContext _context;

        public ItemRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Create(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Item item)
        {
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ItemDTO>> Get(Guid ownerId)
        {
            IEnumerable<ItemDTO> items = new List<ItemDTO>();

            using (MySqlConnection connection = new MySqlConnection(_context.GetConnStr()))
            {
                items = connection.QueryAsync<ItemDTO>($"SELECT * FROM Item WHERE Item.OwnerId = '{ownerId}'").Result.ToList();
            }

            return await Task.FromResult(items);
        }

        public async Task<Item> GetById(Guid id)
        {
            var result = await _context.Items
                .FirstOrDefaultAsync(i => i.Id == id);

            return result;
        }

        public async Task Update(Item item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}