using System.Collections.Generic;
using PlayingCards.Common.Cards;

namespace PlayingCards.Common.Visitors
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

	public class DeckPileVisitor : Visitor
	{
		private readonly Stack<Card> _cards = new Stack<Card>();

		public override void Visit(Card card)
		{
			_cards.Push(card);
		}

		public Stack<Card> Result() => _cards;
	}
}