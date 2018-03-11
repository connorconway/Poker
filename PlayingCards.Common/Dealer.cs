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

		public Hand CreateHand()
		{
			var hand = new Hand();
			hand.Add(DealCard());
			hand.Add(DealCard());
			return hand;
		}

		private Card DealCard() => _deck.Draw();
	}
}