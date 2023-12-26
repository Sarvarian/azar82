using System;
using Godot;

namespace azar82.aban.r;

public readonly struct RCanvas() : IDisposable
{
	private static readonly RenderingServerInstance Server = RenderingServer.Singleton;
	private readonly Rid canvas_ = Server.CanvasCreate();

	public readonly void Free()
	{
		Server.FreeRid(canvas_);
	}

	public readonly void Dispose()
	{
		Free();
	}
    
	public readonly void AttachToViewport(RViewport viewport)
	{
		viewport.AttachCanvas(canvas_);
	}

	public readonly void AttachToViewport(Rid viewport)
	{
		Server.ViewportAttachCanvas(viewport, canvas_);
	}

	public readonly RItem CreateItem()
	{
		var item = new RItem();
		AttachItem(item);
		return item;
	}
	
	public readonly void AttachItem(RItem item)
	{
		item.AttachToCanvas(canvas_);
	}

	public readonly void AttachItem(Rid canvasItem)
	{
		Server.CanvasItemSetParent(canvasItem, canvas_);
	}
	
}