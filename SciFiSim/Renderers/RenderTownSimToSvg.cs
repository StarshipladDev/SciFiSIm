using SciFiSim.Assets;
using SciFiSim.Logic.Models.System.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Renderers
{
    public class RenderTownSimToSvg
    {
        public string RenderSVGFromTow(TownSimulation simulation, int svgSize)
        {
            List<HouseDrawObject> houseList = new List<HouseDrawObject>();
            simulation.buildings.ForEach(building =>
            {
                houseList.Add(new HouseDrawObject(building));
            });
            return SVGs.GetGridWithHouses(svgSize, simulation.town.townCells.GetLength(0), houseList.ToArray(), simulation.persons.ToArray());
        }
    }
}
