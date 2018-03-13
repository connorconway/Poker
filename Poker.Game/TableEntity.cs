using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poker.Core;

namespace Poker.Game
{
	public class TableEntity : Table
	{
		private readonly GraphicsDevice _graphicsDevice;
		private static Texture2D _tableTextureSheet;
		private readonly Position _position;

		public TableEntity(GraphicsDevice graphicsDevice, int players) : base(players)
		{
			_graphicsDevice = graphicsDevice;
			_position = new Position { X = 0f, Y = 0f };
			if (_tableTextureSheet != null) return;
			using (var stream = TitleContainer.OpenStream("Content/table.png"))
			{
				_tableTextureSheet = Texture2D.FromStream(graphicsDevice, stream);
			}
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			var topLeftOfSprite = new Vector2(_position.X, _position.Y);
			var sourceRectangle = new Rectangle
			{
				X = 0,
				Y = 0,
				Height = _graphicsDevice.DisplayMode.Height,
				Width = _graphicsDevice.DisplayMode.Width
			};
			spriteBatch.Draw(_tableTextureSheet, topLeftOfSprite, sourceRectangle, Color.White);
		}
	}
}