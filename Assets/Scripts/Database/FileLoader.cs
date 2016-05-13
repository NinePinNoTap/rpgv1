using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System;

public static class FileLoader
{
	public static void Load(string fileName, ref List<string[]> fileStorage)
	{
		try
		{
			string line;
			StreamReader theReader = new StreamReader(fileName, Encoding.Default);
			using (theReader)
			{
				do
				{
					line = theReader.ReadLine();
					
					if (line != null)
					{
						string[] entries = line.Split(',');
						if (entries.Length > 0)
						{
							fileStorage.Add(entries);
						}
					}
				}
				while (line != null);
				
				theReader.Close();
			}
		}
		catch (Exception e)
		{
			Debug.LogError(e.Message);
		}
	}
}

