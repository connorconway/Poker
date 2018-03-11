using NUnit.Framework;
using PlayingCards.Common;
using PlayingCards.Common.Cards;

namespace Poker.Core.Tests
{
	[TestFixture]
	public class DeckTests
	{
		private Deck _deck;

		[SetUp]
		public void DeckShouldBeInitialised()
		{
			_deck = new Deck();
		}

		[Test]
		public void WithFiftyTwoUniqueCards()
		{
			Assert.AreEqual(52, _deck.Count);
			Assert.True(_deck.Unique);
		}

		[Test]
		public void DrawShould_ReturnTopCard()
		{
			var topCard = _deck.Draw();
			Assert.AreEqual(Value.King, topCard.Value);
			Assert.AreEqual(Suit.Spades, topCard.Suit);
			Assert.AreEqual(51, _deck.Count);
		}

		[Test]
		public void ShuffleShould_RandomiseCardOrder()
		{
			var cardsBeforeShuffle = _deck.Cards;
			_deck.Shuffle();

			Assert.AreEqual(52, _deck.Count);
			Assert.True(_deck.Unique);
			Assert.AreNotEqual(cardsBeforeShuffle, _deck.Cards);
		}
	}
}