using PlayingCards.Common;
using Poker.Core.Categorisers.Chain;

namespace Poker.Core.Categorisers
{
	internal class FullHouseCategoriser : HandCategoriser
	{
		public override HandRank Catagorise(Hand hand)
		{
			return hand.HasNoOfKind(3) && hand.HasNoOfKind(2) ? HandRank.FullHouse : Next.Catagorise(hand);
		}
	}
}