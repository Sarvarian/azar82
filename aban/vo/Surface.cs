using azar82.aban.extensions;
using Godot;

namespace azar82.aban.vo;

public class Surface(Node parent) : VisualObject
{
	protected readonly SubViewport View = new();
	private readonly TextureRect texture_ = new();
	
	protected override void OnStart()
	{
		base.OnStart();
				
		texture_.Texture = View.GetTexture();
		parent.AddChild(View);
		parent.AddChild(texture_);
		SetNewSize(parent.GetViewport().GetVisibleRect().Size.ToInt());
	}

	protected override void OnEnd()
	{
		base.OnEnd();
		View.SafeFree();
		texture_.SafeFree();
	}
    
	public override void SetNewSize(Vector2I newSize)
	{
		base.SetNewSize(newSize);
	
		View.Size = newSize;
		texture_.Size = newSize;
		SizeUpdated();
	}

	public override void SizeUpdated()
	{
		base.SizeUpdated();
		// texture_.AnchorsPreset = (int)Control.LayoutPreset.FullRect;
	}

	public override void SetNewPosition(Vector2I newPosition)
	{
		base.SetNewPosition(newPosition);
	
		texture_.Position = newPosition;
		PositionUpdated();
	}

	public override void PositionUpdated()
	{
		base.PositionUpdated();
	}
	
}