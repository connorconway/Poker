using NUnit.Framework;

namespace Poker.Core.Tests
{
	[TestFixture]
	public class HandTests
	{
		[Test]
		public void WhenGameStarts_HandShouldBeDealt_WithFiveCards()
		{
			var hand = new Hand();
			Assert.AreEqual(5, hand.Count);
		}

	}
}