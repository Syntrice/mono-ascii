using System;
using Microsoft.Xna.Framework;
using MonoASCII.Core.Interfaces;

namespace MonoASCII.Core.Scenes;

public abstract class Scene
{
    protected readonly Action<Scene> ChangeScene;
    protected readonly IRenderer Renderer;
    
    public Scene(IRenderer renderer, Action<Scene> changeScene)
    {
        ChangeScene = changeScene;
        Renderer = renderer;
    }
    
    public abstract void Update(GameTime gameTime);
    public abstract void Render();
}