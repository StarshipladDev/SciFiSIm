using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Logic.Models.Entities.People
{
    public enum MouthType
    {
        Smile,
        Grin,
        Sad,
        Neutral
    }
    public class Mouth : PersonFeature
    {
        public MouthType mouthType;
    }
}
