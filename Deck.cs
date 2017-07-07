using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack2
{
    public enum FaceEnum
    {
        Ace = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King
    }

    class Deck
    {

        public List<Card> Cards { get; set; }

        public Deck()
        {
            Cards = new List<Card>();

            List<string> suits = new List<string> { "Hearts", "Diamonds", "Clubs", "Spades" };
            var faces = Enum.GetValues(typeof(FaceEnum));

            foreach (var suit in suits)
            {
                foreach (var face in faces)
                {
                    Cards.Add(new Card(suit, face.ToString(), (int)face));
                }

            }
            FixCardValues();
            Shuffle();
     }


     public void Shuffle()
         {
            Random rand = new Random();
            int n = Cards.Count;
            while (n > 1)
            {
                n--;
                int k = rand.Next(n + 1);
                var value = Cards[k];
                Cards[k] = Cards[n];
                Cards[n] = value;
            }
         }

     private void FixCardValues()
        {
            foreach (var card in Cards)
            {
                if(card.Value > 10)
                {
                    card.Value = 10;
                }
                if (card.Value == 1)
                {
                    card.Value = 11;
                }
            }
        }

        public List<Card> DealCards(int numOfCardsToDeal)
        {
            List<Card> cards = new List<Card>(); 
            for (int i = 0; i < numOfCardsToDeal; i++) 
            {
                cards.Add(Cards[0]); 
                Cards.RemoveAt(0);
            }
            return cards;
        }

        public void ShowDeck()
        {
            Console.WriteLine("Card Count = " + Cards.Count + " Cards \n"); 
            foreach (var card in Cards)
            {
                Console.WriteLine(card.Face + " of " + card.Suit + " (" + card.Value + ")");
            }
        }
    }
}
   