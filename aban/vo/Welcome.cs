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
	}

	protected override void OnProcess(double delta)
	{
		base.OnProcess(delta);
	}

}