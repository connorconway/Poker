using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Poker.Game.Buttons
{
	public class Button : Clickable
	{
		public delegate void ButtonClickedEventHandler(object sender);
		public event ButtonClickedEventHandler OnClick;
		private readonly Texture2D _texture; 

		public Button(GraphicsDevice graphicsDevice, string nameOfImage)
		{
			if (_texture != null) return;
			using (var stream = TitleContainer.OpenStream($"Content/{nameOfImage}.png"))
			{
				_texture = Texture2D.FromStream(graphicsDevice, stream);
			}
			Target = new Rectangle(0, 500, _texture.Width/2, _texture.Height/2); 
		}

		public void Update()
		{
			if (IsClicked)
			{
				OnClick?.Invoke(this);
				IsClicked = false;
			}
			HandleInput();
		}

		public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(_texture, new Vector2(Target.X, Target.Y), null, Color.White, 0.0f, new Vector2(0,0), 0.5f, SpriteEffects.None, 0.0f);
		}
	}
}