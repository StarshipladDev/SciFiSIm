using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Logic.Models.Entities.Town
{
    public class Town
    {
        public const int TOWNCELLSIZE = 10;
        public TownCell[,] townCells;
        public Town()
        {
            this.townCells = new TownCell[TOWNCELLSIZE,TOWNCELLSIZE];
            for(int x = 0;x< TOWNCELLSIZE; x++)
            {
                for (int y = 0; y < TOWNCELLSIZE; y++)
                {
                    this.townCells[x,y] = new TownCell(new List<TownCell>(),x,y);
                }
            }

            //Assign adjacent cells so each towncell knows its neighbours
            for (int x = 0; x < TOWNCELLSIZE; x++)
            {
                for (int y = 0; y < TOWNCELLSIZE; y++)
                {
                    this.townCells[x, y].PopulateAdjacentCells(townCells, x, y);
                }
            }

        }
    }
}
