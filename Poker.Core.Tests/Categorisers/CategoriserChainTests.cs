using NUnit.Framework;
using Poker.Core.Cards;
using Poker.Core.Categorisers;

namespace Poker.Core.Tests.Categorisers
{
	[TestFixture]
	public class CategoriserChainTests
	{
		private Hand _hand;

		[SetUp]
		public void SetUp()
		{
			_hand = new Hand();
		}

		[Test]
		public void WhenHandHasStraight_ShouldReturnStraightRank()
		{
			_hand.Add(new Card(Suit.Clubs, Value.Two));
			_hand.Add(new Card(Suit.Diamonds, Value.Three));
			_hand.Add(new Card(Suit.Spades, Value.Four));
			_hand.Add(new Card(Suit.Spades, Value.Five));
			_hand.Add(new Card(Suit.Clubs, Value.Six));

			Assert.AreEqual(HandRank.Straight, HandCategoriserChain.GetRank(_hand));
		}

		[Test]
		public void WhenHandHasThreeOfAKind_ShouldReturnThreeOfAKindRank()
		{
			_hand.Add(new Card(Suit.Clubs, Value.Five));
			_hand.Add(new Card(Suit.Diamonds, Value.Five));
			_hand.Add(new Card(Suit.Spades, Value.Five));

			Assert.AreEqual(HandRank.ThreeOfAKind, HandCategoriserChain.GetRank(_hand));
		}

		[Test]
		public void WhenHandHasTwoPair_ShouldReturnTwoPairRank()
		{
			_hand.Add(new Card(Suit.Clubs, Value.Five));
			_hand.Add(new Card(Suit.Diamonds, Value.Eight));
			_hand.Add(new Card(Suit.Spades, Value.Eight));
			_hand.Add(new Card(Suit.Hearts, Value.Five));

			Assert.AreEqual(HandRank.TwoPair, HandCategoriserChain.GetRank(_hand));
		}

		[Test]
		public void WhenHandHasPair_ShouldReturnPairRank()
		{
			_hand.Add(new Card(Suit.Clubs, Value.Five));
			_hand.Add(new Card(Suit.Diamonds, Value.Five));

			Assert.AreEqual(HandRank.Pair, HandCategoriserChain.GetRank(_hand));
		}

		[Test]
		public void WhenHandHasNoPair_ShouldReturnHighCard()
		{
			_hand.Add(new Card(Suit.Clubs, Value.Five));
			_hand.Add(new Card(Suit.Diamonds, Value.Nine));

			Assert.AreEqual(HandRank.HighCard, HandCategoriserChain.GetRank(_hand));
		}
	}
}