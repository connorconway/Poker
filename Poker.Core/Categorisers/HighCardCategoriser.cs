namespace Poker.Core.Categorisers
{
	public class HighCardCategoriser : HandCategoriser
	{
		public override HandRank Catagorise(Hand hand)
		{
			return HandRank.HighCard;
		}
	}
}