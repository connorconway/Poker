using NUnit.Framework;
using PlayingCards.Common.Cards;
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
		public void CreateHand_ShouldReturnHandWithZeroCards()
		{
			var playerOneHand = _dealer.CreateHand();
			var playerTwoHand = _dealer.CreateHand();

			var playerOneVisitor = new CardTestVisitor();
			var playerTwoVisitor = new CardTestVisitor();
			playerOneHand.Accept(playerOneVisitor);
			playerTwoHand.Accept(playerTwoVisitor);

			Assert.AreEqual(0, playerOneVisitor.Count);
			Assert.AreEqual(0, playerTwoVisitor.Count);
		}

		[Test]
		public void DealCard_ShouldDealDifferentCardToPlayer()
		{
			var playerOneHand = _dealer.CreateHand();
			var playerTwoHand = _dealer.CreateHand();
			playerOneHand.Add(_dealer.DealCard());
			playerOneHand.Add(_dealer.DealCard());
			playerTwoHand.Add(_dealer.DealCard());
			playerTwoHand.Add(_dealer.DealCard());
		
			var playerOneVisitor = new CardTestVisitor();
			var playerTwoVisitor = new CardTestVisitor();
			playerOneHand.Accept(playerOneVisitor);
			playerTwoHand.Accept(playerTwoVisitor);

			Assert.AreEqual(2, playerOneVisitor.Count);
			Assert.AreEqual(2, playerTwoVisitor.Count);
			Assert.AreNotEqual(playerOneVisitor.Cards, playerTwoVisitor.Cards);
		}

		[Test]
		public void DealCard_ShouldShuffleDiscardPile_IfNoCardsLeftInDeck()
		{
			DealAllCardsInDeck();

			var deckVisitor = new CardTestVisitor();
			_dealer.Accept(deckVisitor);
			Assert.AreEqual(0, deckVisitor.Count);

			_dealer.DealCard();
			_dealer.Accept(deckVisitor);
			Assert.AreEqual(51, deckVisitor.Count);
			Assert.AreEqual(51, deckVisitor.UniqueCount);
		}

		private void DealAllCardsInDeck()
		{
			for (var i = 0; i < 52; i++)
				_dealer.DealCard();
		}
	}
}
