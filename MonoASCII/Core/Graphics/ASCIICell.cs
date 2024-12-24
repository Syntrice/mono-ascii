using Microsoft.Xna.Framework;

namespace MonoASCII.Core.Graphics
{
    /// <summary>
    /// Represents a single cell in an ASCII grid, with a foreground and background color and a glyph character.
    /// </summary>
    public struct ASCIICell
    {
        public Color Foreground { get; set; }
        public Color Background { get; set; }
        public char Glyph { get; set; }

        public ASCIICell(char glyph, Color foreground, Color background)
        {
            Foreground = foreground;
            Background = background;
            Glyph = glyph;
        }
    }
}