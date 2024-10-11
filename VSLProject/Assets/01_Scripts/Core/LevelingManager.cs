using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelingManager : MonoSingleton<LevelingManager>
{
    private int _level; // 현재 레벨

    public event Action<int> LevelChanged;

    private void Start()
    {
        LevelChanged?.Invoke(_level);
    }

    public int GetRandomIdx(int maxCnt) => UnityEngine.Random.Range(0, maxCnt);
    public float GetPercentage() => ((float)GetRandomIdx(int.MaxValue) / int.MaxValue) * 100;

    public void LevelUP()
    {
        _level++;
        LevelChanged?.Invoke(_level);
    }
}
