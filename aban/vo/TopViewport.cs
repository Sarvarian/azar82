using azar82.aban.extensions;
using Godot;

namespace azar82.aban.vo;

public class TopViewport(Viewport topViewport) : VisualObject
{
	protected override void OnStart()
	{
		base.OnStart();
		topViewport.SizeChanged += OnTopViewportSizeChanged;
		AddSub(surface01_);
	}

	protected override void OnProcess(double delta)
	{
		base.OnProcess(delta);
		if (doUpdateSize_)
		{
			var newSize = topViewport.GetVisibleRect().Size.ToInt();
			surface01_.SetNewSize(newSize);
			doUpdateSize_ = false;
		}
	}

	private bool doUpdateSize_ = false;
	private readonly Surface surface01_ = new Welcome(topViewport);
	
	private void OnTopViewportSizeChanged()
	{
		doUpdateSize_ = true;
	}
	
}