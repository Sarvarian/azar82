using Godot;

namespace azar82.main_scene;

public sealed partial class MainScene : Node
{
    private agents.Main? main_;
    
    public override void _Ready()
    {
        base._Ready();
        main_ = new agents.Main(this, GetViewport());
        main_.Start();
    }

    public override void _Input(InputEvent @event)
    {
        base._Input(@event);
        main_!.Input(@event);
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        main_!.Process(delta);
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        main_!.PhysicsProcess(delta);
        if (agents.ExitRequest.DoExit)
        {
            GetTree().Quit();
        }
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        main_!.End();
    }

}