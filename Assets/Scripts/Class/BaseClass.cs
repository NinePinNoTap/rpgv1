using UnityEngine;
using System.Collections;
using CharacterConfig;

[System.Serializable]
public class BaseClass
{
    [Header("Information")]
    public string className = "";
    public string classDescription = "";

    [Header("Resources")]
    public int baseHealth = 0;
    public int baseResourceAmount = 0;
    public GameResource baseResourceType;

    [Header("Attributes")]
    public int baseAgility = 0;
    public int baseIntelligence = 0;
    public int baseStrength = 0;
    public int baseStamina = 0;
}
