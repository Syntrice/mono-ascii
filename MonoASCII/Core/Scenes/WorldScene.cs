using System;
using Microsoft.Xna.Framework;
using MonoASCII.Core.Interfaces;

namespace MonoASCII.Core.Scenes;

public class WorldScene : Scene
{
    public WorldScene(IRenderer renderer, Action<Scene> ChangeScene) : base(renderer, ChangeScene)
    {
    }

    public override void Update(GameTime gameTime)
    {
        throw new System.NotImplementedException();
    }

    public override void Render()
    {
        throw new System.NotImplementedException();
    }
}