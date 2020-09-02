using System;

namespace BuyList.Domain.Entities
{
    public class ListBuyItem
    {
        public Guid ItemId { get; set; }
        public Item Item { get; set; }

        public Guid ListBuyId { get; set; }
        public ListBuy ListBuy { get; set; }
    }
}
