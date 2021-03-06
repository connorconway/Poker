﻿using PlayingCards.Common;
using Poker.Core.Categorisers.Chain;

namespace Poker.Core.Categorisers
{
	public class FlushCategoriser : HandCategoriser
	{
		public override HandRank Catagorise(Hand hand)
		{
			return hand.HasFlush() ? HandRank.Flush : Next.Catagorise(hand);
		}
	}
}