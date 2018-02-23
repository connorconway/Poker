using Poker.Core.PlayerActions;

namespace Poker.Core.Players
{
	public class Player
	{
		private Hand _hand = new Hand();

		public void TakeTurn(ICommand command)
		{
			command.Execute();
		}
	}
}