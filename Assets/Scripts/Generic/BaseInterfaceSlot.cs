using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class BaseInterfaceSlot : MonoBehaviour, IPointerClickHandler
{
	[Header("Configuration")]
	public Text slotText;
	public Image slotIcon;
	public Sprite slotEmpty;
	public float slotTextScale = 0.5f;

	[Header("Information")]
	public Stack<BaseUsable> slotStack;

	public virtual void UseSlot()
	{
		Debug.Log ("Slot Clicked");
	}
	
	//==============================
	// Updates the Icon Sprite
	//==============================

	protected void UpdateSlotIcon(Sprite itemIcon)
	{
		if(IsEmpty())
		{
			slotIcon.sprite = slotEmpty;
			slotIcon.overrideSprite = slotEmpty;
		}
		else
		{
			slotIcon.sprite = itemIcon;
			slotIcon.overrideSprite = itemIcon;
		}
	}
	
	//==============================
	// Checks if the stack is empty
	//==============================
	
	public bool IsEmpty()
	{
		// Check if the slot is empty
		return slotStack.Count == 0;
	}
	
	//==============================
	// Using an item in the slot
	//==============================
	
	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			UseSlot();
		}
	}
	
	//=====================
	// Show / Hide Tooltip 
	//=====================

	public virtual void ShowTooltip()
	{
		Debug.Log ("Show Tooltip");
	}
	
	public virtual void HideTooltip()
	{
		Debug.Log ("Hide Tooltip");
	}
}

