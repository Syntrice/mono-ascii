using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Graphics;

namespace MonoASCII.Source.Graphics
{
    public class ASCIIGrid
    {

        // TODO: Encapsulate as struct
        private Color[,] backgroundColors;
        private Color[,] foregroundColors;
        private char[,] glyphs;


        public Color DefaultBackground { get; }
        public Color DefaultForeground { get; }
        public int Width { get; }
        public int Height { get; }
        public int TileWidth { get; }
        public int TileHeight { get; }
        public ASCIITileset Tileset { get; }
        
        public ASCIIGrid(ASCIITileset tileset, int width, int height, int tileWidth, int tileHeight, Color defaultBackground, Color defaultForeground)
        {
            Width = width;
            Height = height;
            Tileset = tileset;
            DefaultBackground = defaultBackground;
            DefaultForeground = defaultForeground;
            TileWidth = tileWidth;
            TileHeight = tileHeight;

            backgroundColors = new Color[Width, Height];
            foregroundColors = new Color[Width, Height];
            glyphs = new char[Width, Height];
        }

        public ASCIIGrid(ASCIITileset tileset, int width, int height, int tileWidth, int tileHeight)
            : this(tileset, width, height, tileWidth, tileHeight, Color.Black, Color.White) { }

        public void ClearGrid()
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    backgroundColors[i,j] = DefaultBackground;
                    foregroundColors[i,j] = DefaultForeground;
                    glyphs[i, j] = (char) 0;
                }
            }
        }

        public void SetGlyph(int x, int y, char glyph, Color background, Color foreground)
        {
                backgroundColors[x, y] = background;
                foregroundColors[x,y] = foreground;
                glyphs[x, y] = glyph;
        }

        public void Render(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    spriteBatch.FillRectangle(new Rectangle(i,j,TileWidth,TileHeight), backgroundColors[i,j]);
                    spriteBatch.Draw(Tileset.GetGlyph(glyphs[i,j]), new Rectangle(i,j, TileWidth, TileWidth), foregroundColors[i,j]);
                }
            }
        }
    }
}