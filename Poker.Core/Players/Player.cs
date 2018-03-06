using Poker.Core.PlayerActions;

namespace Poker.Core.Players
{
	public class Player
	{
		private Hand _hand;

		public void TakeTurn(ICommand command)
		{
			command.Execute();
		}

		public void AcceptHand(Hand h)
		{
			_hand = h;
		}
	}
}