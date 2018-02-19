using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public NamePlate enemyNamePlate;

    private void OnEnable()
    {
        Targetable.OnTargeted += SetUpNamePlate;
    }

    private void OnDisable()
    {
        Targetable.OnTargeted -= SetUpNamePlate;
    }

    public void SetUpNamePlate(Entity entity)
    {
        enemyNamePlate.SetUpNamePlate(entity.entityName, entity.entityImage, entity.stats.level, entity.stats.health, entity.stats.resource);
    }
}
