using MonoASCII.Core.ASCII;

namespace MonoASCII.Core.Utilities;

public static class RenderUtilities
{
    public static void RenderASCIIGrid(ASCIIGrid asciiGrid, IASCIICellRenderer renderer)
    {
        for (int i = 0; i < asciiGrid.Width; i++)
        {
            for (int j = 0; j < asciiGrid.Height; j++)
            {
                renderer.Render(asciiGrid.GetCell(i, j), i, j, asciiGrid.CellWidth, asciiGrid.CellHeight);
            }
        }
    }
}