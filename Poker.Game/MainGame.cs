using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Poker.Core;
using Poker.Game.Buttons;

namespace Poker.Game
{
	public class MainGame : Microsoft.Xna.Framework.Game
	{
		private SpriteBatch _spriteBatch;
		private PngHandler _tablePng;
		private PngHandler _cardPng;
		private PngHandler _deckPng;

		private Button _startGameButton;
		private Table _table;

		public MainGame()
		{
			ConfigureGraphicsDevice();
		}

		private void StartGame(object sender)
		{
			_table = new Table(players: 4);
			_table.DealCards();
		}

		protected override void Initialize()
		{
			_cardPng = new PngHandler(GraphicsDevice, "cards");
			_tablePng = new PngHandler(GraphicsDevice, "table");
			_deckPng = new PngHandler(GraphicsDevice, "cards");
			_startGameButton = new Button(GraphicsDevice, "start");
			CreateEventListeners();
			base.Initialize();
		}

		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);
		}

		protected override void UnloadContent() { }

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
				Exit();

			_startGameButton.Update();

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			_spriteBatch.Begin();

			_tablePng.DrawFullScreen(_spriteBatch);
			
			//TODO horrible! Oh so horrible....
			if (_table != null)
			{
				for (var i = 0; i < _table.NoOfPlayers; i++)
				{
					var cardNumber = 0;
					foreach (var card in _table.Players[i].Cards)
					{
						_cardPng.Draw(_spriteBatch, card, cardNumber++, i);
					}
				}
			}
		
			_deckPng.DrawDeck(_spriteBatch);
			_startGameButton.Draw(_spriteBatch);

			_spriteBatch.End();
			base.Draw(gameTime);
		}

		private void CreateEventListeners()
		{
			_startGameButton.OnClick += StartGame;
		}

		private void ConfigureGraphicsDevice()
		{
			var graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			graphics.IsFullScreen = true;
			graphics.PreferredBackBufferWidth = 800;
			graphics.PreferredBackBufferHeight = 480;
			graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;
		}
	}
}
