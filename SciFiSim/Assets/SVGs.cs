using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Assets
{
    public class SVGs
    {
        public static string smileySvg = @"<circle id = 'circle' cx='50' cy='50' r='40' fill='yellow' stroke='black' stroke-width='2'/>\r\n  \r\n  <!-- Eyes -->\r\n  <circle cx='35' cy='40' r='5' fill='black'/>\r\n  <circle cx='65' cy='40' r='5' fill='black'/>\r\n  \r\n  <!-- Mouth -->\r\n  <path d='M 30 60 Q 50 80 70 60' stroke='black' fill='none'/>";
        public static string smileySvgMoved = @"<circle id = 'circle' cx='70' cy='70' r='40' fill='yellow' stroke='black' stroke-width='2'/>\r\n  \r\n  <!-- Eyes -->\r\n  <circle cx='35' cy='40' r='5' fill='black'/>\r\n  <circle cx='65' cy='40' r='5' fill='black'/>\r\n  \r\n  <!-- Mouth -->\r\n  <path d='M 30 60 Q 50 80 70 60' stroke='black' fill='none'/>";
        public static string GetSmiley(bool isNormal)
        {
            return "<html><head> <meta http-equiv=\"x-ua-compatible\" content=\"IE=11\"> <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"> <title>SVG sample</title> <style type=\"text/css\"> </style>\r\n</head>" +
            "<body><div>test!</div><br>"+
            "<button id='buttonman' onclick='enRedden()'> Click </button> <br><svg width='100' height='100' x='0' y='0'>" + (isNormal? SVGs.smileySvg : SVGs.smileySvgMoved )+ "</svg>"+
            "<script> function moveCircle(){ document.getElementById('circle').setAttribute('cy',70);}</script>\"" +
            "<script> function enRedden(){ moveCircle(); document.getElementById('buttonman').setAttribute('style','background-color:red');}</script>\"" +
            "+</body></html>";
        }
    }
}
