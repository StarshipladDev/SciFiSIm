using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Logic.Models.Entities.People
{
    public enum SkinColorType
    {
        Dark,
        Brown,
        Tan,
        Light
    };
    public class SkinColor : PersonFeature
    {
        public SkinColorType skinType;
    }
}
