using Microsoft.Xna.Framework;
using MonoASCII.Core.Interfaces;

namespace MonoASCII.Core.Scenes;

public class SceneManager
{
    private Scene _currentScene;
    private readonly IRenderer _renderer;

    public SceneManager(IRenderer renderer)
    {
        _renderer = renderer;
        _currentScene = new MainMenuScene(_renderer, ChangeScene);
    }

    private void ChangeScene(Scene scene)
    {
        _currentScene = scene;
    }

    public void Update(GameTime gameTime)
    {
        _currentScene.Update(gameTime);
    }

    public void Render()
    {
        _currentScene.Render();
    }
}