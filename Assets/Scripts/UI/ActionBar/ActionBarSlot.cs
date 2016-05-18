using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class ActionBarSlot : BaseInterfaceSlot
{
	void Start ()
	{		
		// Create stack to store item
		slotStack = new Stack<BaseUsable>();
	
		// Text Counter
		slotText.text = "";
	}

	public override void UseSlot ()
	{
		if (!IsEmpty())
		{
            if(slotStack.Peek().GetType().Equals(typeof(BaseAbility)))
            {
                BaseAbility ability = slotStack.Peek() as BaseAbility;
                
                ability.Use();
            }
            else if(slotStack.Peek().GetType().Equals(typeof(BaseItem)))
            {
                BaseItem ability = slotStack.Peek() as BaseItem;
                
                ability.Use();
            }
            else
            {
                slotStack.Peek().Use();
            }
		}
  	}
}