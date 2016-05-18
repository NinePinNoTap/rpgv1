using UnityEngine;
using System.Collections;

public class Consumable : BaseItem
{
    public int spellDuration = -1;                      // How long the effect

    public override void Use()
    {
        // Execute spell
        spellCharges = spellCharges > 0 ? spellCharges - 1 : -1;
    }
}

