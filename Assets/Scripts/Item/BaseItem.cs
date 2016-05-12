using UnityEngine;
using System.Collections;


public enum Rarity { Common, Rare, Legendary };
public enum Weilding { OneHanded, TwoHanded };

[System.Serializable]
public class BaseItem
{
	public int itemID;
    public string itemName = "";
    public string itemDescription = "";     
	public Sprite itemIcon;                 // Icon to display in inventory
	public Rarity itemRarity;                  // How rare the item is
	public int itemLevel;                   // The level of the item
    public int requiredLevel;               // Requires the player to be of a certain level
	public ItemMainClass mainClass;         // Main Class = Weapon, Armor etc
	public ItemSubClass subClass;           // Sub Class = Sword, Helmet etc
    public int buyPrice = 0;                // How much it costs to buy from vendor
    public int sellPrice = 0;               // How much you get by selling to vendor
    public int maxCount;                    // How many we can have in our inventory
    public int stackSize;                   // How many can be placed in a single stack
	public int remainingCharges = -1;		// How many times we can use the item

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