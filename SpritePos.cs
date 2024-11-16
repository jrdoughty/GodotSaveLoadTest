using Godot;

[GlobalClass]
public partial class SpritePos : Resource
{

    [Export] public Vector2 Position { get; set; }
    public SpritePos() : this(0, 0) {}
    public SpritePos(int x, int y)
    {
        Position = new Vector2(x, y);
    }
}