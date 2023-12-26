using azar82.aban.extensions;
using azar82.aban.r;
using Godot;

namespace azar82.aban;

public sealed class VisObjManuBar
{
	private readonly Font font_ = ThemeDB.FallbackFont;
	// private readonly List<RCanvasItem> texts_ = [];
	private readonly RViewport view_;
	private readonly RCanvas canvas_;
	private readonly RCanvasItem item_;
	
	public VisObjManuBar(EditorMenuBarSystem menuSystem)
	{
		view_ = new RViewport();
		view_.SetFor2D();
		view_.SetRetained();
		canvas_ = view_.CreateCanvas();
		item_ = canvas_.CreateItem();
		
		// var x = 0.0f;
		// var ascent = font_.GetAscent();
		// foreach (var str in menuSystem.Menus)
		// {
		// 	var ci = canvas_.CreateItem();
		// 	texts_.Add(ci);
		// 	font_.DrawString(ci.Rid, new Vector2(x, ascent), str);
		// 	x = font_.GetStringSize(str).X;
		// }
	}

	public void End()
	{
		// foreach (var item in texts_)
		// {
		// 	item.Free();
		// }
		item_.Free();
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
		
		var size = new Vector2(screenSize.X, font_.GetAscent());
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

		RenderingServer.CanvasItemAddLine(item_.Rid, new Vector2(5.0f, 5.0f), new Vector2(50.0f, 50.0f), Colors.Aqua);
		
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