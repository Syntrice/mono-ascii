using System;
using Microsoft.Xna.Framework;
using MonoASCII.Framework.ASCII;

namespace MonoASCII.Core.Scenes;

public abstract class Scene
{
    protected readonly Action<Scene> ChangeScene;
    protected readonly IASCIICellRenderer Renderer;
    
    public Scene(IASCIICellRenderer renderer, Action<Scene> changeScene)
    {
        ChangeScene = changeScene;
        Renderer = renderer;
    }
    
    public abstract void Update(GameTime gameTime);
    public abstract void Render();
}