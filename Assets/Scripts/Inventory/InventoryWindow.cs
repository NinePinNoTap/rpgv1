using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryWindow : MonoBehaviour
{
    [Header("GUI Configuration")]
    public int columnCount = 9;
    public int rowCount = 3;
    public float slotPadding = 3;
    public float slotSize = 25;
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

    public bool AddItem(BaseItem item)
    {
        InventorySlot currentSlot;

        if (item.IsStackable())
        {
            // Search the inventory for the item and add to the current stack
            foreach (GameObject slotObj in inventorySlots)
            {
                currentSlot = slotObj.GetComponent<InventorySlot>();

                if (currentSlot.IsEmpty())
                {
                    continue;
                }

                if(currentSlot.CanStack(item))
                {
                    currentSlot.AddItem(item);
                    Debug.Log("Found an existing stack!");
                    return true;
                }
            }
        }

        // Create new stack
        if (emptySlotCount > 0)
        {
            AddNewItem(item);
            return true;
        }

        Debug.Log("Inventory Full!");

        return false;
    }

    private bool AddNewItem(BaseItem item)
    {
        InventorySlot invSlot;

        foreach (GameObject obj in inventorySlots)
        {
            invSlot = obj.GetComponent<InventorySlot>();

            if (invSlot.IsEmpty())
            {
                invSlot.AddItem(item);
                emptySlotCount--;
                Debug.Log("New Stack Created! Free Slots : " + emptySlotCount);
                return true;
            }
        }

        return false;
    }
}