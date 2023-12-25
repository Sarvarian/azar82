using System.Collections.Generic;
using System.Linq;
using azar82.aban.resources;
using Godot;

namespace azar82.aban;

public sealed class VisObjManuBar
{
	public VisObjManuBar(EditorMenuBarSystem menuSystem, GuiIterator guiIterator)
	{
		foreach (var menu in menuSystem.Menus)
		{
			texts_.Add(new VisObjText(menu, guiIterator));
		}
		
		view_.SetFor2D();
		view_.SetRetained();
	}

	public void End()
	{
		view_.Free();
	}

	public Rect2I Update(Vector2I screeSize)
	{
		foreach (var text in texts_)
		{
			text.Update();
		}

		var y = Mathf.RoundToInt(texts_.Select(text => text.GetSize().Y).Prepend(0.0f).Max());
		var size = new Vector2I(screeSize.X, y);

		view_.SetSize(size);
		
		/*
		 * DONE: Update Text Nodes. :DONE
		 * Get Text Textures.
		 * Blit Text Textures Unto Menu Bar Viewport.
		 */
		
		view_.UpdateRetained();
		return new Rect2I(Vector2I.Zero, size);
	}

	public Rid GetTexture()
	{
		return view_.Texture;
	}
	
	// UpdateSize and GetNewSize
	
	// ReDraw
	
	// Texture

	private readonly RViewport view_ = new();
	private readonly List<VisObjText> texts_ = [];


}