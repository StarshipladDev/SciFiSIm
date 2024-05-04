using SciFiSim.Logic.Models.Entities.Root;
using SciFiSim.Logic.Models.Entities.Town;
using SciFiSim.Logic.Models.System.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicTestApp.Tests
{
    public class SimulationTest
    {
        public static void SimulationTestRunning()
        {
            List<Time> timeList = new List<Time>();

            // Generate times from 0:00 to 23:00
            for (int hour = 0; hour < 24; hour++)
            {
                string timeString = $"{hour}:00"; // Format the time string
                timeList.Add(new Time(timeString, Guid.NewGuid())); // Add new Time object with a unique Guid
            }
            Town town = new Town();
            string[] listOfNames = {
                "Amir Al-Farsi",
                "Leyla Hassani",
                "Tariq Al-Najjar",
                "Yasmin Shirazi",
                "Farid Mostafa",
                "Nour El-Din",
                "Sanaa Al-Rashid",
                "Malik Al-Khalil",
                "Dalia Al-Saad",
                "Samir Zahedi"
            };

            List<PersonEntity> people = new List<PersonEntity>();
            foreach (string name in listOfNames)
            {
                people.Add(new PersonEntity(Guid.NewGuid(),name));
            }
            List<BuildingEntity> buildings = new List<BuildingEntity>();
            for (int i = 0; i< 10; i++)
            {
                buildings.Add(new BuildingEntity(Guid.NewGuid(), new SciFiSim.Logic.Models.System.Places.BuildingBehaviour(false,0,0)));
            }
            Simulation simulation = new Simulation(town, people, buildings);
            simulation.RunSimulation(timeList.ToList(),null);

        }

    }
}
