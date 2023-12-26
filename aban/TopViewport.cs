using azar82.aban.r;
using Godot;

namespace azar82.aban;

public class TopViewport
{
	private readonly ManuBar menuBar_;
	// private readonly Surface surface01_;
	private bool doUpdateSize_ = false;
	private readonly Viewport topViewport_;

	public TopViewport(GuiIterator iterator, Viewport topViewport, ManuBar menuBar)
	{
		menuBar_ = menuBar;
		topViewport_ = topViewport;
		// surface01_ = new Welcome(topViewport);
		iterator.OnStart += Start;
		iterator.OnProcess += Process;
		iterator.OnEnd += End;
		canvas_ = new RCanvas();
		item_ = canvas_.CreateItem();
		canvas_.AttachToViewport(topViewport_.GetViewportRid());
		UpdateMenuBar();
	}

	private void Start()
	{
		topViewport_.SizeChanged += OnTopViewportSizeChanged;
		// surface01_.Start();
	}

	private readonly RCanvas canvas_;
	private readonly RCanvasItem item_;

	private void End()
	{
		// surface01_.End();
		menuBar_.End();
		item_.Free();
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
		var newSize = topViewport_.GetVisibleRect().Size;
		var rect = menuBar_.Update(newSize);
		var texture = menuBar_.GetTexture();
		item_.BlitTexture(texture, rect);
		item_.SetSize(rect);
	}
	
}