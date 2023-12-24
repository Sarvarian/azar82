using System;
using Godot;

namespace azar82.aban;

public interface IMain
{
	event Action? OnStart;
	event Action<double>? OnProcess;
	event Action<double>? OnPhysicsProcess;
	event Action<InputEvent>? OnInputEvent;
	event Action? OnEnd;

	Viewport GetTopViewport();

}