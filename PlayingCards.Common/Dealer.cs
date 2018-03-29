using PlayingCards.Common.Cards;
using PlayingCards.Common.Exceptions;

namespace PlayingCards.Common
{
	public class Dealer
	{
		private readonly Deck _deck = new Deck();

		public void ShuffleDeck()
		{
			_deck.Shuffle();
		}

		public Hand CreateHand() => new Hand();

		public Card DealCard()
		{
			if (_deck.AnyCardsLeft())
				return _deck.Draw();

			return null;
		}
	}
}