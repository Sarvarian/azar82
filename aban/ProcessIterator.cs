using Godot;

namespace azar82.aban;

public abstract class ProcessIterator
{
	public ProcessIterator(IMain main)
	{
		main.OnProcess += ProcessDispatch;
	}

	private void ProcessDispatch(double delta)
	{
		Process();
	}
	
	private ulong lastTime_ = Time.GetTicksUsec();
	
	/// <summary>
	/// 
	/// </summary>
	/// <returns>True if did run and false if skip a run.</returns>
	private bool Process()
	{
		const ulong uSecInSec = 1_000_000;
		var delay = uSecInSec / GetMaxFps();
		var thisTime = Time.GetTicksUsec();
		var deltaInUSec = thisTime - lastTime_;
		var doProcess = deltaInUSec > delay;
		if (doProcess == false)
		{
			return false;
		}
		else
		{
			lastTime_ = thisTime;
			// GD.Print($"fps: {uSecInSec / deltaInUSec}");
			var deltaInSec = (double)deltaInUSec / (double)uSecInSec;
			RunSystems(deltaInSec);
			return true;
		}
	}

	protected abstract ulong GetMaxFps();

	protected abstract void RunSystems(double delta);

}
