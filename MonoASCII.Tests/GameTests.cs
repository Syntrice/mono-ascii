namespace MonoASCII.Tests
{
    public class GameTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Run_OneFrame_NoExceptions()
        {
            try
            {
                Game game = new Game();
                game.RunOneFrame();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}