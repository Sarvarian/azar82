using azar82.aban.extensions;
using azar82.aban.vo;
using Godot;

namespace azar82.aban;

public class TopViewport
{
	private readonly VisObjManuBar menuBar_;
	// private readonly Surface surface01_;
	private bool doUpdateSize_ = false;
	private readonly Viewport topViewport_;

	public TopViewport(GuiIterator iterator, Viewport topViewport, VisObjManuBar menuBar)
	{
		menuBar_ = menuBar;
		topViewport_ = topViewport;
		// surface01_ = new Welcome(topViewport);
		iterator.OnStart += Start;
		iterator.OnProcess += Process;
		iterator.OnEnd += End;
	}

	private void Start()
	{
		topViewport_.SizeChanged += OnTopViewportSizeChanged;
		// surface01_.Start();
		var rs = RenderingServer.Singleton;
		c_ = rs.CanvasCreate();
		rs.ViewportAttachCanvas(topViewport_.GetViewportRid(), c_);
		ci_ = rs.CanvasItemCreate();
		rs.CanvasItemSetParent(ci_, c_);
	}

	private Rid c_;
	private Rid ci_;

	private void End()
	{
		// surface01_.End();
		menuBar_.End();
		var rs = RenderingServer.Singleton;
		rs.FreeRid(ci_);
		rs.FreeRid(c_);
	}

	private void Process(double delta)
	{
		// surface01_.Process(delta);
		if (doUpdateSize_)
		{
			var newSize = topViewport_.GetVisibleRect().Size.ToInt();
			// surface01_.SetNewSize(newSize);
			var rect = menuBar_.Update(newSize);
			var texture = menuBar_.GetTexture();
			var rs = RenderingServer.Singleton;
			rs.CanvasItemAddTextureRect(ci_, rect, texture);
			doUpdateSize_ = false;
		}
	}
	
	private void OnTopViewportSizeChanged()
	{
		doUpdateSize_ = true;
	}
	
}