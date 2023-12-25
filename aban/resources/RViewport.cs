using System;
using Godot;

namespace azar82.aban.resources;

public readonly struct RViewport : IDisposable
{
	private static readonly RenderingServerInstance Server = RenderingServer.Singleton;
	private readonly Rid viewport_;
	public readonly Rid Texture;
	
	public RViewport()
	{
		viewport_ = Server.ViewportCreate();
		Texture = Server.ViewportGetTexture(viewport_);
	}
	
	public readonly void Free()
	{
		Server.FreeRid(viewport_);
	}
	
	public readonly void Dispose()
	{
		Free();
	}

	public readonly void SetFor2D()
	{
		Server.ViewportSetDisable3D(viewport_, true);
		Server.ViewportSetDisable2D(viewport_, false);
	}

	public readonly void SetRetained()
	{
		Server.ViewportSetUpdateMode(viewport_, RenderingServer.ViewportUpdateMode.Once);
	}

	public readonly void SetImmediate()
	{
		Server.ViewportSetUpdateMode(viewport_, RenderingServer.ViewportUpdateMode.Always);
	}

	public readonly void UpdateRetained()
	{
		Server.ViewportSetUpdateMode(viewport_, RenderingServer.ViewportUpdateMode.Once);
	}

	public readonly void SetSize(Vector2I newSize)
	{
		Server.ViewportSetSize(viewport_, newSize.X, newSize.Y);
	}

	public readonly void UpdateRetainedWithNewSize(Vector2I newSize)
	{
		SetSize(newSize);
		UpdateRetained();
	}

}