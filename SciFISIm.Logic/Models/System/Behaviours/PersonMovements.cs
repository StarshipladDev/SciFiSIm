using SciFiSim.Logic.Models.Entities.Root;
using SciFiSim.Logic.Models.Entities.Town;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Logic.Models.System.Behaviours
{
    public class PersonMovements
    {
        public TownCell currentCell = null;
        public List<TownCell> pastCells = new List<TownCell>();
        public TownCell targetCell = null;
        public Stack<TownCell> listOfFutureMovements;
        public bool canMove = true;
        public PersonMovements()
        {
            this.listOfFutureMovements = new Stack<TownCell>();
        }
        public void MoveToCell(TownCell cellMovedTo, PersonEntity terrorsit = null)
        {
            if (canMove)
            {
                if (cellMovedTo.id != this.currentCell.id)
                {
                    this.pastCells.Add(currentCell);
                    this.currentCell = cellMovedTo;
                }
                if (cellMovedTo.id == targetCell.id && listOfFutureMovements.Count > 0)
                {
                    UpdateTarget(terrorsit != null);
                }
            }

        }
        public void AddNewRandomTargetCellIfStatic(TownCell[,] townCells, Random rand)
        {
            if (this.listOfFutureMovements.Count == 0)
            {
                this.listOfFutureMovements.Push(townCells[rand.Next(townCells.GetLength(0)), rand.Next(townCells.GetLength(0))]);
            }
        }
        public void UpdateTarget(bool assignTarget = false)
        {
            if (listOfFutureMovements != null && listOfFutureMovements.Count > 0)
            {
                if (this.targetCell != null && assignTarget) this.targetCell.entitiesComingHere--;
                this.targetCell = listOfFutureMovements.Pop();
                if( assignTarget ) this.targetCell.entitiesComingHere++;
            }
        }
        // Method to move an entity one step towards its target cell
        public TownCell? MoveEntityTowardsTarget(TownCell[,] townCells)
        {
            if (this.targetCell == null) UpdateTarget();
            // Calculate the direction towards the target cell
            int CurrentX = this.currentCell.x;
            int CurrentY = this.currentCell.y;
            int TargetX = this.targetCell.x;
            int TargetY = this.targetCell.y;
            // Iterate through the possible directions (-1, 0, 1) for both x and y

            // Calculate the direction towards the target cell
            int dx = 0;
            int dy = 0;
            if (targetCell.x != currentCell.x)
            {
                dx = targetCell.x > currentCell.x ? 1 : -1;
            }
            if (targetCell.y != currentCell.y)
            {
                dy = targetCell.y > currentCell.y ? 1 : -1;
            }

            int size = townCells.GetLength(0);
            // Calculate the direction towards the target cell

            // Define the order of directions to try (primary, diagonal, orthogonal)
            (int, int)[] directions = {
                (dx, dy), // Primary direction
                (dx, 0), // Horizontal
                (0, dy), // Vertical
                (dx, -dy), // Opposite diagonal
                (-dx, dy)  // Opposite diagonal
            };

            // Attempt to move the entity in one of the defined directions
            foreach (var direction in directions)
            {
                int newX = CurrentX + direction.Item1;
                int newY = CurrentY + direction.Item2;
                if (IsValidCell(newX, newY, size) && townCells[newX, newY].temporaryEntityOnSquare == null)
                {
                    return townCells[newX, newY];
                }
            }
            return null;
        }
        // Method to check if the cell coordinates are within the grid bounds
        private bool IsValidCell(int x, int y, int gridSize)
        {
            // Return true if the coordinates are within the grid dimensions
            return x >= 0 && y >= 0 && x < gridSize && y < gridSize;
        }
    }
}
