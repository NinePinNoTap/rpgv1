using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class BaseObject
{
	public int ID;										// Unique identifier
	public string name = "<color=red>ERROR!</color>";	// Name of the item
	public string description = "";     				// Lore text or description
	public Sprite icon;                 				// Icon to display

	public virtual void Use()
	{
		Debug.Log ("Default Use");
    }

    public virtual void GetTooltip()
    {
        UIManager.Instance.tooltip.AddText(name, 24, Color.blue);
        UIManager.Instance.tooltip.AddText(description, 14, Color.white);
    }
}