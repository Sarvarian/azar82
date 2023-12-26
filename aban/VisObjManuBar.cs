using System.Collections.Generic;
using azar82.aban.extensions;
using azar82.aban.r;
using Godot;

namespace azar82.aban;

public sealed class VisObjManuBar
{
	private readonly List<RString> texts_ = [];
	private readonly RViewport view_;
	private readonly RCanvas canvas_;

	private Vector2 size_ = Vector2.Zero;
	
	public VisObjManuBar(EditorMenuBarSystem menuSystem)
	{
		view_ = new RViewport();
		view_.SetFor2D();
		view_.SetRetained();
		canvas_ = view_.CreateCanvas();
		
		size_.X = 0.0f;
		foreach (var str in menuSystem.Menus)
		{
			var text = new RString(str);
			texts_.Add(text);
			canvas_.AttachItem(text.Item);
			
			var trans = Transform2D.Identity;
			trans.Origin.X = size_.X;
			text.Item.SetTransform(trans);
			
			size_.X += text.Size.X + 10.0f;
			size_.Y = size_.Y < text.Size.Y ? text.Size.Y : size_.Y;
		}
		view_.SetSize(size_.ToInt());
	}

	public void End()
	{
		foreach (var item in texts_)
		{
			item.Free();
		}
		canvas_.Free();
		view_.Free();
	}

	public Rect2 Update(Vector2 screenSize)
	{
		// size_ = new Vector2(screenSize.X, size_.Y);
		// view_.SetSize(size_.ToInt());
		view_.UpdateRetained();
		return new Rect2(Vector2I.Zero, size_);
	}

	public Rid GetTexture()
	{
		return view_.Texture;
	}
	
	// UpdateSize and GetNewSize
	
	// ReDraw
	
	// Texture



}