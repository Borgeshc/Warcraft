using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnchantAbility : Ability
{
    public override void ActivateAbility()
    {
        if (requiresTarget && Target.target == null) return;

        if (!OnGlobalCooldown() && !OnCooldown())
        {
            for(int i = 0; i < AbilityLoadout.abilities.Count; i++)
            {
                AbilityLoadout.abilities[i].currentEnchant = enchant;
                AbilityLoadout.abilities[i].statusLength = statusLength;
            }

            TriggerCooldown();
        }
    }
}
