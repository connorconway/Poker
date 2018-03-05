using NUnit.Framework;
using Poker.Core.Cards;
using Poker.Core.Categorisers;
using Poker.Core.Categorisers.Chain;

namespace Poker.Core.Tests.Categorisers
{
	[TestFixture]
	public class StraightFlushTests
	{
		private Hand _hand;

		[SetUp]
		public void SetUp()
		{
			_hand = new Hand();
		}

		[Test]
		public void WhenHandHasStraightFlush_WithLowAce_ShouldReturnStraightFlushRank()
		{
			_hand.Add(new Card(Suit.Clubs, Value.Ace));
			_hand.Add(new Card(Suit.Clubs, Value.Two));
			_hand.Add(new Card(Suit.Clubs, Value.Three));
			_hand.Add(new Card(Suit.Clubs, Value.Four));
			_hand.Add(new Card(Suit.Clubs, Value.Five));

			Assert.AreEqual(HandRank.StraightFlush, HandCategoriserChain.GetRank(_hand));
		}

		[Test]
		public void WhenHandHasStraightFlush_WithHighAce_ShouldReturnStraightFlushRank()
		{
			_hand.Add(new Card(Suit.Clubs, Value.Ace));
			_hand.Add(new Card(Suit.Clubs, Value.King));
			_hand.Add(new Card(Suit.Clubs, Value.Queen));
			_hand.Add(new Card(Suit.Clubs, Value.Jack));
			_hand.Add(new Card(Suit.Clubs, Value.Ten));

			Assert.AreEqual(HandRank.StraightFlush, HandCategoriserChain.GetRank(_hand));
		}

		[Test]
		public void WhenHandHasNoStraightFlush_ShouldNotReturnStraightFlushRank()
		{
			_hand.Add(new Card(Suit.Clubs, Value.Eight));
			_hand.Add(new Card(Suit.Clubs, Value.Ten));
			_hand.Add(new Card(Suit.Clubs, Value.Queen));
			_hand.Add(new Card(Suit.Clubs, Value.Seven));
			_hand.Add(new Card(Suit.Clubs, Value.Ten));

			Assert.AreNotEqual(HandRank.Straight, HandCategoriserChain.GetRank(_hand));
		}
	}
}