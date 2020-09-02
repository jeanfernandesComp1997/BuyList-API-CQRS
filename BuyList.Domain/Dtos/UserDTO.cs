using System;
using System.Collections.Generic;

namespace BuyList.Domain.Dtos
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IEnumerable<ListBuyDTO> BuyLists { get; set; }
        public IEnumerable<ItemDTO> Items { get; set; }
    }
}
