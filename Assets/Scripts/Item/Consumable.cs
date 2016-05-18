using UnityEngine;
using System.Collections;

public class Consumable : AttributeItem
{
    public int spellDuration = -1;                      // How long the effect

    public override void Use()
    {
        // Execute spell
        spellCharges = spellCharges > 0 ? spellCharges - 1 : -1;
    }
}

