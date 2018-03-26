using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;

namespace Poker.Game.TextureHandling
{
	public class DeckTexture : Texture
	{
		private const int CardTextureHeight = 96;
		private const int CardTextureWidth = 72;
		private const int DeckPositionOnSpriteSheet = 13;
		private const int DeckTextureHeight = 96;
		private const int DeckTextureWidth = 72;

		public DeckTexture(GraphicsDevice graphicsDevice) : base(graphicsDevice, "cards") { }

		public override void Draw(SpriteBatch spriteBatch, PlayingCards.Common.Cards.Card card, int cardNumber, int playerNumber)
		{
			//Do not need this here
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			var topLeftOfSprite = new Vector2(GraphicsDevice.DisplayMode.Width/2.0f, GraphicsDevice.DisplayMode.Height/2.0f);
			var sourceRectangle = new Rectangle
			{
				X = DeckPositionOnSpriteSheet * DeckTextureWidth,
				Y = DeckTextureHeight,
				Height = CardTextureHeight,
				Width = CardTextureWidth - Offset
			};
			spriteBatch.Draw(Texture2D, topLeftOfSprite, sourceRectangle, Color.White);
		}
	}
}