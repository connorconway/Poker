using NUnit.Framework;
using Poker.Core.PlayerActions;

namespace Poker.Core.Tests
{
	[TestFixture]
	public class TableTests
	{
		private Table _table;

		[SetUp]
		public void WhenTableInitialise_WithFourPlayers()
		{
			_table = new Table(players: 4);
		}
		[Test]
		public void FourPlayersShouldBeLive()
		{
			Assert.AreEqual(4, _table.NoOfPlayers);
		}

		[Test]
		public void WhenPlayerFolds_TableShouldContainThreePlayers()
		{
			_table.Players[2].TakeTurn(new Fold());
			Assert.AreEqual(3, _table.NoOfPlayers);
		}
	}
}