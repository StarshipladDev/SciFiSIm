using SciFiSim.Logic.Models.Entities.Root;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Logic.Models.Entities.Town
{
    public class TownCell
    {
        public Guid id { get; set; }
        public bool movable = true;
        public List<TownCell> adjacentCells = new List<TownCell>();
        public int x, y;
        public Entity? permentantEntityOnSquare;
        public Entity? temporaryEntityOnSquare;
        public Entity? tertiaryEntityOnSquare;
        public int entitiesComingHere = 0;
        public TownCell(List<TownCell> adjacentCells, int x, int y) {
            this.adjacentCells = adjacentCells;
            this.id = Guid.NewGuid();
            this.x = x;
            this.y = y;
        }
        public void PopulateAdjacentCells(TownCell[,] grid, int x, int y)
        {
            int gridSize = grid.GetLength(0);
            // Loop through all possible adjacent positions
            for (int xOffset = -1; xOffset <= 1; xOffset++)
            {
                for (int yOffset = -1; yOffset <= 1; yOffset++)
                {
                    // Skip the cell itself
                    if (xOffset == 0 && yOffset == 0) continue;

                    int ni = x + xOffset; // New row index for adjacent cell
                    int nj = y + yOffset; // New column index for adjacent cell

                    // Check if the new indexes are within the bounds of the grid
                    if (ni >= 0 && ni < gridSize && nj >= 0 && nj < gridSize)
                    {
                        // Add the adjacent cell to the current cell's AdjacentCells list
                        if(grid[ni, nj].movable) this.adjacentCells.Add(grid[ni, nj]);
                    }
                }
            }
        }
        public void SetPermenantEntity(Entity entity)
        {
            this.permentantEntityOnSquare = entity;
        }
        public void SetTempEntity(Entity entity)
        {
            this.temporaryEntityOnSquare = entity;
        }
        public void RemoveTempEntity()
        {
            this.temporaryEntityOnSquare = null;
        }
        public override string ToString()
        {
            return $"X: {x} Y:{y}";
        }
    }
}
