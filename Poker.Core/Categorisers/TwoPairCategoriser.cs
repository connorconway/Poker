﻿namespace Poker.Core.Categorisers
{
	internal class TwoPairCategoriser : HandCategoriser
	{
		public override HandRank Catagorise(Hand hand)
		{
			return hand.HasTwoPair() ? HandRank.TwoPair : Next.Catagorise(hand);
		}
	}
}