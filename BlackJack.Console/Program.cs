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

            var deck = gamePlay.ShuffleDeck();
            foreach (var card in deck)
            Console.WriteLine($"{card.Number} {card.Suit}");




 



            Console.ReadLine();
        }
    }
}

