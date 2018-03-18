using System.Collections.Generic;
using System.Linq;
using PlayingCards.Common.Cards;
using PlayingCards.Common.Visitors;

namespace PlayingCards.Common.Tests.Visitors
{
	public class CardTestVisitor : Visitor
	{
		private readonly List<Card> _cards = new List<Card>();

		public override void Visit(Card card)
		{
			_cards.Add(card);
		}

		public int Count => _cards.Count;
		public int UniqueCount => _cards.Distinct().Count();
		public List<Card> Cards => _cards;
	}
}