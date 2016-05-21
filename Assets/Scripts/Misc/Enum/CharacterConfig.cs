using UnityEngine;

namespace CharacterConfig
{
	//===============================
	// Game Classes
	//===============================

	public enum GameClass
	{
		Hunter = 0,		// 0
		Mage = 1,		// 1
		Warrior = 2		// 2
	}
	
	//===============================
	// Game Races
	//===============================

	public enum GameRace
	{
        Human = 0,
        HighElf = 1,
        DarkOrc = 2
	}

	//===============================
	// Game Genders
	//===============================

	public enum GameGender
	{
		Male = 0,
		Female = 1,
		Other = 2       // To Be Used
	}
	
	//===============================
	// Game Resources
	//===============================

	public enum GameResource
	{
		Energy = 0,
		Mana = 1,
		Rage = 2
	}
}