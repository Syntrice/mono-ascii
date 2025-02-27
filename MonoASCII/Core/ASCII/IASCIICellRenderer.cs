using Microsoft.Xna.Framework;
using MonoASCII.Core.ASCII;

namespace MonoASCII.Core.ASCII;

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
}