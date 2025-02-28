using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoASCII.Engine.Renderers;
using MonoASCII.Framework;
using MonoASCII.Framework.ASCII;
using MonoASCII.Framework.Components;
using MonoGame.Extended;
using MonoGame.Extended.Graphics;

namespace MonoASCII.Engine;

public class MonoGameRenderHandler : IRenderHandler
{
    private SpriteBatch _spriteBatch = null!;
    private ASCIITileset _tileset = null!;

    public MonoGameRenderHandler(SpriteBatch spriteBatch, ASCIITileset tileset)
    {
        _tileset = tileset;
        _spriteBatch = spriteBatch;
    }

    public void Render(Component component)
    {
        if (component is ASCIIGrid asciiGrid)
        {
            for (int i = 0; i < asciiGrid.Width; i++)
            {
                for (int j = 0; j < asciiGrid.Height; j++)
                {
                    var cell = asciiGrid.GetCell(i, j);
                    _spriteBatch.FillRectangle(new Rectangle(i,j, asciiGrid.CellWidth, asciiGrid.CellHeight), cell.Background);
                    _spriteBatch.Draw(_tileset.GetGlyph(cell.Glyph), new Rectangle(i,j,asciiGrid.CellWidth,asciiGrid.CellHeight), cell.Foreground);
                    
                }
            }
        }
    }
}