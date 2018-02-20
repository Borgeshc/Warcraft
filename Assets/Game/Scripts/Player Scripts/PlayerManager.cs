using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : EntityManager
{
    public NamePlate playerNamePlate;
    public NamePlate enemyNamePlate;

    Entity playerEntity;

    private void Awake()
    {
        playerEntity = GetComponent<Entity>();
        playerNamePlate.SetUpBaseValues(playerEntity.stats.health, playerEntity.stats.resource);    //This needs to be changed with real health value and resource value
        playerNamePlate.SetUpNamePlate(playerEntity.entityName, playerEntity.entityImage, playerEntity.stats.level, playerEntity.stats.health, playerEntity.stats.resource);
    }

    public override void ActivateNamePlate(Entity entity)
    {
        enemyNamePlate.SetUpNamePlate(entity.entityName, entity.entityImage, entity.stats.level, entity.stats.health, entity.stats.resource);
        enemyNamePlate.gameObject.SetActive(true);
    }

    public void DisableEnemyNamePlate()
    {
        enemyNamePlate.gameObject.SetActive(false);
    }
}
