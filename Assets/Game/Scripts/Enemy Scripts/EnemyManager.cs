using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : EntityManager
{
    Health health;
    Entity entity;
    ReferenceManager referenceManager;
    NamePlate enemyNamePlate;

    private void Start()
    {
        health = GetComponent<Health>();
        entity = GetComponent<Entity>();

        referenceManager = GameObject.Find("GameManager").GetComponent<ReferenceManager>();
        enemyNamePlate = referenceManager.enemyNamePlate;

        enemyNamePlate.SetUpBaseValues(health.health, entity.stats.resource); //Resource needs to be changed with real resource value
        enemyNamePlate.SetUpNamePlate(entity.entityName, entity.entityImage, entity.stats.level, entity.stats.health, entity.stats.resource);
    }

    public override void ActivateNamePlate(Entity entity)
    {
        //enemyNamePlate.SetUpNamePlate(entity.entityName, entity.entityImage, entity.stats.level, health.health, entity.stats.resource);
        enemyNamePlate.UpdateHealth(health.health);
    }
}
