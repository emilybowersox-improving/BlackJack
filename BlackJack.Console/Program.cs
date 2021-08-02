﻿using System;
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

            Console.WriteLine("Welcome to BlackJack!");
            Console.WriteLine("You will be starting off the game with $100 to play with. Every win earns you $5 and every loss costs you $5.");
            Console.WriteLine("However, everytime you score a BlackJack (21) you earn $7.50. Ready to play?");
            Console.ReadLine();
            Console.WriteLine("___________________");
            Console.WriteLine();


            do
            {
                int playerHandCount = 0;
                int dealerHandCount = 0;
                List<Card> fullDeck = new List<Card>();
                for (int i = 1; i <= 13; i++)
                {
                    fullDeck.Add(new Card() { Suit = "Heart", Number = i });
                    fullDeck.Add(new Card() { Suit = "Diamond", Number = i });
                    fullDeck.Add(new Card() { Suit = "Club", Number = i });
                    fullDeck.Add(new Card() { Suit = "Spade", Number = i });
                }

                fullDeck = fullDeck.OrderBy(c => Guid.NewGuid()).ToList();


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



                Console.WriteLine("Dealer's hand:");
                Console.WriteLine($"{dealerHand[0].Number} {dealerHand[0].Suit}, ??");

                Console.WriteLine("Your hand:");
                Console.WriteLine($"{playerHand[0].Number} {playerHand[0].Suit}, {playerHand[1].Number} {playerHand[1].Suit}");

                fullDeck.RemoveRange(0, 4);
          /*      Console.WriteLine(fullDeck.Count());*/

                Console.WriteLine("___________________");

                do
                {
                    Console.WriteLine();
                    Console.WriteLine("Would you like to stay or hit?");
                    userResponse = Console.ReadLine();
                    if (userResponse == "hit")
                    {
                        var newPlayerCard = fullDeck[0];
                        playerHand.Add(newPlayerCard);
                        Console.WriteLine("___________________");
                        Console.WriteLine();
                        Console.WriteLine("Here is your new hand:");
                        for(int i = 0; i < playerHand.Count(); i++)
                        {
                            Console.WriteLine($"{playerHand[i].Number} {playerHand[i].Suit}");
                        }
                        fullDeck.RemoveAt(0);
                       /* Console.WriteLine(fullDeck.Count());*/

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



                // one the User decides to 'stay', time for the dealer to stay or hit
                for (int i = 0; i < dealerHand.Count(); i++)
                {
                    dealerHandCount += dealerHand[i].Number;
                }

                if (dealerHandCount < 17) { 
                do
                {
                    var newDealerCard = fullDeck[0];
                    dealerHand.Add(newDealerCard);
                    fullDeck.RemoveAt(0);
            /*        Console.WriteLine($"Remaining number of cards in the deck is: { fullDeck.Count()}");*/
                        dealerHandCount = 0;
                    for (int i = 0; i < dealerHand.Count(); i++)
                    {
                        dealerHandCount += dealerHand[i].Number;
                    }
                } while (dealerHandCount < 17);
                } 
                
                    Console.WriteLine();
                    Console.WriteLine("Here was the dealer's final hand:");
                for (int i = 0; i < dealerHand.Count(); i++)
                {
                    Console.WriteLine($"{dealerHand[i].Number} {dealerHand[i].Suit}");
                }
                    Console.WriteLine();



                    //Calculate Player Hand total and display both Player and Dealer Hand totals
                    /*                Console.WriteLine($"Here was the dealer's total hand: {dealerHand[0].Number} {dealerHand[0].Suit}, Mystery Card");*/

                    for (int i = 0; i < playerHand.Count(); i++)
                {
                    playerHandCount += playerHand[i].Number;
                }

      /*          Console.WriteLine($"Your final card count: {playerHandCount}");
                Console.WriteLine($"The dealer's final card count: {dealerHandCount}");
                Console.WriteLine();*/


                if (playerHandCount == 21 && dealerHandCount != 21)
                {
                    Console.WriteLine($"Congrats! Your scored a blackjack with your total of {playerHandCount}!");
                } 
                else if (dealerHandCount == 21 && playerHandCount != 21) {
                    Console.WriteLine($"Better luck next time- you scored {playerHandCount} but the dealer scored a Blackjack with {dealerHandCount}.");
                }
                else if (playerHandCount <= 21 && dealerHandCount > 21)
                {
                    Console.WriteLine($"You win! The dealer busted with a total of {dealerHandCount} while your total was {playerHandCount}.");
                }
                else if (dealerHandCount <= 21 && playerHandCount <= 21 && (dealerHandCount > playerHandCount))
                {
                    Console.WriteLine($"Looks like you got beat, better luck next time. The dealer's total was {dealerHandCount} and your total was {playerHandCount}.");
                }
                else if (dealerHandCount <= 21 && playerHandCount <= 21 && (dealerHandCount < playerHandCount))
                {
                    Console.WriteLine($"Way to beat the dealer! The dealer's total was {dealerHandCount} but your total was {playerHandCount}.");
                }
                else if (dealerHandCount <= 21 && playerHandCount <= 21 && (dealerHandCount == playerHandCount))
                {
                    Console.WriteLine($"It's a draw! The dealer's total was {dealerHandCount} and your total was also {playerHandCount}.");
                } 
                else if (playerHandCount > 21)
                {
                    Console.WriteLine($"Busted! You went over 21 with a score of {playerHandCount}. The dealer's total was {dealerHandCount}.");
                }
                else
                {
                    Console.WriteLine($"I haven't been programmed to handle this kind of scenario yet! But the dealer's total was {dealerHandCount} and your total was {playerHandCount}.");
                }

                Console.WriteLine("___________________");
                Console.WriteLine();
                Console.WriteLine("Would you like to play again? If so, type 'yes'");
                userWantsToContinue = Console.ReadLine();
                Console.WriteLine("___________________");
                Console.WriteLine();

            } while (userWantsToContinue == "yes");




            Console.WriteLine("Goodbye");
            Console.ReadLine();
        }
    }
}

