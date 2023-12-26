using System;
using azar82.aban.extensions;
using Godot;

namespace azar82.aban.r;

public readonly struct RItemView : IDisposable
{
	public readonly RItem Item;
	public readonly RViewport View;

	public RItemView(RViewport viewport)
	{
		Item = new RItem();
		View = viewport;
	}
	
	public RItemView(RItem item)
	{
		Item = item;
		View = new RViewport();
	}
	
	public RItemView(RItem item, RViewport viewport)
	{
		Item = item;
		View = viewport;
	}
	
	public RItemView()
	{
		Item = new RItem();
		View = new RViewport();
	}

	public readonly void Free()
	{
		View.Free();
		Item.Free();
	}

	public readonly void Dispose()
	{
		Free();
	}

	public readonly void Update(Rect2 rect)
	{
		Item.BlitTexture(View.Texture, rect);
		Item.SetSize(rect);
	}

	public readonly void UpdateRetained(Rect2 rect)
	{
		View.UpdateRetained();
		Update(rect);
	}

	public readonly void UpdateRetainedWithNewSize(Rect2 rect)
	{
		View.UpdateRetainedWithNewSize(rect.Size.ToInt());
		Update(rect);
	}
	
}