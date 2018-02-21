namespace Poker.Core.Categorisers
{
	public abstract class HandCategoriser
	{
		public void RegisterNext(HandCategoriser next)
		{
			Next = next;
		}

		protected HandCategoriser Next { get; private set; }

		public abstract HandRank Catagorise(Hand hand);
	}
}