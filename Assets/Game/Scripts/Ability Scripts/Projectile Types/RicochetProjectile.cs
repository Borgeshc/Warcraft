using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RicochetProjectile : Projectile
{
    float distFromTarget;

    int nearbyTargetIndex;
    int ricochetCounter;

    public override void SetProjectileValues(Transform _target, int _minimumDamage, int _maximumDamage, int _criticalStrikeChance, float _criticalStrikeDamage, float _statusLength, NamePlate _enemyNamePlate, Ability.Enchant _enchant)
    {
        target = _target;
        minimumDamage = _minimumDamage;
        maximumDamage = _maximumDamage;
        criticalStrikeChance = _criticalStrikeChance;
        criticalStrikeDamage = _criticalStrikeDamage;
        statusLength = _statusLength;
        enemyNamePlate = _enemyNamePlate;
        currentEnchant = _enchant;
    }

    private void Update()
    {
        if (target)
            transform.LookAt(target);

        smoothTime += speed * Time.deltaTime;

        if(target != null)
            transform.position = Vector3.Lerp(transform.position, target.transform.position, smoothTime);

        if(target)
            distFromTarget = Vector3.Distance(transform.position, target.transform.position);

        if (distFromTarget <= .5f)
        {
            int randomDamage = Random.Range(minimumDamage, maximumDamage);

            if(target)
            {
                target.GetComponent<Health>().TookDamage(randomDamage, criticalStrikeChance, criticalStrikeDamage, enemyNamePlate);

                if (currentEnchant == Ability.Enchant.Weighted)
                    PushBack(target.gameObject);
            }

            ricochetCounter++;
            if (nearbyTargetIndex < Target.nearByTargets.Count)
            {
                if(Target.nearByTargets[nearbyTargetIndex])
                    target = Target.nearByTargets[nearbyTargetIndex].transform;
                nearbyTargetIndex++;
            }
            else
            {
                nearbyTargetIndex = 0;
                if(Target.nearByTargets[nearbyTargetIndex])
                    target = Target.nearByTargets[nearbyTargetIndex].transform;
            }
            return;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Enemy"))
        {
            switch (currentEnchant)
            {
                case Ability.Enchant.None:
                    break;
                case Ability.Enchant.Dot:
                    other.GetComponent<EnchantEffects>().Dot(minimumDamage, maximumDamage, criticalStrikeChance, criticalStrikeDamage, enemyNamePlate, statusLength);
                    break;
                case Ability.Enchant.Slow:
                    other.GetComponent<EnchantEffects>().Slow(statusLength);
                    break;
            }
            
            if(ricochetCounter >= 5)
                Destroy(gameObject);
        }
    }
}
