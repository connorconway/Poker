using Poker.Core.PlayerActions.EventArgs;
using Poker.Core.Players;

namespace Poker.Core.PlayerActions
{
	public class Raise : ICommand
	{
		private readonly int _money;

		public Raise(int money)
		{
			_money = money;
		}

		public void Execute(Player player)
		{
			player.OnPlayerRaised(new PlayerRaisedEventArgs{Amount = _money});
		}
	}
}