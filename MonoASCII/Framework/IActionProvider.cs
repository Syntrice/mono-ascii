using System.Collections.Generic;
using MonoASCII.Framework.Components;

namespace MonoASCII.Framework;

public interface IActionProvider
{
    public List<string> GetActions(Component component);
}