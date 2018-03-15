using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;

namespace Poker.Game.Buttons
{
	public class Clickable 
	{
		protected Rectangle Target;
		protected bool IsClicked;

		protected void HandleInput()
		{
			var touches = TouchPanel.GetState();

			if (touches.Count <= 0) return;
			var touchLocation = touches[0];
			var position = touchLocation.Position;
				
			var touch = new Rectangle((int)position.X, (int)position.Y, Target.Width, Target.Height);

			if (Target.Intersects(touch))
			{
				//TODO Fire event here?
				IsClicked = true;
			}
		}
	}
}