using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack2
{
    class Hand
    {
        public List<Card> Cards
        {
            get; set;
        }

        private int cardValues;
        public int CardValues { get { return cardValues; } }

        public Hand(List<Card> cards, int cardValues = 0)
        {
            this.cardValues = cardValues;
            Cards = cards;
            if (cardValues > 21)
                checkForAce();
            var currentHandValue = DisplayHand();
        }

        public void Hit(Card card)
        {
            Cards.Add(card);// make a new property like total score, adding card to hand adds total to hand
            DisplayHand();
        }

        private void checkForAce()
        {
            foreach (Card card in Cards)
            {
                if(card.Suit == "Ace")
                {
                    card.Value = 1;
                }
            }
        }

        public int DisplayHand()
        {
            int handValue = 0;
            foreach (var card in Cards)
            {
                Console.Write(card.Face + " of " + card.Suit + " ");
                handValue = handValue + card.Value;
            }
            cardValues = handValue;
            Console.WriteLine(" = " + handValue);
             
            return handValue;
        }

    }
}




