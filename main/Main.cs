using azar82.aban;
using azar82.aban.vo;
using Godot;

namespace azar82.main;

public sealed partial class Main : Node
{
    private readonly GuiIterator guiIterator_ = new();
    private Viewport? topViewport_ = null;

    private Rid ci_;
    private SubViewport? vp_ = null;
    private Rid c_;
    
    public override void _Ready()
    {
        base._Ready();
        topViewport_ = GetViewport();
    }

    public void Start()
    {
        guiIterator_.Start(new TopViewport(GetViewport()));
    }

    public override void _Input(InputEvent @event)
    {
        base._Input(@event);

        topViewport_!.SetInputAsHandled();
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        guiIterator_.Process();
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        guiIterator_.End();
    }
    
}