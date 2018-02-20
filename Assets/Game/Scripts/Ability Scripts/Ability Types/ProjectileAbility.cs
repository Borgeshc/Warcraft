using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAbility : Ability
{
    public GameObject projectile;
    public GameObject spawnPosition;
    public NamePlate enemyNamePlate;
    public Stats stats;
    public int minimumDamage;
    public int maximumDamage;
    public int numberOfShots = 1;
    public float timeBetweenShots = 0f;

    public int numberOfTargets;
    public bool targetAllInRange;
    public bool simultaneousFire;

    Target target;

    private void Start()
    {
        target = GameObject.Find("Player").GetComponent<Target>();
    }

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
        if (targetAllInRange)
        {
            if(simultaneousFire)
            {
                for (int j = 0; j < numberOfShots; j++)
                {
                    for (int i = 0; i < Target.nearByTargets.Count; i++)
                    {
                        FireProjectile(Target.nearByTargets[i].transform);
                    }
                    yield return new WaitForSeconds(timeBetweenShots);
                }
            }
            else
            {
                for (int i = 0; i < Target.nearByTargets.Count; i++)
                {
                    for (int j = 0; j < numberOfShots; j++)
                    {

                        FireProjectile(Target.nearByTargets[i].transform);
                        yield return new WaitForSeconds(timeBetweenShots);
                    }
                }
            }
        }
        else if (numberOfTargets > 1 )
        {
            if(simultaneousFire)
            {
                for (int j = 0; j < numberOfShots; j++)
                {
                    for (int i = 0; i < target.GrabTargets(numberOfTargets).Count; i++)
                    {
                        FireProjectile(target.GrabTargets(numberOfTargets)[i].transform);
                    }
                    yield return new WaitForSeconds(timeBetweenShots);
                }
            }
            else
            {
                for (int i = 0; i < target.GrabTargets(numberOfTargets).Count; i++)
                {
                    for (int j = 0; j < numberOfShots; j++)
                    {
                    
                        FireProjectile(target.GrabTargets(numberOfTargets)[i].transform);
                        yield return new WaitForSeconds(timeBetweenShots);
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < numberOfShots; i++)
            {
                if(Target.target)
                    FireProjectile(Target.target.transform);
                yield return new WaitForSeconds(timeBetweenShots);
            }
        }

        for (int i = 0; i < AbilityLoadout.abilities.Count; i++)
        {
            AbilityLoadout.abilities[i].RemoveEnchant();
        }

        TriggerCooldown();
    }

    void FireProjectile(Transform myTarget)
    {
        GameObject newProjectile = Instantiate(projectile, spawnPosition.transform.position, spawnPosition.transform.rotation);
        if (Target.target != null)
            newProjectile.GetComponent<Projectile>().SetProjectileValues(myTarget, minimumDamage, maximumDamage, stats.criticalStrikeChance, stats.criticalStrikeDamage, statusLength, enemyNamePlate, currentEnchant);
        else
            Destroy(newProjectile);
    }
}
