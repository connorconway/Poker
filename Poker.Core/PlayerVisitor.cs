using System.Collections.Generic;
using PlayingCards.Common.Cards;
using PlayingCards.Common.Visitors;
using Poker.Core.Players;

namespace Poker.Core
{
	public class PlayerVisitor : Visitor
	{
		private readonly SortedDictionary<Player, List<Card>> _result = new SortedDictionary<Player, List<Card>>();
		private Player _player;

		public void AddPlayer(Player p)
		{
			_result.Add(p, new List<Card>());
			_player = p;
		}

		public override void Visit(Card card)
		{
			_result.TryGetValue(_player, out var cards);
			cards.Add(card);
			_result[_player] = cards;
		}

		public SortedDictionary<Player, List<Card>> Result() => _result;
	}
}