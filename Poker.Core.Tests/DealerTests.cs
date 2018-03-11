using NUnit.Framework;
using PlayingCards.Common;

namespace Poker.Core.Tests
{
	[TestFixture]
	public class DealerTests
	{
		private Dealer _dealer;

		[SetUp]
		public void DealerShouldBeInitialised()
		{
			_dealer = new Dealer();
			_dealer.ShuffleDeck();
		}

		[Test]
		public void CreateHand_ShouldReturnHandWithTwoCards()
		{
			var playerOneHand = _dealer.CreateHand();
			var playerTwoHand = _dealer.CreateHand();
			Assert.AreEqual(2, playerOneHand.Count);
			Assert.AreEqual(2, playerTwoHand.Count);
			Assert.AreNotEqual(playerOneHand, playerTwoHand);
		}
	}
}
