using SciFiSim.Logic.Models.Entities.Overlay.Explosion;
using SciFiSim.Logic.Models.Entities.Root;
using SciFiSim.Logic.Models.Entities.Town;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Logic.Models.System.Logic
{
    public class TownSimulation
    {
        public Town town;
        public List<PersonEntity> persons;
        public List<BuildingEntity> buildings;
        public List<OverlayEntity> overlays;
        public PersonEntity terrorist;
        private int IngredientBuildingsCount = 2;

        public TownSimulation(Town town, List<PersonEntity> people, List<BuildingEntity> buildings)
        {
            this.town = town;
            this.persons = people;
            this.buildings = buildings;
            this.overlays = new List<OverlayEntity>();
        }
        public void SetStartLocation()
        {
            AssignGoals();
            persons.ForEach(person =>
            {
                person.movements.currentCell = person.movements.targetCell;
            });
            Random rand = new Random();
            buildings.ForEach(building =>
            {
                building.behaviour.xLoc = rand.Next(town.townCells.GetLength(0));
                building.behaviour.yLoc = rand.Next(town.townCells.GetLength(0));
            });
        }
        public void CreateTerrorist()
        {
            List<int> availableBuildingIndexes = new List<int> { };
            int buildingIndex = 0;
            this.buildings.ForEach((building) =>
            {
                availableBuildingIndexes.Add(buildingIndex);
                buildingIndex++;
            });
            Random rand = new Random();
            PersonEntity badPerson = this.persons[rand.Next(this.persons.Count)];
            this.terrorist = badPerson;
            badPerson.terroristBehaviour = new Behaviours.TerroristBehaviour(IngredientBuildingsCount, 0);
            int possibleBuildingIndex = 0;
            while (
                badPerson.terroristBehaviour.ingredientBuildingCells.Count < IngredientBuildingsCount &&
                badPerson.terroristBehaviour.ingredientBuildingCells.Count < this.buildings.Count - 2)
            {
                possibleBuildingIndex = availableBuildingIndexes[rand.Next(availableBuildingIndexes.Count)];
                TownCell maybeIngredientCell = this.town.townCells[this.buildings[possibleBuildingIndex].behaviour.xLoc, this.buildings[possibleBuildingIndex].behaviour.yLoc];
                if (!badPerson.terroristBehaviour.ingredientBuildingCells.Contains(maybeIngredientCell))
                {
                    badPerson.terroristBehaviour.ingredientBuildingCells.Add(
                       maybeIngredientCell
                    );
                    availableBuildingIndexes.Remove(possibleBuildingIndex);
                }
            }

            possibleBuildingIndex = availableBuildingIndexes[rand.Next(availableBuildingIndexes.Count)];
            TownCell maybeTargetCell = this.town.townCells[this.buildings[possibleBuildingIndex].behaviour.xLoc, this.buildings[possibleBuildingIndex].behaviour.yLoc];

            while (badPerson.terroristBehaviour.ingredientBuildingCells.Contains(maybeTargetCell))
            {
                possibleBuildingIndex = rand.Next(this.buildings.Count);
                maybeTargetCell = this.town.townCells[this.buildings[possibleBuildingIndex].behaviour.xLoc, this.buildings[possibleBuildingIndex].behaviour.yLoc];

                availableBuildingIndexes.Remove(possibleBuildingIndex);
            }
            badPerson.terroristBehaviour.targetBuildingCell =
               maybeTargetCell;
            badPerson.movements.listOfFutureMovements = new Stack<TownCell>();
            badPerson.movements.listOfFutureMovements.Push(badPerson.terroristBehaviour.targetBuildingCell);
            badPerson.terroristBehaviour.ingredientBuildingCells.ForEach((cell =>
            {

                badPerson.movements.listOfFutureMovements.Push(cell);
            }));
            var FirstTarget =  badPerson.movements.listOfFutureMovements.Pop();
            badPerson.terroristBehaviour.nextTargetCellx = FirstTarget.x;
            badPerson.terroristBehaviour.nextTargetCelly = FirstTarget.y;
            badPerson.movements.listOfFutureMovements.Push(FirstTarget);

        }
        public void SetOffExplosion(int x, int y)
        {
            this.overlays.Add(new OverlayEntity
            {
                overlayItem = new Explosion
                {
                },
                positionx = x,
                positiony = y
            });
            var removeBUilding = this.buildings.Where((building) =>
            {
                return building.behaviour.xLoc == x &&
                building.behaviour.yLoc == y;
            }).ToList();
            if(removeBUilding.Count > 0)
            {

                this.buildings.Remove(removeBUilding[0]);
            }
        }
        public void UpdateOverlayFrames()
        {
            int currentTick = 0;
            List<int> indexToDeleteList = new List<int>();
            this.overlays.ForEach((overlay) =>
            {
                if (
                overlay.overlayItem.endAnimationOnEnd &&
                overlay.overlayItem.currentFrame == overlay.overlayItem.frameTotal
                )
                {
                    indexToDeleteList.Add(currentTick);
                }
                else if (overlay.overlayItem.currentFrame < overlay.overlayItem.frameTotal)
                {
                    overlay.overlayItem.currentFrame++;
                }
                currentTick++;
            });
            indexToDeleteList.OrderByDescending((x) => x).ToList().ForEach((index) =>
            {
                overlays.RemoveAt(index);
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

                /* Random movements */
                /*
                TownCell cellToMoveTo = person.movements.currentCell.adjacentCells[rand.Next(person.movements.currentCell.adjacentCells.Count())];
                person.movements.MoveToCell(cellToMoveTo);
                */
                //Randomzie to stop gridlock
                if (rand.Next(5) < 3)
                {
                    TownCell? newCell = person.movements.MoveEntityTowardsTarget(this.town.townCells);
                    if (newCell != null)
                    {

                        person.movements.currentCell.RemoveTempEntity();
                        person.movements.MoveToCell(newCell, this.terrorist);
                        newCell.temporaryEntityOnSquare = person;
                        person.movements.AddNewRandomTargetCellIfStatic(this.town.townCells, rand);
                    }
                }
            });
            if (
                this.terrorist.movements.currentCell == this.terrorist.movements.targetCell &&
                this.terrorist.movements.currentCell ==
                this.town.townCells[
                    this.terrorist.terroristBehaviour.nextTargetCellx, 
                    this.terrorist.terroristBehaviour.nextTargetCelly
                ]
            )
            {
                this.terrorist.terroristBehaviour.ingredientsAquired++;
                this.terrorist.terroristBehaviour.ingredientBuildingCells.Remove(this.terrorist.terroristBehaviour.ingredientBuildingCells.Last());
                if(this.terrorist.terroristBehaviour.ingredientBuildingCells.Count > 0)
                {
                    TownCell nextCell = this.terrorist.terroristBehaviour.ingredientBuildingCells.Last();
                    this.terrorist.terroristBehaviour.nextTargetCellx = nextCell.x;
                    this.terrorist.terroristBehaviour.nextTargetCelly = nextCell.y;
                }
               
            }
            if (
                this.overlays.FindAll((x) => x.overlayItem.type == "Explosion").Count == 0 &&
                this.terrorist != null &&
                this.terrorist.movements.currentCell == this.terrorist.terroristBehaviour.targetBuildingCell)
            {
                SetOffExplosion(this.terrorist.movements.currentCell.x, this.terrorist.movements.currentCell.y);
            }
            //Deal with animations
            UpdateOverlayFrames();
        }
    }
}
