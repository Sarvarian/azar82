using Godot;

namespace azar82.main;

public sealed partial class Main : Node
{
    public override void _Ready()
    {
        base._Ready();
        topViewport_ = GetViewport();

        var vp = new SubViewport();
        AddChild(vp);

        var welcomeScene = GD.Load<PackedScene>("res://panels/welcome/welcome.tscn");
        var welcome = welcomeScene.Instantiate();
        vp.AddChild(welcome);

        var tvpSize = topViewport_.GetVisibleRect().Size;
        vp.Size = new Vector2I((int)tvpSize.X, (int)tvpSize.Y);

        var tr = new TextureRect();
        tr.AnchorsPreset = (int)Control.LayoutPreset.FullRect;
        AddChild(tr);

        tr.Texture = vp.GetTexture();
    }

    public override void _Input(InputEvent @event)
    {
        base._Input(@event);

        topViewport_!.SetInputAsHandled();
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
    }

    private Viewport? topViewport_ = null;

}