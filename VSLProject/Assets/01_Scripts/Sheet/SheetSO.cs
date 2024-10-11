using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Leveling/EnemySpawnRate")]
public class EnemySpawnRateSO : ScriptableObject
{
    public List<EnemySpawnRateInfo> spawnRateDataList = new();
}
