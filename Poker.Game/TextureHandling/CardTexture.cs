using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;

namespace Poker.Game.TextureHandling
{
	public class CardTexture : Texture
	{
		private const int CardTextureHeight = 96;
		private const int CardTextureWidth = 72;
		private const int DeckPositionOnSpriteSheet = 13;
		private const int DeckTextureHeight = 96;
		private const int DeckTextureWidth = 72;

		public CardTexture(GraphicsDevice graphicsDevice) : base(graphicsDevice, "cards") { }

		private static int XPosOnSpriteSheet(PlayingCards.Common.Cards.Card card) => ((int)card.Value - Offset) * CardTextureWidth;
		private static int YPosOnSpriteSheet(PlayingCards.Common.Cards.Card card) => ((int)card.Suit - Offset) * CardTextureHeight;

		public override void Draw(SpriteBatch spriteBatch, PlayingCards.Common.Cards.Card card, int cardNumber, int playerNumber)
		{
			var tablePos = new Position();
			if (playerNumber == 1) tablePos = PossiblePlayerPositions.Top;
			if (playerNumber == 2) tablePos = PossiblePlayerPositions.Right;
			if (playerNumber == 3) tablePos = PossiblePlayerPositions.Bottom;
			if (playerNumber == 4) tablePos = PossiblePlayerPositions.Left;

			var topLeftOfSprite = new Vector2(tablePos.X + cardNumber * CardTextureWidth, tablePos.Y);
			var sourceRectangle = new Rectangle
			{
				X = XPosOnSpriteSheet(card),
				Y = YPosOnSpriteSheet(card),
				Height = CardTextureHeight,
				Width = CardTextureWidth - Offset
			};
			spriteBatch.Draw(Texture2D, topLeftOfSprite, sourceRectangle, Color.White);
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			var topLeftOfSprite = new Vector2(GraphicsDevice.DisplayMode.Width / 2.0f, GraphicsDevice.DisplayMode.Height / 2.0f);
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