using SciFiSim.Logic.Models.Entities.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Logic.Models.Entities.Building
{
    public class Building
    {
        public Roof roof;
        public Windows window;
        public BuildingColor color;
        public Building()
        {
            Random rand = new Random();

            List<RoofType> roofTypes = Enum.GetValues(typeof(RoofType)).Cast<RoofType>().ToList();
            List<WindowType> windowTypes = Enum.GetValues(typeof(WindowType)).Cast<WindowType>().ToList();
            List<BuildingColors> colorTypes = Enum.GetValues(typeof(BuildingColors)).Cast<BuildingColors>().ToList();

        }
    }
}
