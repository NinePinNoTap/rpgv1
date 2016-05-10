using UnityEngine;
using System.Collections;

public class Item
{
	public int itemID;
    public string itemName = "";
    public string itemDescription = "";
	public Sprite itemIcon;
	public int itemLevel;
	public ItemMainClass mainClass;
	public ItemSubClass subClass;
    public int buyPrice = 0;
    public int sellPrice = 0;

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
}