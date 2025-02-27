using System;
using Microsoft.Xna.Framework;
using MonoASCII.Core.ASCII;
using MonoASCII.Core.Interfaces;

namespace MonoASCII.Core.Scenes;

public class MainMenuScene : Scene
{
    private ASCIIGrid _grid;
    public MainMenuScene(IRenderer renderer, Action<Scene> changeScene) : base(renderer, changeScene)
    {
        _grid = new ASCIIGrid(16,16,1,1, Color.Blue, Color.White);
        _grid.SetCell(1,1,'H');
        _grid.SetCell(2,1,'E');
        _grid.SetCell(3,1,'L');
        _grid.SetCell(4,1,'L');
        _grid.SetCell(5,1,'O');
    }

    public override void Update(GameTime gameTime)
    {
    }

    public override void Render()
    {
        Renderer.RenderAsciiGrid(_grid);
    }
}