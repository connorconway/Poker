using Poker.Core.Players;

namespace Poker.Core.PlayerActions
{
	public interface ICommand
	{
		void Execute(Player player);
	}
}