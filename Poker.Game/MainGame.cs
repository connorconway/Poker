using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Poker.Core;

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
			var graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			graphics.IsFullScreen = true;
			graphics.PreferredBackBufferWidth = 800;
			graphics.PreferredBackBufferHeight = 480;
			graphics.SupportedOrientations = DisplayOrientation.Portrait | DisplayOrientation.PortraitDown;

			_table = new Table(players: 4);
			_table.DealCards();
		}

		protected override void Initialize()
		{
			_cardPng = new PngHandler(GraphicsDevice, "cards");
			_tablePng = new PngHandler(GraphicsDevice, "table");
			_deckPng = new PngHandler(GraphicsDevice, "cards");
			base.Initialize();
		}

		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);
			_startGameButton = new Button(GraphicsDevice, _spriteBatch);
		}

		protected override void UnloadContent()
		{
			// TODO: Unload any non ContentManager content here
		}

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


			//TODO horrible! but trying to figure out how this is going to all fit in....
			for (var i = 0; i < _table.NoOfPlayers; i++)
			{
				var cardNumber = 0;
				foreach (var card in _table.Players[i].Cards)
				{
					_cardPng.Draw(_spriteBatch, card, cardNumber++, i);
				}

			}

			_deckPng.DrawDeck(_spriteBatch);
			_startGameButton.Draw();

			_spriteBatch.End();
			base.Draw(gameTime);
		}
	}
}
