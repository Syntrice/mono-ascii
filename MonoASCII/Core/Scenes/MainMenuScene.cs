using System;
using Microsoft.Xna.Framework;
using MonoASCII.Framework.ASCII;

namespace MonoASCII.Core.Scenes;

public class MainMenuScene : Scene
{
    private ASCIIGrid _grid;
    private IASCIICellRenderer _cellRenderer;
    
    public MainMenuScene(IASCIICellRenderer cellRenderer, Action<Scene> changeScene) : base(cellRenderer, changeScene)
    {
        _grid = new ASCIIGrid(16,16,1,1, Color.DarkSlateGray, Color.White);
        _cellRenderer = cellRenderer;
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
        _cellRenderer.RenderGrid(_grid);
    }
}