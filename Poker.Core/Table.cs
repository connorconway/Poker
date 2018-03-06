using System.Collections.Generic;
using Poker.Core.Players;

namespace Poker.Core
{
	public class Table
	{
		private Dealer _dealer = new Dealer();
		private List<Player> _players = new List<Player>();

		public Table(int players)
		{
			_dealer.ShuffleDeck();
			for (var i = 0; i < players; i++)
			{
				var player = new Player();
				player.AcceptHand(_dealer.CreateHand());
				_players.Add(player);
			}
		}

		public int NoOfPlayers => _players.Count;
	}
}