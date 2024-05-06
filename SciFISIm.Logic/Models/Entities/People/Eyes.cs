using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Logic.Models.Entities.People
{
    public enum EyeType
    {
        Wide,
        Small,
        Squint,
        Sus
    }
    public class Eyes : PersonFeature
    {
        public EyeType eyeType;
    }
}
