using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using MonoASCII.Framework;
using MonoASCII.Framework.Components;
using MonoASCII.Framework.Scenes;

namespace MonoASCII.Engine;

public class MonoGameActionProvider : IActionProvider
{
    private KeyboardState _previousKeyboardState;
    private KeyboardState _currentKeyboardState;

    public void GetKeyboardState()
    {
        _currentKeyboardState = Keyboard.GetState();
    }

    public List<string> GetActions(Component component)
    {
        List<string> actions = new List<string>();
        
        if (component is MainMenuScene)
        {
            if (_currentKeyboardState.IsKeyDown(Keys.Space))
            {
                if (!_previousKeyboardState.IsKeyDown(Keys.Space))
                {
                    actions.Add("SPACE_ACTION");
                }
            }
        }
        
        _previousKeyboardState = _currentKeyboardState;
        
        return actions;
    }
}