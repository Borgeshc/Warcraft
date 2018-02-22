using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAbilities : MonoBehaviour
{
    public List<Ability> abilities;

    private void Update()
    {
        if (DevMode.devMove)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                foreach (Ability ability in abilities)
                {
                    ability.LockAbility();
                }
                print("Abilities Reset");
            }
        }
    }
}
