using Poker.Core.Players;

namespace Poker.Core.PlayerActions
{
	public class Fold : ICommand
	{
		public void Execute(Player player)
		{
			player.Out();
		}
	}
}