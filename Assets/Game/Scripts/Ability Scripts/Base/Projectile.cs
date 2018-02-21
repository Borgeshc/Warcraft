using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;
    public float pushBackForce;

    public Ability.Enchant currentEnchant;

    protected Transform target;
    protected int minimumDamage;
    protected int maximumDamage;
    protected int criticalStrikeChance;
    protected float criticalStrikeDamage;
    protected float statusLength;
    protected NamePlate enemyNamePlate;

    protected float smoothTime;

    public virtual void SetProjectileValues(Transform _target, int _minimumDamage, int _maximumDamage, int _criticalStrikeChance, float _criticalStrikeDamage, float _statusLength, NamePlate _enemyNamePlate, Ability.Enchant enchant)
    {

    }

    public void PushBack(GameObject target)
    {
        Rigidbody rb = target.GetComponent<Rigidbody>();
        rb.AddForce((target.transform.up + -target.transform.forward) * pushBackForce);
    }
}
