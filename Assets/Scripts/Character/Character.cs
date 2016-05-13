using UnityEngine;
using System.Collections;
using CharacterConfig;

[System.Serializable]
public class Character
{
	[Header("Information")]
	public string characterName;
	public int characterLevel;
	public BaseClass characterClass;
	public GameGender characterGender;
	public GameRace characterRace;
	public int currentExperience;
	public int requiredExperience;

    [Header("Attributes")]
    public int Strength = 0;
    public int Intelligence = 0;
    public int Stamina = 0;

    public Character()
    {
		characterName = "Not Set";
		characterLevel = LevelSystem.startLevel;
		characterClass = null;
		characterGender = GameGender.Male;
		characterRace = GameRace.Human;
		currentExperience = 0;
		requiredExperience = LevelSystem.GetRequiredXP(characterLevel);
    }

	public void GrantExperience(int value)
	{
		// Don't grant experience at max level
		if(characterLevel == LevelSystem.maxLevel)
		{
			return;
		}

		// Add Experience
		currentExperience += value;

		// Level Up
		if(currentExperience >= requiredExperience)
		{
			Debug.Log (characterName + " levelled Up!");

			characterLevel++;
			characterLevel = Mathf.Clamp(characterLevel, 0, LevelSystem.maxLevel);

			currentExperience = 0;
			requiredExperience = LevelSystem.GetRequiredXP(characterLevel);
		}
	}
}