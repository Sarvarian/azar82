using azar82.aban.vo;

namespace azar82.aban;

internal sealed class GuiIterator() : ProcessIterator
{
	// private Query queryTopViewportChildren_ =
	// 	world.Query(filter: world.FilterBuilder()
	// 		.Term(Ecs.ChildOf, topViewport)
	// 	);

	private TopViewport? topViewport_ = null;

	public void Start(TopViewport topViewport)
	{
		topViewport_ = topViewport;
		topViewport_.Start();
	}

	public void End()
	{
		topViewport_?.End();
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
		
		topViewport_?.Process(delta);
		
	}

	private void ChildrenOfTopViewport()
	{
		// GD.Print($"Children of Top Viewport: {e.Name()}");
	}
	
}