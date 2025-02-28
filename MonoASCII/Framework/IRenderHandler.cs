using MonoASCII.Framework.Components;

namespace MonoASCII.Framework;

public interface IRenderHandler
{
    void Render(Component component);
}