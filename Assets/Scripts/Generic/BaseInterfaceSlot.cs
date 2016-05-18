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
	public Stack<BaseObject> slotStack;

    //===================================
    // Base Use Function for Inheritance
    //===================================

	public virtual void UseSlot()
	{
		Debug.Log ("Slot Clicked");
	}

    //=================
    // Slot Management
    //=================

    public void AddAbility(BaseAbility ability)
    {
        slotStack.Push(ability);
        
        UpdateSlotIcon(ability.icon);
    }
    
    public void AddItem(BaseItem item)
    {
        slotStack.Push(item);
        
        UpdateSlotIcon(item.icon);
    }
	
	//==============================
	// Updates the Icon Sprite
	//==============================

	protected void UpdateSlotIcon(Sprite useableIcon)
	{
		if(IsEmpty())
        {
			slotIcon.sprite = slotEmpty;
			slotIcon.overrideSprite = slotEmpty;
		}
		else
        {
			slotIcon.sprite = useableIcon;
			slotIcon.overrideSprite = useableIcon;
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

    public void ShowTooltip()
    {
        if(IsEmpty ())
        {
            return;
        }

        UIManager.Instance.tooltip.ClearTooltip();
        slotStack.Peek().GetTooltip();
        UIManager.Instance.tooltip.Build();

        UIManager.Instance.tooltip.ShowTooltip();
    }

    public void HideTooltip()
    {
        UIManager.Instance.tooltip.HideTooltip();
    }
}

