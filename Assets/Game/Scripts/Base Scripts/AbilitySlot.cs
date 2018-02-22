using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySlot : MonoBehaviour
{
    public Ability ability;
    public Image iconSlot;

    private void Start()
    {
        if (!ability) return;

        if(!ability.AbilityUnlocked())
            iconSlot.sprite = ability.abilityIconGreyscale;
        else
            iconSlot.sprite = ability.abilityIcon;
    }

    public void UnlockAbility()
    {
        if (!ability) return;

        if (!ability.AbilityUnlocked())
        {
            ability.UnlockAbility();
            iconSlot.sprite = ability.abilityIcon;
        }
    }
}
