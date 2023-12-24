using Godot;

namespace azar82.aban.vo;

public class Text : Surface
{
	public Text(Node parent) : base(parent)
	{
		View.Disable3D = true;
		View.RenderTargetUpdateMode = SubViewport.UpdateMode.Once;
	}

	protected override void OnStart()
	{
		base.OnStart();
		View.AddChild(text_);
		text_.Text = "File";
	}

	private readonly Label text_ = new();

}