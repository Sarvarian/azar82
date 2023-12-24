using Godot;

namespace azar82.aban.extensions;

public static class NodeExtension
{
	public static void SafeFree(this Node node)
	{
		var parent = node.GetParent();
		parent?.RemoveChild(node);
		node.QueueFree();
	}
}