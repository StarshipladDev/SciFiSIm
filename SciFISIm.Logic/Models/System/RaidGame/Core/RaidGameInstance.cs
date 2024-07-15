using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Logic.Models.System.RaidGame.Core
{
    public class RaidGameInstance
    {
        public List<Place> places;
        public List<Actor> actors;
        Deck cardDeck;
        public RaidGameInstance()
        {
            this.places = new List<Place>();
            this.actors = new List<Actor>();
            this.cardDeck = new Deck(new List<Card>());

        }
        public List<Card> GetDeckHand()
        {
            return this.cardDeck.cardsInHand;
        }
        public Stack<Card> GetUnplayedCards()
        {
            return this.cardDeck.currentDeck;
        }
        public void DrawACard()
        {
            this.cardDeck.DrawACard();
        }
        public void SetDeck(List<Card> cardList)
        {
            this.cardDeck.SetUpDeck(cardList);
        }
        public string PlayCardInHand(Card cardPlayed, Actor actor)
        {
            this.cardDeck.PalyACard(cardPlayed);
            string replytext = "";
            replytext += $"In response to your " + cardPlayed.cardAction.actionTitle + " an actor " + actor.behaviours[0].actionList[0].actionTitle+"\n";

            return replytext;
        }
    }
}
