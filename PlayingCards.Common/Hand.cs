using System;
using System.Collections.Generic;
using System.Linq;
using PlayingCards.Common.Cards;
using PlayingCards.Common.Visitors;

namespace PlayingCards.Common
{
	public class Hand : IVisitable
	{
		private readonly List<Card> _cards = new List<Card>();

		public void Add(Card c)
		{
			if (_cards.Count == 5)
				throw new InvalidOperationException("Hand can not exceed five cards");
			_cards.Add(c);
		}

		public void Accept(Visitor visitor)
		{
			_cards.ForEach(c => c.Accept(visitor));
		}


		//TODO These are specific to poker and should not be in playingcards common. Refactor out into poker core dll.
		public bool HasNoOfKind(int i)
		{
			foreach (var card in _cards)
			{
				if (_cards.Count(c => c.Value == card.Value) == i)
					return true;
			}
			return false;
		}

		public bool HasTwoPair()
		{
			var cardGroups = _cards.GroupBy(card => card.Value).Where(group => group.Count() == 2);
			return cardGroups.Count() == 2;
		}

		public bool HasStraight()
		{
			var orderedCards = _cards.OrderBy(a => a.Value).ToList();
			if (orderedCards.First().Value == Value.Ace)
			{
				var highStraight = _cards.Count(c => c.Value == Value.King || c.Value == Value.Queen || c.Value == Value.Jack || c.Value == Value.Ten) == 4;
				var lowStraight = _cards.Count(c => c.Value == Value.Two || c.Value == Value.Three || c.Value == Value.Four || c.Value == Value.Five) == 4;
				if (lowStraight || highStraight)
					return true;
			}
			return orderedCards.Select((i, j) => i.Value - j).Distinct().Skip(1).Count() <= _cards.Count - 5;
		}

		public bool HasFlush()
		{
			return _cards.GroupBy(card => card.Suit).Any(group => group.Count() == 5);
		}
	}
}