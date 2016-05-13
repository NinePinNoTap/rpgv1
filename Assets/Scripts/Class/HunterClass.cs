using UnityEngine;
using System.Collections;
using CharacterConfig;

public class HunterClass : BaseClass
{
    public HunterClass()
    {
        // Class Information
        className = "Hunter";
        classDescription = "A master of woodcraft and beast mastery.";

        // Attributes
        baseStrength = 20;
        baseAgility = 23;
        baseIntelligence = 20;
        baseStamina = 21;

        // Resources
        baseHealth = 60;
        baseResourceAmount = 100;
        baseResourceType = GameResource.Energy;
    }
}