using UnityEngine;
using System.Collections;

public class Consumable : AttributeItem
{
	public int duration;

    public override void Use()
    {
        // Execute spell

        remainingCharges = remainingCharges > 0 ? remainingCharges - 1 : -1;
    }
}

