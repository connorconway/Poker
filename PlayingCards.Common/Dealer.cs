using PlayingCards.Common.Cards;

namespace PlayingCards.Common
{
	public class Dealer
	{
		private readonly Deck _deck = new Deck();
		private readonly DiscardPile _pile = new DiscardPile();

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