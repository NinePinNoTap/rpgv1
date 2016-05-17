using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Inventory : BaseInterfacePanel
{
	void Start ()
    {
		CreatePanel();
		CreateSlots();
	}

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) AddItem(ItemDatabase.Instance.itemDB[0]);
        if(Input.GetKeyDown(KeyCode.Alpha2)) AddItem(ItemDatabase.Instance.itemDB[1]);
        if(Input.GetKeyDown(KeyCode.Alpha3)) AddItem(ItemDatabase.Instance.itemDB[2]);
        if(Input.GetKeyDown(KeyCode.Alpha4)) AddItem(ItemDatabase.Instance.itemDB[3]);
        if(Input.GetKeyDown(KeyCode.Alpha5)) AddItem(ItemDatabase.Instance.itemDB[4]);
        if(Input.GetKeyDown(KeyCode.Alpha6)) AddItem(ItemDatabase.Instance.itemDB[5]);
    }

    //===============================
    // Adds an item to the inventory
    //===============================

    public void AddItem(BaseItem item)
    {
		// Limit Count
        if(HasExceededMaximumNumber(item))
        {
            Debug.Log("Too many instances found!");
            return;
        }

		// Stack Item
        if (item.IsStackable())
        {
			IEnumerable<GameObject> objs = panelSlots.Where(obj => obj.GetComponent<InventorySlot>().CanStack(item));

			if(objs.Count() > 0)
			{
				objs.First().GetComponent<InventorySlot>().AddItem(item);
				return;
			}
        }

        // Create New Stack
		AddNewItem(item);
    }

    //========================================
    // Adds an item to a fresh stack
    //========================================

    void AddNewItem(BaseItem item)
    {
		IEnumerable<GameObject> emptySlots = panelSlots.Where(obj => obj.GetComponent<InventorySlot>().IsEmpty());

		if(emptySlots.Count() > 0)
		{
			emptySlots.First().GetComponent<InventorySlot>().AddItem(item);
		}
    }

    //========================================
    // Checks if we have too many of the item
    //========================================

    bool HasExceededMaximumNumber(BaseItem item)
    {
        int itemCount = 0;
        InventorySlot invSlot;

        // Has No Limit
        if(item.maxCount == 0)
        {
            return false;
        }

        IEnumerable<GameObject> itemSlots = panelSlots.Where(obj => obj.GetComponent<InventorySlot>().ContainsItem(item));

        // Find instances within inventory
		foreach (GameObject obj in itemSlots)
        {
            invSlot = obj.GetComponent<InventorySlot>();

            itemCount += invSlot.GetNumOfItems();
        }

        if(itemCount >= item.maxCount)
        {
            return true;
        }

        return false;
    }
}