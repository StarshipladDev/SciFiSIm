using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Logic.Models.Entities.Building
{
    public enum WindowType
    {
        Circle,
        Small,
        Square
    }
    public class Windows : BuildingFeature
    {
        public WindowType windowType;
    }
}
