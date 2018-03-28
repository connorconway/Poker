﻿using System.Collections.Generic;
using System.Linq;
using PlayingCards.Common;
using PlayingCards.Common.Visitors;
using Poker.Core.Players;

namespace Poker.Core
{
	public class Table : IVisitable
	{
		private readonly Dealer _dealer = new Dealer();

		//TODO used to decide which player should take action. Refactor out.
		public readonly List<Player> Players = new List<Player>();

		public Table(int players)
		{
			_dealer.ShuffleDeck();
			for (var i = 0; i < players; i++)
			{
				Players.Add(new Player());
			}

			Players.ForEach(p => p.PlayerRaised += (s, e) => Pot += e.Amount);
		}

		public void InitialiseHands()
		{
			Players.ForEach(InitialiseHand);
		}

		public void Accept(Visitor visitor)
		{
			Players.ForEach(p => p.Accept(visitor));
		}

		public void Accept(PlayerVisitor visitor)
		{
			Players.ForEach(p => Visit(p, visitor));
		}

		private void Visit(Player player, PlayerVisitor v)
		{
			v.AddPlayer(player);
			player.Accept(v);
		}

		private void InitialiseHand(Player player)
		{
			player.Accept(_dealer.CreateHand());
			player.Accept(_dealer.DealCard());
			player.Accept(_dealer.DealCard());
		}

		//TODO public getters used for testing. Refactor out.
		public int NoOfPlayers => Players.Count(p => p.InGame);
		public int Pot { get; private set; }
	}
}