using SciFiSim.Logic.Models.Entities.People;
using SciFiSim.Logic.Models.System.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicTestApp.Tests
{
    internal class TimeTest
    {
        public static void TestTimeRunning()
        {
            List<Time> timeList = new List<Time>{
                new Time("0:00", new Guid()),
                new Time("1:00", new Guid()),
                new Time("2:00", new Guid()),
                new Time("3:00", new Guid()),
                new Time("4:00", new Guid()),
            };
            Simulation simulation = new Simulation();
            simulation.RunSimulation(timeList.ToList());

        }

    }
}
