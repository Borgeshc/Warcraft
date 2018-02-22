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
    }
    #endregion
}
