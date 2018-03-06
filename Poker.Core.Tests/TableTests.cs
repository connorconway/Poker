using NUnit.Framework;

namespace Poker.Core.Tests
{
	[TestFixture]
	public class TableTests
	{
		[Test]
		public void WhenTableInitialised_WithFourPlayers_FourPlayersShouldExist()
		{
			var table = new Table(players: 4);
			Assert.AreEqual(4, table.NoOfPlayers);
		}
	}
}