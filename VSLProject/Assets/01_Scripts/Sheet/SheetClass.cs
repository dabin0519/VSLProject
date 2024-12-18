using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct EnemySheetInfo
{
    public string name;
    public int level;
    public float hp;
    public float damage;
}

[System.Serializable]
public struct ExpSheetInfo
{
    public float exp;
}

[System.Serializable]
public struct EnemySpawnRateInfo
{
    public int spawnAmount;
    public float spawnCoolTime;
}
