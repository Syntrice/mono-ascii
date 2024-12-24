using Microsoft.Xna.Framework;

namespace MonoASCII.Core.ASCII
{
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