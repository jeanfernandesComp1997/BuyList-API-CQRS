using BuyList.Domain.Dtos;
using BuyList.Domain.Entities;
using BuyList.Domain.Interfaces.Repositories;
using BuyList.Infra.Contexts;
using Dapper;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyList.Infra.Repositories
{
    public class BuyListRepository : IBuyListRepository
    {
        private readonly DataContext _context;

        public BuyListRepository(DataContext context)
        {
            _context = context;
        }
        public async Task Create(ListBuy buyList)
        {
            _context.ListBuy.Add(buyList);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ListBuyDTO>> Get(Guid ownerId)
        {
            IEnumerable<ListBuyDTO> buyLists = new List<ListBuyDTO>();

            using (MySqlConnection connection = new MySqlConnection(_context.GetConnStr()))
            {
                var sql = $@"select b.Id, b.Name, b.Date, b.TotalValue, i.Id, i.Name, i.Quantity, i.TypeOfMeasure, i.Value, i.Category
                            from buylist.BuyList b
                            left join buylist.ListBuyItems lbi on lbi.ListBuyId = b.Id
                            left join buylist.Item i on i.Id = lbi.ItemId where b.OwnerId = '{ownerId}';";

                var lists = await connection.QueryAsync<ListBuyDTO, ItemDTO, ListBuyDTO>(sql, (list, item) =>
                {
                    if (list.Items == null)
                        list.Items = new List<ItemDTO>();

                    list.Items.Add(item);
                    return list;
                }, splitOn: "Id");

                var result = lists.GroupBy(l => l.Id).Select(g =>
                {
                    var groupedList = g.First();
                    groupedList.Items = g.Select(l => l.Items.Single()).ToList();
                    return groupedList;
                });

                buyLists = result;
            }

            return await Task.FromResult(buyLists);
        }

        public async Task<ListBuy> GetById(Guid id)
        {
            var result = await _context.ListBuy
                .FirstOrDefaultAsync(lb => lb.Id == id);

            return result;
        }

        public async Task AddItem(ListBuyItem listBuyItem)
        {
            _context.ListBuyItems.Add(listBuyItem);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveItem(Guid itemId, Guid listBuyId)
        {
            var listbuyItem = await _context.ListBuyItems.FirstAsync(row => row.ListBuyId == listBuyId && row.ItemId == itemId);
            _context.ListBuyItems.Remove(listbuyItem);
            await _context.SaveChangesAsync();
        }

        public async Task Update(ListBuy buyList)
        {
            _context.Entry(buyList).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(ListBuy buyList)
        {
            _context.ListBuy.Remove(buyList);
            await _context.SaveChangesAsync();
        }
    }
}