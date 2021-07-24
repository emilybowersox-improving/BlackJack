using System;
using System.Linq;
using BlackJack;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var gamePlay = new GamePlay();

            /*          var deck = gamePlay.GenerateDeck();
                        foreach (var card in deck)
                        Console.WriteLine($"{card.Number} {card.Suit}");*/

            /*            var deck = gamePlay.ShuffleDeck();
                        foreach (var card in deck)
                        Console.WriteLine($"{card.Number} {card.Suit}");*/

            var deck = gamePlay.DealHands();

            Console.WriteLine("Dealer:");
            Console.WriteLine($"{deck[0].Number} {deck[0].Suit}, {deck[1].Number} {deck[1].Suit}");

            Console.WriteLine("Player:");
            Console.WriteLine($"{deck[2].Number} {deck[2].Suit}, {deck[3].Number} {deck[3].Suit}");
           






            Console.ReadLine();
        }
    }
}

