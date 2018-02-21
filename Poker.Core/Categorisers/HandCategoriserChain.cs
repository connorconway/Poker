namespace Poker.Core.Categorisers
{
	public class HandCategoriserChain
	{
		private static readonly HandCategoriserChain Instance = new HandCategoriserChain();
		private HandCategoriser Root { get; }

		private HandCategoriserChain()
		{
			Root = new TwoPairCategoriser();
			Root.RegisterNext(new PairCategoriser())
				.RegisterNext(new HighCardCategoriser());
		}

		public static HandRank GetRank(Hand hand) => Instance.Root.Catagorise(hand);
	}

	internal class TwoPairCategoriser : HandCategoriser
	{
		public override HandRank Catagorise(Hand hand)
		{
			return hand.HasHoOfKind(2) ? HandRank.TwoPair : Next.Catagorise(hand);
		}
	}
}