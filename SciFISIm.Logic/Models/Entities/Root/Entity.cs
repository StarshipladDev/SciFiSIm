using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFISIm.Logic.Models.Entities.Root
{
    public class Entity
    {
        public int entityId { get; }

        public Entity(int entityID)
        {
            this.entityId = entityID;
        }
    }
}
