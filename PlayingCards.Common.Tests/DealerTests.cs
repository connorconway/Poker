using NUnit.Framework;
using PlayingCards.Common.Tests.Visitors;

namespace PlayingCards.Common.Tests
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

			var playerOneVisitor = new CardTestVisitor();
			var playerTwoVisitor = new CardTestVisitor();
			playerOneHand.Accept(playerOneVisitor);
			playerTwoHand.Accept(playerTwoVisitor);

			Assert.AreEqual(2, playerOneVisitor.Count);
			Assert.AreEqual(2, playerTwoVisitor.Count);
			Assert.AreNotEqual(playerOneVisitor.Cards, playerTwoVisitor.Cards);
		}
	}
}
