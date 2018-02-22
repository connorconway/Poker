namespace Poker.Core.Categorisers
{
	public class HandCategoriserChain
	{
		private static readonly HandCategoriserChain Instance = new HandCategoriserChain();
		private HandCategoriser Root { get; }

		private HandCategoriserChain()
		{
			Root = new FlushCategoriser();
			Root.RegisterNext(new StraightCategoriser())
				.RegisterNext(new ThreeOfAKindCategoriser())
				.RegisterNext(new TwoPairCategoriser())
				.RegisterNext(new PairCategoriser())
				.RegisterNext(new HighCardCategoriser());
		}

		public static HandRank GetRank(Hand hand) => Instance.Root.Catagorise(hand);
	}
}