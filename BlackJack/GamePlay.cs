using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class GamePlay
    {
/*        List<Card> cards = new List<Card>();*/

        public List<Card> FullDeck()
        {
            List<Card> cards = new List<Card>();

            cards = Enumerable.Range(1, 4).SelectMany(s => Enumerable.Range(1, 13).Select(c => new Card()
            {
                Suit = (Suit)s,
                Number = (Number)c
            }
                ))
                .ToList();

            var allNumbers = (Number[])Enum.GetValues(typeof(Number));
            var allSuits = (Suit[])Enum.GetValues(typeof(Suit));
            var fullDeck = allSuits.SelectMany(x => allNumbers.Select(y => new Card { Suit = x, Number = y })).ToList();

            return (fullDeck);
        }

        public List<Card> ShuffledDeck()
        {
            List<Card> shuffledDeck = FullDeck();

            shuffledDeck = shuffledDeck.OrderBy(c => Guid.NewGuid())
                       .ToList();

            return (shuffledDeck);
        }










    }
}
