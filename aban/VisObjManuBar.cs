using System.Collections.Generic;
using System.Linq;
using azar82.aban.resources;
using Godot;

namespace azar82.aban;

public sealed class VisObjManuBar
{
	private readonly struct TextItem
	{
		public readonly VisObjText Obj;
		public readonly RCanvasItem Item;

		public TextItem(string str, GuiIterator guiIterator, RCanvas canvas)
		{
			Obj = new VisObjText(str, guiIterator);
			Item = canvas.CreateItem();
		}

		public void Free()
		{
			Item.Free();
		}
		
	}
    
	private readonly List<TextItem> texts_ = [];
	private readonly RViewport view_;
	private readonly RCanvas canvas_;
	
	public VisObjManuBar(EditorMenuBarSystem menuSystem, GuiIterator guiIterator)
	{
		foreach (var menu in menuSystem.Menus)
		{
			texts_.Add(new TextItem(menu, guiIterator, canvas_));
		}

		view_ = new RViewport();
		view_.SetFor2D();
		view_.SetRetained();
		canvas_ = view_.CreateCanvas();
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

	public Rect2 Update(Vector2I screenSize)
	{
		foreach (var text in texts_)
		{
			text.Obj.Update();
		}

		var y = Mathf.RoundToInt(texts_.Select(text => text.Obj.GetSize().Y).Prepend(0.0f).Max());
		var size = new Vector2I(screenSize.X, y);

		view_.SetSize(size);
		
		/*
		 * - [X] Update Text Nodes.
		 * - [X] Get Text Textures.
		 * - [X] Blit Text Textures Unto Menu Bar Viewport.
		 */
		
		foreach (var textItem in texts_)
		{
			var obj = textItem.Obj;
			var item = textItem.Item;
			var texture = obj.GetTexture();
			var textureSize = texture.GetSize();
			var textureRect = new Rect2(Vector2.Zero, textureSize);
			item.SetSize(textureRect);
			var textureRid = texture.GetRid();
			item.BlitTexture(textureRid, textureRect);

			/*
			 * - [X] Make Canvas.
			 * - [X] Make Canvas Item for each texture.
			 * - [X] Set size of each Canvas Item.
			 * - [X] Map each texture to its respective Canvas Item.
			 */

		}
		
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