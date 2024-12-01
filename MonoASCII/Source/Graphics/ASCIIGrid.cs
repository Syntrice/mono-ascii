using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Graphics;

namespace MonoASCII.Source.Graphics
{
    public class ASCIIGrid
    {
        private ASCIICell[,] cells;

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

        public ASCIITileset Tileset { get; }

        public ASCIIGrid(ASCIITileset tileset, int width, int height, int tileWidth, int tileHeight, Color defaultBackground, Color defaultForeground)
        {
            Width = width;
            Height = height;
            Tileset = tileset;
            DefaultBackground = defaultBackground;
            DefaultForeground = defaultForeground;
            CellWidth = tileWidth;
            CellHeight = tileHeight;

            cells = new ASCIICell[Width, Height];
        }

        public ASCIIGrid(ASCIITileset tileset, int width, int height, int tileWidth, int tileHeight)
            : this(tileset, width, height, tileWidth, tileHeight, Color.Black, Color.White) { }

        /// <summary>
        /// Clear the grid, initializing all cells to the default background and foreground colors, and the null glyph.
        /// </summary>
        public void ClearGrid()
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    cells[i, j] = new ASCIICell((char)0, DefaultForeground, DefaultBackground);
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
            cells[x, y].Background = background;
            cells[x, y].Foreground = foreground;
            cells[x, y].Glyph = glyph;
        }

        /// <summary>
        /// Renders the current state of the grid to the given SpriteBatch.
        /// </summary>
        public void Render(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    spriteBatch.FillRectangle(new Rectangle(i, j, CellWidth, CellHeight), cells[i, j].Background);
                    spriteBatch.Draw(Tileset.GetGlyph(cells[i, j].Glyph), new Rectangle(i, j, CellWidth, CellWidth), cells[i, j].Foreground);
                }
            }
        }
    }
}