using Microsoft.Xna.Framework;
using MonoASCII.Framework.Scenes;

namespace MonoASCII.Framework;

public class SceneManager
{
    private Scene _currentScene;

    public SceneManager(Scene startingScene)
    {
        _currentScene = startingScene;
    }
    
    public void Update(GameTime gameTime, IActionProvider actionProvider)
    {
        _currentScene.Update(gameTime, actionProvider);
    }

    public void Render(GameTime gameTime, IRenderHandler renderHandler)
    {
        _currentScene.Render(gameTime, renderHandler);
    }
}