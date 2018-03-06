using System.Collections.Generic;
using System.Linq;
using Poker.Core.Players;

namespace Poker.Core
{
	public class Table
	{
		private Dealer _dealer = new Dealer();
		public List<Player> Players = new List<Player>();

		public Table(int players)
		{
			_dealer.ShuffleDeck();
			for (var i = 0; i < players; i++)
			{
				var player = new Player();
				player.AcceptHand(_dealer.CreateHand());
				Players.Add(player);
			}
		}

		public int NoOfPlayers => Players.Count(p => p.InGame);
	}
}