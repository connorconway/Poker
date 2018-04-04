using System.Collections.Generic;
using NUnit.Framework;
using PlayingCards.Common.Cards;
using PlayingCards.Common.Tests.Visitors;

namespace PlayingCards.Common.Tests
{
	[TestFixture]
	public class DiscardPileTests
	{
		private DiscardPile _discardPile;

		[SetUp]
		public void DiscardPile_ShouldBeInitialised()
		{
			var dealer = new Dealer();
			_discardPile = new DiscardPile();
			_discardPile.Add(dealer.DealCard());
		}

		[Test]
		public void Add()
		{
			var discardPile = new CardTestVisitor();
			_discardPile.Accept(discardPile);
			
			Assert.AreEqual(1, discardPile.Count);
			Assert.AreEqual(1, discardPile.UniqueCount);
		}

		[Test]
		public void Reset()
		{
			_discardPile.Reset();

			var discardPile = new CardTestVisitor();
			_discardPile.Accept(discardPile);

			Assert.AreEqual(0, discardPile.Count);
			Assert.AreEqual(0, discardPile.UniqueCount);
		}
	}
}