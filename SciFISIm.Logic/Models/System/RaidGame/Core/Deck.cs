using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SciFiSim.Logic.Models.System.RaidGame.Core
{
    public class Deck
    {
        public List<Card> allCardsInDeck;
        public List<Card> playedCards;
        public Stack<Card> unplayedCards;
        public List<Card> cardsInHand;
        public RaidGameInstance instance;
        public Deck(List<Card> allCardsAtStart, RaidGameInstance instance)
        {
            this.allCardsInDeck = allCardsAtStart;
            this.unplayedCards = new Stack<Card> ();
            ShuffleDeck();
            allCardsAtStart.ForEach(card =>
            {
                unplayedCards.Push (card);
            });
            this.cardsInHand = new List<Card>();
            this.playedCards = new List<Card>();
            this.instance = instance;

        }
        public void SetUpDeck(List<Card> allCardsAtStart)
        {
            this.allCardsInDeck = allCardsAtStart;
            this.unplayedCards = new Stack<Card>();
            allCardsAtStart.ForEach(card =>
            {
                unplayedCards.Push(card);
            });
            ShuffleDeck();
            this.cardsInHand = new List<Card>();
            this.playedCards = new List<Card>();
        }

        public Card? DrawACard()
        {
            if(unplayedCards.Count == 0)
            {
                this.playedCards.ForEach(card =>
                {
                    unplayedCards.Push(card);
                });
                this.playedCards = new List<Card> ();
                ShuffleDeck();
            }
            if (unplayedCards.Count != 0)
            {
                Card topCard = unplayedCards.Pop();
                this.cardsInHand.Add(topCard);
                return topCard;
            }
            return null;
        }

        public void PlayACard(Card cardPlayed, Actor? targetedActor )
        {
            this.cardsInHand.Remove(cardPlayed);
            this.playedCards.Add(cardPlayed);
            cardPlayed.cardAction.PreformAction(this.instance,targetedActor);
        }
        public void DiscardACardFromHand(Card cardToDiscard)
        {
            this.cardsInHand.Remove(cardToDiscard);
            this.playedCards.Add(cardToDiscard);
        }

        public void ShuffleDeck()
        {
            List<Card> cards = this.unplayedCards.ToList();
            Random rand = new Random();
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = rand.Next(n + 1);
                Card value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }

            unplayedCards = new Stack<Card>();
            cards.ForEach(card =>
            {
                unplayedCards.Push(card);
            });
        }
    }
}
