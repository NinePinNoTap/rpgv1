using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class ActionBarSlot : BaseInterfaceSlot
{
	void Start ()
	{	
		// Text Counter
        if(slotText != null)
        {
            slotText.text = "";
        }
	}

	public override void UseSlot ()
	{
		if (!IsEmpty())
        {
            slotStack.Peek().Use();
		}
  	}
}