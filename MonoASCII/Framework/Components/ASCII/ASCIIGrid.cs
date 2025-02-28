using Microsoft.Xna.Framework;

namespace MonoASCII.Framework.Components.ASCII
{
    public class ASCIIGrid : Component
    {
        /// <summary>
        /// The cell used to represent out of bounds cells.
        /// </summary>
        public static ASCIICell BoundsCell = new ASCIICell((char)178, Color.Red, Color.Black);

        private ASCIICell[,] _cells;
        public Color DefaultBackground { get; set; }
        public Color DefaultForeground { get; set; }
        public int Width { get; }
        public int Height { get; }

        /// <summary>
        /// The width of each cell in world units.
        /// </summary>
        public int CellWidth { get; }

        /// <summary>
        /// The height of each cell in world units.
        /// </summary>
        public int CellHeight { get; }

        public ASCIIGrid(int width, int height, int tileWidth, int tileHeight, Color defaultBackground, Color defaultForeground)
        {
            if (width <= 0 || height <= 0)
            {
                throw new System.ArgumentException("Width and height must be greater than 0.");
            }

            if (tileWidth <= 0 || tileHeight <= 0)
            {
                throw new System.ArgumentException("Tile width and height must be greater than 0.");
            }

            Width = width;
            Height = height;
            DefaultBackground = defaultBackground;
            DefaultForeground = defaultForeground;
            CellWidth = tileWidth;
            CellHeight = tileHeight;

            _cells = new ASCIICell[Width, Height];
            ClearGrid();
        }

        /// <summary>
        /// Clears the grid using the default background and foreground colors.
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

        public void SetCell(int x, int y, char glyph, Color background, Color foreground)
        {
            _cells[x, y].Background = background;
            _cells[x, y].Foreground = foreground;
            _cells[x, y].Glyph = glyph;
        }

        public void SetCell(int x, int y, char glyph)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height)
            {
                return;
            }

            SetCell(x, y, glyph, DefaultBackground, DefaultForeground);
        }

        public ASCIICell GetCell(int x, int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height)
            {
                return BoundsCell;
            }

            return _cells[x, y];
        }

        public override void Render(GameTime gameTime, IRenderHandler renderHandler)
        {
            renderHandler.Render(this);
        }
    }
}