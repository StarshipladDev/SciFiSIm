using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Logic.Models.Entities.Overlay
{
    public abstract class Overlaybase
    {
        public bool isAnimated;
        public int currentFrame = 0;
        public int frameTotal = 0;
        public string type = "";
        public bool endAnimationOnEnd = true;
    }
}
