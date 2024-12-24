using Microsoft.Xna.Framework;

namespace MonoASCII.Core.Graphics
{
    public class ASCIIGrid
    {
        private ASCIICell[,] _cells;
        public Color DefaultBackground { get; }
        public Color DefaultForeground { get; }
        public int Width { get; }
        public int Height { get; }

        /// <summary>
        /// The width of each cell in the grid, in world units. This would normally be the width of the tileset's glyphs in pixels,
        /// or a custom value if using a transformMatrix to scale the grid to world units.
        /// </summary>
        public int CellWidth { get; }

        /// <summary>
        /// The height of each cell in the grid, in world units. This would normally be the width of the tileset's glyphs in pixels,
        /// or a custom value if using a transformMatrix to scale the grid to world units.
        /// </summary>
        public int CellHeight { get; }

        public ASCIIGrid(int width, int height, int tileWidth, int tileHeight, Color defaultBackground, Color defaultForeground)
        {
            Width = width;
            Height = height;
            DefaultBackground = defaultBackground;
            DefaultForeground = defaultForeground;
            CellWidth = tileWidth;
            CellHeight = tileHeight;

            _cells = new ASCIICell[Width, Height];
        }

        public ASCIIGrid(int width, int height, int tileWidth, int tileHeight)
            : this(width, height, tileWidth, tileHeight, Color.Black, Color.White) { }

        /// <summary>
        /// Clear the grid, initializing all cells to the default background and foreground colors, and the null glyph.
        /// </summary>
        public void ClearGrid()
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    _cells[i, j] = new ASCIICell((char)0, DefaultForeground, DefaultBackground);
                }
            }
        }

        /// <summary>
        /// Set the cell at the given x and y coordinates.
        /// </summary>
        /// <param name="x">X coordinate of cell to set</param>
        /// <param name="y">Y coordinate of cell to set</param>
        /// <param name="glyph">The character to use for the glyph</param>
        /// <param name="background">The background color</param>
        /// <param name="foreground">The foreground (i.e. glyph) color</param>
        public void SetCell(int x, int y, char glyph, Color background, Color foreground)
        {
            _cells[x, y].Background = background;
            _cells[x, y].Foreground = foreground;
            _cells[x, y].Glyph = glyph;
        }
    }
}