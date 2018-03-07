using System;
using Poker.Core.PlayerActions;

namespace Poker.Core.Players
{
	public class Player
	{
		private Hand _hand;
		private bool _inPlay = true;
		public int Money { get; set; } = 100;

		public delegate void PlayerRaisedEventHandler(object sender, PlayerRaisedEventArgs e);

		public event PlayerRaisedEventHandler PlayerRaised;

		public void OnPlayerRaised(PlayerRaisedEventArgs e)
		{
			var handler = PlayerRaised;
			handler?.Invoke(this, e);
		}

		public void TakeTurn(ICommand command)
		{
			command.Execute(this);
		}

		public void Out() => _inPlay = false;
		public bool InGame => _inPlay;

		public void AcceptHand(Hand h)
		{
			_hand = h;
		}
	}
}