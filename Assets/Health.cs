using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Stats stats;
    public GameObject enemyCanvas;
    public GameObject combatText;
    public GameObject criticalCombatText;

    [HideInInspector]
    public int health;
    bool isDead;

    private void Awake()
    {
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
            enemyNamePlate.DisableNamePlate();
            Destroy(gameObject);
        }
    }

    void ResetHealth()
    {
        health = stats.health;
    }
}
