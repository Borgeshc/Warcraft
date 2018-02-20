using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetedProjectile : Projectile
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
        if(target)
            transform.LookAt(target);

        smoothTime += speed * Time.deltaTime;

        if (target)
            transform.position = Vector3.Lerp(transform.position, target.transform.position, smoothTime);
        else
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Enemy"))
        {
            switch(statusEffect)
            {
                case Status.None:
                    int randomDamage = Random.Range(minimumDamage, maximumDamage);
                    other.GetComponent<Health>().TookDamage(randomDamage, criticalStrikeChance, criticalStrikeDamage, enemyNamePlate);
                    break;
                case Status.Dot:
                    other.GetComponent<StatusEffects>().Dot(minimumDamage, maximumDamage, criticalStrikeChance, criticalStrikeDamage, enemyNamePlate, statusLength);
                    break;
                case Status.Slow:
                    other.GetComponent<StatusEffects>().Slow(statusLength);
                    break;
            }

            Destroy(gameObject);
        }
    }
}
