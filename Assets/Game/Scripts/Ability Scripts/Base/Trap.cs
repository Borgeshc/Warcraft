using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public int minDamage;
    public int maxDamage;
    public float statusLength;
    public Stats stats;

    protected NamePlate namePlate;

    public void SetUpTrap(NamePlate _namePlate)
    {
        namePlate = _namePlate;
    }
}
