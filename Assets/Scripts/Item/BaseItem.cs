using UnityEngine;
using System.Collections;

[System.Serializable]
public class BaseItem
{
	public int itemID;
    public string itemName = "";
    public string itemDescription = "";
	public Sprite itemIcon;
	public int itemRarity;
	public int itemLevel;
	public ItemMainClass mainClass;         // Main Class = Weapon, Armor etc
	public ItemSubClass subClass;           // Sub Class = Sword, Helmet etc
    public int buyPrice = 0;
    public int sellPrice = 0;
    public int maxCount;                    // How many we can have in our inventory
    public int stackSize;                   // How many can be placed in a single stack
	public int remainingCharges = -1;					// How many times we can use the item

	public enum ItemMainClass
	{
		Armor,
		Weapon,
		Consumable
	}

	public enum ItemSubClass
	{
		// Armor
		Helm,
		Shoulder,
		Chest,
		Wrist,
		Glove,
		Belt,
		Leg,
		Boot,

		// Weapon
		Axe,
		Mace,
		Sword,

		// Consumable
		Potion
	}

    public virtual void Use()
    {
        Debug.Log("Use Item");

		remainingCharges = remainingCharges > 0 ? remainingCharges - 1 : -1;
    }

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
		return remainingCharges == 0;
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