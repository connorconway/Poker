using System.Collections.Generic;
using System.Linq;

namespace Poker.Core
{
	public class Hand
	{
		private List<Card> _cards;
		public double Count => _cards.Count();
	}
}