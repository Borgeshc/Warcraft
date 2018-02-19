using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityLoadout : MonoBehaviour
{
    [Header("Ability Loadout"), Space]
    public Ability actionButton1;
    [Space]
    public Ability actionButton2;
    [Space]
    public Ability actionButton3;
    [Space]
    public Ability actionButton4;
    [Space]
    public Ability actionButton5;
    [Space]
    public Ability actionButton6;
    [Space]
    public Ability actionButton7;
    [Space]
    public Ability actionButton8;
    [Space]
    public Ability actionButton9;
    [Space]
    public Ability actionButton10;
    [Space]
    public Ability actionButton11;
    [Space]
    public Ability actionButton12;

    public void ActionButtonPressed(int button)
    {
        switch(button)
        {
            case 1:
                if(actionButton1)
                    actionButton1.ActivateAbility();
                break;
            case 2:
                if (actionButton2)
                    actionButton2.ActivateAbility();
                break;
            case 3:
                if (actionButton3)
                    actionButton3.ActivateAbility();
                break;
            case 4:
                if (actionButton4)
                    actionButton4.ActivateAbility();
                break;
            case 5:
                if (actionButton5)
                    actionButton5.ActivateAbility();
                break;
            case 6:
                if (actionButton6)
                    actionButton6.ActivateAbility();
                break;
            case 7:
                if (actionButton7)
                    actionButton7.ActivateAbility();
                break;
            case 8:
                if (actionButton8)
                    actionButton8.ActivateAbility();
                break;
            case 9:
                if (actionButton9)
                    actionButton9.ActivateAbility();
                break;
            case 10:
                if (actionButton10)
                    actionButton10.ActivateAbility();
                break;
            case 11:
                if (actionButton11)
                    actionButton11.ActivateAbility();
                break;
            case 12:
                if (actionButton12)
                    actionButton12.ActivateAbility();
                break;
        }
    }
}
