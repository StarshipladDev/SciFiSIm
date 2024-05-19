using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Logic.Models.Entities.Overlay.Explosion
{
    public class Explosion:Overlaybase
    {
        public Explosion() {
            this.isAnimated = true;
            this.frameTotal = 7;
            this.currentFrame = 1;
            this.type = "Explosion";
        }
    }
}
