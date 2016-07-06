using UnityEngine;

public sealed class WaitForSecondsRealtime : CustomYieldInstruction
{
	private float targetTime;

	public override bool keepWaiting
	{
		get
		{
			return targetTime > Time.realtimeSinceStartup;
		}
	}

	public WaitForSecondsRealtime(float time)
	{
		targetTime = Time.realtimeSinceStartup + time;
	}
}
