using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffects : MonoBehaviour
{
    Health health;

    Coroutine dot;
    Coroutine slow;

    bool isDotted;
    bool isSlowed;

    private void Start()
    {
        health = GetComponent<Health>();
    }

    public void Dot(int minDamage, int maxDamage, int critChance, float critDamage, NamePlate namePlate, float statusLength)
    {
        if(!isDotted)
        {
            isDotted = true;
            dot = StartCoroutine(Dotted(minDamage, maxDamage, critChance, critDamage, namePlate, statusLength));
        }
        else
        {
            StopCoroutine(dot);

            isDotted = true;
            dot = StartCoroutine(Dotted(minDamage, maxDamage, critChance, critDamage, namePlate, statusLength));
        }
    }

    IEnumerator Dotted(int minDamage, int maxDamage, int critChance, float critDamage, NamePlate namePlate, float statusLength)
    {
        for(int i = 0; i < statusLength; i++)
        {
            int randomDamage = Random.Range(minDamage, maxDamage);
            health.TookDamage(randomDamage, critChance, critDamage, namePlate);

            yield return new WaitForSeconds(1);
        }

        isDotted = false;
    }

    public void Slow(float statusLength)
    {
        if(!isSlowed)
        {
            isSlowed = true;
            slow = StartCoroutine(Slowed(statusLength));
        }
        else
        {
            StopCoroutine(slow);

            isSlowed = true;
            slow = StartCoroutine(Slowed(statusLength));
        }
    }

    IEnumerator Slowed(float statusLength)
    {
        print("IsSlowed");
        yield return new WaitForSeconds(statusLength);
        isSlowed = false;
    }
}
