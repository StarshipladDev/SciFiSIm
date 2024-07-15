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
        public List<Card> allCardsAtStart;
        public Stack<Card> currentDeck;
        public List<Card> allCardsPlayed;
        public List<Card> cardsInHand;
        public Deck(List<Card> allCardsAtStart)
        {
            this.allCardsAtStart = allCardsAtStart;
            this.currentDeck = new Stack<Card> ();
            ShuffleDeck(allCardsAtStart);
            allCardsAtStart.ForEach(card =>
            {
                currentDeck.Push (card);
            });
            this.allCardsPlayed = new List<Card>();
            this.cardsInHand = new List<Card>();

        }
        public void SetUpDeck(List<Card> allCardsAtStart)
        {
            this.allCardsAtStart = allCardsAtStart;
            this.currentDeck = new Stack<Card>();
            ShuffleDeck(allCardsAtStart);
            allCardsAtStart.ForEach(card =>
            {
                currentDeck.Push(card);
            });
            this.allCardsPlayed = new List<Card>();
            this.cardsInHand = new List<Card>();
        }

        public void DrawACard()
        {
            if(currentDeck.Count == 0)
            {
                ShuffleDeck(allCardsPlayed);
                allCardsPlayed.ForEach(card =>
                {
                    currentDeck.Push(card);
                });
                allCardsPlayed = new List<Card> (); 
            }

            Card topCard = currentDeck.Pop();
            this.cardsInHand.Add(topCard);
        }

        public void PalyACard(Card cardPlayed)
        {
            this.cardsInHand.Remove(cardPlayed);
            this.allCardsPlayed.Add(cardPlayed);
        }

        private void ShuffleDeck(List<Card> list)
        {
            Random rand = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rand.Next(n + 1);
                Card value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
