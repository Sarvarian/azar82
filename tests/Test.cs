using azar82.aban;
using azar82.aban.extensions;
using azar82.aban.resources;
using Godot;

namespace azar82.tests;

public partial class Test : Node
{
	private EditorMenuBarSystem menuSystem_ = new();
	private VisObjManuBar menuBar_;
	private RCanvas c_ = new();
	private RCanvasItem ci_ = new();

	public Test()
	{
		menuBar_ = new VisObjManuBar(menuSystem_);
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
		menuBar_.End();
		ci_.Free();
		c_.Free();
	}

	public override void _Ready()
	{
		base._Ready();
		c_.AttachToViewport(GetViewport().GetViewportRid());
		ci_.AttachToCanvas(c_);
	}

	public override void _Process(double delta)
	{
		base._Process(delta);
		var rect = menuBar_.Update(GetViewport().GetVisibleRect().Size);
		var texture = menuBar_.GetTexture();
		ci_.BlitTexture(texture, rect);
	}
}