using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Graphics;

namespace MonoASCII.Source.Graphics
{
    internal class ASCIIGrid
    {
        private SpriteBatch _batch;
        public int Height { get; }
        public ASCIITileset Tileset { get; }
        public int Width { get; }

        public ASCIIGrid(int width, int height, ASCIITileset tileset, SpriteBatch batch)
        {
            Width = width;
            Height = height;
            Tileset = tileset;
            _batch = batch;
        }

        public void DrawGlyph(char glyph, int x, int y, Color foreground, Color background)
        {
            _batch.FillRectangle(new Rectangle(x, y, 1, 1), background);

            _batch.Draw(Tileset.GetGlyph(glyph), new Rectangle(x, y, 1, 1), foreground);
        }

        public void DrawGlyph(int glyph, int x, int y, Color foreground, Color background)
        {
            _batch.FillRectangle(new Rectangle(x, y, 1, 1), background);

            _batch.Draw(Tileset.GetGlyph(glyph), new Rectangle(x, y, 1, 1), foreground);
        }
    }
}