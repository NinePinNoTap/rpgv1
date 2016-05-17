using UnityEngine;
using System.Collections;

public static class Parse
{
	public static T Enum<T>(string input)
	{
		return (T)System.Enum.Parse( typeof( T ), input );
	}

	public static T Enum<T>(int input)
	{
		return (T)System.Enum.Parse( typeof( T ), input.ToString() );
	}
}