using System.Collections.Generic;
using System.Linq;
using PlayingCards.Common.Cards;

namespace PlayingCards.Common.Extensions
{
	public static class ListExtensions
	{
		public static Card Pop(this List<Card> cards)
		{
			var card = cards.Last();
			cards.Remove(card);
			return card;
		}
	}
}