using UnityEngine;
using System.Collections;

public class HunterClass : BaseCharacterClass
{
    public HunterClass()
    {
        // Class Information
        Name = "Hunter";
        Description = "A master of woodcraft and beast mastery.";

        // Attributes
        BaseStrength = 20;
        BaseAgility = 23;
        BaseIntelligence = 20;
        BaseStamina = 21;

        // Resources
        BaseHealth = 60;
        BaseEnergy = 100;
        BaseResource = ResourceType.Energy;
    }
}