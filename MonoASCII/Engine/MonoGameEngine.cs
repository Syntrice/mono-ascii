﻿using Microsoft.Extensions.Logging;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoASCII.Core.ASCII;
using MonoASCII.Core.Scenes;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;

namespace MonoASCII.Engine
{
    public class MonoGameEngine : Game
    {
        private readonly ILogger<MonoGameEngine> _logger;
        private OrthographicCamera _camera;
        private ASCIITileset _asciiTileset;
        private SpriteBatch _spriteBatch;
        private MonoGameASCIICellRenderer _asciiCellRenderer;
        private GraphicsDeviceManager _graphics;
        private SceneManager _sceneManager;
        
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
            
            base.Initialize();
            
            _asciiCellRenderer = new MonoGameASCIICellRenderer(_spriteBatch, _asciiTileset);
            _sceneManager = new SceneManager(_asciiCellRenderer);
        }

        protected override void LoadContent()
        {
            _logger.LogInformation("Loading content...");
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
            _sceneManager.Render();
            _spriteBatch.End();
            
            base.Draw(gameTime);
        }

    }
}