using System;

namespace BuyList.Domain.Entities.Base
{
    public abstract class Entity
    {
        public Guid Id { get; private set; }

        public Entity()
        {
            Id = new Guid();
        }
    }
}