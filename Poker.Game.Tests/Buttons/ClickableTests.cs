using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;
using Poker.Game.Buttons;

namespace Poker.Game.Tests.Buttons
{
    [TestClass]
    public class ClickableTests
    {
        [TestMethod]
        public void WhenButtonPressed_ThenIsClickedIsTrue()
        {
	        var button = new FakeButton();
	        var c = TouchPanel.GetState();
			c.Add(new TouchLocation(1, TouchLocationState.Pressed, new Vector2(10, 10)));
	        button.HandleInput();

			Assert.AreEqual(true, button.IsClicked);
        }
    }

	public class FakeButton : Clickable
	{
		public FakeButton()
		{
			Target = new Rectangle(0, 0, 50, 50);
		}
	}
}
