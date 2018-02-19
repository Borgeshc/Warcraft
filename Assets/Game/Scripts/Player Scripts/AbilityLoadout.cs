using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityLoadout : MonoBehaviour
{
    [Header("Ability Loadout"), Space]
    public ActionButton actionButton1;
    public Ability actionButton1Ability;
    [Space]
    public ActionButton actionButton2;
    public Ability actionButton2Ability;
    [Space]
    public ActionButton actionButton3;
    public Ability actionButton3Ability;
    [Space]
    public ActionButton actionButton4;
    public Ability actionButton4Ability;
    [Space]
    public ActionButton actionButton5;
    public Ability actionButton5Ability;
    [Space]
    public ActionButton actionButton6;
    public Ability actionButton6Ability;
    [Space]
    public ActionButton actionButton7;
    public Ability actionButton7Ability;
    [Space]
    public ActionButton actionButton8;
    public Ability actionButton8Ability;
    [Space]
    public ActionButton actionButton9;
    public Ability actionButton9Ability;
    [Space]
    public ActionButton actionButton10;
    public Ability actionButton10Ability;
    [Space]
    public ActionButton actionButton11;
    public Ability actionButton11Ability;
    [Space]
    public ActionButton actionButton12;
    public Ability actionButton12Ability;

    private void Start()
    {
        UpdateIcons();
    }

    public void ActionButtonPressed(int button)
    {
        switch(button)
        {
            case 1:
                if(actionButton1Ability)
                {
                    actionButton1Ability.ActivateAbility();
                    actionButton1.ShowCooldown(actionButton1Ability.abilityCooldown);
                }
                break;
            case 2:
                if (actionButton2Ability)
                {
                    actionButton2Ability.ActivateAbility();
                    actionButton2.ShowCooldown(actionButton2Ability.abilityCooldown);
                }
                break;
            case 3:
                if (actionButton3Ability)
                {
                    actionButton3Ability.ActivateAbility();
                    actionButton3.ShowCooldown(actionButton3Ability.abilityCooldown);
                }
                break;
            case 4:
                if (actionButton4Ability)
                {
                    actionButton4Ability.ActivateAbility();
                    actionButton4.ShowCooldown(actionButton4Ability.abilityCooldown);
                }
                break;
            case 5:
                if (actionButton5Ability)
                {
                    actionButton5Ability.ActivateAbility();
                    actionButton5.ShowCooldown(actionButton5Ability.abilityCooldown);
                }
                break;
            case 6:
                if (actionButton6Ability)
                {
                    actionButton6Ability.ActivateAbility();
                    actionButton6.ShowCooldown(actionButton6Ability.abilityCooldown);
                }
                break;
            case 7:
                if (actionButton7Ability)
                {
                    actionButton7Ability.ActivateAbility();
                    actionButton7.ShowCooldown(actionButton7Ability.abilityCooldown);
                }
                break;
            case 8:
                if (actionButton8Ability)
                {
                    actionButton8Ability.ActivateAbility();
                    actionButton8.ShowCooldown(actionButton8Ability.abilityCooldown);
                }
                break;
            case 9:
                if (actionButton9Ability)
                {
                    actionButton9Ability.ActivateAbility();
                    actionButton9.ShowCooldown(actionButton9Ability.abilityCooldown);
                }
                break;
            case 10:
                if (actionButton10Ability)
                {
                    actionButton10Ability.ActivateAbility();
                    actionButton10.ShowCooldown(actionButton10Ability.abilityCooldown);
                }
                break;
            case 11:
                if (actionButton11Ability)
                {
                    actionButton11Ability.ActivateAbility();
                    actionButton11.ShowCooldown(actionButton11Ability.abilityCooldown);
                }
                break;
            case 12:
                if (actionButton12Ability)
                {
                    actionButton12Ability.ActivateAbility();
                    actionButton12.ShowCooldown(actionButton12Ability.abilityCooldown);
                }
                break;
        }

        if(actionButton1Ability)
        {
            if(!actionButton1Ability.OnCooldown())
                actionButton1.ShowCooldown(1);

            StartCoroutine(actionButton1Ability.GlobalCooldown());
        }

        if (actionButton2Ability)
        {
            if (!actionButton2Ability.OnCooldown())
                actionButton2.ShowCooldown(1);

            StartCoroutine(actionButton2Ability.GlobalCooldown());
        }

        if (actionButton3Ability)
        {
            if (!actionButton3Ability.OnCooldown())
                actionButton3.ShowCooldown(1);

            StartCoroutine(actionButton3Ability.GlobalCooldown());
        }

        if (actionButton4Ability)
        {
            if (!actionButton4Ability.OnCooldown())
                actionButton4.ShowCooldown(1);

            StartCoroutine(actionButton4Ability.GlobalCooldown());
        }

        if (actionButton5Ability)
        {
            if (!actionButton5Ability.OnCooldown())
                actionButton5.ShowCooldown(1);

            StartCoroutine(actionButton5Ability.GlobalCooldown());
        }

        if (actionButton6Ability)
        {
            if (!actionButton6Ability.OnCooldown())
                actionButton6.ShowCooldown(1);

            StartCoroutine(actionButton6Ability.GlobalCooldown());
        }

        if (actionButton7Ability)
        {
            if (!actionButton7Ability.OnCooldown())
                actionButton7.ShowCooldown(1);

            StartCoroutine(actionButton7Ability.GlobalCooldown());
        }

        if (actionButton8Ability)
        {
            if (!actionButton8Ability.OnCooldown())
                actionButton8.ShowCooldown(1);

            StartCoroutine(actionButton8Ability.GlobalCooldown());
        }

        if (actionButton9Ability)
        {
            if (!actionButton9Ability.OnCooldown())
                actionButton9.ShowCooldown(1);

            StartCoroutine(actionButton9Ability.GlobalCooldown());
        }

        if (actionButton10Ability)
        {
            if (!actionButton10Ability.OnCooldown())
                actionButton10.ShowCooldown(1);

            StartCoroutine(actionButton10Ability.GlobalCooldown());
        }

        if (actionButton11Ability)
        {
            if (!actionButton11Ability.OnCooldown())
                actionButton11.ShowCooldown(1);

            StartCoroutine(actionButton11Ability.GlobalCooldown());
        }

        if (actionButton12Ability)
        {
            if (!actionButton12Ability.OnCooldown())
                actionButton12.ShowCooldown(1);

            StartCoroutine(actionButton12Ability.GlobalCooldown()); 
        }
    }

    public void UpdateIcons()
    {
        if (actionButton1Ability)
            actionButton1.SetIconImage(actionButton1Ability.abilityIcon);

        if (actionButton2Ability)
            actionButton2.SetIconImage(actionButton2Ability.abilityIcon);

        if (actionButton3Ability)
            actionButton3.SetIconImage(actionButton3Ability.abilityIcon);

        if (actionButton4Ability)
            actionButton4.SetIconImage(actionButton4Ability.abilityIcon);

        if (actionButton5Ability)
            actionButton5.SetIconImage(actionButton5Ability.abilityIcon);

        if (actionButton6Ability)
            actionButton6.SetIconImage(actionButton6Ability.abilityIcon);

        if (actionButton7Ability)
            actionButton7.SetIconImage(actionButton7Ability.abilityIcon);

        if (actionButton8Ability)
            actionButton8.SetIconImage(actionButton8Ability.abilityIcon);

        if (actionButton9Ability)
            actionButton9.SetIconImage(actionButton9Ability.abilityIcon);

        if (actionButton10Ability)
            actionButton10.SetIconImage(actionButton10Ability.abilityIcon);

        if (actionButton11Ability)
            actionButton11.SetIconImage(actionButton11Ability.abilityIcon);

        if (actionButton12Ability)
            actionButton12.SetIconImage(actionButton12Ability.abilityIcon);
    }
}
