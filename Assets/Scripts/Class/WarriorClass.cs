using UnityEngine;
using System.Collections;

public class WarriorClass : BaseCharacterClass
{
    public WarriorClass()
    {
        // Class Information
        Name = "Warrior";
        Description = "A strong and powerful hero who is skilled in combat.";

        // Attributes
        BaseStrength = 23;
        BaseAgility = 20;
        BaseIntelligence = 20;
        BaseStamina = 22;

        // Resources
        BaseHealth = 60;
        BaseEnergy = 0;
        BaseResource = ResourceType.Rage;
    }
}