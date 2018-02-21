using NUnit.Framework;
using Poker.Core.Cards;
using Poker.Core.Categorisers;

namespace Poker.Core.Tests
{
	[TestFixture]
	public class CategoriserTests
	{
		private Hand _hand;

		[SetUp]
		public void SetUp()
		{
			_hand = new Hand();
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