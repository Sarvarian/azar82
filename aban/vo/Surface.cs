using azar82.aban.extensions;
using Godot;

namespace azar82.aban.vo;

public class Surface(Node parent) : VisualObject
{
	protected override void OnStart()
	{
		base.OnStart();
		
		texture_.Texture = viewport_.GetTexture();
		parent.AddChild(viewport_);
		parent.AddChild(texture_);
		SetNewSize(parent.GetViewport().GetVisibleRect().Size.ToInt());
		
		var welcomeScene = GD.Load<PackedScene>("res://panels/welcome/welcome.tscn");
		var welcome = welcomeScene.Instantiate();
		viewport_.AddChild(welcome);
        
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

	protected override void OnEnd()
	{
		base.OnEnd();
		viewport_.SafeFree();
		texture_.SafeFree();
	}

	public override void SetNewSize(Vector2I newSize)
	{
		base.SetNewSize(newSize);
	
		viewport_.Size = newSize;
		texture_.Size = newSize;
		SizeUpdated();
	}

	public override void SizeUpdated()
	{
		base.SizeUpdated();
		// texture_.AnchorsPreset = (int)Control.LayoutPreset.FullRect;
	}

	public override void SetNewPosition(Vector2I newPosition)
	{
		base.SetNewPosition(newPosition);
	
		texture_.Position = newPosition;
		PositionUpdated();
	}

	public override void PositionUpdated()
	{
		base.PositionUpdated();
	}

	private SubViewport viewport_ = new();
	private TextureRect texture_ = new();
}