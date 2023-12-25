using azar82.aban.extensions;
using Godot;

namespace azar82.aban;

public readonly struct VisObjText
{
	public VisObjText(string text, GuiIterator guiIterator)
	{
		label_.Text = text;
		view_.AddChild(label_);
		guiIterator.GetRootNode().AddChild(view_);
		view_.RenderTargetUpdateMode = SubViewport.UpdateMode.Once;
	}

	public ViewportTexture GetTexture()
	{
		return view_.GetTexture();
	}

	public Vector2 GetSize()
	{
		return label_.Size;
	}

	public void Update()
	{
		view_.Size = label_.Size.ToInt();
		view_.RenderTargetUpdateMode = SubViewport.UpdateMode.Once;
	}

	private readonly Label label_ = new();
	private readonly SubViewport view_ = new();

}