using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using PlayingCards.Common.Cards;
using Poker.Core.Players;
using Poker.Game.TextureHandling;

namespace Poker.Game.Drawing
{
	public class PlayerCardDrawingConverter
	{
		private readonly SpriteBatch _spriteBatch;
		private readonly CardTexture _cardTexturePng;

		public PlayerCardDrawingConverter(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
		{
			_spriteBatch = spriteBatch;
			_cardTexturePng = new CardTexture(graphicsDevice);
		}

		public void Draw(SortedDictionary<Player, List<Card>> players)
		{
			var playerNumber = 0;
			foreach (var player in players)
			{
				playerNumber++;
				var cardNumber = 0;
				foreach (var card in player.Value)
				{
					_cardTexturePng.Draw(_spriteBatch, card, cardNumber++, playerNumber);
				}
			}
		}
	}
}