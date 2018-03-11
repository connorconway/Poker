using PlayingCards.Common;
using Poker.Core.Categorisers.Chain;

namespace Poker.Core.Categorisers
{
	public class StraightCategoriser : HandCategoriser
	{
		public override HandRank Catagorise(Hand hand)
		{
			return hand.HasStraight() ? HandRank.Straight : Next.Catagorise(hand);
		}
	}
}