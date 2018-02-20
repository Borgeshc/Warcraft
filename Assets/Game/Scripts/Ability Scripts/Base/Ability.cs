using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public string abilityName;
    public Sprite abilityIcon;
    public float abilityCooldown;
    public bool requiresTarget;

    bool onCooldown;
    [HideInInspector]
    public bool globalCooldown;

    public virtual void ActivateAbility()
    {

    }

    public void TriggerCooldown()
    {
        onCooldown = true;
        StartCoroutine(Cooldown());
    }

    public bool OnCooldown()
    {
        return onCooldown;
    }

    public bool OnGlobalCooldown()
    {
        return globalCooldown;
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(abilityCooldown);
        onCooldown = false;
    }

    public IEnumerator GlobalCooldown()
    {
        globalCooldown = true;
        yield return new WaitForSeconds(1);
        globalCooldown = false;
    }
}
