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
     /*       Stack<Card> fullDeck = new Stack<Card>();
            for (int i = 1; i <= 13; i++)
            {
                fullDeck.Push(new Card() { Suit = "Heart", Number = i });
                fullDeck.Push(new Card() { Suit = "Diamond", Number = i });
                fullDeck.Push(new Card() { Suit = "Club", Number = i });
                fullDeck.Push(new Card() { Suit = "Spade", Number = i });
            }

            foreach (var card in fullDeck)
                Console.WriteLine($"{card.Number} {card.Suit}");*/


            List<Card> fullDeck = new List<Card>();
            for (int i = 1; i <= 13; i++)
            {
                fullDeck.Add(new Card() { Suit = "Heart", Number = i });
                fullDeck.Add(new Card() { Suit = "Diamond", Number = i });
                fullDeck.Add(new Card() { Suit = "Club", Number = i });
                fullDeck.Add(new Card() { Suit = "Spade", Number = i });
            }
    /*        foreach (var card in fullDeck)
                Console.WriteLine($"{card.Number} {card.Suit}");*/

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
            /*      Console.WriteLine(fullDeck.Count());*/

            Console.WriteLine("___________________");
            Console.WriteLine();

            /*          Console.WriteLine("Would you like to stay or hit?");
                      var userReponse = Console.ReadLine();*/
            string userResponse = "";

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

         

   




 









            Console.ReadLine();
        }
    }
}

