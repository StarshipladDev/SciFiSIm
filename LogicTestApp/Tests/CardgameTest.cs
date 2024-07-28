using Microsoft.Web.WebView2.Core;
using SciFiSim.Logic.Models.System.RaidGame.Actions;
using SciFiSim.Logic.Models.System.RaidGame.Actors;
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
            Actor newActor = new Actor( new ActorDetails(3, FactionType.Blufor));
            cardList.Add(new Card(new BlastAway(newActor)));
            cardList.Add(new Card(new Prefire(newActor)));
            cardList.Add(new Card(new Prefire(newActor)));
            RaidGameInstance gameInstance = new RaidGameInstance();
            newActor.behaviours.Add(new BasicMob());
            newActor.behaviours[0].AddCardPush(
                new Card(new Prefire(newActor))
            );
            gameInstance.actors.Add(newActor);
            gameInstance.SetDeck(cardList);
            Console.WriteLine("Deck set up, current hand count is " + gameInstance.GetDeckHand().Count());
            gameInstance.DrawACard();
            Console.WriteLine("Drew a card, current hand count is " + gameInstance.GetDeckHand().Count() + "and cards left is " + gameInstance.GetUnplayedCards().Count());
            Console.WriteLine("Playing a card on enter");
            Console.ReadLine();

            Console.ReadLine();


        }
        public static void RunCardgameTestActions( bool debug = true)
        {
            DebugWrite("Starting Simulation", debug);
            // initalize
            List<Card> cardList = new List<Card>();
            RaidGameInstance gameInstance = new RaidGameInstance();


            // Set up agents in the world
            // Add blufor person
            Actor agent = new Actor(new ActorDetails(3, FactionType.Blufor));
            agent.behaviours.Add(new BasicMob());
            agent.behaviours[0].AddCardPush(new Card(new BlastAway(agent)));


            DebugWrite("Agent Created", debug);
            // Add Redfor Agents
            Actor redfor1 = new Actor(new ActorDetails(1, FactionType.Redfor));
            redfor1.behaviours.Add(new BasicMob());
            redfor1.behaviours[0].AddCardPush(new Card(new Prefire(redfor1)));
            Actor redfor2 = new Actor(new ActorDetails(1, FactionType.Redfor));
            redfor2.behaviours.Add(new BasicMob());
            redfor2.behaviours[0].AddCardPush(new Card(new Prefire(redfor2)));

            DebugWrite("Redfor Created", debug);


            // Set Up Default Cards
            cardList.Add(new Card(new BlastAway(null)));
            cardList.Add(new Card(new BlastAway(null)));
            DebugWrite("Neutral cards Created", debug);

            //Set up places and inital locations
            gameInstance.places = new List<Place> { new Place("room 1"), new Place("room 2") };
            gameInstance.actors.Add(agent);
            gameInstance.actors.Add(redfor1);
            gameInstance.actors.Add(redfor2);
            gameInstance.SetDeck(cardList);
            DebugWrite("Actors and places added", debug);




        }
        public static void DebugWrite(string message, bool debug)
        {
            if (debug)
            {
                Console.WriteLine(message);
            }
        }
    }
}
