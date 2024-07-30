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
        public string actorName;
        public ActorDetails(int health, FactionType factionType, string actorName)
        {
            this.health = health;
            this.factionType = factionType;
            this.actorName = actorName;
        }
    }
}
