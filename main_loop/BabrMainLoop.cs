using azar82.scripts_godot_agents;
using Godot;

namespace azar82.main_loop;

public sealed partial class BabrMainLoop : MainLoop
{
    private readonly Main main_ = new();

    public override void _Initialize()
    {
        //GD.Print("Main Loop Initialize");
        main_.Start();
    }

    public override bool _Process(double delta)
    {
        //GD.Print("Main Loop Process");
        main_.Process(delta);
        return ExitRequest.DoExit;
    }

    public override bool _PhysicsProcess(double delta)
    {
        //GD.Print("Main Loop Physics Process");
        main_.PhysicsProcess(delta);
        return ExitRequest.DoExit;
    }

    public override void _Finalize()
    {
        //GD.Print("Main Loop Finalize");
        //Console.WriteLine("Main Loop Finalize");
        main_.End();
    }
}