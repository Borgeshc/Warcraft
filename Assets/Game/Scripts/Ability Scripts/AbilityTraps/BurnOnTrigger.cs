using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnOnTrigger : Trap
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Enemy"))
        {
            other.GetComponent<EnchantEffects>().Dot(minDamage, maxDamage, stats.criticalStrikeChance, stats.criticalStrikeDamage, namePlate, statusLength);
            Destroy(gameObject);
        }
    }
}
