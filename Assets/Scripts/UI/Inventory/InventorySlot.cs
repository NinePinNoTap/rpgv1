using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[System.Serializable]
public class InventorySlot : BaseInterfaceSlot
{
	void Start ()
    {
        RectTransform slotRect;
        RectTransform textRect;

		// Create stack to store item
		slotStack = new Stack<BaseUsable>();

        // Configure the text
        slotRect = GetComponent<RectTransform>();
        textRect = slotText.GetComponent<RectTransform>();

        // Text Counter
        slotText.resizeTextMinSize = (int)(slotRect.sizeDelta.x * slotTextScale);
        slotText.resizeTextMaxSize = (int)(slotRect.sizeDelta.x * slotTextScale);
        textRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotRect.sizeDelta.x * 0.9f);
        textRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotRect.sizeDelta.y * 0.9f);
        slotText.text = "";
	}

    public override void UseSlot ()
	{
        if (!IsEmpty())
        {
			BaseItem item = slotStack.Peek() as BaseItem;

			item.Use();

			if(item.HasExpired())
			{
				slotStack.Pop();

				UpdateTextCounter();
				UpdateSlotIcon(GetItem ().icon);
			}
        }
    }

    void UpdateTextCounter()
    {
        // Update the text if we have more than one
        if (slotStack.Count > 1)
        {
            slotText.text = slotStack.Count.ToString();
        }
        else
        {
            slotText.text = "";
        }
    }

    //===========================
    // Adds an item to the stack
    //===========================

    public void AddItem(BaseItem item)
    {
        slotStack.Push(item);

        UpdateTextCounter();
		UpdateSlotIcon(item.icon);
    }

    //=================================
    // Retrieves the item in the stack
    //=================================

    public BaseItem GetItem()
    {
        if(slotStack.Count == 0)
        {
            return null;
        }
        else
        {
            // Return the type of item we are storing in this slot
			return slotStack.Peek() as BaseItem;
        }
    }

    public bool ContainsItem(BaseItem item)
    {
        if(IsEmpty())
        {
            return false;
        }

        if(GetItem().Equals(item))
        {
            return true;
        }

        return false;
    }

    //===================================================
    // Checks if theres room to add an item to the stack
    //===================================================

    public bool CanStack()
    {
        return slotStack.Count < GetItem().stackSize;
    }

    //================================================
    // Checks for a matching item to add to the stack
    //================================================

    public bool CanStack(BaseItem item)
    {
		if(IsEmpty())
		{
			return false;
		}
	
        if(!GetItem().mainClass.Equals(item.mainClass))
        {
            return false;
        }

        if(!GetItem().subClass.Equals(item.subClass))
        {
            return false;
        }

        if(CanStack())
        {
            return true;
        }

        return false;
    }

    public int GetNumOfItems()
    {
        return slotStack.Count;
    }

	//=====================
	// Show / Hide Tooltip 
	//=====================

	public override void ShowTooltip()
	{
		if(IsEmpty ())
		{
			return;
		}

        UIManager.Instance.tooltip.ClearTooltip();
        
        UIManager.Instance.tooltip.AddText(GetItem().name, 24, Color.blue);
        UIManager.Instance.tooltip.AddText(GetItem().mainClass.ToString(), 16, Color.green);
        UIManager.Instance.tooltip.AddText(GetItem().subClass.ToString(), 16, Color.green);
        UIManager.Instance.tooltip.AddText(GetItem().requiredLevel.ToString(), 16, Color.red);
        UIManager.Instance.tooltip.AddText(TextFormat.Format(GetItem().description, 16, Color.yellow, false, true));
        UIManager.Instance.tooltip.Build();

        UIManager.Instance.tooltip.ShowTooltip();
	}

	public override void HideTooltip()
	{
        UIManager.Instance.tooltip.HideTooltip();
	}
}