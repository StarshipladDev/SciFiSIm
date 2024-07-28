using SciFiSim.Logic.Models.System.RaidGame.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Logic.Models.System.RaidGame.Actors
{
    public class ActorDetails
    {
        public int health;
        public FactionType factionType;
        public ActorDetails(int health, FactionType factionType)
        {
            this.health = health;
            this.factionType = factionType;
        }
    }
}
