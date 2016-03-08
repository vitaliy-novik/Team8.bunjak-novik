using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public abstract class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
    }
}
