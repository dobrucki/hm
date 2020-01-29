using System;

namespace Entities
{
    public abstract class EntityBase : IEntityBase<Guid>
    {
        public Guid Id { get; set; }
    }
}