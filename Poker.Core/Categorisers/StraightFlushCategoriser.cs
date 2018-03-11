using PlayingCards.Common;
using Poker.Core.Categorisers.Chain;

namespace Poker.Core.Categorisers
{
	internal class StraightFlushCategoriser : HandCategoriser
	{
		public override HandRank Catagorise(Hand hand)
		{
			return hand.HasStraight() && hand.HasFlush() ? HandRank.StraightFlush : Next.Catagorise(hand);
		}
	}
}