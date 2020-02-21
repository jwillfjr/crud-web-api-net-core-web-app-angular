using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleCRUD.Domain.Entities
{
    public abstract class EntityBase
    {
        public EntityBase()
        {
            Created = DateTime.Now;
        }
        private long id;
        public long Id { get => id; set => id = value; }
        public bool Actived { get; set; }
        public DateTime Created { get; set; }
    }
}
