namespace Poker.Core.Categorisers
{
	public class PairCategoriser : HandCategoriser
	{
		public override HandRank Catagorise(Hand hand)
		{
			return hand.HasHoOfKind(2) ? HandRank.Pair : Next.Catagorise(hand);
		}
	}
}