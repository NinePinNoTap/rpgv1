using UnityEngine;
using System.Collections;

[System.Serializable]
public class BaseItem
{
	public int itemID;
    public string itemName = "";
    public string itemDescription = "";
	public Sprite itemIcon;
	public int itemLevel;
	public ItemMainClass mainClass;         // Main Class = Weapon, Armor etc
	public ItemSubClass subClass;           // Sub Class = Sword, Helmet etc
    public int buyPrice = 0;
    public int sellPrice = 0;
    public int maxCount;                    // How many we can have in our inventory
    public int stackSize;                   // How many can be placed in a single stack

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
}