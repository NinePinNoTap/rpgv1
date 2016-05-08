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
    public int Level;
    public CharacterClass Class;
    public CharacterGender Gender;

    [Header("Attributes")]
    public int Strength = 0;
    public int Intelligence = 0;
    public int Stamina = 0;

    public Character()
    {
        Name = "";
        Class = null;
        Level = 1;
    }
}
