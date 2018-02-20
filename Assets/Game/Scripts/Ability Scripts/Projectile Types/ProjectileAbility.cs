using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAbility : Ability
{
    public GameObject projectile;
    public GameObject spawnPosition;
    public NamePlate enemyNamePlate;
    public int minimumDamage;
    public int maximumDamage;
    public int numberOfShots = 1;
    public float timeBetweenShots = 0f;
    public Stats stats;

    public override void ActivateAbility()
    {
        if (requiresTarget && Target.target == null) return;

        if(!OnGlobalCooldown() && !OnCooldown())
        {
            StartCoroutine(Fire());
        }
    }

    IEnumerator Fire()
    {
        for(int i = 0; i < numberOfShots; i++)
        {
            GameObject newProjectile = Instantiate(projectile, spawnPosition.transform.position, spawnPosition.transform.rotation);
            if (Target.target != null)
                newProjectile.GetComponent<Projectile>().SetProjectileValues(Target.target.transform, minimumDamage, maximumDamage, stats.criticalStrikeChance, stats.criticalStrikeDamage, statusLength, enemyNamePlate, currentEnchant);
            else
                Destroy(newProjectile);
            yield return new WaitForSeconds(timeBetweenShots);
        }
        RemoveEnchant();
        TriggerCooldown();
    }
}
