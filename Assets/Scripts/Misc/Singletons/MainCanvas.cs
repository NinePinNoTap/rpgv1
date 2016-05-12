using UnityEngine;
using System.Collections;

public class MainCanvas : Singleton<MainCanvas>
{
	public Canvas canvas;

	void Start ()
	{
		canvas = GetComponent<Canvas>();
	}
}
