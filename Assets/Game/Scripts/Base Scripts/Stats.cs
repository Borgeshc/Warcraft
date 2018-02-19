﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Stats")]
public class Stats : ScriptableObject
{
    public int level;
    public int health;
    public int resource;
    public int damage;
    public int criticalStrikeChance;
    public float criticalStrikeDamage;
}