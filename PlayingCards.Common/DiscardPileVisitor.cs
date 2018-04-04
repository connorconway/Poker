using System.Collections.Generic;
using PlayingCards.Common.Cards;
using PlayingCards.Common.Visitors;

namespace PlayingCards.Common
{
	public class DiscardPileVisitor : Visitor
	{
		private readonly Stack<Card> _cards = new Stack<Card>();

		public override void Visit(Card card)
		{
			_cards.Push(card);
		}

		public Stack<Card> Result() => _cards;
	}
}