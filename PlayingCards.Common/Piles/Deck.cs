using System;
using System.Collections.Generic;
using System.Linq;
using PlayingCards.Common.Cards;
using PlayingCards.Common.Exceptions;
using PlayingCards.Common.Visitors;

namespace PlayingCards.Common.Piles
{
	public class Deck : IVisitable
	{
		private Stack<Card> _cards;

		public Deck()
		{
			InitialiseCards();
		}

		public void Accept(Visitor visitor)
		{
			_cards.ToList().ForEach(c => c.Accept(visitor));
		}

		public void Shuffle()
		{
			var values = _cards.ToArray();
			_cards.Clear();
			var r = new Random();
			foreach (var value in values.OrderBy(x => r.Next()))
				_cards.Push(value);
		}

		public Card Draw()
		{
			if (_cards.Count == 0)
				throw new OutOfCardsException("There are no cards left in the deck. Unable to draw.");

			return _cards.Pop();
		}

		public bool AnyCardsLeft() => _cards.Count > 0;

		private void InitialiseCards()
		{
			_cards =
				new Stack<Card>(new[] {Suit.Clubs, Suit.Diamonds, Suit.Hearts, Suit.Spades}
					.SelectMany(suit => Enumerable.Range(1, 13), (suit, value) => new Card(suit, (Value) value))
					.ToArray());
		}

		public void ReShuffle()
		{
			InitialiseCards();
			Shuffle();
		}
	}
}