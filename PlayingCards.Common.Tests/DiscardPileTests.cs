using NUnit.Framework;
using PlayingCards.Common.Cards;
using PlayingCards.Common.Tests.Visitors;

namespace PlayingCards.Common.Tests
{
	[TestFixture]
	public class DiscardPileTests
	{
		private DiscardPile _discardPile;
		private CardTestVisitor _visitor;

		[SetUp]
		public void DiscardPileShouldBeInitialised()
		{
			_discardPile = new DiscardPile();
			_visitor = new CardTestVisitor();
		}

		[Test]
		public void Add_ShouldAddCardToDiscardPile()
		{
			_discardPile.Add(new Card(Suit.Diamonds, Value.Jack));
			_discardPile.Add(new Card(Suit.Clubs, Value.Jack));
			_discardPile.Accept(_visitor);
			Assert.AreEqual(2, _visitor.Count);
			Assert.AreEqual(_visitor.Count, _visitor.UniqueCount);
		}
	}
}