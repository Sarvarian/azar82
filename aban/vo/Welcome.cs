using azar82.aban.extensions;
using Godot;

namespace azar82.aban.vo;

public class Welcome(Node parent) : Surface(parent)
{
	protected override void OnStart()
	{
		base.OnStart();
		
		var welcomeScene = GD.Load<PackedScene>("res://panels/welcome/welcome.tscn");
		var welcome = welcomeScene.Instantiate();
		View.AddChild(welcome);
        
		// var rs = RenderingServer.Singleton;
		// ci_ = rs.CanvasItemCreate();
		//
		// c_ = rs.CanvasCreate();
		
		// var vp2 = new SubViewport();
		// AddChild(vp2);
		
		// var mainMenuScene = GD.Load<PackedScene>("res://panels/mainmenu/mainmenu.tscn");
		// var mainMenu = mainMenuScene.Instantiate();
		// vp2.AddChild(mainMenu);
	}

	protected override void OnProcess(double delta)
	{
		base.OnProcess(delta);
	}

}