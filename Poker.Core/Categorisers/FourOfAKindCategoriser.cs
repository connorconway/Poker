using PlayingCards.Common;
using Poker.Core.Categorisers.Chain;

namespace Poker.Core.Categorisers
{
	internal class FourOfAKindCategoriser : HandCategoriser
	{
		public override HandRank Catagorise(Hand hand)
		{
			return hand.HasNoOfKind(4) ? HandRank.FourOfAKind : Next.Catagorise(hand);
		}
	}
}