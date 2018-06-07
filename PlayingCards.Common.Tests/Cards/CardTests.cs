using NUnit.Framework;
using PlayingCards.Common.Cards;

namespace PlayingCards.Common.Tests.Cards
{
	public class CardTests
	{
		[Test]
		public void WhenCardIsSpades_ThenColorIsBlack()
		{
			var card = new Card(Suit.Spades, Value.Eight);
			Assert.AreEqual(Color.Black, card.Color);
		}

		[Test]
		public void WhenCardIsClubs_ThenColorIsBlack()
		{
			var card = new Card(Suit.Clubs, Value.Seven);
			Assert.AreEqual(Color.Black, card.Color);
		}

		[Test]
		public void WhenCardIsHearts_ThenColorIsRed()
		{
			var card = new Card(Suit.Hearts, Value.Eight);
			Assert.AreEqual(Color.Red, card.Color);
		}

		[Test]
		public void WhenCardIsDiamonds_ThenColorIsRed()
		{
			var card = new Card(Suit.Diamonds, Value.Ace);
			Assert.AreEqual(Color.Red, card.Color);
		}
	}
}