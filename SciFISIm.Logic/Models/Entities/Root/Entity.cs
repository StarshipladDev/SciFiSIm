using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Logic.Models.Entities.Root
{
    public class Entity
    {
        public Guid entityId { get; }

        public Entity(Guid entityID)
        {
            this.entityId = entityID;
        }
    }
}
