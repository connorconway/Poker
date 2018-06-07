using Microsoft.Xna.Framework;

namespace Poker.Game.TextureHandling
{
	public static class Positions
	{
		public static Vector2 TableTop => new Vector2 {X = 550, Y = 170};
		public static Vector2 TableRight => new Vector2 {X = 1010, Y = 320};
		public static Vector2 TableLeft => new Vector2 {X = 140, Y = 320};
		public static Vector2 TableBottom => new Vector2 {X = 550, Y = 510};
		public static Vector2 TableMiddleRight => new Vector2 {X = 750, Y = 320};
		public static Vector2 TableMiddleLeft => new Vector2 {X = 500, Y = 320};
		public static Vector2 BelowTable => new Vector2 {X = 560, Y = 680};
	}
}