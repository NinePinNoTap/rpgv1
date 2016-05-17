using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ActionBar : BaseInterfacePanel
{
	void Start ()
	{
		CreatePanel();
		CreateSlots();
	}

	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.Alpha7))
		{
            BaseAbility baseAbility = new BaseAbility();
			baseAbility.icon = Resources.Load<Sprite>("custom-spell");
			baseAbility.spellMinDamage = 5;
			baseAbility.spellMaxDamage = 10;
			baseAbility.spellAvgDamage = 7;
			baseAbility.spellCooldown = 3;
			AddAbility(baseAbility);
		}
	}

	public void AddAbility(BaseAbility ability)
	{
		IEnumerable<GameObject> emptySlots = panelSlots.Where(obj => obj.GetComponent<ActionBarSlot>().IsEmpty());
		
		if(emptySlots.Count() > 0)
		{
			emptySlots.First().GetComponent<ActionBarSlot>().AddAbility(ability);
		}
	}
}