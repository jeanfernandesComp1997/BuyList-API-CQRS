using System;
using System.Collections.Generic;

namespace BuyList.Domain.Dtos
{
    public class ListBuyDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalValue { get; set; }
        public IList<ItemDTO> Items { get; set; }
    }
}
