namespace azar82.aban;

public class Editor
{
	public Editor(azar82.main.Main main)
	{
		menuSystem_ = new EditorMenuBarSystem(this);

		/*
		 * Get Gui Iterator.
		 * Get Top Viewport Visual Object.
		 * Add Menubar Visual Object.
		 * Add Page-bar Visual Object.
		 * Add Workspace Visual Object.
		 */
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
	private EditorMenuBarSystem menuSystem_;
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