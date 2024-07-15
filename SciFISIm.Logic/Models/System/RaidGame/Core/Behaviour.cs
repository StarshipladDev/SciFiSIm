using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Logic.Models.System.RaidGame.Core
{
    public abstract class Behaviour
    {
        public List<Action> actionList = new List<Action>();
        public void AddAction(Core.Action action)
        {
            this.actionList.Add(action);
        }
    }
}
