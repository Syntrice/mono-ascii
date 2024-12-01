using FluentAssertions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoASCII.Source.Graphics;
using MonoGame.Extended.Graphics;

namespace MonoASCII.Tests
{
    [TestFixture]
    public class ASCIITilesetTests
    {

        [TestCase(0,0,0)]
        [TestCase(1,8,0)]
        [TestCase(20,32,8)]
        public void GetGlyph_InRangeChars_ReturnsCorrectTextureCoordinates(int charCode, int xBound, int yBound)
        {
            // Arrange
            Game game = Utility.GetDefaultGameObject();
            Texture2D tilesetTexture = GetDefaultTexture(game);
            ASCIITileset tileset = new ASCIITileset(tilesetTexture, glyphWidth: 8, glyphHeight: 8);
            Rectangle expectedBounds = new Rectangle(xBound, yBound, 8, 8);

            // Act
            Rectangle actualBounds = tileset.GetGlyph(charCode).Bounds;

            // Assert
            actualBounds.X.Should().Be(expectedBounds.X);
            actualBounds.Y.Should().Be(expectedBounds.Y);
            actualBounds.Width.Should().Be(expectedBounds.Width);
            actualBounds.Height.Should().Be(expectedBounds.Height);
        }

        [TestCase(256)]
        [TestCase(512)]
        [TestCase(-16)]
        public void GetGlyph_OutOfRangeChars_ThrowsException(int charCode)
        {
            // Arrange
            Game game = Utility.GetDefaultGameObject();
            Texture2D tilesetTexture = GetDefaultTexture(game);
            ASCIITileset tileset = new ASCIITileset(tilesetTexture, glyphWidth: 8, glyphHeight: 8);

            // Act
            TestDelegate act = () =>
            {
                Texture2DRegion texture = tileset.GetGlyph(charCode);
            };

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        private Texture2D GetDefaultTexture(Game game)
        {
            return game.Content.Load<Texture2D>("cp437_8x8");
        }
    }
}
