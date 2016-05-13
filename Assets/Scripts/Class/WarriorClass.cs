using UnityEngine;
using System.Collections;
using CharacterConfig;

public class WarriorClass : BaseClass
{
    public WarriorClass()
    {
        // Class Information
        className = "Warrior";
        classDescription = "A strong and powerful hero who is skilled in combat.";

        // Attributes
        baseStrength = 23;
        baseAgility = 20;
        baseIntelligence = 20;
        baseStamina = 22;

        // Resources
        baseHealth = 60;
        baseResourceAmount = 0;
        baseResourceType = GameResource.Rage;
    }
}