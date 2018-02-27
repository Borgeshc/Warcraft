using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Stage")]
public class Stage : ScriptableObject
{
    public List<GameObject> enemies;    //These two lists are parallel
    public List<int> spawnPositions;    //spawn position is out of 5 from left to right order
}
