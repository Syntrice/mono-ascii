using System;
using Microsoft.Xna.Framework;
using MonoASCII.Framework.Components.ASCII;

namespace MonoASCII.Framework.Scenes;

public class MainMenuScene : Scene
{
    
    private bool _toggle = false;
    private ASCIIGrid _display;
    private ASCIIGrid _display2;
    public MainMenuScene()
    {
        _display = new ASCIIGrid(0,0,24, 24, 1, 1, Color.Black, Color.White);
        _display2 = new ASCIIGrid(24,0,24, 24, 1, 1, Color.Blue, Color.White);
        _display.SetCell(1,1,'H');
        _display.SetCell(2,1,'E');
        _display.SetCell(3,1,'L');
        _display.SetCell(4,1,'L');
        _display.SetCell(5,1,'O');
        _display.SetCell(6,1,' ');
        _display.SetCell(7,1,'W');
        _display.SetCell(8,1,'O');
        _display.SetCell(9,1,'R');
        _display.SetCell(10,1,'L');
        _display.SetCell(11,1,'D');
        
        _display2.SetCell(1,1,'W');
        _display2.SetCell(2,1,'O');
        _display2.SetCell(3,1,'R');
        _display2.SetCell(4,1,'L');
        _display2.SetCell(5,1,'D');
        _display2.SetCell(6,1,' ');
        _display2.SetCell(7,1,'H');
        _display2.SetCell(8,1,'E');
        _display2.SetCell(9,1,'L');
        _display2.SetCell(10,1,'L');
        _display2.SetCell(11,1,'O');

        AddComponent("display", _display);
        AddComponent("display2", _display2);
    }

    public override void Update(GameTime gameTime, IActionProvider actionProvider)
    {
        var actions = actionProvider.GetActions(this);
        if (actions.Contains("SPACE_ACTION"))
        {
            if (_toggle)
            {
                _toggle = false;
                _display.SetCell(10,10,'Y',Color.Black, Color.Green);
            }
            else
            {
                _toggle = true;
                _display.SetCell(10,10,'N',Color.Black, Color.Red);
            }
        }
        // base.Update(gameTime, actionProvider);
    }
}