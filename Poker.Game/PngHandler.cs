using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlayingCards.Common.Cards;
using Color = Microsoft.Xna.Framework.Color;

namespace Poker.Game
{
	public class PngHandler
	{
		private readonly GraphicsDevice _graphicsDevice;
		private const int Offset = 1;
		private const int CardTextureHeight = 96;
		private const int CardTextureWidth = 72;
		private const int DeckPositionOnSpriteSheet = 13;
		private const int DeckTextureHeight = 96;
		private const int DeckTextureWidth = 72;
		private readonly Texture2D _texture;

		public PngHandler(GraphicsDevice graphicsDevice, string nameOfImage)
		{
			_graphicsDevice = graphicsDevice;
			if (_texture != null) return;
			using (var stream = TitleContainer.OpenStream($"Content/{nameOfImage}.png"))
			{
				_texture = Texture2D.FromStream(_graphicsDevice, stream);
			}
		}

		private int XPosOnSpriteSheet(Card card) => ((int)card.Value - Offset) * CardTextureWidth;
		private int YPosOnSpriteSheet(Card card) => ((int)card.Suit - Offset) * CardTextureHeight;

		public void Draw(SpriteBatch spriteBatch, Card card, int cardNumber, int playerNumber)
		{
			var topLeftOfSprite = new Vector2(cardNumber * CardTextureWidth, playerNumber * CardTextureHeight);
			var sourceRectangle = new Rectangle
			{
				X = XPosOnSpriteSheet(card),
				Y = YPosOnSpriteSheet(card),
				Height = CardTextureHeight,
				Width = CardTextureWidth - Offset
			};
			spriteBatch.Draw(_texture, topLeftOfSprite, sourceRectangle, Color.White);
		}

		public void DrawDeck(SpriteBatch spriteBatch)
		{
			var topLeftOfSprite = new Vector2(460, 280);
			var sourceRectangle = new Rectangle
			{
				X = DeckPositionOnSpriteSheet * DeckTextureWidth,
				Y = DeckTextureHeight,
				Height = CardTextureHeight,
				Width = CardTextureWidth - Offset
			};
			spriteBatch.Draw(_texture, topLeftOfSprite, sourceRectangle, Color.White);
		}

		public void DrawFullScreen(SpriteBatch spriteBatch)
		{
			var topLeftOfSprite = new Vector2(0, 0);
			var sourceRectangle = new Rectangle
			{
				X = 0,
				Y = 0,
				Height = _graphicsDevice.DisplayMode.Height,
				Width = _graphicsDevice.DisplayMode.Width
			};
			spriteBatch.Draw(_texture, topLeftOfSprite, sourceRectangle, Color.White);
		}
	}
}