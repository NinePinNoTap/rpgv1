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
			BaseAbility ability = slotStack.Peek() as BaseAbility;
			
			ability.Use();
		}
	}

	public void AddAbility(BaseAbility ability)
	{
		slotStack.Push(ability);

		UpdateSlotIcon(ability.icon);
  	}
}