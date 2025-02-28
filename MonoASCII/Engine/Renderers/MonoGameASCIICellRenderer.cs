using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoASCII.Engine.Renderers;
using MonoASCII.Framework.ASCII;
using MonoGame.Extended;
using MonoGame.Extended.Graphics;

namespace MonoASCII.Engine;

public class MonoGameASCIICellRenderer : IASCIICellRenderer
{
    private SpriteBatch _spriteBatch = null!;
    private ASCIITileset _tileset = null!;

    public MonoGameASCIICellRenderer(SpriteBatch spriteBatch, ASCIITileset tileset)
    {
        _tileset = tileset;
        _spriteBatch = spriteBatch;
    }
    
    public void Render(ASCIICell cell, int x, int y, int width, int height)
    {
        _spriteBatch.FillRectangle(new Rectangle(x,y, width, height), cell.Background);
        _spriteBatch.Draw(_tileset.GetGlyph(cell.Glyph), new Rectangle(x,y,width,height), cell.Foreground);
    }
}