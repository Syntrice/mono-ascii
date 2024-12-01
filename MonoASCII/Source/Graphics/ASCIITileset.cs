using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Graphics;
using System;

namespace MonoASCII.Source.Graphics
{
    public class ASCIITileset
    {
        private Texture2DAtlas _atlas;
        private Texture2D _texture;

        public int GlyphCount { get { return _atlas.RegionCount; } }
        public int GlyphHeight { get; }
        public int GlyphWidth { get; }

        public ASCIITileset(Texture2D tilesetTexture, int glyphWidth, int glyphHeight)
        {
            GlyphWidth = glyphWidth;
            GlyphHeight = glyphHeight;
            _texture = tilesetTexture;
            _atlas = Texture2DAtlas.Create(null, _texture, glyphWidth, glyphHeight);
        }

        public Texture2DRegion GetGlyph(char c)
        {
            return GetGlyph((int)c);
        }

        public Texture2DRegion GetGlyph(int c)
        {
            if (c < 0  || c >= GlyphCount)
            {
                throw new ArgumentOutOfRangeException(nameof(c), $"Invalid char code {c}: must be between 0 and {GlyphCount - 1}");
            }

            return _atlas[c];
        }
    }
}