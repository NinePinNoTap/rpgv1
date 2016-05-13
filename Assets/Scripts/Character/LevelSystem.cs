using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class LevelSystem
{
	public static int startLevel = 1;
	public static int maxLevel = 30;
	
	// TODO
	// Feed from external fire
	private static List<int> requiredExp = new List<int> ()
	{
		400,
		900,
		1400,
		2100,
		2800,
		3600,
		4500,
		5400,
		6500,
		6700,
		7000,
		7700,
		8700,
		9700,
		10800,
		11900,
		13100,
		14200,
		15400,
		16600,
		17900,
		19200,
		20400,
		21800,
		23100,
		24400,
		25800,
		29000,
		31000
	};
	
	public static int GetRequiredXP (int level)
	{
		return requiredExp [level - 1];
	}
}

