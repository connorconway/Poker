using System;
using System.Collections.Generic;
using System.Linq;
using PlayingCards.Common.Cards;

namespace PlayingCards.Common
{
	public class Deck
	{
		private Stack<Card> _cards;

		public Deck()
		{
			InitialiseCards();
		}

		private void InitialiseCards()
		{
			_cards =
				new Stack<Card>(new[] { Suit.Clubs, Suit.Diamonds, Suit.Hearts, Suit.Spades }
					.SelectMany(suit => Enumerable.Range(1, 13), (suit, value) => new Card(suit, (Value)value))
					.ToArray());
		}

		public void Shuffle()
		{
			var values = _cards.ToArray();
			_cards.Clear();
			var r = new Random();
			foreach (var value in values.OrderBy(x => r.Next()))
				_cards.Push(value);
		}

		public Card Draw() => _cards.Pop();

		//TODO Used in tests. Refactor out using visitor pattern??
		public int Count => _cards.Count;
		public bool Unique => _cards.Count == _cards.Distinct().Count();
		public List<Card> Cards => _cards.ToList();
	}
}