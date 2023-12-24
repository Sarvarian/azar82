using System;

namespace azar82.aban;

public sealed class GuiIterator : ProcessIterator
{
	public event Action? OnStart;
	public event Action<double>? OnProcess;
	public event Action? OnEnd;
	
	// private Query queryTopViewportChildren_ =
	// 	world.Query(filter: world.FilterBuilder()
	// 		.Term(Ecs.ChildOf, topViewport)
	// 	);

	public GuiIterator(azar82.main.Main main) : base(main)
	{
		main_ = main;
		main_.OnStart += Start;
	}

	private readonly azar82.main.Main main_;
	private TopViewport? topViewport_ = null;

	private void Start()
	{
		topViewport_ = new TopViewport(this, main_.GetTopViewport());
		OnStart?.Invoke();
	}

	private void End()
	{
		OnEnd?.Invoke();
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