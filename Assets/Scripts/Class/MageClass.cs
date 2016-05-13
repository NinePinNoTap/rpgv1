using UnityEngine;
using System.Collections;
using CharacterConfig;

public class MageClass : BaseClass
{
    public MageClass()
    {
        // Class Information
        className = "Mage";
        classDescription = "A hero who can weild powerful spells.";

        // Attributes
        baseStrength = 20;
        baseAgility = 20;
        baseIntelligence = 23;
        baseStamina = 20;

        // Resources
        baseHealth = 50;
        baseResourceAmount = 100;
        baseResourceType = GameResource.Mana;
    }
}
