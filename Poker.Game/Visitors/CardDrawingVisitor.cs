using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using PlayingCards.Common.Cards;
using PlayingCards.Common.Visitors;
using Poker.Game.TextureHandling;

namespace Poker.Game.Visitors
{
	public class CardDrawingVisitor : Visitor
	{
		private readonly Microsoft.Xna.Framework.Graphics.SpriteBatch _spriteBatch;
		private readonly CardTexture _cardTexturePng;
		private readonly Stack<PlayingCards.Common.Cards.Card> _result = new Stack<PlayingCards.Common.Cards.Card>();

		public CardDrawingVisitor(GraphicsDevice graphicsDevice, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
		{
			_spriteBatch = spriteBatch;
			_cardTexturePng = new CardTexture(graphicsDevice);
		}

		public override void Visit(PlayingCards.Common.Cards.Card card)
		{
			_result.Push(card);
		}

		public void Draw()
		{
			//TODO horrendous. Drawing cards at different positions depending on player
			var cardNumber = 0;
			foreach (var card in _result)
			{
				_cardTexturePng.Draw(_spriteBatch, card, cardNumber++, 0);
			}
		}
	}
}