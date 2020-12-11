using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class MonoBehaviourExtensions{

	public static void CallWithDelay(this MonoBehaviour monoBehaviour, float delay, Action action)
	{
		monoBehaviour.StartCoroutine(_invoke(delay, action));
	}

	private static IEnumerator _invoke(float delay, Action action)
	{
		if (delay > 0f)
		{
			yield return new WaitForSeconds(delay);
		}
		action();
		yield return null;
	}
}
