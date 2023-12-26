using System.Collections.Generic;
using azar82.aban.extensions;
using azar82.aban.r;
using Godot;

namespace azar82.aban;

public sealed class VisObjManuBar
{
	private readonly Font font_ = ThemeDB.FallbackFont;
	private readonly List<RCanvasItem> texts_ = [];
	private readonly RViewport view_;
	private readonly RCanvas canvas_;

	private float y_ = 0;
	
	public VisObjManuBar(EditorMenuBarSystem menuSystem)
	{
		view_ = new RViewport();
		view_.SetFor2D();
		view_.SetRetained();
		canvas_ = view_.CreateCanvas();
		
		var x = 0.0f;
		var ascent = font_.GetAscent();
		foreach (var str in menuSystem.Menus)
		{
			var ci = canvas_.CreateItem();
			texts_.Add(ci);
			font_.DrawString(ci.Rid, new Vector2(x, ascent), str);
			var size = font_.GetStringSize(str);
			x += size.X + 10.0f;
			y_ = y_ < size.Y ? size.Y : y_;
		}
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
		// foreach (var text in texts_)
		// {
		// 	text.Obj.Update();
		// }
		//
		// var y = Mathf.RoundToInt(texts_.Select(text => text.Obj.GetSize().Y).Prepend(0.0f).Max());
		
		var size = new Vector2(screenSize.X, y_);
		view_.SetSize(size.ToInt());
		
		/*
		 * - [X] Update Text Nodes.
		 * - [X] Get Text Textures.
		 * - [X] Blit Text Textures Unto Menu Bar Viewport.
		 */
		
		// foreach (var textItem in texts_)
		// {
		// 	var obj = textItem.Obj;
		// 	var item = textItem.Item;
		// 	var texture = obj.GetTexture();
		// 	var textureSize = texture.GetSize();
		// 	var textureRect = new Rect2(Vector2.Zero, textureSize);
		// 	item.SetSize(textureRect);
		// 	var textureRid = texture.GetRid();
		// 	item.BlitTexture(textureRid, textureRect);
		// }

		/*
		 * - [X] Make Canvas.
		 * - [X] Make Canvas Item for each texture.
		 * - [X] Set size of each Canvas Item.
		 * - [X] Map each texture to its respective Canvas Item.
		 */
		
		view_.UpdateRetained();
		return new Rect2(Vector2I.Zero, size);
	}

	public Rid GetTexture()
	{
		return view_.Texture;
	}
	
	// UpdateSize and GetNewSize
	
	// ReDraw
	
	// Texture



}