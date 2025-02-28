using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoASCII.Framework;
using MonoASCII.Framework.Components;
using MonoASCII.Framework.Components.ASCII;
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
                    var xScreenPosition = i * asciiGrid.CellWidth + asciiGrid.X * asciiGrid.CellWidth;
                    var yScreenPosition = j * asciiGrid.CellHeight + asciiGrid.Y * asciiGrid.CellHeight;
                    
                    _spriteBatch.FillRectangle(new Rectangle(xScreenPosition,yScreenPosition, asciiGrid.CellWidth, asciiGrid.CellHeight), cell.Background);
                    _spriteBatch.Draw(_tileset.GetGlyph(cell.Glyph), new Rectangle(xScreenPosition, yScreenPosition, asciiGrid.CellWidth,asciiGrid.CellHeight), cell.Foreground);
                    
                }
            }
        }
    }
}