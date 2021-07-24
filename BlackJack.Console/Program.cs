using System;
using System.Collections.Generic;
using System.Linq;
using BlackJack;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var gamePlay = new GamePlay();

            string userResponse = "";
            string userWantsToContinue = "";

            do
            {
                List<Card> fullDeck = new List<Card>();
                for (int i = 1; i <= 13; i++)
                {
                    fullDeck.Add(new Card() { Suit = "Heart", Number = i });
                    fullDeck.Add(new Card() { Suit = "Diamond", Number = i });
                    fullDeck.Add(new Card() { Suit = "Club", Number = i });
                    fullDeck.Add(new Card() { Suit = "Spade", Number = i });
                }

                fullDeck = fullDeck.OrderBy(c => Guid.NewGuid()).ToList();

                /*       foreach (var card in fullDeck)
                           Console.WriteLine($"{card.Number} {card.Suit}");*/

                var dealerCard1 = fullDeck[0];
                var dealerCard2 = fullDeck[1];
                var playerHand1 = fullDeck[2];
                var playerHand2 = fullDeck[3];

                Console.WriteLine("Dealer:");
                Console.WriteLine($"{dealerCard1.Number} {dealerCard1.Suit}, {dealerCard2.Number} {dealerCard2.Suit}");

                Console.WriteLine("Player:");
                Console.WriteLine($"{playerHand1.Number} {playerHand1.Suit}, {playerHand2.Number} {playerHand2.Suit}");

                fullDeck.RemoveRange(0, 4);
                Console.WriteLine(fullDeck.Count());

                Console.WriteLine("___________________");
                Console.WriteLine();

                do
                {
                    Console.WriteLine("Would you like to stay or hit?");
                    userResponse = Console.ReadLine();
                    if (userResponse == "hit")
                    {
                        var playerCard3 = fullDeck[0];
                        Console.WriteLine($"Your hand is now {playerCard3.Number} {playerCard3.Suit}, {playerHand1.Number} {playerHand1.Suit}, {playerHand2.Number} {playerHand2.Suit}");
                    }
                    else if (userResponse == "stay")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Sorry i didn't understand that");
                    }
                } while (userResponse != "stay");


                int dealerHandCount = dealerCard1.Number + dealerCard2.Number;
                Console.WriteLine($"Dealer hand count: {dealerHandCount}");
                int playerHandCount = playerHand1.Number + playerHand2.Number;
                Console.WriteLine($"Player hand count: {playerHandCount}");

                if (playerHandCount <= 21 && dealerHandCount > 21)
                {
                    Console.WriteLine($"You win! The dealer busted with a total of {dealerHandCount} and your total was {playerHandCount}");
                }
                else if (dealerHandCount <= 21 && playerHandCount <= 21 && (dealerHandCount > playerHandCount))
                {
                    Console.WriteLine($"Looks like you got beat, better luck next time. The dealer's hand total was {dealerHandCount} and your total was {playerHandCount}");
                }
                else if (dealerHandCount <= 21 && playerHandCount <= 21 && (dealerHandCount < playerHandCount))
                {
                    Console.WriteLine($"Way to beat the dealer! The dealer's hand total was {dealerHandCount} and your total was {playerHandCount}");
                }
                else if (dealerHandCount <= 21 && playerHandCount <= 21 && (dealerHandCount == playerHandCount))
                {
                    Console.WriteLine($"It's a draw! The dealer's hand total was {dealerHandCount} and your total was also {playerHandCount}");
                } 
                else if (playerHandCount > 21)
                {
                    Console.WriteLine($"Busted! You went over 21 with a score of {playerHandCount}. The dealer's hand total was {dealerHandCount}.");
                }
                else
                {
                    Console.WriteLine($"I haven't been programmed to handle this kind of scenario yet! But the dealer's hand total was {dealerHandCount} and your total was also {playerHandCount}");
                }


                Console.WriteLine("Would you like to play again? If so, type 'yes'");
                userWantsToContinue = Console.ReadLine();
                Console.WriteLine("___________________");

            } while (userWantsToContinue == "yes");












            Console.WriteLine("Goodbye");
            Console.ReadLine();
        }
    }
}

