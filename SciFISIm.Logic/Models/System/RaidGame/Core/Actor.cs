using SciFiSim.Logic.Models.System.RaidGame.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Logic.Models.System.RaidGame.Core
{
    public class Actor
    {
        public List<Behaviour> behaviours;
        public bool isAlive;
        public ActorDetails details;
        public Place currentLocation;
        public Actor(ActorDetails details)
        {
            this.behaviours = new List<Behaviour>();
            this.isAlive = true;
            this.details = details;
        }

        public void ChangeHealth( int healthChange)
        {
            this.details.health += healthChange;
            if(this.details.health < 0)
            {
                this.isAlive=false;
            }
        }
        public void ChangeLocation(Place newLocation)
        {
            if(this.currentLocation != null)
            {
                this.currentLocation.actorsInPlace.Remove(this);
            }
            this.currentLocation = newLocation;
            newLocation.actorsInPlace.Add(this);
        }
    }
}
