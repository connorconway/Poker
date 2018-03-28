using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Poker.Core;
using Poker.Game.Buttons;
using Poker.Game.Drawing;
using Poker.Game.TextureHandling;
using Texture = Poker.Game.TextureHandling.Texture;

namespace Poker.Game
{
	public class MainGame : Microsoft.Xna.Framework.Game
	{
		private SpriteBatch _spriteBatch;
		private Texture _tableTexture;
		private Texture _deckTexture;

		private Button _startGameButton;
		private readonly Table _table;

		public MainGame()
		{
			ConfigureGraphicsDevice();
			_table = new Table(players: 4);
		}

		private void StartGame(object sender)
		{
			_table.InitialiseHands();
		}

		protected override void Initialize()
		{
			_tableTexture = new TableTexture(GraphicsDevice);
			_deckTexture = new DeckTexture(GraphicsDevice);
			_startGameButton = Button.StartButton(GraphicsDevice);
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
			_startGameButton.Update();
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			using (new DisposableSpriteBatch(_spriteBatch))
			{
				_tableTexture.Draw(_spriteBatch);
				_deckTexture.Draw(_spriteBatch);
				_startGameButton.Draw(_spriteBatch);
				DrawCards();
			}

			base.Draw(gameTime);
		}

		private void DrawCards()
		{
			var playerVisitor = new PlayerVisitor();
			_table.Accept(playerVisitor);
			var players = playerVisitor.Result();
			var converter = new CardDrawingConverter(GraphicsDevice, _spriteBatch);
			converter.Draw(players);
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