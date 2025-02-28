using System;
using Microsoft.Xna.Framework;
using MonoASCII.Framework.Components.ASCII;

namespace MonoASCII.Framework.Scenes;

public class MainMenuScene : Scene
{
    
    private bool _toggle = false;
    private ASCIIGrid _display;
    public MainMenuScene()
    {
        _display = new ASCIIGrid(48, 24, 1, 1, Color.Black, Color.White);
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
        AddComponent("display", _display);
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