using NUnit.Framework;
using PlayingCards.Common.Cards;

namespace PlayingCards.Common.Tests.Visitors
{
	[TestFixture]
	public class DiscardPileVisitorTests
	{
		private DiscardPileVisitor _discardPileVisitor;

		[SetUp]
		public void SetUp()
		{
			_discardPileVisitor = new DiscardPileVisitor();
		}

		[Test]
		public void Result()
		{
			var discardPile = new DiscardPile();
			discardPile.Add(new Card(Suit.Clubs, Value.Eight));
			discardPile.Add(new Card(Suit.Diamonds, Value.Seven));
			discardPile.Add(new Card(Suit.Diamonds, Value.Ace));

			discardPile.Accept(_discardPileVisitor);

			Assert.AreEqual(3, _discardPileVisitor.Result().Count);
			Assert.AreEqual(Value.Ace, _discardPileVisitor.Result().Peek().Value);
			Assert.AreEqual(Suit.Diamonds, _discardPileVisitor.Result().Peek().Suit);
		}
	}
}