using System.Collections.Generic;
using System.Linq;
using PlayingCards.Common.Cards;
using PlayingCards.Common.Visitors;

namespace PlayingCards.Common
{
	public class DiscardPile : IVisitable
	{
		private readonly Stack<Card> _cards;

		public DiscardPile()
		{
			_cards = new Stack<Card>();
		}

		public void Add(Card c)
		{
			_cards.Push(c);
		}

		public void Accept(Visitor visitor)
		{
			_cards.ToList().ForEach(c => c.Accept(visitor));
		}
	}
}