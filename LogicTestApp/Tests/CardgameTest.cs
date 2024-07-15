using Microsoft.Web.WebView2.Core;
using SciFiSim.Logic.Models.System.RaidGame.Actions;
using SciFiSim.Logic.Models.System.RaidGame.Behaviours;
using SciFiSim.Logic.Models.System.RaidGame.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicTestApp.Tests
{
    public static class CardgameTest
    {
        public static void RunCardgameTest()
        {
            List<Card> cardList = new List<Card>();
            cardList.Add(new Card(new BlastAway()));
            cardList.Add(new Card(new SecureRoom()));
            cardList.Add(new Card(new SecureRoom()));
            RaidGameInstance gameInstance = new RaidGameInstance();
            Actor newActor = new Actor();
            newActor.behaviours.Add(new BasicMob());
            newActor.behaviours[0].AddAction(new SecureRoom());
            gameInstance.actors.Add(newActor);
            gameInstance.SetDeck(cardList);
            Console.WriteLine("Deck set up, current hand count is " + gameInstance.GetDeckHand().Count());
            gameInstance.DrawACard();
            Console.WriteLine("Drew a card, current hand count is " + gameInstance.GetDeckHand().Count() + "and cards left is " + gameInstance.GetUnplayedCards().Count());
            Console.WriteLine("Palying a card on enter");
            Console.ReadLine();
            Console.WriteLine(gameInstance.PlayCardInHand(gameInstance.GetDeckHand()[0], gameInstance.actors[0]));


        }
    }
}
