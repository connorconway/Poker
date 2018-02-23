using NUnit.Framework;
using Poker.Core.Cards;
using Poker.Core.Categorisers;
using Poker.Core.Categorisers.Chain;

namespace Poker.Core.Tests.Categorisers
{
	[TestFixture]
	public class StraightTests
	{
		private Hand _hand;

		[SetUp]
		public void SetUp()
		{
			_hand = new Hand();
		}

		[Test]
		public void WhenHandHasStraight_WithLowAce_ShouldReturnStraightRank()
		{
			_hand.Add(new Card(Suit.Clubs, Value.Ace));
			_hand.Add(new Card(Suit.Diamonds, Value.Two));
			_hand.Add(new Card(Suit.Spades, Value.Three));
			_hand.Add(new Card(Suit.Spades, Value.Four));
			_hand.Add(new Card(Suit.Clubs, Value.Five));

			Assert.AreEqual(HandRank.Straight, HandCategoriserChain.GetRank(_hand));
		}

		[Test]
		public void WhenHandHasStraight_WithHighAce_ShouldReturnStraightRank()
		{
			_hand.Add(new Card(Suit.Clubs, Value.Ace));
			_hand.Add(new Card(Suit.Diamonds, Value.King));
			_hand.Add(new Card(Suit.Spades, Value.Queen));
			_hand.Add(new Card(Suit.Spades, Value.Jack));
			_hand.Add(new Card(Suit.Clubs, Value.Ten));

			Assert.AreEqual(HandRank.Straight, HandCategoriserChain.GetRank(_hand));
		}

		[Test]
		public void WhenHandHasNoStraight_ShouldNotReturnStraightRank()
		{
			_hand.Add(new Card(Suit.Clubs, Value.Eight));
			_hand.Add(new Card(Suit.Diamonds, Value.Ten));
			_hand.Add(new Card(Suit.Spades, Value.Queen));
			_hand.Add(new Card(Suit.Spades, Value.Seven));
			_hand.Add(new Card(Suit.Clubs, Value.Ten));

			Assert.AreNotEqual(HandRank.Straight, HandCategoriserChain.GetRank(_hand));
		}
	}
}