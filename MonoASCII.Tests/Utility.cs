using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoASCII.Tests
{
    public class Utility
    {
        public static Game GetDefaultGameObject()
        {
            Game game = new Game();
            game.RunOneFrame();
            return game;
        }

    }
}
