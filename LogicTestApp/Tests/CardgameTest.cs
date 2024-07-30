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
            Actor newActor = new Actor( new ActorDetails(3, FactionType.Blufor, "BLUFOR agent"));
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
            Actor agent = new Actor(new ActorDetails(3, FactionType.Blufor, "BLUFOR agent"));
            agent.behaviours.Add(new BasicMob());
            agent.behaviours[0].AddCardPush(new Card(new BlastAway(agent)));


            DebugWrite("Agent Created", debug);
            // Add Redfor Agents
            Actor redfor1 = new Actor(new ActorDetails(1, FactionType.Redfor, "REDFOR agent 1"));
            redfor1.behaviours.Add(new BasicMob());
            redfor1.behaviours[0].AddCardPush(new Card(new Prefire(redfor1)));
            Actor redfor2 = new Actor(new ActorDetails(1, FactionType.Redfor, "REDFOR agent 2"));
            redfor2.behaviours.Add(new BasicMob());
            redfor2.behaviours[0].AddCardPush(new Card(new Prefire(redfor2)));

            DebugWrite("Redfor Created", debug);


            // Set Up Default Cards
            cardList.Add(new Card(new BlastAway(null)));
            cardList.Add(new Card(new BlastAway(null)));
            DebugWrite("Neutral cards Created", debug);

            //Set up places and initial locations
            gameInstance.places = new List<Place> { new Place("room 1"), new Place("room 2") };
            gameInstance.actors.Add(agent);
            gameInstance.actors.Add(redfor1);
            gameInstance.actors.Add(redfor2);
            gameInstance.SetDeck(cardList);
            DebugWrite("Actors and places added", debug);

            //Set Initial Locations
            agent.ChangeLocation(gameInstance.places[0]);
            redfor1.ChangeLocation(gameInstance.places[1]);
            redfor2.ChangeLocation(gameInstance.places[1]);
            DebugWrite("Inital locations set", debug);

            //Inital Shuffle and set up
            gameInstance.ShuffleAllCardsInDeck();
            DebugWrite("Shuffled Deck", debug);

            while (agent.isAlive)
            {
                int cardsToDraw = 2;
                DebugWrite($"New Turn, Drawing {cardsToDraw} cards",true);
                for(int i = 0; i < cardsToDraw; i++)
                {
                    var latestCard = gameInstance.DrawACard();
                    if (latestCard != null)
                    {
                        DebugWrite($"You Drew {latestCard.cardAction.actionTitle}", true);
                    }
                    else
                    {
                        DebugWrite($"No Card Drawn", true);
                    }
                }

                //Print End Of Turn Summary:
                DebugWrite($"Your hand is " +
                    $"{
                    String.Join(
                        ',',
                        gameInstance
                            .GetDeckHand()
                            .Select(
                                x => x.cardAction.actionTitle
                            )
                            .ToArray()
                    )}", 
                    true
                );
                DebugWrite($"The current Room is "+agent.currentLocation.placeName,
                    true
                );

                //Check If Room Clear, play cards otherwise
                bool canEndTurn = (
                    agent
                    .currentLocation
                    .actorsInPlace
                    .Where(
                        actor => (
                            actor.details.factionType == FactionType.Redfor
                            && actor.isAlive
                        )
                    )
                    .ToList().Count == 0
                );

                while(!canEndTurn)
                {

                    //Get Instruction And End Turn
                    DebugWrite($"Type Your Next Instruction", true);
                    DebugWrite($"The following agents are in the room ", debug);
                    {
                        agent
                        .currentLocation
                        .actorsInPlace
                        .Where( (actor) => actor.isAlive)
                        .ToList()
                        .ForEach((actor) => {

                            DebugWrite($"{actor.details.actorName}, Faction : {actor.details.factionType}", debug);
                        });
                    }
                    DebugWrite(
                        $"Your hand is " +
                        $"{String.Join(
                            ',',
                            gameInstance
                                .GetDeckHand()
                                .Select(
                                    x => x.cardAction.actionTitle
                                )
                                .ToArray()
                        )}",
                        true
                    );
                    DebugWrite($"Instruction Is index of target, comma, index of card", true);
                    string nextInstruction = Console.ReadLine();
                    InterpretCommand(CommandTypes.PlayCard, gameInstance, agent, nextInstruction);
                    if(gameInstance.GetDeckHand().Count() == 0)
                    {

                        DebugWrite($"All cards are out, reshuffling", debug);
                        gameInstance.ShuffleAllCardsInDeck();
                        DebugWrite($"New Turn, Drawing {cardsToDraw} cards", true);
                        for (int i = 0; i < cardsToDraw; i++)
                        {
                            var latestCard = gameInstance.DrawACard();
                            if (latestCard != null)
                            {
                                DebugWrite($"You Drew {latestCard.cardAction.actionTitle}", true);
                            }
                            else
                            {
                                DebugWrite($"No Card Drawn", true);
                            }
                        }
                    }
                }

                DebugWrite($"Room Clear, Discarding Hand", true);
                gameInstance.DiscardAllCardsInHand();

                DebugWrite($"Discarded Hand, Hand Count is {gameInstance.GetDeckHand().Count()}", debug);
                DebugWrite($"Enter a RoomToEnter ", true);
                string nextRoomInstruction = Console.ReadLine();
                InterpretCommand(CommandTypes.Movement, gameInstance, agent, nextRoomInstruction);

            }
        }
        public static void DebugWrite(string message, bool debug)
        {
            if (debug)
            {
                Console.WriteLine(message);
            }
        }
        public enum CommandTypes{
            Movement,
            PlayCard
        };

        public static void InterpretCommand(
            CommandTypes type,
            RaidGameInstance gameInstance,
            Actor agent,
            string instruction)
        {
            switch (type)
            {
                case CommandTypes.Movement:
                    int roomIndex = Int32.Parse(instruction);
                    agent.ChangeLocation(gameInstance.places[roomIndex]);

                    DebugWrite($"Entered {gameInstance.places[roomIndex].placeName}", true);
                    if (
                        gameInstance
                        .places[roomIndex].actorsInPlace
                        .Where(
                            actor => actor.details.factionType == FactionType.Redfor
                        )
                        .ToList().Count > 0)
                    {

                        DebugWrite($"Enimes In Room, Adding their actions", true);
                        gameInstance
                        .places[roomIndex].actorsInPlace
                        .Where(
                            actor => actor.details.factionType == FactionType.Redfor
                        )
                        .ToList()
                        .ForEach( (enemy) => {
                            gameInstance.AddCardToDeck(enemy.behaviours[0].cardActionList[0]);
                        });
                        gameInstance.ShuffleAllCardsInDeck();
                    }
                    break;
                case CommandTypes.PlayCard:
                    int targetIndex = Int32.Parse(instruction.Split(',')[0]);
                    int cardIndex = Int32.Parse(instruction.Split(',')[1]);
                    gameInstance.PlayCardInHand(gameInstance.GetDeckHand()[cardIndex], gameInstance.actors[targetIndex]);
                    break;
            }
        }
    }
}
