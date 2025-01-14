﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Stats stats;
    public GameObject enemyCanvas;
    public GameObject combatText;
    public GameObject criticalCombatText;
    public Collider damageCollider;

    [HideInInspector]
    public int health;

    [HideInInspector]
    public bool isDead;

    Animator anim;
    SpawnManager spawnManager;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        spawnManager = GameObject.Find("GameManager").GetComponent<SpawnManager>();
        ResetHealth();
    }

    public void TookDamage(int damage, int criticalStrikeChance, float criticalStrikeDamage, NamePlate enemyNamePlate)
    {
        int crit = Random.Range(0, 100);

        if (crit <= criticalStrikeChance)
        {
            float finalDamage = damage * criticalStrikeDamage;
            finalDamage = Mathf.RoundToInt(finalDamage + .4f);
            health -= (int)finalDamage;
            GameObject cbt = Instantiate(criticalCombatText, enemyCanvas.transform.position, enemyCanvas.transform.rotation, enemyCanvas.transform);
            cbt.GetComponent<Text>().text = finalDamage.ToString();
        }
        else
        {
            health -= damage;
            GameObject cbt = Instantiate(combatText, enemyCanvas.transform.position, enemyCanvas.transform.rotation, enemyCanvas.transform);
            cbt.GetComponent<Text>().text = damage.ToString();
        }

        if(Target.target == gameObject)
            enemyNamePlate.UpdateHealth(health);

        if(health <= 0 && !isDead)
        {
            isDead = true;
            anim.SetBool("Dead", true);

            if (damageCollider)
                damageCollider.enabled = false;

            if(spawnManager.activeEnemies.Contains(gameObject))
                spawnManager.CheckStage(gameObject);

            enemyNamePlate.DisableNamePlate();
            Destroy(gameObject, 5);
        }
    }

    void ResetHealth()
    {
        health = stats.health;
    }
}
