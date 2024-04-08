using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using SciFiSim.Logic.Models.Entities.Building;
using SciFiSim.Logic.Models.System.Places;

namespace SciFiSim.Logic.Models.Entities.Root
{
    public class BuildingEntity : Entity
    {
        public Building.Building building;
        public BuildingBehaviour behaviour;
        public BuildingEntity(Guid entityId,BuildingBehaviour behaviour) : base(entityId)
        {
            this.building = new Building.Building();
            this.behaviour = behaviour;
        }
    }
}
