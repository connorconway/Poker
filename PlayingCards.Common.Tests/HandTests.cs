using System;
using NUnit.Framework;
using PlayingCards.Common.Cards;

namespace PlayingCards.Common.Tests
{
	[TestFixture]
	public class HandTests
	{
		private Hand _hand;

		[SetUp]
		public void HandShouldBeDealt()
		{
			_hand = new Hand();
		}

		[Test]
		public void WhenHandExceedsFiveCards_ShouldThrow()
		{
			_hand.Add(new Card(Suit.Clubs, Value.Ace));
			_hand.Add(new Card(Suit.Diamonds, Value.Ace));
			_hand.Add(new Card(Suit.Diamonds, Value.Ace));
			_hand.Add(new Card(Suit.Diamonds, Value.Ace));
			_hand.Add(new Card(Suit.Diamonds, Value.Ace));
			Assert.Throws<InvalidOperationException>(() => _hand.Add(new Card(Suit.Spades, Value.Queen)));
		}
	}
}