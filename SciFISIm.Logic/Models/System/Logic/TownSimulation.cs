using SciFiSim.Logic.Models.Entities.Root;
using SciFiSim.Logic.Models.Entities.Town;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Logic.Models.System.Logic
{
    public class TownSimulation
    {
        public Town town;
        public List<PersonEntity> persons;

        public TownSimulation(Town town, List<PersonEntity> people)
        {
            this.town = town;
            this.persons = people;
        }
        public void SetStartLocation()
        {
            AssignGoals();
            persons.ForEach(person =>
            {
                person.movements.currentCell = person.movements.targetCell;
            });
        }
        public void AssignGoals()
        {
            Random rand = new Random();
            persons.ForEach(person =>
            {
                if (person.movements.targetCell == null || person.movements.targetCell == person.movements.currentCell)
                {
                    List<TownCell> filteredTown = new List<TownCell>();
                    for (int i = 0; i < town.townCells.GetLength(0); i++)
                    {
                        for (int j = 0; j < town.townCells.GetLength(1); j++)
                        {
                            // Check if the cell is movable (Immovable == false)
                            if (town.townCells[i, j].movable)
                            {
                                filteredTown.Add(town.townCells[i, j]);
                            }
                        }
                    }
                    person.movements.targetCell = filteredTown[rand.Next(filteredTown.Count())];
                }
            });
        }
        public void OnTick()
        {

            Random rand = new Random();
            persons.ForEach(person =>
            {
                TownCell cellToMoveTo = person.movements.currentCell.adjacentCells[rand.Next(person.movements.currentCell.adjacentCells.Count())];
                person.movements.MoveToCell(cellToMoveTo);
            });
        }
    }
}
