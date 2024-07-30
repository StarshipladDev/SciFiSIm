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
        public Grid grid;
        public RaidGameInstance(int gridSize = 5)
        {
            this.places = new List<Place>();
            this.actors = new List<Actor>();
            this.cardDeck = new Deck(new List<Card>(), this);
            this.grid = new Grid(gridSize,gridSize);

        }
        public void AddNewPlace(string placeName)
        {
            this.grid.PlaceObject(placeName);
        }
        public List<Card> GetDeckHand()
        {
            return this.cardDeck.cardsInHand;
        }
        public Stack<Card> GetUnplayedCards()
        {
            return this.cardDeck.unplayedCards;
        }
        public Card? DrawACard()
        {
            return this.cardDeck.DrawACard();
        }
        public void SetDeck(List<Card> cardList)
        {
            this.cardDeck.SetUpDeck(cardList);
        }
        public void AddCardToHand(Card cardToAdd)
        {
            this.cardDeck.allCardsInDeck.Add(cardToAdd);
            this.cardDeck.cardsInHand.Add(cardToAdd); ;
        }
        public void AddCardToDeck(Card cardToAdd)
        {
            this.cardDeck.allCardsInDeck.Add(cardToAdd);
        }
        public void PlayCardInHand(Card cardPlayed, Actor? targetedActor)
        {
            this.cardDeck.PlayACard(cardPlayed, targetedActor);
        }

        public void DiscardAllCardsInHand()
        {
            List<Card> cardsToRemove = new List<Card>();
            foreach (Card card in this.cardDeck.cardsInHand)
            {
                cardsToRemove.Add(card);
            }
            cardsToRemove.ForEach((card) =>
            {
                DiscardCardInHand(card);
            });
        }
        public void DiscardCardInHand(Card cardToDiscard)
        {
            this.cardDeck.DiscardACardFromHand(cardToDiscard);
        }
        public void ShuffleAllCardsInDeck()
        {
            this.cardDeck.SetUpDeck(this.cardDeck.allCardsInDeck);
            this.cardDeck.ShuffleDeck();
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
