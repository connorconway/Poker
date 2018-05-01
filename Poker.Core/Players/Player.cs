using System;
using PlayingCards.Common;
using PlayingCards.Common.Cards;
using PlayingCards.Common.Visitors;
using Poker.Core.PlayerActions;
using Poker.Core.PlayerActions.EventArgs;

namespace Poker.Core.Players
{
	public class Player : IVisitable, IComparable<Player>
	{
		private Hand _hand = new Hand();
		private bool _inPlay = true;
		public int Money { get; } = 100;

		public delegate void PlayerRaisedEventHandler(object sender, PlayerRaisedEventArgs e);
		public event PlayerRaisedEventHandler PlayerRaised;

		public delegate void CardDiscardedEventHandler(object sender, CardDiscardedEventArgs e);
		public event CardDiscardedEventHandler CardDiscarded;

		protected internal void OnPlayerRaised(PlayerRaisedEventArgs e)
		{
			PlayerRaised?.Invoke(this, e);
		}

		private void OnCardDiscarded(CardDiscardedEventArgs e)
		{
			CardDiscarded?.Invoke(this, e);
		}

		public void TakeTurn(ICommand command)
		{
			command.Execute(this);
		}

		public void Out() => _inPlay = false;
		public bool InGame => _inPlay;

		public void Accept(Hand h)
		{
			_hand = h;
		}

		public void Accept(Card c)
		{
			_hand.Add(c);
		}

		public void Accept(Visitor visitor)
		{
			_hand.Accept(visitor);
		}

		public int CompareTo(Player other)
		{
			return GetHashCode().CompareTo(other.GetHashCode());
		}

		public void Discard()
		{
			var card = _hand.Pop();
			if (card != null)
				OnCardDiscarded(new CardDiscardedEventArgs { Card = card });
		}
	}
}