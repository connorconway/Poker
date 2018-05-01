using NUnit.Framework;
using PlayingCards.Common.Piles;
using PlayingCards.Common.Tests.Visitors;

namespace PlayingCards.Common.Tests.Piles
{
	[TestFixture]
	public class DiscardTests
	{
		private Discard _discard;

		[SetUp]
		public void Discard_ShouldBeInitialised()
		{
			var dealer = new Dealer();
			_discard = new Discard();
			_discard.Add(dealer.DealCard());
		}

		[Test]
		public void Add()
		{
			var discardPile = new CardTestVisitor();
			_discard.Accept(discardPile);
			
			Assert.AreEqual(1, discardPile.Count);
			Assert.AreEqual(1, discardPile.UniqueCount);
		}

		[Test]
		public void Reset()
		{
			_discard.Reset();

			var discardPile = new CardTestVisitor();
			_discard.Accept(discardPile);

			Assert.AreEqual(0, discardPile.Count);
			Assert.AreEqual(0, discardPile.UniqueCount);
		}
	}
}