using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;

namespace Poker.Game.TextureHandling
{
	public class TableTexture : Texture
	{
		public TableTexture(GraphicsDevice graphicsDevice) : base(graphicsDevice, "table") { }

		public override void Draw(SpriteBatch spriteBatch, PlayingCards.Common.Cards.Card card, int cardNumber, int playerNumber)
		{
			//Do not need this here
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			var scale = new Vector2(Texture2D.Width <= GraphicsDevice.DisplayMode.Width
				? (float)GraphicsDevice.DisplayMode.Width / Texture2D.Width
				: (float)Texture2D.Width / GraphicsDevice.DisplayMode.Width);

			spriteBatch.Draw(Texture2D, new Vector2(0, -50), null, Color.White, 0.0f, Vector2.Zero, scale, SpriteEffects.None, 0.0f);
		}
	}
}