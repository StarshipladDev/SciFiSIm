using SciFiSim.Logic.Models.Entities.Town;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Logic.Models.System.Behaviours
{
    public class TerroristBehaviour
    {
        public TownCell targetBuildingCell;
        public List<TownCell> ingredientBuildingCells;
        public int ingredientsNeeded = 0;
        public int ingredientsAquired = 0;
        public int nextTargetCellx = 0;
        public int nextTargetCelly = 0;

        public TerroristBehaviour(int ingredientsNeeded, int ingredientsAquired)
        {
            this.ingredientBuildingCells = new List<TownCell>();
            this.ingredientsNeeded = ingredientsNeeded;
            this.ingredientsAquired = ingredientsAquired;
        }
    }
}
