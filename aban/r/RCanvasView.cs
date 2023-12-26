using System;
using Godot;

namespace azar82.aban.r;

public readonly struct RCanvasView : IDisposable
{
	private readonly RViewport view_;
	private readonly RCanvas canvas_;
	public Rid Texture => view_.Texture;

	public RCanvasView()
	{
		view_ = new RViewport();
		canvas_ = view_.CreateCanvas();
	}
	
	public readonly void Free()
	{
		canvas_.Free();
		view_.Free();
	}


	public void Dispose()
	{
		Free();
	}

	public void SetFor2D()
	{
		view_.SetFor2D();
	}

	public void SetRetained()
	{
		view_.SetRetained();
	}

	public void AttachItem(RCanvasItem canvasItem)
	{
		canvas_.AttachItem(canvasItem);
	}

	public void SetSize(Vector2I size)
	{
		view_.SetSize(size);
	}

	public void UpdateRetained()
	{
		view_.UpdateRetained();
	}
}