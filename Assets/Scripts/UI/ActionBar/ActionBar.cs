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
            baseAbility.name = "Fire Spell";
            baseAbility.description = "A fiery spell that sets enemies on fire.";
			baseAbility.icon = Resources.Load<Sprite>("custom-spell");
			baseAbility.spellMinDamage = 5;
			baseAbility.spellMaxDamage = 10;
			baseAbility.spellAvgDamage = 7;
			baseAbility.spellCooldown = 3;
			AddAbility(baseAbility);
		}

        if(Input.GetKeyDown(KeyCode.Alpha8))
        {
            AddItem(ItemDatabase.Instance.itemDB[0]);
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

    public void AddItem(BaseItem item)
    {
        IEnumerable<GameObject> emptySlots = panelSlots.Where(obj => obj.GetComponent<ActionBarSlot>().IsEmpty());
        
        if(emptySlots.Count() > 0)
        {
            emptySlots.First().GetComponent<ActionBarSlot>().AddItem(item);
        }
    }
}