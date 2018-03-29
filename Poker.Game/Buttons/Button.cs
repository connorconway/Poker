using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poker.Game.TextureHandling;

namespace Poker.Game.Buttons
{
	public class Button : Clickable
	{
		public delegate void ButtonClickedEventHandler(object sender);
		public event ButtonClickedEventHandler OnClick;
		private readonly Texture2D _texture; 

		private Button(GraphicsDevice graphicsDevice, string nameOfImage)
		{
			if (_texture != null) return;
			using (var stream = TitleContainer.OpenStream($"Content/{nameOfImage}.png"))
			{
				_texture = Texture2D.FromStream(graphicsDevice, stream);
			}
			Target = new Rectangle((int)Positions.BelowTable.X, (int)Positions.BelowTable.Y, _texture.Width/2, _texture.Height/2); 
		}

		public static Button StartButton(GraphicsDevice graphicsDevice) => new Button(graphicsDevice, "start");

		public void Update()
		{
			if (IsClicked)
			{
				OnClick?.Invoke(this);
				IsClicked = false;
			}
			HandleInput();
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(_texture, Positions.BelowTable, null, Color.White, 0.0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0.0f);
		}
	}
}