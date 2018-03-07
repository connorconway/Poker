using System;
using NUnit.Framework;
using Poker.Core.PlayerActions;

namespace Poker.Core.Tests
{
	[TestFixture]
	public class TableTests
	{
		private Table _table;

		[OneTimeSetUp]
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

		[Test]
		public void WhenPlayerRaises_TablePot_ShouldAddRaisedAmount()
		{
			_table.Players[1].TakeTurn(new Raise(88));
			Assert.AreEqual(88, _table.Pot);
		}

		[Test]
		public void WhenPlayerRaisesMoreThanTheirCurrentMoney_ShouldThrowException()
		{
			Assert.Throws<ArgumentException>(() => _table.Players[1].TakeTurn(new Raise(101)));
		}

		[Test]
		public void WhenPlayerRaisesNegativeAmount_ShouldThrowException()
		{
			Assert.Throws<ArgumentException>(() => _table.Players[1].TakeTurn(new Raise(-10)));
		}
	}
}