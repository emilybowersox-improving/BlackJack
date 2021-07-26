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
            int playerHandCount = 0;

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

                List<Card> dealerHand = new List<Card>()
                {
                    new Card() {Number = fullDeck[0].Number, Suit = fullDeck[0].Suit },
                    new Card() {Number = fullDeck[1].Number, Suit = fullDeck[1].Suit }
                };

                List<Card> playerHand = new List<Card>()
                {
                    new Card() {Number = fullDeck[2].Number, Suit = fullDeck[2].Suit },
                    new Card() {Number = fullDeck[3].Number, Suit = fullDeck[3].Suit }
                };

                //// working on converting from variables to Lists for dealer and player hands 


 /*               var dealerCard1 = fullDeck[0];
                var dealerCard2 = fullDeck[1];
                var playerHand1 = fullDeck[2];
                var playerHand2 = fullDeck[3];*/

                Console.WriteLine("Dealer:");
                Console.WriteLine($"{dealerHand[0].Number} {dealerHand[0].Suit}, {dealerHand[1].Number} {dealerHand[1].Suit}");

                Console.WriteLine("Player:");
                Console.WriteLine($"{playerHand[0].Number} {playerHand[0].Suit}, {playerHand[1].Number} {playerHand[1].Suit}");

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
                        var newPlayerCard = fullDeck[0];
                        playerHand.Add(newPlayerCard);
                        Console.WriteLine("Here is your new hand:");
                        for(int i = 0; i < playerHand.Count(); i++)
                        {
                            Console.WriteLine($"{playerHand[i].Number} {playerHand[i].Suit}");
                        }
                        fullDeck.RemoveAt(0);
                        Console.WriteLine(fullDeck.Count());

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


                int dealerHandCount = dealerHand[0].Number + dealerHand[1].Number;
                Console.WriteLine($"Dealer hand count: {dealerHandCount}");

                for (int i = 0; i < playerHand.Count(); i++)
                {
                    playerHandCount += playerHand[i].Number;
                }
               /* int playerHandCount = playerHand[0].Number + playerHand[1].Number;*/
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

