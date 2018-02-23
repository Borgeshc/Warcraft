using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityInformation : MonoBehaviour
{
    public GameObject abilityInformationPanel;
    public Text abilityName;
    public Image abilityImage;
    public Text resourceRequirement;
    public Text range;
    public Text damage;
    public Text cooldown;
    public Text abilityDescription;
    public Text enchantable;

    public void UpdateAbilityInformation(Ability ability)
    {
        abilityInformationPanel.SetActive(true);

        abilityName.text = ability.abilityName;
        abilityImage.sprite = ability.abilityIcon;

        switch(ability.resourceType)
        {
            case Ability.ResourceType.None:
                resourceRequirement.text = "No Resource";
                break;
            case Ability.ResourceType.Arrows:
                resourceRequirement.text = ability.abilityResourceRequirement + " Arrow(s)";
                break;
            case Ability.ResourceType.Energy:
                resourceRequirement.text = ability.abilityResourceRequirement + " Energy";
                break;
        }
        range.text = ability.abilityRange + " yds";
        damage.text = ability.abilityMinDamage + " - " + ability.abilityMaxDamage + " Damage";
        cooldown.text = ability.abilityCooldown + " Sec CD";
        abilityDescription.text = ability.abilityDescription;

        if (ability.abilityEnchantable)
            enchantable.text = "Can be enchanted";
        else
            enchantable.text = "Can not be enchanted";

    }

    public void DisablePanel()
    { 
        abilityInformationPanel.SetActive(false);
    }


    //Must call thse methods
    //Must turn on and off panel depending on if you are on an ability
    //Update panel text
}
