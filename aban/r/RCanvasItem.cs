using System;
using Godot;

namespace azar82.aban.r;

public readonly struct RCanvasItem() : IDisposable
{
	private static readonly RenderingServerInstance Server = RenderingServer.Singleton;
	public readonly Rid Rid = Server.CanvasItemCreate();

	public readonly void Free()
	{
		Server.FreeRid(Rid);
	}

	public readonly void Dispose()
	{
		Free();
	}

	public readonly void AttachToCanvas(RCanvas canvas)
	{
		canvas.AttachItem(Rid);
	}

	public readonly void AttachToCanvas(Rid canvas)
	{
		Server.CanvasItemSetParent(Rid, canvas);
	}

	public readonly void SetSize(Rect2 rect)
	{
		Server.CanvasItemSetCustomRect(Rid, true, rect);
	}

	public readonly void BlitTexture(Rid texture, Rect2 rect)
	{
		Server.CanvasItemAddTextureRect(Rid, rect, texture);
	}
	
}