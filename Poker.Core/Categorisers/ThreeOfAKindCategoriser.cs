using Poker.Core.Categorisers.Chain;

namespace Poker.Core.Categorisers
{
	internal class ThreeOfAKindCategoriser : HandCategoriser
	{
		public override HandRank Catagorise(Hand hand)
		{
			return hand.HasNoOfKind(3) ? HandRank.ThreeOfAKind : Next.Catagorise(hand);
		}
	}
}