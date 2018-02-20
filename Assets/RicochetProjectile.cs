using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RicochetProjectile : Projectile
{
    public float speed = 5f;

    public enum Status
    {
        None,
        Dot,
        Slow
    };

    public Status statusEffect;

    Transform target;
    int minimumDamage;
    int maximumDamage;
    int criticalStrikeChance;
    float criticalStrikeDamage;
    float statusLength;
    NamePlate enemyNamePlate;

    float smoothTime;
    float distFromTarget;

    int nearbyTargetIndex;
    int ricochetCounter;

    public override void SetProjectileValues(Transform _target, int _minimumDamage, int _maximumDamage, int _criticalStrikeChance, float _criticalStrikeDamage, float _statusLength, NamePlate _enemyNamePlate)
    {
        target = _target;
        minimumDamage = _minimumDamage;
        maximumDamage = _maximumDamage;
        criticalStrikeChance = _criticalStrikeChance;
        criticalStrikeDamage = _criticalStrikeDamage;
        statusLength = _statusLength;
        enemyNamePlate = _enemyNamePlate;
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
                target.GetComponent<Health>().TookDamage(randomDamage, criticalStrikeChance, criticalStrikeDamage, enemyNamePlate);

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
            switch (statusEffect)
            {
                case Status.None:
                    break;
                case Status.Dot:
                    other.GetComponent<StatusEffects>().Dot(minimumDamage, maximumDamage, criticalStrikeChance, criticalStrikeDamage, enemyNamePlate, statusLength);
                    break;
                case Status.Slow:
                    other.GetComponent<StatusEffects>().Slow(statusLength);
                    break;
            }
            
            if(ricochetCounter >= 5)
                Destroy(gameObject);
        }
    }
}
