using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Logic.Models.System.RaidGame.Core
{
    public abstract class Behaviour
    {
        public List<Card> cardActionList = new List<Card>();
        public void AddCardPush(Card cardToAdd)
        {
            this.cardActionList.Add(cardToAdd);
        }
    }
}
