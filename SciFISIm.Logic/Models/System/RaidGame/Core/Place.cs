using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Logic.Models.System.RaidGame.Core
{
    public class Place
    {
        public List<Actor> actorsInPlace;
        public string placeName;

        public Place(string placeName)
        {
            actorsInPlace = new List<Actor>();
            this.placeName = placeName;
        }
    }
}
