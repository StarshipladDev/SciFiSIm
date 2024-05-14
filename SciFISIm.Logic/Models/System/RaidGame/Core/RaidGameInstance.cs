using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Logic.Models.System.RaidGame.Core
{
    public class RaidGameInstance
    {
        List<Place> places;
        List<Actor> actors;
        public RaidGameInstance()
        {
            this.places = new List<Place>();
            this.actors = new List<Actor>();


        }

        public string UpdateInstance(Action action)
        {
            string replytext = "";
            foreach (Actor actor in actors)
            {
                replytext += $"In response to your " + action.actionTitle + " an actor " + actor.behaviours[0].actionList[0].actionTitle+"\n";
            }
            return replytext;
        }
    }
}
