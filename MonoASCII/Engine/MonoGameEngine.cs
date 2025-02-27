using Microsoft.Extensions.Logging;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoASCII.Core.Interfaces;
using MonoASCII.Core.Scenes;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;

namespace MonoASCII.Engine
{
    public class MonoGameEngine : Game
    {
        private readonly ILogger<MonoGameEngine> _logger;
        private MonoGameRenderer _renderer;
        private SceneManager _sceneManager;
        private GraphicsDeviceManager _graphics;
        private OrthographicCamera _camera;
        
        public MonoGameEngine(ILogger<MonoGameEngine> logger)
        {
            _logger = logger;
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        
        protected override void Initialize()
        {
            _logger.LogInformation("Initializing...");
            var viewportAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, 24, 16);
            _camera = new OrthographicCamera(viewportAdapter);
            viewportAdapter.Reset();
            Window.AllowUserResizing = true;
            _renderer = new MonoGameRenderer(_camera);
            _sceneManager = new SceneManager(_renderer);
            
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _logger.LogInformation("Loading content...");
            _renderer.LoadContent(Content, GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            _sceneManager.Update(gameTime);
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _sceneManager.Render();

            base.Draw(gameTime);
        }

    }
}