using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Poker.Game
{
	public class CardEntity
	{
		static Texture2D cardsSheetTexture;

		public float X
		{
			get;
			set;
		}

		public float Y
		{
			get;
			set;
		}

		public CardEntity(GraphicsDevice graphicsDevice)
		{
			if (cardsSheetTexture == null)
			{
				using (var stream = TitleContainer.OpenStream("Content/cards.png"))
				{
					cardsSheetTexture = Texture2D.FromStream(graphicsDevice, stream);
				}
			}
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			Vector2 topLeftOfSprite = new Vector2(this.X, this.Y);
			Color tintColor = Color.White;
			spriteBatch.Draw(cardsSheetTexture, topLeftOfSprite, tintColor);
		}
	}
}
