using UnityEngine;
using System.Collections;

public class BaseAbility : BaseUsable
{
	public int spellMinDamage = 0;
	public int spellMaxDamage = 0;
	public int spellAvgDamage = 0;
	public int spellCooldown = 0;

	public BaseAbility()
	{
		spellAvgDamage = (spellMinDamage + spellMaxDamage) / 2;
	}

	public virtual void Use()
	{
		Debug.Log("Use Ability");
	}
}
