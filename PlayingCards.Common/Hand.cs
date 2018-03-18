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
		public double Count => _cards.Count;
		public List<Card> Cards => _cards;

		public void Add(Card c)
		{
			if (_cards.Count == 5)
				throw new InvalidOperationException("Hand can not exceed five cards");
			_cards.Add(c);
		}


		//TODO These are specific to poker and should not be in playingcards common. Refactor out into poker core dll.
		public bool HasNoOfKind(int i)
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

		public bool HasStraight()
		{
			var orderedCards = _cards.OrderBy(a => a.Value).ToList();
			if (orderedCards.First().Value.Equals(Value.Ace))
			{
				var highStraight = _cards.Count(c => c.Value.Equals(Value.King) || c.Value.Equals(Value.Queen) || c.Value.Equals(Value.Jack) || c.Value.Equals(Value.Ten)) == 4;
				var lowStraight = _cards.Count(c => c.Value.Equals(Value.Two) || c.Value.Equals(Value.Three) || c.Value.Equals(Value.Four) || c.Value.Equals(Value.Five)) == 4;
				if (lowStraight || highStraight)
					return true;
			}
			return orderedCards.Select((i, j) => i.Value - j).Distinct().Skip(1).Count() <= _cards.Count - 5;
		}

		public bool HasFlush()
		{
			return _cards.GroupBy(card => card.Suit).Any(group => group.Count() == 5);
		}

		public void Accept(Visitor visitor)
		{
			visitor.PreVisit(this);
			_cards.ForEach(c => c.Accept(visitor));
			visitor.PostVisit(this);
		}
	}
}