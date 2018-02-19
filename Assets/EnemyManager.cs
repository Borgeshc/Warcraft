using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public NamePlate enemyNamePlate;
    Health health;
    Entity entity;

    private void Start()
    {
        health = GetComponent<Health>();
        entity = GetComponent<Entity>();
        enemyNamePlate.SetUpBaseValues(health.health, entity.stats.resource); //Resource needs to be changed with real resource value
        enemyNamePlate.SetUpNamePlate(entity.entityName, entity.entityImage, entity.stats.level, entity.stats.health, entity.stats.resource);
    }

    private void OnEnable()
    {
        Targetable.OnTargeted += SetUpNamePlate;    //This is calling on all enemies, have to change it <-------
        //THIS IS A BUG
    }

    private void OnDisable()
    {
        Targetable.OnTargeted -= SetUpNamePlate;
    }

    public void SetUpNamePlate(Entity entity)
    {
        print("Switched Target");
        //enemyNamePlate.SetUpNamePlate(entity.entityName, entity.entityImage, entity.stats.level, health.health, entity.stats.resource);
        enemyNamePlate.UpdateHealth(health.health);
    }
}
