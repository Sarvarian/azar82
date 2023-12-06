using Godot;

namespace azar82.scripts;

public partial class Main : Node
{
    public override void _Ready()
    {
        base._Ready();
        GD.Print("Hello, world!");
    }
}