using BuyList.Domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace BuyList.Domain.Entities
{
    public class ListBuy : Entity
    {
        public string Name { get; private set; }
        public DateTime Date { get; private set; }
        public decimal TotalValue { get; private set; }
        public User Owner { get; private set; }
        public IList<ListBuyItem> Items { get; set; }

        public ListBuy() { }

        public ListBuy(string name, DateTime date, User owner)
        {
            Name = name;
            Date = date;
            TotalValue = 0;
            Owner = owner;
        }

        public ListBuy(string name, DateTime date, decimal totalValue, User owner)
        {
            Name = name;
            Date = date;
            TotalValue = totalValue;
            Owner = owner;
        }

        public void UpdateBuyList(string name, DateTime date)
        {
            Name = name;
            Date = date;
        }

        public void SumTotalValue(Item item)
        {
            TotalValue += item.TypeOfMeasure == "un" ? item.Value * item.Quantity : item.Value;
        }

        public void SubTotalValue(Item item)
        {
            TotalValue -= item.TypeOfMeasure == "un" ? item.Value * item.Quantity : item.Value;
        }
    }
}