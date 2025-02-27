using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoASCII.Core.ASCII;
using MonoASCII.Core.Interfaces;
using MonoGame.Extended;
using MonoGame.Extended.Graphics;

namespace MonoASCII.Engine;

public class MonoGameRenderer : IRenderer
{
    private SpriteBatch _spriteBatch = null!;
    private ASCIITileset _tileset = null!;
    private OrthographicCamera _camera;

    public MonoGameRenderer(OrthographicCamera camera)
    {
        _camera = camera;
    }
    
    public void LoadContent(ContentManager content, GraphicsDevice graphicsDevice)
    {
        _spriteBatch = new SpriteBatch(graphicsDevice);
        _tileset = new ASCIITileset(content.Load<Texture2D>("cp437_8x8"), 8, 8);
    }
    
    public void RenderAsciiGrid(ASCIIGrid grid)
    {
        _spriteBatch.Begin(transformMatrix: _camera.GetViewMatrix(), samplerState: SamplerState.PointClamp);
        for (int i = 0; i < grid.Width; i++)
        {
            for (int j = 0; j < grid.Height; j++)
            {
                var cell = grid.GetCell(i, j);
                _spriteBatch.FillRectangle(new Rectangle(i,j, grid.CellWidth, grid.CellHeight), cell.Background);
                _spriteBatch.Draw(_tileset.GetGlyph(cell.Glyph), new Rectangle(i,j,grid.CellWidth,grid.CellHeight), cell.Foreground);
            }
        }
        _spriteBatch.End();
    }
}