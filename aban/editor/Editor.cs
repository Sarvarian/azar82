namespace azar82.aban.editor;

public class Editor
{
	public Editor(IMain main)
	{
		
	}
	
	public void AddEditorMenu()
	{
	}

	public void AddShortcut()
	{
	}
	
	
	/*
	 * Main System
	 *	 Main System Object : GuiIterator
	 *                          VisualObject
	 *   Main System Object : Editor
	 *                          EditorObject
	 */
	
	/*
	 * Collision Detection
	 *   Visual Objects
	 * Event Goes In
	 *   VisualObjects
	 * Render Comes Out
	 *   Visual Objects
	 *
	 * Visual Object <-> Editor Object
	 * 
	 */
	
	/*
	 * Main
	 *   GuiIterator
	 *     VisualObject::TopViewport
	 *   Editor
	 *     EditorObject(s)
	 *     MenuSystem
	 *     PageSystem
	 *     Workspace
	 *     List<Panel>
	 */
	private EditorObject menuSystem_ = new();
	private EditorObject pageSystem_ = new();
	/*
	 * EditorObjects
	 * Page System:
	 *  List<Page>
	 *  Page:
	 *    List<Panel>
	 *    Panel
	 *  
	 */
	private EditorObject workspace_ = new();
	
	
}