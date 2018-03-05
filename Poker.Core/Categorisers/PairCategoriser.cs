using Poker.Core.Categorisers.Chain;

namespace Poker.Core.Categorisers
{
	public class PairCategoriser : HandCategoriser
	{
		public override HandRank Catagorise(Hand hand)
		{
			return hand.HasNoOfKind(2) ? HandRank.Pair : Next.Catagorise(hand);
		}
	}
}