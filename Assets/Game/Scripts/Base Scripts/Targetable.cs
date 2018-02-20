using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetable : MonoBehaviour
{
    public bool hasNamePlate;

    EntityManager entityManager;
    Entity entity;

    private void Start()
    {
        entity = GetComponent<Entity>();
        entityManager = GetComponent<EntityManager>();
    }

    public void Target(EntityManager playerManager)
    {
        if (hasNamePlate)
        {
            playerManager.ActivateNamePlate(entity);
            entityManager.ActivateNamePlate(entity);
        }
    }
}
