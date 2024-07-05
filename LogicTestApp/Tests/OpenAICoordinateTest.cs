using Newtonsoft.Json;
using SciFiSim.Logic.Models.Entities.Root;
using SciFiSim.Logic.Models.Entities.Town;
using SciFiSim.Logic.Models.System.Logic;
using SciFiSim.Logic.OpenAI;
using SciFiSim.Logic.OpenAI.Migration;
using SciFiSim.Logic.OpenAI.Prompts;
using SciFiSim.Logic.OpenAI.Replies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicTestApp.Tests
{
    public class OpenAICoordinateTest
    {
        public static async void SimulationTestRunning()
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
            Random personCellPicker = new Random();
            foreach (string name in listOfNames)
            {
                PersonEntity newPerson = new PersonEntity(Guid.NewGuid(), name);
                people.Add(newPerson);
            }
            List<BuildingEntity> buildings = new List<BuildingEntity>();
            for (int i = 0; i < 10; i++)
            {
                buildings.Add(new BuildingEntity(Guid.NewGuid(), new SciFiSim.Logic.Models.System.Behaviours.BuildingBehaviour(false, 0, 0)));
            }
            Simulation simulation = new Simulation(town, people, buildings);
            simulation.simulation.CreateBlankTerroristAndIngridentBuilding(4);
            List<TownCell> terroristTargetCells = new List<TownCell>();
            foreach (TownCell cell in simulation.simulation.terrorist.terroristBehaviour.ingredientBuildingCells)
            {
                terroristTargetCells.Add(simulation.simulation.town.townCells[cell.x,cell.y]);
            }

            terroristTargetCells.Add(simulation.simulation.town.townCells[simulation.simulation.terrorist.terroristBehaviour.targetBuildingCell.x, simulation.simulation.terrorist.terroristBehaviour.targetBuildingCell.y]);
            await OpenAICoordsToSimulation.RenderCoordsReplyToSimulation(simulation, terroristTargetCells);
            simulation.RunSimulation(timeList.ToList(), (simulation) => {
                simulation.persons.ForEach((PersonEntity person) => {
                    Console.WriteLine($"\nPerson {person.personStyle.firstName} is at {person.movements.currentCell} moving to {person.movements?.targetCell}");
                    Console.WriteLine("Target cells size for them is :" + person.movements.listOfFutureMovements.Count());
                    if (person.terroristBehaviour != null)
                    {
                        Console.WriteLine($"Person {person.personStyle.firstName} is terrorist, going to ");
                        Console.Write($"{person.terroristBehaviour.targetBuildingCell}");
                        int ingredientOrder = 0;
                        person.terroristBehaviour.ingredientBuildingCells.ForEach((ingredientCell => {

                            Console.Write($"\n ,  ingredient cell {ingredientOrder} : {ingredientCell}");
                            ingredientOrder++;
                        }));

                    }
                    if (simulation.overlays.Count > 0)
                    {
                        Console.WriteLine("Bomb went off at " + simulation.overlays[0].positionx + "," + simulation.overlays[0].positiony);
                    }
                });
            });

        }

    }
}
