using System;

namespace PlayingCards.Common.Exceptions
{
	public class OutOfCardsException : Exception
	{
		public OutOfCardsException(string message) : base(message) { }
	}
}