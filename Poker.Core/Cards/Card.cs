namespace Poker.Core.Cards
{
	public class Card
	{
		public Suit Suit;
		public Value Value;

		public Card(Suit suit, Value value)
		{
			Suit = suit;
			Value = value;
		}
	}
}