using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace MonoASCII.Framework.Components;

public class Component
{
    private readonly Dictionary<Type, Component> _components = new Dictionary<Type, Component>();
    public Component[] Components => _components.Values.ToArray();

    public void AddComponent(Component component)
    {
        _components.Add(component.GetType(), component);
    }

    public T? GetComponent<T>() where T : Component
    {
        return _components.TryGetValue(typeof(T), out var component) ? component as T : null;
    }

    public virtual void Update(GameTime gameTime) {}
}