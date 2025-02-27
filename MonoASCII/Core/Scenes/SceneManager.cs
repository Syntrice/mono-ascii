using Microsoft.Xna.Framework;
using MonoASCII.Core.ASCII;

namespace MonoASCII.Core.Scenes;

public class SceneManager
{
    private Scene _currentScene;
    private readonly IASCIICellRenderer _cellRenderer;

    public SceneManager(IASCIICellRenderer cellRenderer)
    {
        _cellRenderer = cellRenderer;
        _currentScene = new MainMenuScene(_cellRenderer, ChangeScene);
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