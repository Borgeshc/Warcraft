using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;

    Transform target;
    int damage;
    int criticalStrikeChance;
    float criticalStrikeDamage;
    float smoothTime;
    NamePlate enemyNamePlate;

    public void SetProjectileValues(Transform _target, int _damage, int _criticalStrikeChance, float _criticalStrikeDamage, NamePlate _enemyNamePlate)
    {
        target = _target;
        damage = _damage;
        criticalStrikeChance = _criticalStrikeChance;
        criticalStrikeDamage = _criticalStrikeDamage;
        enemyNamePlate = _enemyNamePlate;
    }

    private void Update()
    {
        if(target)
            transform.LookAt(target);

        smoothTime += speed * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, target.transform.position, smoothTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Enemy"))
        {
            other.GetComponent<Health>().TookDamage(damage, criticalStrikeChance, criticalStrikeDamage, enemyNamePlate);
            Destroy(gameObject);
        }
    }
}
