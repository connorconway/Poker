using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Poker.Game
{
	public class CardEntity
	{
		static Texture2D cardsSheetTexture;
		Animation walkDown;
		Animation currentAnimation;


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
			if(cardsSheetTexture == null)

			{
				using (var stream = TitleContainer.OpenStream("Content/cards.png"))
				{
					cardsSheetTexture = Texture2D.FromStream(graphicsDevice, stream);
				}
			}

			walkDown = new Animation();
			walkDown.AddFrame(new Rectangle(0, 0, 16, 16), TimeSpan.FromSeconds(.25));
			walkDown.AddFrame(new Rectangle(16, 0, 16, 16), TimeSpan.FromSeconds(.25));
			walkDown.AddFrame(new Rectangle(0, 0, 16, 16), TimeSpan.FromSeconds(.25));
			walkDown.AddFrame(new Rectangle(32, 0, 16, 16), TimeSpan.FromSeconds(.25));
		}

		public void Update(GameTime gameTime)
		{
			// temporary - we'll replace this with logic based off of which way the
			// character is moving when we add movement logic
			currentAnimation = walkDown;

			currentAnimation.Update(gameTime);
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			Vector2 topLeftOfSprite = new Vector2(this.X, this.Y);
			Color tintColor = Color.White;
			var sourceRectangle = currentAnimation.CurrentRectangle;

			spriteBatch.Draw(cardsSheetTexture, topLeftOfSprite, sourceRectangle, Color.White);
		}
	}
}
