using UnityEngine;
using System.Collections;

[System.Serializable]
public class CharacterClass
{
    public enum ResourceType
    {
        Energy, Mana, Rage
    };

    [Header("Information")]
    public string Name = "";
    public string Description = "";

    [Header("Resources")]
    public int BaseHealth = 0;
    public int BaseEnergy = 0;
    public ResourceType BaseResource;

    [Header("Attributes")]
    public int BaseAgility = 0;
    public int BaseIntelligence = 0;
    public int BaseStrength = 0;
    public int BaseStamina = 0;
}
