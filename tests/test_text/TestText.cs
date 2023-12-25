using azar82.aban.extensions;
using azar82.aban.resources;
using Godot;

namespace azar82.tests.test_text;

public partial class TestText : Node
{
	/*
	 * Text Management Microcosm
	 * - [ ] Get top Viewport.
	 * - [ ] ... 
	 */

	private SubViewport sub_ = new();
	private StaticText text_ = new("Hello!");
	private RCanvas canvas_ = new();
	private RCanvasItem item_ = new();

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
		item_.Free();
		canvas_.Free();
		text_.SafeFree();
		sub_.SafeFree();
	}

	public override void _Ready()
	{
		base._Ready();
		// AddChild(sub_);
		sub_.AddChild(text_);
		text_.OnUpdated += TextUpdated;
		canvas_.AttachToViewport(GetViewport().GetViewportRid());
		item_.AttachToCanvas(canvas_);
	}

	private uint counter_ = 2;
	
	private void TextUpdated()
	{
		GD.Print(counter_);
		if (counter_ == 0)
		{
			RemoveChild(sub_);
		}
		else
		{
			item_.BlitTexture(sub_.GetTexture().GetRid(), sub_.GetVisibleRect());
		}
		counter_ -= 1;
	}
	
	
}