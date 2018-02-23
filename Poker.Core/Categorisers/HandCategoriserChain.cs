namespace Poker.Core.Categorisers
{
	public class HandCategoriserChain
	{
		private static readonly HandCategoriserChain Instance = new HandCategoriserChain();
		private HandCategoriser Root { get; }

		private HandCategoriserChain()
		{
			Root = new StraightFlushCategoriser();
			Root.RegisterNext(new FourOfAKindCategoriser())
				.RegisterNext(new FullHouseCategoriser())
				.RegisterNext(new FlushCategoriser())
				.RegisterNext(new StraightCategoriser())
				.RegisterNext(new ThreeOfAKindCategoriser())
				.RegisterNext(new TwoPairCategoriser())
				.RegisterNext(new PairCategoriser())
				.RegisterNext(new HighCardCategoriser());
		}

		public static HandRank GetRank(Hand hand) => Instance.Root.Catagorise(hand);
	}
}