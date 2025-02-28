using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoASCII.Engine.Renderers;
using MonoASCII.Framework;
using MonoASCII.Framework.Scenes;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;

namespace MonoASCII.Engine
{
    public class MonoGameEngine : Game
    {
        private OrthographicCamera _camera;
        private ASCIITileset _asciiTileset;
        private SpriteBatch _spriteBatch;
        private MonoGameRenderHandler _renderHandler;
        private GraphicsDeviceManager _graphics;
        private SceneManager _sceneManager;
        
        public MonoGameEngine()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        
        protected override void Initialize()
        {
            var viewportAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, 24, 16);
            _camera = new OrthographicCamera(viewportAdapter);
            viewportAdapter.Reset();
            Window.AllowUserResizing = true;
            
            base.Initialize();
            
            _renderHandler = new MonoGameRenderHandler(_spriteBatch, _asciiTileset);
            _sceneManager = new SceneManager(new MainMenuScene());
        }

        protected override void LoadContent()
        {
            _asciiTileset = new ASCIITileset(Content.Load<Texture2D>("cp437_8x8"), 8, 8);
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _sceneManager.Update(gameTime);
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin(transformMatrix: _camera.GetViewMatrix(), samplerState: SamplerState.PointClamp);
            _sceneManager.Render(gameTime, _renderHandler);
            _spriteBatch.End();
            
            base.Draw(gameTime);
        }

    }
}