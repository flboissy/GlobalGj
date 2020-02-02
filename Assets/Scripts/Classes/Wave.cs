using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public int InitialNumberOfEnemy;
    public int CurrentNumberOfEnemy;
    public float TimeBetweenSpawn;
    public EnemySpawn[] EnemySpawns;
}
