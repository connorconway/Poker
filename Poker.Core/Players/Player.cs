using Poker.Core.PlayerActions;

namespace Poker.Core.Players
{
	public class Player
	{
		private Hand _hand;
		private bool _inPlay = true;

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