using System;
using System.Linq;
using NUnit.Framework;
using PlayingCards.Common;
using Poker.Core.Players;

namespace Poker.Core.Tests
{
	[TestFixture]
	public class PlayerVisitorTests
	{
		[Test]
		public void Visit()
		{
			var table = new Table(players: 3);
			table.InitialiseHands();

			var playerVisitor = new PlayerVisitor();
			table.Accept(playerVisitor);
			var players = playerVisitor.Result();

			Assert.AreEqual(3, players.Keys.Count);
			Assert.AreEqual(2, players.First().Value.Count);

			foreach (var player in players)
			{
				Console.WriteLine($"{player.Key.InGame}");
				player.Value.ForEach(v => Console.WriteLine($"{v.Suit} {v.Value} {v.Color}"));
			}
		}
	}
}