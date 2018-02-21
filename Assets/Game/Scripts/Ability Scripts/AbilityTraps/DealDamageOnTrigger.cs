using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageOnTrigger : Trap
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Enemy"))
        {
            int randomExplosiveDamage = Random.Range(minDamage, maxDamage);
            other.transform.GetComponent<Health>().TookDamage(randomExplosiveDamage, stats.criticalStrikeChance, stats.criticalStrikeDamage, namePlate);
            Destroy(gameObject);
        }
    }
}
