using System;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Graphics;

namespace MonoASCII.Engine.Renderers;

/// <summary>
    /// Represents a tileset of ASCII glyphs. Internally, it uses MonoGame.Extended's Texture2DAtlas to split a texture into
    /// a tileset, where each tile is a glyph from top-left to bottom-right corresponds to an ascii character code. It has
    /// methods for getting the corresponding Texture2DRegion for a given character, looking this up in the atlas.
    /// </summary>
    public class ASCIITileset
    {
        private Texture2DAtlas _atlas;
        private Texture2D _texture;

        /// <summary>
        /// The number of glyphs in the tileset.
        /// </summary>
        public int GlyphCount
        { get { return _atlas.RegionCount; } }

        /// <summary>
        /// The height in pixels of each glyph in the tileset.
        /// </summary>
        public int GlyphHeight { get; }

        /// <summary>
        /// The width in pixels of each glyph in the tileset.
        /// </summary>
        public int GlyphWidth { get; }

        /// <summary>
        /// Create a new ASCIITileset from the given Texture2D, with the given glyph width and height.
        /// </summary>
        /// <param name="tilesetTexture">The texture to create the ASCII tileset from</param>
        /// <param name="glyphWidth">The width of each glyph (i.e. tile) in the tileset texture</param>
        /// <param name="glyphHeight"> The height of each glyph (i.e. tile) in the tileset texture</param>
        public ASCIITileset(Texture2D tilesetTexture, int glyphWidth, int glyphHeight)
        {
            GlyphWidth = glyphWidth;
            GlyphHeight = glyphHeight;
            _texture = tilesetTexture;
            _atlas = Texture2DAtlas.Create(null, _texture, glyphWidth, glyphHeight);
        }

        /// <summary>
        /// Get the Texture2DRegion corresponding to the given character.
        /// </summary>
        public Texture2DRegion GetGlyph(char c)
        {
            return GetGlyph((int)c);
        }

        /// <summary>
        /// Get the Texture2DRegion corresponding to the given character int value.
        /// </summary>
        public Texture2DRegion GetGlyph(int c)
        {
            if (c < 0 || c >= GlyphCount)
            {
                throw new ArgumentOutOfRangeException(nameof(c), $"Invalid char code {c}: must be between 0 and {GlyphCount - 1}");
            }

            return _atlas[c];
        }
    }