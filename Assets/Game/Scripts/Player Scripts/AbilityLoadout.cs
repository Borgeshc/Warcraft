using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityLoadout : MonoBehaviour
{
    #region Ability Loadout
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
    #endregion

    [Space, Header("Action Bar Variables")]
    public float globalCooldown;
    public GameObject targetRequiredText;

    public static List<Ability> abilities;

    bool requiringTarget;

    private void Start()
    {
        abilities = new List<Ability>(12);
        SetUpAbilities();
        UpdateIcons();
    }
    #region SetUpAbilities()
    public void SetUpAbilities()
    {
        if (actionButton1Ability)
            abilities.Add(actionButton1Ability);

        if (actionButton2Ability)
            abilities.Add(actionButton2Ability);

        if (actionButton3Ability)
            abilities.Add(actionButton3Ability);

        if (actionButton4Ability)
            abilities.Add(actionButton4Ability);

        if (actionButton5Ability)
            abilities.Add(actionButton5Ability);

        if (actionButton6Ability)
            abilities.Add(actionButton6Ability);

        if (actionButton7Ability)
            abilities.Add(actionButton7Ability);

        if (actionButton8Ability)
            abilities.Add(actionButton8Ability);

        if (actionButton9Ability)
            abilities.Add(actionButton9Ability);

        if (actionButton10Ability)
            abilities.Add(actionButton10Ability);

        if (actionButton11Ability)
            abilities.Add(actionButton11Ability);

        if (actionButton12Ability)
            abilities.Add(actionButton12Ability);
    }
    #endregion
    #region UpdateAbilities()
    public void UpdateAbilities()
    {
        if (actionButton1Ability)
        {
            abilities[0] = actionButton1Ability;
        }

        if (actionButton2Ability)
        {
            abilities[1] = actionButton2Ability;
        }

        if (actionButton3Ability)
        {
            abilities[2] = actionButton3Ability;
        }

        if (actionButton4Ability)
        {
            abilities[3] = actionButton4Ability;
        }

        if (actionButton5Ability)
        {
            abilities[4] = actionButton5Ability;
        }

        if (actionButton6Ability)
        {
            abilities[5] = actionButton6Ability;
        }

        if (actionButton7Ability)
        {
            abilities[6] = actionButton7Ability;
        }

        if (actionButton8Ability)
        {
            abilities[7] = actionButton8Ability;
        }

        if (actionButton9Ability)
        {
            abilities[8] = actionButton9Ability;
        }

        if (actionButton10Ability)
        {
            abilities[9] = actionButton10Ability;
        }

        if (actionButton11Ability)
        {
            abilities[10] = actionButton11Ability;
        }

        if (actionButton12Ability)
        {
            abilities[11] = actionButton12Ability;
        }
    }
    #endregion
    
    public void ActionButtonPressed(int button)
    {
        #region Input
        switch (button)
        {
            case 1:
                if(actionButton1Ability)
                {
                    if (actionButton1Ability.requiresTarget && Target.target == null)
                    {
                        if (!requiringTarget)
                            StartCoroutine(TargetRequired());

                        return;
                    }
                    actionButton1Ability.ActivateAbility();

                    if(!actionButton1.ShowingCooldown())
                        actionButton1.ShowCooldown(actionButton1Ability.abilityCooldown);
                }
                break;
            case 2:
                if (actionButton2Ability)
                {
                    if (actionButton2Ability.requiresTarget && Target.target == null)
                    {
                        if (!requiringTarget)
                            StartCoroutine(TargetRequired());

                        return;
                    }
                    actionButton2Ability.ActivateAbility();

                    if (!actionButton2.ShowingCooldown())
                        actionButton2.ShowCooldown(actionButton2Ability.abilityCooldown);
                }
                break;
            case 3:
                if (actionButton3Ability)
                {
                    if (actionButton3Ability.requiresTarget && Target.target == null)
                    {
                        if (!requiringTarget)
                            StartCoroutine(TargetRequired());

                        return;
                    }
                    actionButton3Ability.ActivateAbility();

                    if (!actionButton3.ShowingCooldown())
                        actionButton3.ShowCooldown(actionButton3Ability.abilityCooldown);
                }
                break;
            case 4:
                if (actionButton4Ability)
                {
                    if (actionButton4Ability.requiresTarget && Target.target == null)
                    {
                        if (!requiringTarget)
                            StartCoroutine(TargetRequired());

                        return;
                    }
                    actionButton4Ability.ActivateAbility();

                    if (!actionButton4.ShowingCooldown())
                        actionButton4.ShowCooldown(actionButton4Ability.abilityCooldown);
                }
                break;
            case 5:
                if (actionButton5Ability)
                {
                    if (actionButton5Ability.requiresTarget && Target.target == null)
                    {
                        if (!requiringTarget)
                            StartCoroutine(TargetRequired());

                        return;
                    }
                    actionButton5Ability.ActivateAbility();

                    if (!actionButton5.ShowingCooldown())
                        actionButton5.ShowCooldown(actionButton5Ability.abilityCooldown);
                }
                break;
            case 6:
                if (actionButton6Ability)
                {
                    if (actionButton6Ability.requiresTarget && Target.target == null)
                    {
                        if (!requiringTarget)
                            StartCoroutine(TargetRequired());

                        return;
                    }
                    actionButton6Ability.ActivateAbility();

                    if (!actionButton6.ShowingCooldown())
                        actionButton6.ShowCooldown(actionButton6Ability.abilityCooldown);
                }
                break;
            case 7:
                if (actionButton7Ability)
                {
                    if (actionButton7Ability.requiresTarget && Target.target == null)
                    {
                        if (!requiringTarget)
                            StartCoroutine(TargetRequired());

                        return;
                    }
                    actionButton7Ability.ActivateAbility();

                    if (!actionButton7.ShowingCooldown())
                        actionButton7.ShowCooldown(actionButton7Ability.abilityCooldown);
                }
                break;
            case 8:
                if (actionButton8Ability)
                {
                    if (actionButton8Ability.requiresTarget && Target.target == null)
                    {
                        if (!requiringTarget)
                            StartCoroutine(TargetRequired());

                        return;
                    }
                    actionButton8Ability.ActivateAbility();

                    if (!actionButton8.ShowingCooldown())
                        actionButton8.ShowCooldown(actionButton8Ability.abilityCooldown);
                }
                break;
            case 9:
                if (actionButton9Ability)
                {
                    if (actionButton9Ability.requiresTarget && Target.target == null)
                    {
                        if (!requiringTarget)
                            StartCoroutine(TargetRequired());

                        return;
                    }
                    actionButton9Ability.ActivateAbility();

                    if (!actionButton9.ShowingCooldown())
                        actionButton9.ShowCooldown(actionButton9Ability.abilityCooldown);
                }
                break;
            case 10:
                if (actionButton10Ability)
                {
                    if (actionButton10Ability.requiresTarget && Target.target == null)
                    {
                        if (!requiringTarget)
                            StartCoroutine(TargetRequired());

                        return;
                    }
                    actionButton10Ability.ActivateAbility();

                    if (!actionButton10.ShowingCooldown())
                        actionButton10.ShowCooldown(actionButton10Ability.abilityCooldown);
                }
                break;
            case 11:
                if (actionButton11Ability)
                {
                    if (actionButton11Ability.requiresTarget && Target.target == null)
                    {
                        if (!requiringTarget)
                            StartCoroutine(TargetRequired());

                        return;
                    }
                    actionButton11Ability.ActivateAbility();

                    if (!actionButton11.ShowingCooldown())
                        actionButton11.ShowCooldown(actionButton11Ability.abilityCooldown);
                }
                break;
            case 12:
                if (actionButton12Ability)
                {
                    if (actionButton12Ability.requiresTarget && Target.target == null)
                    {
                        if (!requiringTarget)
                            StartCoroutine(TargetRequired());

                        return;
                    }
                    actionButton12Ability.ActivateAbility();

                    if (!actionButton12.ShowingCooldown())
                        actionButton12.ShowCooldown(actionButton12Ability.abilityCooldown);
                }
                break;
        }
        #endregion
        #region GlobalCooldown
        if (actionButton1Ability)
        {
            if(!actionButton1Ability.OnCooldown() && !actionButton1.ShowingCooldown())
                actionButton1.ShowCooldown(globalCooldown);
        }

        if (actionButton2Ability)
        {
            if (!actionButton2Ability.OnCooldown() && !actionButton2.ShowingCooldown())
                actionButton2.ShowCooldown(globalCooldown);
        }

        if (actionButton3Ability)
        {
            if (!actionButton3Ability.OnCooldown() && !actionButton3.ShowingCooldown())
                actionButton3.ShowCooldown(globalCooldown);
        }

        if (actionButton4Ability)
        {
            if (!actionButton4Ability.OnCooldown() && !actionButton4.ShowingCooldown())
                actionButton4.ShowCooldown(globalCooldown);
        }

        if (actionButton5Ability)
        {
            if (!actionButton5Ability.OnCooldown() && !actionButton5.ShowingCooldown())
                actionButton5.ShowCooldown(globalCooldown);
        }

        if (actionButton6Ability)
        {
            if (!actionButton6Ability.OnCooldown() && !actionButton6.ShowingCooldown())
                actionButton6.ShowCooldown(globalCooldown);
        }

        if (actionButton7Ability)
        {
            if (!actionButton7Ability.OnCooldown() && !actionButton7.ShowingCooldown())
                actionButton7.ShowCooldown(globalCooldown);
        }

        if (actionButton8Ability)
        {
            if (!actionButton8Ability.OnCooldown() && !actionButton8.ShowingCooldown())
                actionButton8.ShowCooldown(globalCooldown);
        }

        if (actionButton9Ability)
        {
            if (!actionButton9Ability.OnCooldown() && !actionButton9.ShowingCooldown())
                actionButton9.ShowCooldown(globalCooldown);
        }

        if (actionButton10Ability)
        {
            if (!actionButton10Ability.OnCooldown() && !actionButton10.ShowingCooldown())
                actionButton10.ShowCooldown(globalCooldown);
        }

        if (actionButton11Ability)
        {
            if (!actionButton11Ability.OnCooldown() && !actionButton11.ShowingCooldown())
                actionButton11.ShowCooldown(globalCooldown);
        }

        if (actionButton12Ability)
        {
            if (!actionButton12Ability.OnCooldown() && !actionButton12.ShowingCooldown())
                actionButton12.ShowCooldown(globalCooldown);
        }
        #endregion
    }

    IEnumerator TargetRequired()
    {
        requiringTarget = true;
        targetRequiredText.SetActive(true);
        yield return new WaitForSeconds(1);
        targetRequiredText.SetActive(false);
        requiringTarget = false;
    }

    #region UpdateIcons
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
    #endregion
}
