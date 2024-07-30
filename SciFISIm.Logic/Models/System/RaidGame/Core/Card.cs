using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Logic.Models.System.RaidGame.Core
{
    public class Card
    {
        public Guid Id { get; set; }
        public Action cardAction;
        public Card(Action action)
        {
            this.Id = Guid.NewGuid();
            this.cardAction = action;
        }
    }
}
