using azar82.scripts_godot_agents;
using Godot;

namespace azar82.main_scene;

public sealed partial class MainScene : Node
{
    private scripts_godot_agents.Main? main_;
    
    public override void _Ready()
    {
        base._Ready();
        main_ = new Main(this, GetViewport());
        main_.Start();
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        main_?.Process(delta);
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        main_?.PhysicsProcess(delta);
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        main_?.End();
    }

}