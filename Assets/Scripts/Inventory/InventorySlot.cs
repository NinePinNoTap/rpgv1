using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[System.Serializable]
public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    [Header("Configuration")]
    public Text slotText;
    public Image slotIcon;
    public Sprite slotEmpty;
    public Sprite slotHighlighted;
    public float slotTextScale = 0.5f;
    public Stack<BaseItem> itemStack = new Stack<BaseItem>();
    public List<BaseItem> tempItems = new List<BaseItem>();

	void Start ()
    {
        RectTransform slotRect;
        RectTransform textRect;

        // Configure the text
        slotRect = GetComponent<RectTransform>();
        textRect = slotText.GetComponent<RectTransform>();

        // Text Counter
        slotText.resizeTextMinSize = (int)(slotRect.sizeDelta.x * slotTextScale);
        slotText.resizeTextMaxSize = (int)(slotRect.sizeDelta.x * slotTextScale);
        textRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotRect.sizeDelta.x * 0.9f);
        textRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotRect.sizeDelta.y * 0.9f);
        slotText.text = "";

        // Config Default Icon
        UpdateItemIcon();
	}

    void Update()
    {
        tempItems.Clear();
        tempItems.AddRange(itemStack);
    }

    void UseItem()
    {
        if (!IsEmpty())
        {
            // Use the item and remove from the stack
            itemStack.Pop().Use();

            // Update GUI
            UpdateTextCounter();
            UpdateItemIcon();
        }
    }

    void UpdateTextCounter()
    {
        // Update the text if we have more than one
        if (itemStack.Count >= 1)
        {
            slotText.text = itemStack.Count.ToString();
        }
        else
        {
            slotText.text = "";
        }

        if (IsEmpty())
        {
            Debug.Log("Call here");
            InventoryWindow.emptySlotCount++;
        }
    }

    void UpdateItemIcon()
    {
        if(IsEmpty())
        {
            slotIcon.color = new Color(0,0,0,0);
        }
        else
        {
            slotIcon.sprite = GetItem().itemIcon;
            slotIcon.overrideSprite = GetItem().itemIcon;
            slotIcon.color = new Color(1,1,1,1);
        }
    }

    //===========================
    // Adds an item to the stack
    //===========================

    public void AddItem(BaseItem item)
    {
        itemStack.Push(item);

        UpdateTextCounter();
        UpdateItemIcon();
    }

    //==============================
    // Checks if the stack is empty
    //==============================

    public bool IsEmpty()
    {
        // Check if the slot is empty
        return itemStack.Count == 0;
    }

    //=================================
    // Retrieves the item in the stack
    //=================================

    public BaseItem GetItem()
    {
        if(itemStack.Count == 0)
        {
            return null;
        }
        else
        {
            // Return the type of item we are storing in this slot
            return itemStack.Peek();
        }
    }

    //===================================================
    // Checks if theres room to add an item to the stack
    //===================================================

    public bool CanStack()
    {
        return itemStack.Count < GetItem().stackSize;
    }

    //================================================
    // Checks for a matching item to add to the stack
    //================================================

    public bool CanStack(BaseItem item)
    {
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
        return itemStack.Count;
    }

    //===========================
    // Using an item in the slot
    //===========================

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            UseItem();
        }
    }
}