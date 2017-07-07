//Sturcture needed for assignement, classes suchas card has a property of a suit, property is way to describe class.  methods involving how to cordinate game, logic with dealer 
//Dealer needing to be class and score being a property. Score of the dealer is a property of the dealer to desc the dealer. Method on Hit or Stay response. Class for cards neeing a face value.
//Player needing to be instantiated class. Player class needing cards and options to hit or stay score and option to play again or not. Method to deal the card.

using System;
using System.Collections.Generic;
using System.Text;



namespace BlackJack2
{
    class Program
    {
       public static void Main(string[] args)
        {
            Deck deck = new Deck();
            Hand playerOne = new Hand(deck.DealCards(2));
            Hand dealer = new Hand(deck.DealCards(2));
            bool playerBusted = false;
            bool dealerBusted = false;
            bool draw = false;
            bool playerBlackjack = false;
            bool playerWins = false;
            //bool stay = false;

            string input = "";
            do
            {
                Console.WriteLine("Would you like to hit or stay?");
                input = Console.ReadLine();

                if (input == "hit")
                {
                    playerOne.Hit(deck.DealCards(1)[0]);
                    if( dealer.CardValues < 17) 
                    {
                        dealer.Hit(deck.DealCards(1)[0]);
                    }
                }
              
                if (playerOne.CardValues == 21)
                {
                    playerBlackjack = true;
                }
                if (playerOne.CardValues > 21)
                {
                    playerBusted = true;
                }
                if (dealer.CardValues > 21)
                {
                    dealerBusted = true;
                }
                if (dealer.CardValues == playerOne.CardValues)
                {
                    draw = true;
                }
                if (playerOne.CardValues > dealer.CardValues)
                {
                    playerWins = true;
                }
            }

            while (input != "stay" && !playerBusted && !dealerBusted && !draw && !playerBlackjack);

            //Console.WriteLine("Dealers Hand = " + dealer.CardValues);
            //Console.WriteLine("Players Hand = " + playerOne.CardValues);

            if(draw == true)
            {
                Console.WriteLine("Game was a draw... in the game of life there are no winners or loosers, Shall we try again?");
            } 
            else if (playerBusted == true)
            {
                Console.WriteLine("Bust, Care to Try again?");
            } 
            else if (dealerBusted == true)
            {
                Console.WriteLine("Dealer Busted, Shall we try again?");
            }
            else if (playerWins == true)
            {
                Console.WriteLine("PlayeOne has won this round, congratulations are in order, shall we play again?");
            }
            else
            {
                if (dealer.CardValues > playerOne.CardValues)
                    Console.WriteLine("Dealer has won this round, shall we play again?");
                else
                    Console.WriteLine("Player has won this round, shall we play again?");
            }


            Console.WriteLine("Thank you for playing it was entertaining, switchin off...");
            Console.ReadKey();
        }
    }
}  