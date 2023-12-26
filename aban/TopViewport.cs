using azar82.aban.r;
using Godot;

namespace azar82.aban;

public class TopViewport
{
	// private readonly Surface surface01_;
	private bool doUpdateSize_ = false;
	private readonly Viewport topViewport_;
	private readonly RCanvas canvas_;
	private readonly ManuBar menuBar_;
	private readonly RItemView menuBarItem_; 

	public TopViewport(GuiIterator iterator, Viewport topViewport, ManuBar menuBar)
	{
		menuBar_ = menuBar;
		topViewport_ = topViewport;
		// surface01_ = new Welcome(topViewport);
		iterator.OnStart += Start;
		iterator.OnProcess += Process;
		iterator.OnEnd += End;
		canvas_ = new RCanvas();
		canvas_.AttachToViewport(topViewport_.GetViewportRid());
		menuBarItem_ = canvas_.CreateItemView(menuBar.GetView());
		UpdateMenuBar();
	}

	private void Start()
	{
		topViewport_.SizeChanged += OnTopViewportSizeChanged;
		// surface01_.Start();
	}

	private void End()
	{
		// surface01_.End();
		menuBar_.End();
		menuBarItem_.Free();
		canvas_.Free();
	}

	private void Process(double delta)
	{
		// surface01_.Process(delta);
		if (doUpdateSize_)
		{
			// surface01_.SetNewSize(newSize);
			UpdateMenuBar();
			doUpdateSize_ = false;
		}
	}
	
	private void OnTopViewportSizeChanged()
	{
		doUpdateSize_ = true;
	}

	private void UpdateMenuBar()
	{
		var rect = new Rect2(Vector2.Zero, menuBar_.Size);
		menuBarItem_.UpdateRetainedWithNewSize(rect);
	}
	
}