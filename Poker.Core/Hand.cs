using System;
using System.Collections.Generic;
using System.Linq;
using Poker.Core.Cards;
using Poker.Core.Categorisers;

namespace Poker.Core
{
	public class Hand
	{
		private readonly List<Card> _cards = new List<Card>();
		public double Count => _cards.Count;

		public HandRank Rank => HandCategoriserChain.GetRank(this);

		public void Add(Card c)
		{
			if (_cards.Count == 2)
				throw new InvalidOperationException("Hand can not exceed two cards");
			_cards.Add(c);
		}

		public bool HasHoOfKind(int i)
		{
			foreach (var card in _cards)
			{
				return _cards.Count(c => c.Value.Equals(card.Value)) == i;
			}

			return false;
		}
	}
}