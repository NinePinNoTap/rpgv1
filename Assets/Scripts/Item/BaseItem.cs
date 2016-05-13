using UnityEngine;
using System.Collections;
using ItemConfig;

[System.Serializable]
public class BaseItem
{
	public int itemID;										// Unique identifier
	public string itemName = "<color=red>ERROR!</color>";	// Name of the item
    public string itemDescription = "";     				// Lore text or description
	public Sprite itemIcon;                 				// Icon to display in inventory
	public ItemQuality itemQuality;         				// How rare the item is
	public ItemClass mainClass;         					// Weapon, Armor, Consumable
	public ItemSubClass subClass;           				// Sword, Helmet, Potion
	public ItemSlot itemSlot;								// Slot in the inventory it is put into
	public int itemLevel;                   				// The level of the item
	public int requiredLevel;               				// Requires the player to be of a certain level
	public int buyPrice = 0;                				// How much it costs to buy from vendor
	public int sellPrice = 0;               				// How much you get by selling to vendor
	public int maxCount = 0;                				// How many we can have in our inventory
	public int stackSize = 1;               				// How many can be placed in a single stack
	public int maxDurability = -1;							// How much durability the item has
	public int spellID = -1;								// On use spell
	public int spellCharges = -1;							// How many times we can use the item

    public virtual void Use()
    {
        Debug.Log("Use Item");
    }
	
	//======================================
	// Getters
	//======================================

    public bool IsUnique()
    {
        return maxCount == 1;
    }

    public bool IsStackable()
    {
        return stackSize > 1;
    }

	public bool HasExpired()
	{
		return spellCharges == 0;
	}

    //======================================
    // Override
    //======================================

    public override bool Equals(object obj)
    {
        if(obj == null)
        {
            return false;
        }

        BaseItem otherItem = obj as BaseItem;

        return itemID.Equals(otherItem.itemID);
    }
}