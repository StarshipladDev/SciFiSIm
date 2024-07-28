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
            this.cardDeck = new Deck(new List<Card>(),this);

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
        public void AddCardToHand(Card cardToAdd)
        {
            this.cardDeck.cardsInHand.Add(cardToAdd); ;
        }
        public void PlayCardInHand(Card cardPlayed, Actor? targetedActor)
        {
            this.cardDeck.PlayACard(cardPlayed, targetedActor);
        }
        public string PrintCardNamesInHand()
        {
            string returnString = "";
            foreach (Card card in cardDeck.cardsInHand)
            {
                returnString = card.cardAction.actionTitle + "|";
            }
            return returnString;
        }
    }
}
