using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int baseHealth;
    public GameObject gameOverPanel;

    int health;
    bool isDead;

    private void Start()
    {
        ResetHealth();
    }

    void ResetHealth()
    {
        health = baseHealth;
    }

    public void TookDamage(int damage)
    {
        health -= damage;

        if(health <= 0 && !isDead)
        {
            isDead = true;
            StartCoroutine(Died());
        }
    }

    public void Killed()
    {
        if (isDead) return;

        isDead = true;
        health = 0;
        StartCoroutine(Died());
    }

    IEnumerator Died()
    {
        gameOverPanel.SetActive(true);
        yield return null;
    }
}
