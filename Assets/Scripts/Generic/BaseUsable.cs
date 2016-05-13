using UnityEngine;
using System.Collections;

public class BaseUsable : MonoBehaviour
{
	public int ID;										// Unique identifier
	public string name = "<color=red>ERROR!</color>";	// Name of the item
	public string description = "";     				// Lore text or description
	public Sprite icon;                 				// Icon to display
	public int spellID = -1;								// On use spell
	public int spellCharges = -1;							// How many times we can use the item

	public virtual void Use()
	{
		Debug.Log ("Default Use");
	}
}

