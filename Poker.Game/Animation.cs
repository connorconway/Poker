using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace Poker.Game
{
	public class Animation
	{
		private readonly List<AnimationFrame> _frames = new List<AnimationFrame>();
		private TimeSpan _timeIntoAnimation;

		private TimeSpan Duration
		{
			get
			{
				double totalSeconds = 0;
				foreach (var frame in _frames)
				{
					totalSeconds += frame.Duration.TotalSeconds;
				}

				return TimeSpan.FromSeconds(totalSeconds);
			}
		}

		public void AddFrame(Rectangle rectangle, TimeSpan duration)
		{
			var newFrame = new AnimationFrame()
			{
				SourceRectangle = rectangle,
				Duration = duration
			};

			_frames.Add(newFrame);
		}

		public void Update(GameTime gameTime)
		{
			var secondsIntoAnimation = _timeIntoAnimation.TotalSeconds + gameTime.ElapsedGameTime.TotalSeconds;
			var remainder = secondsIntoAnimation % Duration.TotalSeconds;
			_timeIntoAnimation = TimeSpan.FromSeconds(remainder);
		}

		public Rectangle CurrentRectangle
		{
			get
			{
				AnimationFrame currentFrame = null;
				var accumulatedTime = new TimeSpan();
				foreach (var frame in _frames)
				{
					if (accumulatedTime + frame.Duration >= _timeIntoAnimation)
					{
						currentFrame = frame;
						break;
					}

					accumulatedTime += frame.Duration;
				}

				if (currentFrame == null)
				{
					currentFrame = _frames.LastOrDefault();
				}

				return currentFrame?.SourceRectangle ?? Rectangle.Empty;
			}
		}
	}
}
