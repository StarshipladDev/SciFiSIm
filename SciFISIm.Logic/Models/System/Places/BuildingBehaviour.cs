using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Logic.Models.System.Places
{
    public class BuildingBehaviour
    {
        public bool isStore;
        public int xLoc;
        public int yLoc;
        public BuildingBehaviour(bool isStore, int xLoc, int yLoc)
        {
            this.isStore = isStore;
            this.xLoc = xLoc;
            this.yLoc = yLoc;
        }
    }
}
