namespace Poker.Core.Categorisers
{
	public class HandCategoriserChain
	{
		private static readonly HandCategoriserChain Instance = new HandCategoriserChain();
		private HandCategoriser Root { get; }

		private HandCategoriserChain()
		{
			Root = new StraightCategoriser();
			Root.RegisterNext(new ThreeOfAKindCategoriser())
				.RegisterNext(new TwoPairCategoriser())
				.RegisterNext(new PairCategoriser())
				.RegisterNext(new HighCardCategoriser());
		}

		public static HandRank GetRank(Hand hand) => Instance.Root.Catagorise(hand);
	}

	internal class ThreeOfAKindCategoriser : HandCategoriser
	{
		public override HandRank Catagorise(Hand hand)
		{
			return hand.HasHoOfKind(3) ? HandRank.ThreeOfAKind : Next.Catagorise(hand);
		}
	}
}