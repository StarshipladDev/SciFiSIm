using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Logic.Models.System.Logic
{
    public class Time
    {
        public string timeName;
        Guid timeId;
        public Time(string timeName, Guid timeId)
        {
            this.timeName = timeName;
            this.timeId = timeId;
        }
    }
}
