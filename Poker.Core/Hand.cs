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
			if (_cards.Count == 5)
				throw new InvalidOperationException("Hand can not exceed five cards");
			_cards.Add(c);
		}

		public bool HasHoOfKind(int i)
		{
			foreach (var card in _cards)
			{
				if (_cards.Count(c => c.Value.Equals(card.Value)) == i)
					return true;
			}

			return false;
		}

		public bool HasTwoPair()
		{
			var cardGroups = _cards.GroupBy(card => card.Value).Where(group => group.Count() == 2);
			return cardGroups.Count() == 2;
		}
	}
}