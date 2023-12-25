using System;
using Godot;

namespace azar82.tests.test_text;

public partial class StaticText : Label
{
	public event Action? OnUpdated;
	
	public StaticText(string text)
	{
		Text = text;
	}

	public override void _Process(double delta)
	{
		base._Process(delta);
		OnUpdated?.Invoke();
	}
}