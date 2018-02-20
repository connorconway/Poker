using System;
using System.Collections.Generic;
using Poker.Core.Cards;

namespace Poker.Core
{
	public class Hand
	{
		private readonly List<Card> _cards = new List<Card>();
		public double Count => _cards.Count;

		public void Add(Card c)
		{
			if (_cards.Count == 2)
				throw new InvalidOperationException("Hand can not exceed two cards");
			_cards.Add(c);
		}
	}
}