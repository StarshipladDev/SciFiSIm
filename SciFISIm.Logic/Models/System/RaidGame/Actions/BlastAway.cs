using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SciFiSim.Logic.Models.System.RaidGame.Core;

namespace SciFiSim.Logic.Models.System.RaidGame.Actions
{
    public class BlastAway : SciFiSim.Logic.Models.System.RaidGame.Core.Action
    {
        public BlastAway(Actor? owningActor) {
            this.factionType = FactionType.Blufor;
            this.actionTitle = "Blasts away!";
        }
        public override void PreformAction(RaidGameInstance instance, Actor? targetedActor)
        {
            List<Actor> relevantActors = instance.actors.Where(actor =>
            {
                return (actor == targetedActor && actor.isAlive);
            })
            .ToList();
            if (relevantActors.Count > 0
            )
            {
                relevantActors[0].isAlive = false;
            }
        }

    }
}
