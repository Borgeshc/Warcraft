using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetable : MonoBehaviour
{
    public bool hasNamePlate;

    public delegate void Targeted(Entity entity);
    public static event Targeted OnTargeted;

    Entity entity;

    private void Start()
    {
        entity = GetComponent<Entity>();
    }

    public virtual void Target()
    {
        if (hasNamePlate)
            OnTargeted(entity);
    }
}
