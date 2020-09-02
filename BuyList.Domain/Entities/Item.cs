using BuyList.Domain.Commands.ItemCommands;
using BuyList.Domain.Entities.Base;
using System.Collections.Generic;

namespace BuyList.Domain.Entities
{
    public class Item : Entity
    {
        public string Name { get; private set; }
        public int Quantity { get; private set; }
        public string TypeOfMeasure { get; private set; }
        public decimal Value { get; private set; }
        public string Category { get; private set; }
        public User Owner { get; private set; }
        public IList<ListBuyItem> ListBuys { get; set; }

        public Item() { }

        public Item(string name, int quantity, string typeOfMeasure, decimal value, string category, User owner)
        {
            Name = name;
            Quantity = quantity;
            TypeOfMeasure = typeOfMeasure;
            Value = value;
            Category = category;
            Owner = owner;
        }

        public void UpdateItem(string name, int quantity, string typeOfMeasure, decimal value, string category)
        {
            Name = name;
            Quantity = quantity;
            TypeOfMeasure = typeOfMeasure;
            Value = value;
            Category = category;
        }
    }
}