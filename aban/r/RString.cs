using System;
using Godot;

namespace azar82.aban.r;

public readonly struct RString : IDisposable
{
	private static readonly Font Font = ThemeDB.FallbackFont;
	public readonly RCanvasItem Item = new();
	public readonly Vector2 Size;
	
	public RString(string str)
	{
		Size = Font.GetStringSize(str);
		Font.DrawString(Item.Rid, new Vector2(0.0f, Font.GetAscent()), str);
	}

	public readonly void Free()
	{
		Item.Free();
	}

	public readonly void Dispose()
	{
		Free();
	}
}