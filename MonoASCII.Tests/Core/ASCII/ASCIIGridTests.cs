using Microsoft.Xna.Framework;
using MonoASCII.Framework.Components.ASCII;
using Shouldly;

namespace MonoASCII.Tests.Core.ASCII
{
    [TestFixture]
    public class ASCIIGridTests
    {

        [TestCase(0,0)]
        [TestCase(-1,-1)]
        [TestCase(0,1)]
        [TestCase(1,0)]
        public void Constructor_WithInvalidSize_ThrowsArgumentException(int width, int height)
        {
            // Act
            Action act = () => new ASCIIGrid(width, height, 1, 1, Color.White, Color.Black);
            // Assert
        }

        [TestCase(0, 0)]
        [TestCase(-1, -1)]
        [TestCase(0, 1)]
        [TestCase(1, 0)]
        public void Constructor_WithInvalidCellSize_ThrowsArgumentException(int width, int height)
        {
            // Act
            Action act = () => new ASCIIGrid(1, 1, width, height, Color.White, Color.Black);
            // Assert
            act.ShouldThrow(typeof(ArgumentException));
        }

        [TestCase( 255, 0, 0, 0, 0, 255 )]
        [TestCase( 0, 0 , 255, 255, 0, 0 )]
        public void ClearGrid_SetsGlyphsToBlankUsingDefaultColors(double f_red, double f_green, double f_blue, double b_red, double b_green, double b_blue)
        {
            // Arrange
            var foreground = new Color((float)f_red, (float)f_green, (float)f_blue);
            var  background = new Color((float)b_red, (float)b_green, (float)b_blue);

            var grid = GetDefaultGrid();

            grid.DefaultBackground = background;
            grid.DefaultForeground = foreground;

            // Act 
            grid.ClearGrid();

            // Assert
            for (int row = 0; row < grid.Height; row ++)
            {
                for (int col = 0; col < grid.Width; col++)
                {
                    var cell = grid.GetCell(col, row);
                    cell.Glyph.ShouldBe((char) 0);
                    cell.Foreground.ShouldBeEquivalentTo(foreground);
                    cell.Background.ShouldBeEquivalentTo(background);
                }
            }
        }

        [TestCase('a')]
        [TestCase('b')]
        [TestCase(' ')]
        [TestCase('@')] 
        [TestCase('#')]
        public void SetCell_WithVariedChars_SetsCellGlyph(char glyph)
        {
            // Arrange
            var grid = GetDefaultGrid();

            // Act
            grid.SetCell(1, 1, glyph, Color.White, Color.Black);

            // Assert
            grid.GetCell(1, 1).Glyph.ShouldBe(glyph);
        }

        [TestCase(255, 0, 0, 0, 255, 0)]
        [TestCase(0, 255, 0, 0, 0, 255)]
        public void SetCell_WithVariedColors_SetsCellColor(double f_red, double f_green, double f_blue, double b_red, double b_green, double b_blue)
        {
            // Arrange
            var grid = GetDefaultGrid();
            var foreground = new Color((float)f_red, (float)f_green, (float)f_blue);
            var background = new Color((float)b_red, (float)b_green, (float)b_blue);

            // Act
            grid.SetCell(1, 1, 'a', background, foreground);

            // Assert
            grid.GetCell(1, 1).Foreground.ShouldBeEquivalentTo(foreground);
            grid.GetCell(1, 1).Background.ShouldBeEquivalentTo(background);
        }


        [TestCase(255, 0, 0, 0, 0, 255)]
        [TestCase(0, 0, 255, 255, 0, 0)]
        public void SetCell_WithOnlyChar_SetsCellColorToDefault(double f_red, double f_green, double f_blue, double b_red, double b_green, double b_blue)
        {
            // Arrange
            var foreground = new Color((float)f_red, (float)f_green, (float)f_blue);
            var background = new Color((float)b_red, (float)b_green, (float)b_blue);

            var grid = GetDefaultGrid();

            grid.DefaultBackground = background; 
            grid.DefaultForeground = foreground;

            // Act
            grid.SetCell(1, 1, 'a');

            // Assert
            grid.GetCell(1, 1).Foreground.ShouldBeEquivalentTo(grid.DefaultForeground);
            grid.GetCell(1, 1).Background.ShouldBeEquivalentTo(grid.DefaultBackground);
        }

        [Test]
        public void SetCell_WhenOutOfBounds_DoesNotThrow()
        {
            // Arrange
            var grid = GetDefaultGrid();
            // Act
            Action act1 = () => grid.SetCell(grid.Width + 1, grid.Height + 1, 'a');
            Action act2 = () => grid.SetCell(-1, -1, 'a');
            // Assert
            act1.ShouldNotThrow();
            act2.ShouldNotThrow();
        }

        [Test]
        public void GetCell_WhenOutOfBounds_ReturnsBoundsCell()
        {
            // Arrange
            var grid = GetDefaultGrid();
            // Act
            var cell1 = grid.GetCell(-1, -1);
            var cell2 = grid.GetCell(grid.Width + 1, grid.Height + 1);
            // Assert
            cell1.ShouldBeEquivalentTo(ASCIIGrid.BoundsCell);
            cell2.ShouldBeEquivalentTo(ASCIIGrid.BoundsCell);
        }


        private ASCIIGrid GetDefaultGrid()
        {
            return new ASCIIGrid(3, 3, 1, 1, Color.White, Color.Black);
        }

    }
}
 