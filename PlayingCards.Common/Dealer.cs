using PlayingCards.Common.Cards;
using PlayingCards.Common.Piles;
using PlayingCards.Common.Visitors;

namespace PlayingCards.Common
{
	public class Dealer : IVisitable
	{
		private readonly Deck _deck = new Deck();
		private readonly Discard _discard = new Discard();

		public void ShuffleDeck()
		{
			_deck.Shuffle();
		}

		public Hand CreateHand() => new Hand();

		public Card DealCard()
		{
			if (!_deck.AnyCardsLeft())
			{
				_deck.ReShuffle();
				_discard.Reset();
			}
			return _deck.Draw();
		}

		public void Accept(Visitor visitor)
		{
			_deck.Accept(visitor);
		}

		public void Accept(DiscardPileVisitor visitor)
		{
			_discard.Accept(visitor);
		}

		public void Discard(Card card)
		{
			_discard.Add(card);
		}
	}
}