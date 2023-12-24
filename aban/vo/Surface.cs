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
    
	public void SetNewSize(Vector2I newSize)
	{
		View.Size = newSize;
		texture_.Size = newSize;
		
		OnSetNewSize(newSize);
		
		SizeUpdated();
	}

	protected virtual void OnSetNewSize(Vector2I newSize)
	{
		
	}
	
	public void SizeUpdated()
	{
		// texture_.AnchorsPreset = (int)Control.LayoutPreset.FullRect;
		OnSizeUpdated();
	}

	protected virtual void OnSizeUpdated()
	{
	} 

	public void SetNewPosition(Vector2I newPosition)
	{
		texture_.Position = newPosition;

		OnSetNewPosition(newPosition);
		
		PositionUpdated();
	}

	protected virtual void OnSetNewPosition(Vector2I newPosition)
	{
	}

	public void PositionUpdated()
	{
		OnPositionUpdated();
	}

	protected virtual void OnPositionUpdated()
	{
	}
	
}