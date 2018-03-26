using NUnit.Framework;
using PlayingCards.Common.Cards;
using PlayingCards.Common.Exceptions;
using PlayingCards.Common.Tests.Visitors;

namespace PlayingCards.Common.Tests
{
	[TestFixture]
	public class DeckTests
	{
		private Deck _deck;
		private CardTestVisitor _visitor;

		[SetUp]
		public void DeckShouldBeInitialised()
		{
			_deck = new Deck();
			_visitor = new CardTestVisitor();
		}

		[Test]
		public void WithFiftyTwoUniqueCards()
		{
			_deck.Accept(_visitor);
			Assert.AreEqual(52, _visitor.Count);
			Assert.AreEqual(_visitor.Count, _visitor.UniqueCount);
		}

		[Test]
		public void DrawShould_ReturnTopCard()
		{
			var topCard = _deck.Draw();
			_deck.Accept(_visitor);
			Assert.AreEqual(Value.King, topCard.Value);
			Assert.AreEqual(Suit.Spades, topCard.Suit);
			Assert.AreEqual(51, _visitor.Count);
		}

		[Test]
		public void ShuffleShould_RandomiseCardOrder()
		{
			_deck.Accept(_visitor);
			var cardCountBeforeShuffle = _visitor.Count;
			var cardsBeforeShuffle = _visitor.Cards;

			_deck.Shuffle();
			var afterShuffleVisitor = new CardTestVisitor();
			_deck.Accept(afterShuffleVisitor);
			var cardCountAfterShuffle = afterShuffleVisitor.Count;
			var cardsAfterShuffle = afterShuffleVisitor.Cards;

			Assert.AreEqual(52, cardCountBeforeShuffle);
			Assert.AreEqual(52, cardCountAfterShuffle);
			Assert.AreEqual(cardCountBeforeShuffle, afterShuffleVisitor.UniqueCount);
			Assert.AreNotEqual(cardsBeforeShuffle, cardsAfterShuffle);
		}

		[Test]
		public void DrawShould_ThrowOutOfCardsException_WhenThereAreNoCardsLeftInTheDeck()
		{
			for (var i = 0; i < 52; i++)
			{
				_deck.Draw();
			}

			Assert.Throws<OutOfCardsException>(() => _deck.Draw());
		}
	}
}