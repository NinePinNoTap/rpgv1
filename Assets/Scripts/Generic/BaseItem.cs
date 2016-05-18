using UnityEngine;
using System.Collections;
using ItemConfig;

[System.Serializable]
public class BaseItem : BaseObject
{
    [Header("Properties")]
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

    [Header("OnUse")]
    public int spellID = -1;                                // On use spell
    public int spellCharges = -1;                           // How many times we can use the item

    [Header("Stat Modifiers")]
    public int stamina = 0;                                 // Stat Modifier - Stamina
    public int strength = 0;                                // Stat Modifier - Strength
    public int agility = 0;                                 // Stat Modifier - Agility
    public int intelligence = 0;                            // Stat Modifier - Intelligence

    public override void Use()
    {
        Debug.Log(name + " - Use Item");
    }

    public override void GetTooltip()
    {
        UIManager.Instance.tooltip.AddText(name, 30, Color.blue);
        UIManager.Instance.tooltip.AddText("Item Level : " + itemLevel.ToString(), 20, Color.red);
        UIManager.Instance.tooltip.AddText("Class : " + mainClass.ToString(), 20, Color.white);
        UIManager.Instance.tooltip.AddText("Sub Class : " + subClass.ToString(), 20, Color.white);
        UIManager.Instance.tooltip.AddText("Required Level : " + requiredLevel.ToString(), 20, Color.red);
        UIManager.Instance.tooltip.AddText("Durability : " + maxDurability.ToString(), 20, Color.white);
        UIManager.Instance.tooltip.AddText(TextFormat.Format(description, 18, Color.white, false, true));
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
    // Override Unity
    //======================================

    public override bool Equals(object obj)
    {
        if(obj == null)
        {
            return false;
        }

        BaseItem otherItem = obj as BaseItem;

        return ID.Equals(otherItem.ID);
    }
}