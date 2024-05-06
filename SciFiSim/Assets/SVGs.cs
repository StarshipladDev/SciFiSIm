using SciFiSim.Logic.Models.Entities.People;
using SciFiSim.Logic.Models.Entities.Root;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Assets
{
    public class HouseDrawObject
    {
        public string Style { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public HouseDrawObject(string style, int x, int y)
        {
            Style = style;
            X = x;
            Y = y;
        }

        public HouseDrawObject(Logic.Models.Entities.Root.BuildingEntity building)
        {
            Random rand = new Random();
            string[] styleList = ["style1", "style2", "style3"];
                Style = styleList[rand.Next(styleList.Length)];
                X = building.behaviour.xLoc;
                Y = building.behaviour.yLoc;
            
        }
    }
    public class SVGs
    {
        public static string smileySvg = @"<circle id = 'circle' cx='50' cy='50' r='40' fill='yellow' stroke='black' stroke-width='2'/>\r\n  \r\n  <!-- Eyes -->\r\n  <circle cx='35' cy='40' r='5' fill='black'/>\r\n  <circle cx='65' cy='40' r='5' fill='black'/>\r\n  \r\n  <!-- Mouth -->\r\n  <path d='M 30 60 Q 50 80 70 60' stroke='black' fill='none'/>";
        public static string smileySvgMoved = @"<circle id = 'circle' cx='70' cy='70' r='40' fill='yellow' stroke='black' stroke-width='2'/>\r\n  \r\n  <!-- Eyes -->\r\n  <circle cx='35' cy='40' r='5' fill='black'/>\r\n  <circle cx='65' cy='40' r='5' fill='black'/>\r\n  \r\n  <!-- Mouth -->\r\n  <path d='M 30 60 Q 50 80 70 60' stroke='black' fill='none'/>";
        public static string GetSmiley(bool isNormal)
        {
            return "<html><head> <meta http-equiv=\"x-ua-compatible\" content=\"IE=11\"> <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"> <title>SVG sample</title> <style type=\"text/css\"> </style>\r\n</head>" +
            "<body><div>test!</div><br>" +
            "<button id='buttonman' onclick='enRedden()'> Click </button> <br><svg width='100' height='100' x='0' y='0'>" + (isNormal ? SVGs.smileySvg : SVGs.smileySvgMoved) + "</svg>" +
            "<script> function moveCircle(){ document.getElementById('circle').setAttribute('cy',70);}</script>\"" +
            "<script> function enRedden(){ moveCircle(); document.getElementById('buttonman').setAttribute('style','background-color:red');}</script>\"" +
            "+</body></html>";
        }
        public static string GetGridWithHouses(int svgWidth, int townSize, HouseDrawObject[] houses, PersonEntity[]? people = null)
        {
            List<string> returnSvgs = new List<string>();
            int cellSize = svgWidth / townSize;
            returnSvgs.Add(SVGs.GetTownGrid(svgWidth, townSize));
            returnSvgs.Add(SVGs.GetHouseOnTownCell(svgWidth, cellSize, houses));
            if (people != null) returnSvgs.Add(SVGs.GetPeople(svgWidth, townSize, people));
            string returnText = "<html><head> <meta http-equiv=\"x-ua-compatible\" content=\"IE=11\"> <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"> <title>SVG sample</title> <style type=\"text/css\"> </style>\r\n</head>" +
            "<body><div>";
            returnText += returnSvgs[0];
            returnText += returnSvgs[1];
            if (people != null) returnText += returnSvgs[2];
            returnText += "</div></body></hml>";
            return returnText;

        }

        public static string GetPeople(int svgWidth, int townSize, PersonEntity[] people)
        {
            int cellWidth = svgWidth / townSize;
            // Define SVG header
            string svg = $"<svg width=\"{svgWidth}\" height=\"{svgWidth}\" style = \"position:absolute\">";
            foreach (PersonEntity person in people)
            {

                /*Skin */
                var SkinType =  "Assets\\People\\Skin"+person.personStyle.skinColor.skinType.ToString() + ".png";
                svg += $"<image x=\"{person.movements.currentCell.x * cellWidth}\" y=\"{person.movements.currentCell.y * cellWidth}\"" +
                    $" xlink:href=\"{Path.Combine(Environment.CurrentDirectory, SkinType)}\" width=\"{cellWidth}\" height=\"{cellWidth}\"/>";
                /*Eyes */
                var EyeType = "Assets\\People\\Eyes" + person.personStyle.eyes.eyeType.ToString()+".png";

                var fileExsists = System.IO.File.Exists($"{Path.Combine(Environment.CurrentDirectory, EyeType)}");
                var fileLocation = $"{Path.Combine(Environment.CurrentDirectory, EyeType)}";
                svg += $"<image x=\"{person.movements.currentCell.x * cellWidth}\" y=\"{person.movements.currentCell.y * cellWidth}\"" +
                    $" xlink:href=\"{Path.Combine(Environment.CurrentDirectory, EyeType)}\" width=\"{cellWidth}\"  height=\"{cellWidth}\"/>";
                /*Mouth */
                var MouthType = "Assets\\People\\Mouth" + person.personStyle.mouth.mouthType.ToString() + ".png";
                svg += $"<image x=\"{person.movements.currentCell.x * cellWidth}\" y=\"{person.movements.currentCell.y * cellWidth}\"" +
                    $" xlink:href=\"{Path.Combine(Environment.CurrentDirectory, MouthType)}\" width=\"{cellWidth}\" height=\"{cellWidth}\"/>";
                /*Hair */
                var HairType = "Assets\\People\\Hair" + person.personStyle.hair.hairType.ToString() + ".png";
                svg += $"<image x=\"{person.movements.currentCell.x * cellWidth}\" y=\"{person.movements.currentCell.y * cellWidth}\"" +
                    $" xlink:href=\"{Path.Combine(Environment.CurrentDirectory, HairType)}\" width=\"{cellWidth}\"  height=\"{cellWidth}\"/>";
            }

            // Close SVG tag
            svg += "</svg>";

            return svg;
        }

        public static string GetTownGrid(int svgWidth, int townSize)
        {
            int cellWidth = svgWidth / townSize;
            // Define SVG header
            string svg = $"<svg width=\"{svgWidth}\" height=\"{svgWidth}\" style = \"position:absolute\">";

            // Add dust-covered square
            svg += $"<rect width=\"{svgWidth}\" height=\"{svgWidth}\" fill=\"lightgrey\" />";

            // Add vertical grid lines
            for (int x = 0; x < svgWidth; x += cellWidth)
            {
                svg += $"<line x1=\"{x}\" y1=\"0\" x2=\"{x}\" y2=\"{svgWidth}\" stroke=\"black\" />";
            }

            // Add horizontal grid lines
            for (int y = 0; y < svgWidth; y += cellWidth)
            {
                svg += $"<line x1=\"0\" y1=\"{y}\" x2=\"{svgWidth}\" y2=\"{y}\" stroke=\"black\" />";
            }

            // Close SVG tag
            svg += "</svg>";

            return svg;
        }

        static string GetHouseOnTownCell(int pixelWidth, int cellSize, HouseDrawObject[] houses)
        {
            string svg = $"<svg width=\"{pixelWidth}\" height=\"{pixelWidth}\"  style = \"position:absolute\">";
            foreach (HouseDrawObject house in houses)
            {
                int x = house.X * cellSize;
                int y = house.Y * cellSize;
                string houseStyle = house.Style;

                string houseSvg = DrawHouse(houseStyle, x, y, cellSize);
                svg += houseSvg;
            }

            return svg;
        }

        static string DrawHouse(string style, int x, int y, int size)
        {
            string houseSvg = "";
            switch (style)
            {
                case "style1":
                    // Draw style 1 house
                    houseSvg += $"<rect x=\"{x}\" y=\"{y}\" width=\"{size}\" height=\"{size}\" fill=\"blue\" />";
                    // Draw roof
                    houseSvg += $"<polygon points=\"{x},{y} {x + size / 2},{y - size / 2} {x + size},{y}\" fill=\"red\" />";
                    break;
                case "style2":
                    // Draw style 2 house
                    houseSvg += $"<rect x=\"{x}\" y=\"{y}\" width=\"{size}\" height=\"{size}\" fill=\"green\" />";
                    // Draw roof
                    houseSvg += $"<polygon points=\"{x},{y} {x + size / 2},{y - size / 2} {x + size},{y}\" fill=\"orange\" />";
                    break;
                case "style3":
                    // Draw style 3 house
                    houseSvg += $"<rect x=\"{x}\" y=\"{y}\" width=\"{size}\" height=\"{size}\" fill=\"yellow\" />";
                    // Draw roof
                    houseSvg += $"<polygon points=\"{x},{y} {x + size / 2},{y - size / 2} {x + size},{y}\" fill=\"brown\" />";
                    break;
                default:
                    break;
            }
            return houseSvg;
        }
    }
}

