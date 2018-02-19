using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAbility : Ability
{
    public GameObject projectile;
    public GameObject spawnPosition;
    public Stats stats;

    public bool requiresTarget;

    public override void ActivateAbility()
    {
        if (requiresTarget && Target.target == null) return;

        if(!OnGlobalCooldown() && !OnCooldown())
        {
            GameObject newProjectile = Instantiate(projectile, spawnPosition.transform.position, spawnPosition.transform.rotation);
            newProjectile.GetComponent<Projectile>().SetProjectileValues(Target.target.transform, stats.damage);
            TriggerCooldown();
        }
    }
}
