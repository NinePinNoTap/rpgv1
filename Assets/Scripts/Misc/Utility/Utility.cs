using UnityEngine;
using System.Collections;

public static class Utility
{
	public static T ParseEnum<T>(string input)
	{
		return (T)System.Enum.Parse( typeof( T ), input );
	}

	public static T ParseEnum<T>(int input)
	{
		return (T)System.Enum.Parse( typeof( T ), input.ToString() );
	}
}
