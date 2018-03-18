using System.Collections.Generic;
using System.Linq;
using PlayingCards.Common;
using PlayingCards.Common.Visitors;
using Poker.Core.Players;

namespace Poker.Core
{
	public class Table : IVisitable
	{
		private readonly Dealer _dealer = new Dealer();
		public readonly List<Player> Players = new List<Player>();

		public Table(int players)
		{
			_dealer.ShuffleDeck();
			for (var i = 0; i < players; i++)
			{
				var player = new Player();
				player.AcceptHand(_dealer.CreateHand());
				Players.Add(player);
			}

			Players.ForEach(p => p.PlayerRaised += (s, e) => Pot += e.Amount);
		}

		public void DealCards()
		{
			foreach (var player in Players)
			{
				player.AcceptHand(_dealer.CreateHand());
			}
		}

		public int NoOfPlayers => Players.Count(p => p.InGame);
		public int Pot { get; private set; }
		public void Accept(Visitor visitor)
		{
			Players.ForEach(p => p.Accept(visitor));
		}
	}
}