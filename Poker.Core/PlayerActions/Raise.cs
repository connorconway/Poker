using System;
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
			if (_money > player.Money)
				throw new ArgumentException("Do not have enough money to raise");
			if (_money < 0)
				throw new ArgumentException("Can not raise by a negative amount");
			player.OnPlayerRaised(new PlayerRaisedEventArgs{Amount = _money});
		}
	}
}