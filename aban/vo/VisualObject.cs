using System.Collections.Generic;
using System.Linq;

namespace azar82.aban.vo;

public abstract class VisualObject
{
	private bool isStarted_ = false;
	private readonly List<VisualObject> subs_ = [];

	protected T AddSub<T>(T sub)
		where T : VisualObject
	{
		subs_.Add(sub);
		if (this.isStarted_ == true &&
		    sub.isStarted_ == false)
		{
			sub.Start();
		}
		return sub;
	}

	public void Start()
	{
		OnStart();
		foreach (var sub in subs_.Where(sub => sub.isStarted_ == false))
		{
			sub.Start();
		}
		isStarted_ = true;
	}

	protected virtual void OnStart()
	{
		
	}
	
	public void Process(double delta)
	{
		foreach (var sub in subs_)
		{
			sub.Process(delta);
		}

		OnProcess(delta);
	}

	protected virtual void OnProcess(double delta)
	{
		
	}

	public void End()
	{
		OnEnd();
		foreach (var sub in subs_)
		{
			sub.End();
		}
	}

	protected virtual void OnEnd()
	{
	}

}