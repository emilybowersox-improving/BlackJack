using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class GamePlay
    {



        public List<Card> GenerateDeck()
        {
            List<Card> fullDeck = new List<Card>();
            for (int i = 1; i <= 13; i++)
            {
                fullDeck.Add(new Card() { Suit = "Heart", Number = i });
                fullDeck.Add(new Card() { Suit = "Diamond", Number = i });
                fullDeck.Add(new Card() { Suit = "Club", Number = i });
                fullDeck.Add(new Card() { Suit = "Spade", Number = i });
            }
            return fullDeck;
        }


        public List<Card> ShuffleDeck()
        {
            List<Card> shuffledDeck = GenerateDeck();
            shuffledDeck = shuffledDeck.OrderBy(c => Guid.NewGuid()).ToList();

            return shuffledDeck;
        }
     



        public List<Card> DealHands()
        {
            List<Card> deck = ShuffleDeck();
            var dealtHands = deck.GetRange(0, 4);

            return dealtHands;
        }









/*        


        public List<Card> DealHands()
        {
            List<Card> shuffledDeck = ShuffleDeck();
            *//*        var dealt = shuffledDeck.Take(4);*//*
            List<Card> dealerHand = new List<Card>();
            var newhand = dealerHand.AddRange(0, 4);

        }*/



    }
}
