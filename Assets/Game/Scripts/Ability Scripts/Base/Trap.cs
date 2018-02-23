using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    protected int minDamage;
    protected int maxDamage;
    public float statusLength;
    public Stats stats;

    protected NamePlate namePlate;

    public void SetUpTrap(NamePlate _namePlate, int _minDamage, int _maxDamage)
    {
        namePlate = _namePlate;
        minDamage = _minDamage;
        maxDamage = _maxDamage;
    }
}
