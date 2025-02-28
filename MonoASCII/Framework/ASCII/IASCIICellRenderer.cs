namespace MonoASCII.Framework.ASCII;

/// <summary>
/// An interface which defines methods for rendering various game components.
/// </summary>
public interface IASCIICellRenderer
{
    /// <summary>
    /// Render an ASCII cell onto the display
    /// </summary>
    /// <param name="cell">The cell to render</param>
    /// <param name="x">X position in game units</param>
    /// <param name="y">Y position in game units</param>
    /// <param name="width">width in game units</param>
    /// <param name="height">height in game units</param>
    public void Render(ASCIICell cell, int x, int y, int width, int height);

    /// <summary>
    /// Utility method for rendering an ASCIIGrid
    /// </summary>
    /// <param name="asciiGrid">The grid to render</param>
    public void RenderGrid(ASCIIGrid asciiGrid)
    {
        for (int i = 0; i < asciiGrid.Width; i++)
        {
            for (int j = 0; j < asciiGrid.Height; j++)
            {
                this.Render(asciiGrid.GetCell(i, j), i, j, asciiGrid.CellWidth, asciiGrid.CellHeight);
            }
        }
    }
}