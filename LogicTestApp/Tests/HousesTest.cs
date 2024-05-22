using SciFiSim.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LogicTestApp.Tests
{
    public class HousesTest
    {
        public static void RunHouseTest()
        {
            SciFiSim.Assets.HouseDrawObject[] houses = [
            new HouseDrawObject("style1", 2, 3),
            new HouseDrawObject("style2", 5, 6),
            new HouseDrawObject("style3", 8, 1)
            ];
            string htmlDocumentText = "<html><head></head><body><div style = 'position:relative'>";
                htmlDocumentText += SVGs.GetFullSvg(500, 10, true,houses);
            htmlDocumentText += "</div></body></html>";
            Console.WriteLine(htmlDocumentText);
            Console.ReadLine();
        }
        
    }
}
