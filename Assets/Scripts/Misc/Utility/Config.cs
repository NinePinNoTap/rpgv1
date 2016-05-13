using UnityEngine;
using System.Collections;

namespace Config
{
	//===============================
	// Inventory Slot ID
	//===============================

	public enum ItemSlot
	{
		Helm,			// 0
		Shoulder,		// 1
		Chest,			// 2
		Wrist,			// 3
		Glove,			// 4
		Belt,			// 5
		Leg,			// 6
		Boot,			// 7
		Weapon,			// 8
	}
	
	//===============================
	// Type Of The Item
	//===============================

	public enum ItemClass
	{
		Armor,			// 0
		Weapon,			// 1
		Consumable,		// 2
	}
	
	//===============================
	// Specific Item Type
	//===============================

	public enum ItemSubClass
	{
		// Armor
		Cloth,			// 0
		Leather,		// 1
		Plate,			// 2

		// Weapon
		Axe1H,			// 3
		Axe2H,			// 4
		Mace1H,			// 5
		Mace2H,			// 6
		Sword1H,		// 7
		Sword2H,		// 8

		// Consumable
		Potion,			// 9
		Food			// 10
	}
	
	//===============================
	// How Rare Item Is
	//===============================

	public enum ItemQuality 
	{
		Basic,			// 0
		Regular,		// 1
		Inconsistent,	// 2
		Rare,			// 3
		Majestic,		// 4
		Legendary		// 5
	}
}