﻿using System;
using System.Collections.Generic;
using System.Linq;
using PlayingCards.Common.Cards;
using PlayingCards.Common.Visitors;

namespace PlayingCards.Common
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
			return _cards.Pop();
		}

		private void InitialiseCards()
		{
			_cards =
				new Stack<Card>(new[] {Suit.Clubs, Suit.Diamonds, Suit.Hearts, Suit.Spades}
					.SelectMany(suit => Enumerable.Range(1, 13), (suit, value) => new Card(suit, (Value) value))
					.ToArray());
		}
	}
}