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
    public GameResource baseResourceType = GameResource.Mana;

    [Header("Base Attributes")]
    public int baseStrength = 20;
    public int baseAgility = 20;
    public int baseIntelligence = 20;
    public int baseStamina = 20;
}
