using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Logic.Models.Entities.Building
{

    public enum BuildingColors
    {
        Red,
        Grey,
        DarkGrey,
        BLue
    }
    public class BuildingColor : BuildingFeature
    {
        public BuildingColors buildingColor;
    }

}
