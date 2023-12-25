using System;

namespace azar82.aban;

public sealed class GuiIterator : ProcessIterator
{
	public event Action? OnPreStart;
	public event Action? OnStart;
	public event Action? OnPostStart;
	public event Action<double>? OnProcess;
	public event Action? OnPreEnd;
	public event Action? OnEnd;
	public event Action? OnPostEnd;

	public Godot.Node GetRootNode()
	{
		return root_;
	}
	
	// private Query queryTopViewportChildren_ =
	// 	world.Query(filter: world.FilterBuilder()
	// 		.Term(Ecs.ChildOf, topViewport)
	// 	);

	private readonly Godot.Node root_;

	public GuiIterator(azar82.main.Main main, Godot.Node root) : base(main)
	{
		root_ = root;
		main.OnPreStart += PreStart;
		main.OnStart += Start;
		main.OnPostStart += PostStart;
		main.OnPreEnd += PreEnd;
		main.OnEnd += End;
		main.OnPostEnd += PostEnd;
	}

	private void PreStart()
	{
		OnPreStart?.Invoke();
	}

	private void Start()
	{
		OnStart?.Invoke();
	}

	private void PostStart()
	{
		OnPostStart?.Invoke();
	}

	private void PreEnd()
	{
		OnPreEnd?.Invoke();
	}
	
	private void End()
	{
		OnEnd?.Invoke();
	}
	
	private void PostEnd()
	{
		OnPostEnd?.Invoke();
	}
	
	protected override ulong GetMaxFps() => 30;

	protected override void RunSystems(double delta)
	{
		// GD.Print($"delta: {delta}, fps: {1.0 / delta}");
		
		// queryTopViewportChildren_.Each(ChildrenOfTopViewport);
		
		// Process Top Events : Top Viewport and Panels
		// Process Panel Sizes.
		// Process Panel Positions.
		// Process Panels.
		// ...
		// Process Top Redraw : Panels
		
		// Different Types of GUI Systems
		// Godot Scene
		// Godot Render Server
		// SubViewports and TextureRects
		// 

		OnProcess?.Invoke(delta);

	}

	private void ChildrenOfTopViewport()
	{
		// GD.Print($"Children of Top Viewport: {e.Name()}");
	}
	
}