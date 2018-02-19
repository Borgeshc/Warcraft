using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;

    Transform target;
    int damage;
    float smoothTime;

    public void SetProjectileValues(Transform _target, int _damage)
    {
        target = _target;
        damage = _damage;
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
            //other.GetComponent<Health>().TookDamage(damage);
            Destroy(gameObject);
        }
    }
}
