using SciFiSim.Logic.Models.Entities.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Logic.Models.Entities.Building
{
    public enum RoofType
    {
        Triangle,
        Flat,
        Curved
    }
    public class Roof : BuildingFeature
    {
        public RoofType roofType;
    }
}
