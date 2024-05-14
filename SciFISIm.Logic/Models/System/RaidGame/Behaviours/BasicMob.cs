using SciFiSim.Logic.Models.System.RaidGame.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Logic.Models.System.RaidGame.Behaviours
{
    public class BasicMob : Behaviour
    {
        public BasicMob()
        {
            this.actionList = new Core.Action[] { };
        }
    }
}
