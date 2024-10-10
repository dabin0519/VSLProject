using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct EnemyLevelingInfo
{
    public int level;
    public float hp;
    public float damage;
}

[CreateAssetMenu(menuName = "SO/Leveling/Enemy")]
public class EnemyLevelSO : ScriptableObject
{
    public string enemyName;
    public List<EnemyLevelingInfo> enemyLevelingList = new List<EnemyLevelingInfo>();
}
