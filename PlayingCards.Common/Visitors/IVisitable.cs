namespace PlayingCards.Common.Visitors
{
	public interface IVisitable
	{
		void Accept(Visitor visitor);
	}
}