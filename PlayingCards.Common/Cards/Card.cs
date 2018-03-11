namespace PlayingCards.Common.Cards
{
	public class Card
	{
		public Suit Suit;
		public Value Value;
		public Color Color;

		public Card(Suit suit, Value value)
		{
			Suit = suit;
			Value = value;
			Color = Suit == Suit.Hearts || Suit == Suit.Diamonds ? Color.Red : Color.Black;
		}
	}
}