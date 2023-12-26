using System;
using Godot;

namespace azar82.aban.r;

public readonly struct RViewCanvas : IDisposable
{
	public readonly RViewport View;
	public readonly RCanvas Canvas;
	public Rid Texture => View.Texture;

	public RViewCanvas()
	{
		View = new RViewport();
		Canvas = View.CreateCanvas();
	}
	
	public readonly void Free()
	{
		Canvas.Free();
		View.Free();
	}

	public void Dispose()
	{
		Free();
	}

	public void SetFor2D()
	{
		View.SetFor2D();
	}

	public void SetRetained()
	{
		View.SetRetained();
	}

	public void AttachItem(RItem item)
	{
		Canvas.AttachItem(item);
	}

	public void SetSize(Vector2I size)
	{
		View.SetSize(size);
	}

	public void UpdateRetained()
	{
		View.UpdateRetained();
	}
}