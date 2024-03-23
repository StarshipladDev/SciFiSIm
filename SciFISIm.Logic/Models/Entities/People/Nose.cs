using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Logic.Models.Entities.People
{
    public enum NoseType
    {
        Bulb,
        Large,
        Small
    };
    public class Nose : PersonFeature
    {
        public NoseType noseType;
    }
}
