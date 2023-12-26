using azar82.aban;
using azar82.aban.extensions;
using azar82.aban.r;
using Godot;

namespace azar82.tests;

public partial class Test : Node
{
	private readonly EditorMenuBarSystem menuSystem_ = new();
	private readonly VisObjManuBar menuBar_;
	private readonly RCanvas canvas_ = new();
	private readonly RCanvasItem item_ = new();
	private readonly RViewport subViewport_ = new();
	private readonly RCanvas subCanvas_ = new();
	private readonly RCanvasItem subItem_ = new();

	public Test()
	{
		menuBar_ = new VisObjManuBar(menuSystem_);
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
		menuBar_.End();
		subItem_.Free();
		subCanvas_.Free();
		subViewport_.Free();
		item_.Free();
		canvas_.Free();
	}

	public override void _Ready()
	{
		base._Ready();
		canvas_.AttachToViewport(GetViewport().GetViewportRid());
		item_.AttachToCanvas(canvas_);
		subCanvas_.AttachToViewport(subViewport_);
		subItem_.AttachToCanvas(subCanvas_);
		subViewport_.SetSize(GetViewport().GetVisibleRect().Size.ToInt());
		// subViewport_.SetParent(GetViewport());
	}

	public override void _Process(double delta)
	{
		base._Process(delta);
		
		var rect = menuBar_.Update(GetViewport().GetVisibleRect().Size);
		var texture = menuBar_.GetTexture();
		item_.BlitTexture(texture, rect);
		
		var rs = RenderingServer.Singleton;
		var ci = subItem_.Rid;
		rs.CanvasItemAddLine(ci, new Vector2(5.0f, 5.0f), new Vector2(10.0f, 10.0f), Colors.Aqua);

		var rect2 = GetViewport().GetVisibleRect();
		item_.BlitTexture(subViewport_.Texture, rect2);

	}
}