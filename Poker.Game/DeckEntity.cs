using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PlayingCards.Common;
using XnaColor = Microsoft.Xna.Framework.Color;

namespace Poker.Game
{
	public class DeckEntity
	{
		private const int Offset = 1;
		private const int DeckPositionOnSpriteSheet = 13;
		private const int DeckTextureHeight = 96;
		private const int DeckTextureWidth = 72;
		private static Texture2D _deckSheetTexture;
		private readonly Position _position;
		private Deck deck;

		public DeckEntity(GraphicsDevice graphicsDevice)
		{
			deck = new Deck();
			_position = new Position {X = 220f, Y = 220f};
			if (_deckSheetTexture != null) return;
			using (var stream = TitleContainer.OpenStream("Content/cards.png"))
			{
				_deckSheetTexture = Texture2D.FromStream(graphicsDevice, stream);
			}
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			var topLeftOfSprite = new Vector2(_position.X, _position.Y);
			var sourceRectangle = new Rectangle
			{
				X = DeckPositionOnSpriteSheet * DeckTextureWidth,
				Y = DeckTextureHeight,
				Height = DeckTextureHeight,
				Width = DeckTextureWidth - Offset
			};
			spriteBatch.Draw(_deckSheetTexture, topLeftOfSprite, sourceRectangle, XnaColor.White);
		}
	}
}