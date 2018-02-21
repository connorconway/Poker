namespace Poker.Core.Categorisers
{
	public abstract class HandCategoriser
	{
		public HandCategoriser RegisterNext(HandCategoriser next)
		{
			Next = next;
			return next;
		}

		protected HandCategoriser Next { get; set; }

		public abstract HandRank Catagorise(Hand hand);
	}
}