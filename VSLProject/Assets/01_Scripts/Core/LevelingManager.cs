using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelingManager : MonoSingleton<LevelingManager>
{
    [SerializeField] private EnemyLevelSO[] _sheetDataList;

    private int _level; // 현재 레벨

    public int GetRandomIdx(int maxCnt) => Random.Range(0, maxCnt);
    public float GetPercentage() => ((float)GetRandomIdx(int.MaxValue) / int.MaxValue) * 100;
    
    public EnemyLevelingInfo GetEnemyLevelingData(int idx)
    {
        return _sheetDataList[idx].enemyLevelingList[_level];
    }
}
