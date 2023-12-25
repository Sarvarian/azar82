using System;
using azar82.aban;
using Godot;

namespace azar82.main;

public sealed partial class Main : Node
{
    public event Action? OnPreStart;
    public event Action? OnStart;
    public event Action? OnPostStart;
    public event Action<double>? OnProcess;
    public event Action<double>? OnPhysicsProcess;
    public event Action<InputEvent>? OnInputEvent;
    public event Action? OnPreEnd;
    public event Action? OnEnd;
    public event Action? OnPostEnd;

    public Viewport GetTopViewport()
    {
        return GetViewport();
    }

    public GuiIterator GetGuiIterator()
    {
        return guiIterator_;
    }

    public Editor GetEditor()
    {
        return editor_;
    }

    private Viewport? topViewport_ = null;
    private readonly GuiIterator guiIterator_;
    private readonly Editor editor_;

    public Main()
    {
        guiIterator_ = new GuiIterator(this, this);
        editor_ = new Editor(this);
    }
    
    public override void _Ready()
    {
        base._Ready();
        topViewport_ = GetViewport();
    }

    private void Start()
    {
        OnPreStart?.Invoke();
        OnStart?.Invoke();
        OnPostStart?.Invoke();
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

    public override void _Notification(int what)
    {
        base._Notification(what);
    }

    public override void _ExitTree()
    {
        base._ExitTree();
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        Exit();
    }
    
    private bool isExitHandled_ = false;
    
    private void Exit()
    {
        if (isExitHandled_ == false)
        {
            OnPreEnd?.Invoke();
            OnEnd?.Invoke();
            OnPostEnd?.Invoke();
            // GD.Print("Exit Handled");
            isExitHandled_ = true;
        }
    }
    
    
}