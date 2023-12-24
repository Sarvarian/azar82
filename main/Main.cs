using System;
using azar82.aban;
using azar82.aban.editor;
using Godot;

namespace azar82.main;

public sealed partial class Main : Node, IMain
{
    public event Action? OnStart;
    public event Action<double>? OnProcess;
    public event Action<double>? OnPhysicsProcess;
    public event Action<InputEvent>? OnInputEvent;
    public event Action? OnEnd;
    public Viewport GetTopViewport()
    {
        return GetViewport();
    }

    private Viewport? topViewport_ = null;

    public Main()
    {
        var guiIterator = new GuiIterator(this);
        var editor = new Editor(this);
    }
    
    public override void _Ready()
    {
        base._Ready();
        topViewport_ = GetViewport();
    }

    private void Start()
    {
        OnStart?.Invoke();
    }

    public override void _Input(InputEvent @event)
    {
        base._Input(@event);
        OnInputEvent?.Invoke(@event);
        topViewport_!.SetInputAsHandled();
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        OnProcess?.Invoke(delta);
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        OnPhysicsProcess?.Invoke(delta);
    }

    public override void _ExitTree()
    {
        base._ExitTree();
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        OnEnd?.Invoke();
    }
    
}