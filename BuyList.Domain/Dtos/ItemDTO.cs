using System;

namespace BuyList.Domain.Dtos
{
    public class ItemDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string TypeOfMeasure { get; set; }
        public decimal Value { get; set; }
        public string Category { get; set; }
    }
}
