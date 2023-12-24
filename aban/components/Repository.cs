using Godot;

namespace azar82.aban.components;

// GUI Components

public readonly struct CViewport(Viewport viewport)
{
	public readonly Viewport GObj = viewport;
}

public readonly struct CViewportRid(Rid viewportRid)
{
	public readonly Rid Rid = viewportRid;
}

public readonly struct CSubViewport(SubViewport subViewport)
{
	public readonly SubViewport GObj = subViewport;
}

public struct CNewSize(Vector2I newSize)
{
	public Vector2I NewSize = newSize;
}

public struct CSizeChanged;
