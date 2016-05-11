using UnityEngine;
using System.Collections;

public enum CharacterGender
{
    Male = 0,
    Female = 1
}

[System.Serializable]
public class Character
{
    [Header("Information")]
	public string Name;
    public CharacterGender Gender;
    public BaseCharacterClass Class;

	[Header("Levelling")]
	public int Level;
	public int CurrentLevelExperience;
	public int RequiredLevelExperience;

    [Header("Attributes")]
    public int Strength = 0;
    public int Intelligence = 0;
    public int Stamina = 0;

    public Character()
    {
        Name = "";
        Class = null;
        Level = 1;
		CurrentLevelExperience = 0;
		RequiredLevelExperience = ExperienceToLevel.GetRequiredXP(Level);
    }

	public void AddExperience(int value)
	{
		// Don't grant experience at max level
		if(Level == ExperienceToLevel.GetMaxLevel() + 1)
		{
			return;
		}

		// Add Experience
		CurrentLevelExperience += value;

		// Level Up
		if(CurrentLevelExperience >= RequiredLevelExperience)
		{
			Debug.Log ("Level Up!");
			Level++;
			Level = Mathf.Clamp(Level, 0, ExperienceToLevel.GetMaxLevel() + 1);

			CurrentLevelExperience = 0;
			RequiredLevelExperience = ExperienceToLevel.GetRequiredXP(Level);
		}
	}
}