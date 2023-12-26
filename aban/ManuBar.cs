using System.Collections.Generic;
using azar82.aban.extensions;
using azar82.aban.r;
using Godot;

namespace azar82.aban;

public readonly struct ManuBar
{
	private readonly List<RString> texts_ = [];
	private readonly RViewCanvas view_;

	public readonly Vector2 Size = Vector2.Zero;
	
	public ManuBar(EditorMenuBarSystem menuSystem)
	{
		view_ = new RViewCanvas();
		view_.SetFor2D();
		view_.SetRetained();
		
		Size.X = 0.0f;
		foreach (var str in menuSystem.Menus)
		{
			var text = new RString(str);
			texts_.Add(text);
			view_.AttachItem(text.Item);
			
			var trans = Transform2D.Identity;
			trans.Origin.X = Size.X;
			text.Item.SetTransform(trans);
			
			Size.X += text.Size.X + 10.0f;
			Size.Y = Size.Y < text.Size.Y ? text.Size.Y : Size.Y;
		}
		view_.SetSize(Size.ToInt());
	}

	public void End()
	{
		foreach (var item in texts_)
		{
			item.Free();
		}
		view_.Free();
	}

	public readonly RViewport GetView()
	{
		return view_.View;
	}

}