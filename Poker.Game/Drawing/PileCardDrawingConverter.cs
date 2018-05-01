using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using PlayingCards.Common.Cards;
using Poker.Game.TextureHandling;

namespace Poker.Game.Drawing
{
	public class PileCardDrawingConverter
	{
		private readonly CardTexture _cardTexturePng;
		private readonly SpriteBatch _spriteBatch;

		public PileCardDrawingConverter(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
		{
			_spriteBatch = spriteBatch;
			_cardTexturePng = new CardTexture(graphicsDevice);
		}

		public void Draw(List<Card> cards)
		{
			cards.ForEach(c => _cardTexturePng.Draw(_spriteBatch, c, 1, 5));
		}
	}
}