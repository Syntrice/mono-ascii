using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Graphics;
using MonoGame.Extended;
using System;
using MonoGame.Extended.ViewportAdapters;

namespace MonoASCII
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        public const int TileSize = 10;
        public const int ViewportWidth = 32;
        public const int ViewportHeight = 32;

        private OrthographicCamera _camera;
        private int[,] _tile_map;
        private Random _random;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _random = new Random();
        }

        protected override void Initialize()
        {
            base.Initialize();
            SetupViewport();
            GenerateMap();
        }

        private void SetupViewport()
        {
            var viewportAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, ViewportWidth, ViewportHeight);
            _camera = new OrthographicCamera(viewportAdapter);
            viewportAdapter.Reset();
            Window.AllowUserResizing = true;
        }

        private void GenerateMap()
        {
            _tile_map = new int[ViewportWidth, ViewportHeight];
            for (int i = 0; i < ViewportWidth; i++)
            {
                for (int j = 0; j < ViewportHeight; j++)
                {
                    if (_random.NextDouble() < 0.5)
                    {
                        _tile_map[i, j] = 0;
                    }
                    else
                    {
                        _tile_map[i, j] = 1;
                    }
                }
            }
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);

            _spriteBatch.Begin(transformMatrix: _camera.GetViewMatrix(), samplerState: SamplerState.PointClamp);
            for (int i = 0; i < ViewportWidth; i++)
            {
                for (int j = 0; j < ViewportHeight; j++)
                {
                    if (_tile_map[i, j] == 0)
                    {
                        _spriteBatch.DrawRectangle(new Rectangle(i, j, 1, 1), Color.White);
                    }
                    else if (_tile_map[i, j] == 1)
                    {
                        _spriteBatch.DrawRectangle(new Rectangle(i, j, 1, 1), Color.Black);
                    }
                }
            }
            _spriteBatch.End();
        }
    }
}
