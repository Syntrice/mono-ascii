using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoASCII.Tests
{
    [TestFixture]
    public class ContentTests
    {
        [Test]
        public void ContentLoad_cp437_8x8_DoesNotThrowException()
        {
            // Arrange
            Game game = Utility.GetDefaultGameObject();

            // Act
            TestDelegate act = () =>
            {
                Texture2D texture = game.Content.Load<Texture2D>("cp437_8x8");
            };

            // Assert
            Assert.DoesNotThrow(act);
        }

    }
}
