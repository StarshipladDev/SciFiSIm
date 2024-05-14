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
        public Actor()
        {
            this.behaviours = null;
        }
    }
}
