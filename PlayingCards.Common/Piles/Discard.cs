using System.Collections.Generic;
using PlayingCards.Common.Cards;
using PlayingCards.Common.Visitors;

namespace PlayingCards.Common.Piles
{
	public class Discard : IVisitable
	{
		private readonly List<Card> _cards = new List<Card>();

		public void Add(Card card)
		{
			_cards.Add(card);
		}

		public void Reset()
		{
			_cards.RemoveAll(c => true);
		}

		public void Accept(Visitor visitor)
		{
			_cards.ForEach(c => c.Accept(visitor));
		}
	}
}