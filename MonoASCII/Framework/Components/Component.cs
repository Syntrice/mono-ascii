using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace MonoASCII.Framework.Components;

public abstract class Component
{
    private readonly Dictionary<(string, Type), Component> _components = new Dictionary<(string, Type), Component>();
    public Component[] Components => _components.Values.ToArray();

    public void AddComponent(string name, Component component)
    {
        _components.Add((name, component.GetType()), component);
    }

    public T? GetComponent<T>(string name) where T : Component
    {
        try
        {
            return _components.TryGetValue((name, typeof(T)), out var component) ? component as T : null;
        }
        catch (InvalidCastException e)
        {
            return null;
        }
    }

    public virtual void Update(GameTime gameTime, IActionProvider actionProvider)
    {
        foreach (var component in _components.Values)
        {
            component.Update(gameTime, actionProvider);
        }
    }

    public virtual void Render(GameTime gameTime, IRenderHandler renderHandler)
    {
        foreach (var component in _components.Values)
        {
            component.Render(gameTime, renderHandler);
        }
    }
}