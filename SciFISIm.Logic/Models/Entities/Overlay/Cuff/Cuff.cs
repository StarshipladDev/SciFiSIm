using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Logic.Models.Entities.Overlay.Cuff
{
    public class Cuff : Overlaybase
    {
        public Cuff() {

            this.isAnimated = true;
            this.frameTotal = 6;
            this.currentFrame = 1;
            this.type = "Cuff";
            this.endAnimationOnEnd = false;
        }
    }
}
