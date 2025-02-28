using System;
using Microsoft.Xna.Framework;
using MonoASCII.Framework.ASCII;

namespace MonoASCII.Framework.Scenes;

public class MainMenuScene : Scene
{
    public MainMenuScene()
    {
        var display = new ASCIIGrid(24, 16, 1, 1, Color.Black, Color.White);
        display.SetCell(1,1,'H');
        display.SetCell(2,1,'E');
        display.SetCell(3,1,'L');
        display.SetCell(4,1,'L');
        display.SetCell(5,1,'O');
        display.SetCell(6,1,' ');
        display.SetCell(7,1,'W');
        display.SetCell(8,1,'O');
        display.SetCell(9,1,'R');
        display.SetCell(10,1,'L');
        display.SetCell(11,1,'D');
        AddComponent("display", display);
    }
}