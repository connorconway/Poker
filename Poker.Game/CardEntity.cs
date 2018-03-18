using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlayingCards.Common.Cards;
using XnaColor = Microsoft.Xna.Framework.Color;

namespace Poker.Game
{
	public class CardEntity : Card
	{
		private const int Offset = 1;
		private const int CardTextureHeight = 96;
		private const int CardTextureWidth = 72;
		private static Texture2D _cardsSheetTexture;
		private readonly Position _position;
		private readonly Card _card;

		public CardEntity(GraphicsDevice graphicsDevice, Card card) : base(card.Suit,  card.Value)
		{
			_card = card;
			_position = new Position();
			if (_cardsSheetTexture != null) return;
			using (var stream = TitleContainer.OpenStream("Content/cards.png"))
			{
				_cardsSheetTexture = Texture2D.FromStream(graphicsDevice, stream);
			}
		}

		private int XPosOnSpriteSheet => ((int) _card.Value - Offset) * CardTextureWidth;
		private int YPosOnSpriteSheet => ((int) _card.Suit - Offset) * CardTextureHeight;

		public void Draw(SpriteBatch spriteBatch)
		{
			var topLeftOfSprite = new Vector2(_position.X, _position.Y);
			var sourceRectangle = new Rectangle
			{
				X = XPosOnSpriteSheet,
				Y = YPosOnSpriteSheet,
				Height = CardTextureHeight,
				Width = CardTextureWidth - Offset
			};
			spriteBatch.Draw(_cardsSheetTexture, topLeftOfSprite, sourceRectangle, XnaColor.White);
		}
	}
}