using Godot;

namespace azar82.main_scene;

public sealed partial class MainScene : Node
{
    public override void _Ready()
    {
        base._Ready();
        //GD.Print("Hello, world!");
        GetViewport().SizeChanged += OnSizeChanged;
    }

    private void OnSizeChanged()
    {
        var size = GetViewport().GetVisibleRect().Size;
        //GD.Print($"{size.X}, {size.Y}");
    }

    public override void _EnterTree()
    {
        base._EnterTree();
        //GD.Print("Enter Tree.");
    }

    public override void _ExitTree()
    {
        base._ExitTree();
        //GD.Print("Exit Tree.");
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        //GD.Print($"Disposing: {disposing}");
    }

}