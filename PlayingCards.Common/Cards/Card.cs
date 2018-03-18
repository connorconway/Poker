using PlayingCards.Common.Visitors;

namespace PlayingCards.Common.Cards
{
	public class Card : IVisitable
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

		public void Accept(Visitor visitor)
		{
			visitor.PreVisit(this);
			visitor.PostVisit(this);
		}
	}
}