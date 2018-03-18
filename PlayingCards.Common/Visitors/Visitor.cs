using PlayingCards.Common.Cards;

namespace PlayingCards.Common.Visitors
{
	public abstract class Visitor
	{
		public abstract void PreVisit(Hand hand);
		public abstract void PostVisit(Hand hand);		
		public abstract void PreVisit(Card Card);		
		public abstract void PostVisit(Card card);		
	}
}