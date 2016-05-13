using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionBarSlot : BaseInterfaceSlot
{
	void Start ()
	{
		RectTransform slotRect;
		RectTransform textRect;
		
		// Create stack to store item
		slotStack = new Stack<BaseUsable>();
		
		// Configure the text
		slotRect = GetComponent<RectTransform>();
		textRect = slotText.GetComponent<RectTransform>();
		
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

