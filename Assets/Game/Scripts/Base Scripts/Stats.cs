using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Stats")]
public class Stats : ScriptableObject
{
    public int level;
    public int health;
    public int resource;
    public int autoAttackMinDamage;
    public int autoAttackMaxDamage;
    public int criticalStrikeChance;
    public float criticalStrikeDamage;
}
