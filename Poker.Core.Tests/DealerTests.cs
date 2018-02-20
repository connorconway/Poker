using NUnit.Framework;

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
			var hand = _dealer.CreateHand();
			Assert.AreEqual(2, hand.Count);
		}
	}
}