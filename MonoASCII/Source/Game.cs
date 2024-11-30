using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoASCII.Source.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;

namespace MonoASCII
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        public const int GridHeight = 16;
        public const int GridWidth = 16;
        private OrthographicCamera _camera;

        private GraphicsDeviceManager _graphics;
        private ASCIIGrid _grid;
        private SpriteBatch _spriteBatch;

        private ASCIITileset _tileset;
        private Texture2D _tilesetTexture;

        public Game()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
            _grid = new ASCIIGrid(GridWidth, GridHeight, _tileset, _spriteBatch);
            SetupViewport();
        }

        private void SetupViewport()
        {
            var viewportAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, GridWidth, GridHeight);
            _camera = new OrthographicCamera(viewportAdapter);
            viewportAdapter.Reset();
            Window.AllowUserResizing = true;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _tileset = new ASCIITileset(Content.Load<Texture2D>("cp437_8x8"), 8, 8);
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
            _spriteBatch.Begin(transformMatrix: _camera.GetViewMatrix(), samplerState: SamplerState.PointClamp);

            for (int i = 0; i < 255; i++)
            {
                _grid.DrawGlyph(i, i % GridWidth, i / GridHeight, Color.White, Color.LightGray);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}