using System;
using PlayingCards.Common.Cards;

namespace Poker.Core.Players
{
	public class CardDiscardedEventArgs : EventArgs
	{
		public Card Card { get; set; }
	}
}