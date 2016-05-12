using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class InventoryWindow : MonoBehaviour
{
    [Header("GUI Configuration")]
    public int columnCount = 9;
    public int rowCount = 3;
    public float slotPadding = 3;
    public float slotSize = 100;
    public GameObject slotPrefab;
    private List<GameObject> inventorySlots;
    private RectTransform inventoryBackground;
    private Vector2 inventorySize;

    [Header("Inventory")]
    public static int emptySlotCount;

	void Start ()
    {
        inventorySlots = new List<GameObject>();

        CreateInterface();
	}

    void Update()
    {
        if(Input.GetKey(KeyCode.O))
        {
            BaseItem baseItem = new BaseItem();
            baseItem.itemID = 1;
            baseItem.itemName = "Test Item";
            baseItem.itemIcon = Resources.Load<Sprite>("bloodelf");
            baseItem.stackSize = 5;
            AddItem(baseItem);
        }
    }

    void CreateInterface()
    {
        // Calculate size of inventory window
        inventorySize = new Vector2(0, 0);
        inventorySize.x = columnCount * (slotSize + slotPadding) + slotPadding;
        inventorySize.y = rowCount * (slotSize + slotPadding) + slotPadding;

        // Set up the inventory background
        inventoryBackground = GetComponent<RectTransform>();
        inventoryBackground.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, inventorySize.x);
        inventoryBackground.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, inventorySize.y);

        // Create Slots
        for (int y = 0; y < rowCount; y++)
        {
            for (int x = 0; x < columnCount; x++)
            {
                CreateInventorySlot(x,y);
            }
        }

        // Store how many slots we start with
        emptySlotCount = columnCount * rowCount;
    }

    void CreateInventorySlot(int x, int y)
    {
        GameObject invSlot;
        RectTransform invRect;
        Vector2 invSlotPos;

        // Create a new slot gameobject
        invSlot = (GameObject)Instantiate(slotPrefab);
        invSlot.name = "Slot " + (inventorySlots.Count+1).ToString();
        invSlot.transform.SetParent(transform);
        invSlot.transform.localScale = new Vector3(1,1,1);

        // Define slot transform
        invRect = invSlot.GetComponent<RectTransform>();
        invRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotSize);
        invRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotSize);
        invSlotPos.x = slotPadding * (x + 1) + (slotSize * x) - (inventoryBackground.sizeDelta.x / 2);
        invSlotPos.y = -slotPadding * (y + 1) - (slotSize * y) + (inventoryBackground.sizeDelta.y / 2);
        invRect.localPosition = invSlotPos;

        // Add to our array
        inventorySlots.Add(invSlot);
    }

    //===============================
    // Adds an item to the inventory
    //===============================

    public void AddItem(BaseItem item)
    {
		// Limit Count
        if(HasTooMany(item))
        {
            Debug.Log("Too many instances found!");
            return;
        }

		// Stack Item
        if (item.IsStackable())
        {
			IEnumerable<GameObject> objs = inventorySlots.Where(obj => obj.GetComponent<InventorySlot>().CanStack(item));

			if(objs.Count() > 0)
			{
				objs.First().GetComponent<InventorySlot>().AddItem(item);
				return;
			}
        }

        // Create New Stack
        if (emptySlotCount > 0)
        {
            AddNewItem(item);
            return;
        }
    }

    //========================================
    // Adds an item to a fresh stack
    //========================================

    void AddNewItem(BaseItem item)
    {
		IEnumerable<GameObject> emptySlots = inventorySlots.Where(obj => obj.GetComponent<InventorySlot>().IsEmpty());

		if(emptySlots.Count() > 0)
		{
			emptySlots.First().GetComponent<InventorySlot>().AddItem(item);
			emptySlotCount--;
		}
    }

    //========================================
    // Checks if we have too many of the item
    //========================================

    bool HasTooMany(BaseItem item)
    {
        int itemCount = 0;
        InventorySlot invSlot;

        // Has No Limit
        if(item.maxCount == 0)
        {
            return false;
        }

        // Find instances within inventory
        foreach (GameObject obj in inventorySlots)
        {
            invSlot = obj.GetComponent<InventorySlot>();

            if(invSlot.IsEmpty())
            {
                continue;
            }

            if(invSlot.GetItem().Equals(item))
            {
                itemCount += invSlot.GetNumOfItems();
            }
        }

        if(itemCount >= item.maxCount)
        {
            return true;
        }

        return false;
    }
}