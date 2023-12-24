using Godot;

namespace azar82.aban.extensions;

public static class Vector2Extension
{
	public static Vector2I ToInt(this Vector2 vec)
	{
		return new Vector2I((int)vec.X, (int)vec.Y);
	}

}