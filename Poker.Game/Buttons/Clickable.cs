using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;

namespace Poker.Game.Buttons
{
	public class Clickable 
	{
		protected Rectangle Target;
		public bool IsClicked;

		public void HandleInput()
		{
			var currentTouch = TouchPanel.GetState();

			foreach (var touch in currentTouch.Where(t => t.State == TouchLocationState.Pressed))
			{
				HandlePressed(touch.Position);
			}
		}

		private void HandlePressed(Vector2 position)
		{
			var touch = new Rectangle((int)position.X, (int)position.Y, Target.Width, Target.Height);

			if (Target.Intersects(touch))
			{
				IsClicked = true;
			}
		}
	}
}