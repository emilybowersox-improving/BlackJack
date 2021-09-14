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

            string userResponse = "";
            string userWantsToContinue = "";
            decimal userPurse = 15m;

            Console.WriteLine("Welcome to BlackJack!");
            Console.WriteLine("You will be starting off the game with $15 to play with. Every win earns you $5 and every loss costs you $5.");
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
                        fullDeck.Add(new Card() { Suit = "Heart", Number = i, Name = i.ToString(), Value = i });
                        fullDeck.Add(new Card() { Suit = "Diamond", Number = i, Name = i.ToString(), Value = i });
                        fullDeck.Add(new Card() { Suit = "Club", Number = i, Name = i.ToString(), Value = i });
                        fullDeck.Add(new Card() { Suit = "Spade", Number = i, Name = i.ToString(), Value = i });
                    }

                    fullDeck = fullDeck.OrderBy(c => Guid.NewGuid()).ToList();




                List<Card> dealerHand = new List<Card>()
                {
                    new Card() {Number = fullDeck[0].Number, Suit = fullDeck[0].Suit, Name = fullDeck[0].Name, Value = fullDeck[0].Value },
                    new Card() {Number = fullDeck[1].Number, Suit = fullDeck[1].Suit, Name = fullDeck[1].Name, Value = fullDeck[1].Value }
                };

                //transform Face cards 
                for (int i = 0; i < dealerHand.Count(); i++)
                {
                    if (dealerHand[i].Number >= 1 && dealerHand[i].Number <= 10)
                    {
                        continue;
                    }
                    else if (dealerHand[i].Number == 11)
                    {
                        dealerHand[i].Name = "Jack";
                        dealerHand[i].Value = 10;
                    }
                    else if (dealerHand[i].Number == 12)
                    {
                        dealerHand[i].Name = "Queen";
                        dealerHand[i].Value = 10;
                    }
                    else if (dealerHand[i].Number == 13)
                    {
                        dealerHand[i].Name = "King";
                        dealerHand[i].Value = 10;
                    }
                }


                List<Card> playerHand = new List<Card>()
                {
                    new Card() {Number = fullDeck[2].Number, Suit = fullDeck[2].Suit, Name = fullDeck[2].Name, Value = fullDeck[2].Value  },
                    new Card() {Number = fullDeck[3].Number, Suit = fullDeck[3].Suit, Name = fullDeck[3].Name, Value = fullDeck[3].Value  }
                };

                //transform Face cards 
                for (int i = 0; i < playerHand.Count(); i++)
                {
                    if (playerHand[i].Number >= 1 && playerHand[i].Number <= 10)
                    {
                        continue;
                    }
                    else if (playerHand[i].Number == 11)
                    {
                        playerHand[i].Name = "Jack";
                        playerHand[i].Value = 10;
                    }
                    else if (playerHand[i].Number == 12)
                    {
                        playerHand[i].Name = "Queen";
                        playerHand[i].Value = 10;
                    }
                    else if (playerHand[i].Number == 13)
                    {
                        playerHand[i].Name = "King";
                        playerHand[i].Value = 10;
                    }
                }



                Console.WriteLine("Dealer's hand:");
                    Console.WriteLine($"{dealerHand[0].Name} {dealerHand[0].Suit}, ??");
                    Console.WriteLine();
                    Console.WriteLine("Your hand:");
                    Console.WriteLine($"{playerHand[0].Name} {playerHand[0].Suit}, {playerHand[1].Name} {playerHand[1].Suit}");

                    fullDeck.RemoveRange(0, 4);

                    Console.WriteLine("___________________");

                    do
                    {
                        playerHandCount = 0;
                        for (int i = 0; i < playerHand.Count(); i++)
                        {
                            playerHandCount += playerHand[i].Value;
                        }

                        Console.WriteLine();
                        Console.WriteLine("Would you like to stay or hit?");

                        userResponse = Console.ReadLine();
                        if (userResponse == "hit" && playerHandCount <= 21)
                        {
                            var newPlayerCard = fullDeck[0];

                        //transform Face card
                 /*       if (newPlayerCard.Number >= 1 && newPlayerCard.Number <= 10)
                        {
                            newPlayerCard.
                        }*/
                       if (newPlayerCard.Number == 11)
                        {
                            newPlayerCard.Name = "Jack";
                            newPlayerCard.Value = 10;
                        }
                        else if (newPlayerCard.Number == 12)
                        {
                            newPlayerCard.Name = "Queen";
                            newPlayerCard.Value = 10;
                        }
                        else if (newPlayerCard.Number == 13)
                        {
                            newPlayerCard.Name = "King";
                            newPlayerCard.Value = 10;
                        } 
                        
                        playerHand.Add(newPlayerCard);
                            Console.WriteLine("___________________");
                            Console.WriteLine();
                            Console.WriteLine("Here is your new hand:");
                            for (int i = 0; i < playerHand.Count(); i++)
                            {
                                Console.WriteLine($"{playerHand[i].Name} {playerHand[i].Suit}");
                            }
                            fullDeck.RemoveAt(0);
                        }
                        else if (userResponse == "hit" && playerHandCount > 21)
                        {
                            Console.WriteLine("You've already gone over 21!");
                            Console.WriteLine();
                            break;
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
                        dealerHandCount += dealerHand[i].Value;
                    }

                    if (dealerHandCount < 17)
                    {
                        do
                        {
                            var newDealerCard = fullDeck[0];
                            //transform Face card
                            if (newDealerCard.Number >= 1 && newDealerCard.Number <= 10)
                            {
                                continue;
                            }
                            else if (newDealerCard.Number == 11)
                            {
                                newDealerCard.Name = "Jack";
                                newDealerCard.Value = 10;
                            }
                            else if (newDealerCard.Number == 12)
                            {
                                newDealerCard.Name = "Queen";
                                newDealerCard.Value = 10;
                            }
                            else if (newDealerCard.Number == 13)
                            {
                                newDealerCard.Name = "King";
                                newDealerCard.Value = 10;
                            }


                            dealerHand.Add(newDealerCard);
                            fullDeck.RemoveAt(0);
                            dealerHandCount = 0;
                            for (int i = 0; i < dealerHand.Count(); i++)
                            {
                                dealerHandCount += dealerHand[i].Value;
                            }
                        } while (dealerHandCount < 17);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Here was the dealer's final hand:");
                    for (int i = 0; i < dealerHand.Count(); i++)
                    {
                        Console.WriteLine($"{dealerHand[i].Name} {dealerHand[i].Suit}");
                    }
                    Console.WriteLine();



                    // possible hand outcomes
                    if (playerHandCount == 21 && dealerHandCount != 21)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"Congrats! Your scored a blackjack with your total of {playerHandCount}!");
                        Console.ResetColor();
                        userPurse += 7.5m;
                    }
                    else if (dealerHandCount == 21 && playerHandCount != 21)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Better luck next time- you scored {playerHandCount} but the dealer scored a Blackjack with {dealerHandCount}.");
                        Console.ResetColor();
                        userPurse -= 5m;
                    }
                    else if (playerHandCount <= 21 && dealerHandCount > 21)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"You win! The dealer busted with a total of {dealerHandCount} while your total was {playerHandCount}.");
                        Console.ResetColor();
                        userPurse += 5;
                    }
                    else if (dealerHandCount <= 21 && playerHandCount <= 21 && (dealerHandCount > playerHandCount))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Looks like you got beat, better luck next time. The dealer's total was {dealerHandCount} and your total was {playerHandCount}.");
                        Console.ResetColor();
                        userPurse -= 5m;
                    }
                    else if (dealerHandCount <= 21 && playerHandCount <= 21 && (dealerHandCount < playerHandCount))
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"Way to beat the dealer! The dealer's total was {dealerHandCount} but your total was {playerHandCount}.");
                        Console.ResetColor();
                        userPurse += 5;
                    }
                    else if (dealerHandCount <= 21 && playerHandCount <= 21 && (dealerHandCount == playerHandCount))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"It's a draw! The dealer's total was {dealerHandCount} and your total was also {playerHandCount}.");
                        Console.ResetColor();
                    }
                    else if (playerHandCount > 21)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Busted! You went over 21 with a score of {playerHandCount}. The dealer's total was {dealerHandCount}.");
                        Console.ResetColor();
                        userPurse -= 5m;
                    }
                    else
                    {
                        Console.WriteLine($"I haven't been programmed to handle this kind of scenario yet! But the dealer's total was {dealerHandCount} and your total was {playerHandCount}.");
                    }

                    Console.WriteLine("___________________");
                    Console.WriteLine();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"You currently have ${userPurse} remaining.");
                    Console.ResetColor();

                    Console.WriteLine();
                    Console.WriteLine("Would you like to play again? If not, type 'exit' to leave.");
                    userWantsToContinue = Console.ReadLine();
                    Console.WriteLine("___________________");
                    Console.WriteLine();

                } while (userWantsToContinue != "exit" && userPurse > 0);

                if (userPurse < 5)
                {
                    Console.WriteLine("Sorry you don't have enough money to continue playing, wouldn't want you to take on debts! Bye for now.");
                    Console.ReadLine();
                  
                } else if (userWantsToContinue == "exit")
                {
                    Console.WriteLine("Goodbye");
                    Console.ReadLine();
                }
        
               


    
        }
    }
}

