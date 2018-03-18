using System.Collections.Generic;
using PlayingCards.Common;
using PlayingCards.Common.Cards;
using PlayingCards.Common.Visitors;
using Poker.Core.PlayerActions;
using Poker.Core.PlayerActions.EventArgs;

namespace Poker.Core.Players
{
	public class Player : IVisitable
	{
		private Hand _hand;
		private bool _inPlay = true;
		public int Money { get; } = 100;

		public delegate void PlayerRaisedEventHandler(object sender, PlayerRaisedEventArgs e);
		public event PlayerRaisedEventHandler PlayerRaised;

		protected internal void OnPlayerRaised(PlayerRaisedEventArgs e)
		{
			PlayerRaised?.Invoke(this, e);
		}

		public void TakeTurn(ICommand command)
		{
			command.Execute(this);
		}

		public void Out() => _inPlay = false;
		public bool InGame => _inPlay;
		public IEnumerable<Card> Cards => _hand.Cards;

		public void AcceptHand(Hand h)
		{
			_hand = h;
		}

		public void Accept(Visitor visitor)
		{
			_hand.Accept(visitor);
		}
	}
}