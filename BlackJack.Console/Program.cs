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
            var fullDeck = gamePlay.FullDeck();

            foreach (var card in fullDeck)
                Console.WriteLine($"{card.Number} {card.Suit}");





            Console.ReadLine();
            }
        }
    }

