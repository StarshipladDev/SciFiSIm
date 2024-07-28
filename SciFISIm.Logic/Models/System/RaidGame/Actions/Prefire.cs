using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SciFiSim.Logic.Models.System.RaidGame.Core;

namespace SciFiSim.Logic.Models.System.RaidGame.Actions
{
    public class Prefire : SciFiSim.Logic.Models.System.RaidGame.Core.Action
    {
        public Prefire(Actor? owningActor) {
            this.factionType = FactionType.Redfor;
            this.actionTitle = "PreFires!";
        }
        public override void PreformAction(RaidGameInstance instance, Actor? targetedActor)
        {
            if(owningActor != null && owningActor.currentLocation != null)
            {
                List<Actor> relevantActors = instance.actors.Where(actor =>
                {
                    return (
                    actor.currentLocation != null && 
                    actor.currentLocation == owningActor.currentLocation && 
                    actor.isAlive
                    );
                })
                .ToList();
                if (relevantActors.Count > 0
                )
                {
                    Random rand = new Random();
                    relevantActors[rand.Next(relevantActors.Count)].ChangeHealth( -1 );
                }
            }
        }

    }
}
