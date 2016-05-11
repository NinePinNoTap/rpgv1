using UnityEngine;
using System.Collections;

public class MageClass : BaseCharacterClass
{
    public MageClass()
    {
        // Class Information
        Name = "Mage";
        Description = "A hero who can weild powerful spells.";

        // Attributes
        BaseStrength = 20;
        BaseAgility = 20;
        BaseIntelligence = 23;
        BaseStamina = 20;

        // Resources
        BaseHealth = 50;
        BaseEnergy = 100;
        BaseResource = ResourceType.Mana;
    }
}
