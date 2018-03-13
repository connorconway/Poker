using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace Poker.Game
{
	public class Clickable 
	{
		protected Rectangle Target;
		protected bool IsClicked;

		protected Clickable() 
		{
		}

		protected void HandleInput()
		{
			var touches = TouchPanel.GetState();

			if (touches.Count <= 0) return;
			var touchLocation = touches[0];
			var position = touchLocation.Position;
				
			var touch = new Rectangle((int)position.X, (int)position.Y, Target.Width, Target.Height);

			if (Target.Intersects(touch))
			{
				//TODO Fire event
				IsClicked = true;
			}
		}
	}

	public class Button : Clickable
	{
		private readonly SpriteBatch _spritebatch;
		private readonly Texture2D _texture; 
		public Button(GraphicsDevice graphicsDevice, SpriteBatch spritebatch)
		{
			_spritebatch = spritebatch;
			if (_texture != null) return;
			using (var stream = TitleContainer.OpenStream("Content/start.png"))
			{
				_texture = Texture2D.FromStream(graphicsDevice, stream);
			}
			Target = new Rectangle(0, 500, _texture.Width/2, _texture.Height/2); 
		}

		public void Update()
		{
			HandleInput();
			if (IsClicked)
			{
				MessageBox.Show("CLICKED!", "CLICKED!", new List<string>{"NO"});
			}

			IsClicked = false;
		}

		public void Draw()
		{
			_spritebatch.Draw(_texture, new Vector2(Target.X, Target.Y), null, Color.White, 0.0f, new Vector2(0,0), 0.5f, SpriteEffects.None, 0.0f);
		}
	}
}