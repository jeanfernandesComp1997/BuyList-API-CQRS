using System.Collections.Generic;
using BuyList.Domain.Entities.Base;

namespace BuyList.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public IEnumerable<ListBuy> BuyLists { get; private set; }
        public IEnumerable<Item> Items { get; private set; }

        public User() { }

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }

        public void UpdateName(string name)
        {
            Name = name;
        }
    }
}