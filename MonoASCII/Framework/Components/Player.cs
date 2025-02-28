namespace MonoASCII.Framework.Components;

public class Player : Component
{
    public Player()
    {
        AddComponent(new Transform() {X = 2, Y = 5});
    }
}