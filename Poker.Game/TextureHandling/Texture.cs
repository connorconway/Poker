using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Poker.Game.TextureHandling
{
	public abstract class Texture
	{
		protected readonly Texture2D Texture2D;
		protected readonly GraphicsDevice GraphicsDevice;
		protected const int Offset = 1;

		protected Texture(GraphicsDevice graphicsDevice, string nameOfImage)
		{
			GraphicsDevice = graphicsDevice;
			if (Texture2D != null) return;
			using (var stream = TitleContainer.OpenStream($"Content/{nameOfImage}.png"))
			{
				Texture2D = Texture2D.FromStream(GraphicsDevice, stream);
			}
		}

		public abstract void Draw(SpriteBatch spriteBatch, PlayingCards.Common.Cards.Card card, int cardNumber, int playerNumber);
		public abstract void Draw(SpriteBatch spriteBatch);
	}
}