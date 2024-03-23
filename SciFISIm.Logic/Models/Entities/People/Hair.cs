using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Logic.Models.Entities.People
{
    public enum HairType
    {
        Long,
        Short,
        Buzzcut,
        Bald,
        Curly
    }
    public class Hair : PersonFeature
    {
        public HairType hairType;
    }
}
