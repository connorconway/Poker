using System;
using Microsoft.Xna.Framework.Graphics;

namespace Poker.Game
{
	public class DisposableSpriteBatch : IDisposable
	{
		private readonly SpriteBatch _spritebatch;

		public DisposableSpriteBatch(SpriteBatch spritebatch)
		{
			_spritebatch = spritebatch;
			_spritebatch.Begin();
		}

		public void Dispose()
		{
			_spritebatch.End();
		}
	}
}