using SciFiSim.Logic.Models.Entities.Town;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Logic.Models.System.Places
{
    public class PersonMovements
    {
        public TownCell currentCell = null;
        public List<TownCell> pastCells = new List<TownCell>();
        public TownCell targetCell = null;
        public PersonMovements()
        {

        }
        public void MoveToCell(TownCell cellMovedTo)
        {
            if(cellMovedTo.id != this.currentCell.id)
            {
                this.pastCells.Add(currentCell);
                this.currentCell = cellMovedTo;
            }
        }
    }
}
