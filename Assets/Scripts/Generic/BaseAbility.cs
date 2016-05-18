using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class BaseAbility : BaseObject
{
	public int spellMinDamage = 0;
	public int spellMaxDamage = 0;
	public int spellAvgDamage = 0;
	public int spellCooldown = 0;
    public int spellRange = 0;

	public BaseAbility()
	{
		spellAvgDamage = (spellMinDamage + spellMaxDamage) / 2;
	}

	public override void Use()
	{
		Debug.Log(name + " - Use Ability");
    }

    public override void GetTooltip()
    {
        UIManager.Instance.tooltip.AddText(name, 30, Color.white, true, false);
        UIManager.Instance.tooltip.AddText(description, 20, Color.white, false, true);
        UIManager.Instance.tooltip.AddText("Range : " + spellRange, 20, Color.white);
        UIManager.Instance.tooltip.AddText("Cooldown : " + spellCooldown + "s", 20, Color.white);
        UIManager.Instance.tooltip.AddText("Damage : " + spellMinDamage + " - " + spellMaxDamage, 20, Color.white);
    }
}
