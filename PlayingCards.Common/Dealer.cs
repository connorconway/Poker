using PlayingCards.Common.Cards;

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

		public Card DealCard() => _deck.Draw();
	}
}