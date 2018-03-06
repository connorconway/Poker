using NUnit.Framework;
using Poker.Core.PlayerActions;
using Poker.Core.Players;

namespace Poker.Core.Tests.PlayerActions
{
	[TestFixture]
	public class FoldTests
	{
		[Test]
		public void WhenPlayerFolds_ThenHandRankingShouldBeFold()
		{
			var player = new Player();
			player.TakeTurn(new Fold());
		}
	}
}