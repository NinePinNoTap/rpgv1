using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class InventoryWindow : Singleton<InventoryWindow>
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

	[Header("Tooltip")]
	public ItemTooltipWindow tooltipWindow;

	void Start ()
    {
        inventorySlots = new List<GameObject>();

		tooltipWindow = GetComponent<ItemTooltipWindow>();

        CreateInterface();
	}

    void Update()
    {
        BaseItem baseItem = new BaseItem();
		baseItem.itemDescription = "This is a test item.";
		baseItem.itemRarity = 2;
		baseItem.itemIcon = Resources.Load<Sprite>("Icons/custom-sword");
        baseItem.stackSize = 1;
		baseItem.remainingCharges = 3;
		
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			baseItem.itemID = 1;
			baseItem.itemName = "Test Item - White";
			baseItem.itemRarity = 0;
			baseItem.sellPrice = 100000;
			AddItem(baseItem);
		}
		
		if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			baseItem.itemID = 2;
			baseItem.itemName = "Test Item - Yellow";
			baseItem.itemRarity = 1;
			baseItem.sellPrice = 4893931;
			AddItem(baseItem);
		}
		
		if(Input.GetKeyDown(KeyCode.Alpha3))
		{
			baseItem.itemID = 3;
			baseItem.itemName = "Test Item - Blue";
			baseItem.itemRarity = 2;
			baseItem.sellPrice = 303918493;
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
        if(HasExceededMaximumNumber(item))
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
		AddNewItem(item);
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

		IEnumerable<GameObject> itemSlots = inventorySlots.Where(obj => obj.GetComponent<InventorySlot>().GetItem().Equals(item));

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