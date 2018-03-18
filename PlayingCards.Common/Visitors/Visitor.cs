using PlayingCards.Common.Cards;

namespace PlayingCards.Common.Visitors
{
	public abstract class Visitor
	{
		public abstract void Visit(Card card);		
	}
}