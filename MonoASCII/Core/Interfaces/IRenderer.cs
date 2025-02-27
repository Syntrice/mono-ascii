using Microsoft.Xna.Framework;
using MonoASCII.Core.ASCII;

namespace MonoASCII.Core.Interfaces;

public interface IRenderer
{
    public void RenderAsciiGrid(ASCIIGrid grid);
}