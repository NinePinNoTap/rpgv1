using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class ActionBarSlot : BaseInterfaceSlot
{
	void Start ()
	{		
		// Create stack to store item
		slotStack = new Stack<BaseObject>();
	
		// Text Counter
		slotText.text = "";
	}

	public override void UseSlot ()
	{
		if (!IsEmpty())
        {
            slotStack.Peek().Use();
		}
  	}
}